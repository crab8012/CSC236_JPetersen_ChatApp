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
    public class ClientAndFiles
    {
        // Useful for other code later
    }
    
    // Preferences Class - Serializable, contains preference data for the application.
    public class Preferences
    {
        public System.Drawing.Color GlobalTextColor { get; set; }
        public string DisplayName { get; set; }
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public int UserHash { get; set; }

        public void saveToFile(string fileName)
        {
            using (StreamWriter outWriter = new StreamWriter(fileName))
            {
                outWriter.Write(JsonSerializer.Serialize(this));
            }
        }

        public void readFromFile(string fileName)
        {
            try
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
            catch(IOException e)
            {
                Console.WriteLine(e);

                // The file might not exist. Use a default set of preferences and save to file.
                this.GlobalTextColor = System.Drawing.Color.Black;
                this.DisplayName = "New User";
                this.ServerAddress = "170.0.0.1";
                this.ServerPort = 56565;
                this.UserHash = 0;

                // Save the preferences to a file
                this.saveToFile("prefs.json");
            }
        }
    }

    // Client Class - Used for all communication with the server
    public class Client
    {
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

        public static ArrayList sendNull(string address, int port)
        {
            ArrayList recievedMessages = new ArrayList();

            IPAddress addressToUse = null;

            try
            {
                addressToUse = Dns.GetHostEntry(address).AddressList[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


            string OutJSONPacket = "";

            OutJSONPacket = JsonSerializer.Serialize(new CommandPacket("null"));


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
                            recievedMessages.Add(JsonSerializer.Deserialize<ChatPacket>(chat.ToString()));
                        }
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

            return recievedMessages;
        }

        public static ArrayList sendMessage(ChatPacket cPacket, string address, int port)
        {
            ArrayList recievedMessages = new ArrayList();
            
            IPAddress addressToUse = null;
            
            try
            {
                addressToUse = Dns.GetHostEntry(address).AddressList[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            

            string OutJSONPacket = "";

            OutJSONPacket = JsonSerializer.Serialize(cPacket);


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
                            recievedMessages.Add(JsonSerializer.Deserialize<ChatPacket>(chat.ToString()));
                        }
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

            return recievedMessages;
        }
    }
}
