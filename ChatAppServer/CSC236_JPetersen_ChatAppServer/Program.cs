using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace CSC236_JPetersen_ChatAppServer
{
    class Program
    {
        public const string VERSION = "0.0.1";
        public const int DEFAULT_PORT = 56565;
        public const int OWNER_HASH = 1239847272;
        public static IPAddress addressToUse;
        public static int portToUse = DEFAULT_PORT;

        public static DataLogger messageLog;

        static void Main(string[] args)
        {
            Console.WriteLine("JPetersen ChatApp Server");
            Console.WriteLine("Version: " + VERSION);
            Console.WriteLine("------------------------\n\n");

            // Setup the message log
            messageLog = new DataLogger();

            Console.WriteLine("Getting List of Addresses to Listen on...\n");
            
            int addressIndex = 0;
            int option = -1;

            foreach(IPAddress address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                Console.WriteLine(addressIndex + ".   " + address.ToString());
                addressIndex++;
            }

            addressIndex = Math.Min(Dns.GetHostEntry(Dns.GetHostName()).AddressList.Length-1, addressIndex);

            while (true)
            {
                Console.WriteLine("Enter the Address that the server should listen on: ");

                if(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid Input. Try Again.");
                    continue;
                }else if (option > addressIndex)
                {
                    Console.WriteLine("Invalid Input. Try Again.");
                }
                else
                {
                    break;
                }

            }

            addressToUse = Dns.GetHostEntry(Dns.GetHostName()).AddressList[option];

            Console.WriteLine("Enter the Port that the server should listen on: ");
            if(!int.TryParse(Console.ReadLine(), out portToUse))
            {
                Console.WriteLine("Invalid Input. Using default port of " + DEFAULT_PORT);
            }

            if (args.Length > 0)
            {
                if (args[0].Equals("c"))
                {
                    Client.StartClient();
                }
                else
                {
                    // Create a test datalog
                    getStarterMessages();
                    Server.StartServer();
                }
            }
            else
            {
                getStarterMessages();
                Server.StartServer();
            }
        }

        public static void getStarterMessages(){
            /*
            Program.messageLog.addMessage(new ChatPacket("Test Message"));
            Program.messageLog.addMessage(new ChatPacket("Response Message"));
            Console.WriteLine("SERIALIZING MESSAGES TEST");
            Console.WriteLine(Program.messageLog.getSerializedMessages());
            Console.WriteLine("DONE SERIALIZING MESSAGES");
            */
            Console.WriteLine("\n\n");
            Program.messageLog.addMessage(new ChatPacket("Welcome to the Server!"));
        }
    }

    // The server does not have to be async. For now we are only looking at having one connection at a time...
    // So we do not need to handle multiple different clients at the same time.
    public class Server
    {
        public static void StartServer()
        {
            IPEndPoint localEndPoint = new IPEndPoint(Program.addressToUse, Program.portToUse);
            bool continueLoop = true;

            Socket listener = null;

            try {
                listener = new Socket(Program.addressToUse.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(10);

                Console.WriteLine("Waiting for Connection");
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            while (continueLoop)
            {
                try
                {
                    if(listener == null)
                    {
                        continueLoop = false;
                        throw new Exception("Listener is NULL!!!!");
                    }
                    Socket handler = listener.Accept();

                    try
                    {
                        // Incoming data from the client.
                        string data = null;
                        byte[] bytes = null;

                        while (true)
                        {
                            bytes = new byte[1024];
                            int bytesRec = handler.Receive(bytes);
                            data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                            if (data.IndexOf("<EOF>") > -1)
                            {
                                data = data.Substring(0, data.Length - 5); // Remove "<EOF> from the data to help with JSON Deserialization.
                                break;
                            }
                        }

                        Console.WriteLine("Text Recieved: {0}", data);
                        Console.WriteLine("DESERIALIZE RECIEVED DATA");

                        Packet p = JsonSerializer.Deserialize<Packet>(data.ToString());
                        if (p.Type == PacketType.Message)
                        {
                            ChatPacket cPacket = JsonSerializer.Deserialize<ChatPacket>(data.ToString());
                            Program.messageLog.addMessage(cPacket);

                            Console.WriteLine();
                        }
                        else if (p.Type == PacketType.Command)
                        {
                            CommandPacket commandPacket = JsonSerializer.Deserialize<CommandPacket>(data.ToString());
                            if (commandPacket.Command.Equals("save"))
                            {
                                Program.messageLog.saveToFile("messageLog.json");
                            }
                            else if (commandPacket.Command.Equals("restore"))
                            {
                                Program.messageLog.restoreFromFile("messageLog.json");
                            }
                            else if (commandPacket.Command.Equals("shutdown"))
                            {
                                continueLoop = false;
                            }
                        }
                        else if (p.Type == PacketType.AdminCommand)
                        {
                            CommandPacket commandPacket = JsonSerializer.Deserialize<CommandPacket>(data.ToString());
                            if (commandPacket.Command.Equals("clear"))
                            {
                                if (commandPacket.AdminHash == Program.OWNER_HASH)
                                {
                                    Program.messageLog.clearLog(true);
                                }
                                else
                                {
                                    Program.messageLog.clearLog();
                                }
                            }
                        }


                        byte[] msg = Encoding.ASCII.GetBytes(Program.messageLog.getSerializedMessages());
                        handler.Send(msg);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine("END LOOP ITER\n\n");
            }
            

            Console.WriteLine("\n\n\n SERVER PROCESS EXIT");
        }
    }

    public class Client
    {
        public static PacketType getTypeToSend()
        {
            Console.Write("What packet are you sending (admin/cmd/chat/null): ");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if(input.Equals("cmd") || input.Equals("CMD"))
                {
                    return PacketType.Command;
                }else if (input.Equals("admin"))
                {
                    return PacketType.AdminCommand;
                }else if (input.Equals("chat"))
                {
                    return PacketType.Message;
                }else if (input.Equals("null"))
                {
                    return PacketType.AdminCommand;
                }
                else
                {
                    Console.WriteLine(String.Format("Invalid Command: {0}", input));
                }
            }
        }

        public static string getMessage()
        {
            Console.Write("Enter message to send: ");
            return Console.ReadLine();
        }

        public static string getCommand()
        {
            Console.Write("Enter command to send: ");
            return Console.ReadLine();
        }

        public static int getAdminHash()
        {
            Console.Write("Enter Admin Hash: ");
            string input = Console.ReadLine();
            int hash;
            Int32.TryParse(input, out hash);
            return hash;
        }

        public static void StartClient()
        {
            string OutJSONPacket = "";

            // Get packet type
            PacketType type = getTypeToSend();

            // Get packet data
            if(type == PacketType.Message)
            {
                OutJSONPacket = JsonSerializer.Serialize(new ChatPacket(getMessage()));
            }else if(type == PacketType.Command)
            {
                OutJSONPacket = JsonSerializer.Serialize(new CommandPacket(getCommand()));
            }else if(type == PacketType.AdminCommand)
            {
                OutJSONPacket = JsonSerializer.Serialize(new CommandPacket(getCommand(), getAdminHash()));
            }
            else
            {
                OutJSONPacket = JsonSerializer.Serialize(new Packet().Type = PacketType.None);
            }
            
            
            // Send packet data
            byte[] bytes = new byte[1024];

            try
            {
                IPEndPoint remoteEP = new IPEndPoint(Program.addressToUse, Program.portToUse);

                Socket sender = new Socket(Program.addressToUse.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket Connected to {0}", sender.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.ASCII.GetBytes(OutJSONPacket + "<EOF>");

                    int bytesSend = sender.Send(msg);

                    // Receive the reponse from the remote device
                    int bytesRec = sender.Receive(bytes);
                    
                    Console.WriteLine("Output: {0}\n\n", Encoding.ASCII.GetString(bytes, 0, bytesRec));


                    // Deserialize data
                    string data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    ArrayList packets = JsonSerializer.Deserialize<ArrayList>(data);
                    foreach(JsonElement chat in packets)
                    {
                        Packet p = JsonSerializer.Deserialize<Packet>(chat.ToString());
                        if(p.Type == PacketType.Message)
                        {
                            Console.WriteLine(JsonSerializer.Deserialize<ChatPacket>(chat.ToString()));
                        }
                        //Console.WriteLine();
                        //Console.WriteLine(JsonSerializer.Deserialize<ChatPacket>(chat));
                    }

                    // Release the socket
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

}
