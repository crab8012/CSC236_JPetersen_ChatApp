using System;
using System.IO;
using System.Text;
using System.Text.Json; // To use, must install System.Text.Json from NuGet.
using System.Net;
using System.Collections;
using System.Net.Sockets;
using CSC236_JPetersen_ChatAppServer; // Copy of the file in ChatAppServer, because the server runs on .Net5 and cannot be referenced :(

namespace CSC236_JPetersen_ChatApp
{
    class ClientAndFiles
    {
        // Serialize a preferences object and then save to a file.
        public static void savePreferences()
        {

        }
        
        // Load from a file and deserialize to a preferences object.
        public static void loadPreferences()
        {

        }
    }
    
    // Preferences Class - Serializable, contains preference data for the application.
    class Preferences
    {
        System.Drawing.Color GlobalTextColor { get; set; }
        string DisplayName { get; set; }
        string ServerAddress { get; set; }
        int ServerPort { get; set; }
        int UserHash { get; set; }

        public void saveToFile(string fileName)
        {
            using (StreamWriter outWriter = new StreamWriter(fileName))
            {
                outWriter.Write(JsonSerializer.Serialize(this));
            }
        }

        public void readFromFile(string fileName)
        {
            using (StreamReader inReader = new StreamReader(fileName))
            {
                // Read in data from the preferences file.
                Preferences tempPrefs = JsonSerializer.Deserialize<Preferences>(inReader.ReadToEnd());

                // Apply preferences to current application instance.
                this.GlobalTextColor = tempPrefs.GlobalTextColor;
                this.DisplayName = tempPrefs.DisplayName;
                this.ServerAddress = tempPrefs.ServerAddress;
                this.ServerPort = tempPrefs.ServerPort;
                this.UserHash = tempPrefs.UserHash;
            }
        }
    }

    // Client Class - Used for all communication with the server
    public class Client
    {
        public static PacketType getTypeToSend()
        {
            Console.Write("What packet are you sending (admin/cmd/chat/null): ");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input.Equals("cmd") || input.Equals("CMD"))
                {
                    return PacketType.Command;
                }
                else if (input.Equals("admin"))
                {
                    return PacketType.AdminCommand;
                }
                else if (input.Equals("chat"))
                {
                    return PacketType.Message;
                }
                else if (input.Equals("null"))
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

        public static void sendCommand(CommandPacket cmd, string address, int port)
        {
            IPAddress addressToUse = Dns.GetHostEntry(address).AddressList[0];
            // Send packet data
            byte[] bytes = new byte[1024];

            try
            {
                IPEndPoint remoteEP = new IPEndPoint(addressToUse, port);

                Socket sender = new Socket(addressToUse.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes(JsonSerializer.Serialize(cmd) + "<EOF>");

                    int bytesSend = sender.Send(msg);

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

        public static void StartClient(string address, int port)
        {
            IPAddress addressToUse = Dns.GetHostEntry(address).AddressList[0];

            string OutJSONPacket = "";

            // Get packet type
            PacketType type = getTypeToSend();

            // Get packet data
            if (type == PacketType.Message)
            {
                OutJSONPacket = JsonSerializer.Serialize(new ChatPacket(getMessage()));
            }
            else if (type == PacketType.Command)
            {
                OutJSONPacket = JsonSerializer.Serialize(new CommandPacket(getCommand()));
            }
            else if (type == PacketType.AdminCommand)
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
                IPEndPoint remoteEP = new IPEndPoint(addressToUse, port);

                Socket sender = new Socket(addressToUse.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

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
                    foreach (JsonElement chat in packets)
                    {
                        Packet p = JsonSerializer.Deserialize<Packet>(chat.ToString());
                        if (p.Type == PacketType.Message)
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
