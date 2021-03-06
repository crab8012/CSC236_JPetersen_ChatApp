using System;
using System.Collections;
using System.IO;
using System.Text.Json;

namespace CSC236_JPetersen_ChatAppServer
{
    class DataLogger
    {
        ArrayList packets;

        public DataLogger()
        {
            packets = new ArrayList();
        }

        public void addMessage(ChatPacket packet)
        {
            this.packets.Add(packet);
        }


        // There are two getSerializedMessages methods to support two different ways of recieving the output.
        public void getSerializedMessages(out String JSONString)
        {
            // Serialize the 'packets' ArrayList
            // Send it to the String object.

            JSONString = JsonSerializer.Serialize(this.packets);
        }

        public String getSerializedMessages()
        {
            // Serialize the 'packets' ArrayList
            // Return the string object.
            return JsonSerializer.Serialize(this.packets);
        }

        public void saveToFile(string fileName)
        {
            using (StreamWriter outWriter = new StreamWriter(fileName))
            {
                outWriter.Write(getSerializedMessages()); // Write the JSON string to a file.
            }
        }

        public void restoreFromFile(string fileName)
        {
            // Read JSON string from file
            using (StreamReader reader = new StreamReader(fileName))
            {
                // Deserialize data
                ArrayList jsonPackets = JsonSerializer.Deserialize<ArrayList>(reader.ReadToEnd());
                foreach (JsonElement packet in jsonPackets)
                {
                    Packet p = JsonSerializer.Deserialize<Packet>(packet.ToString());
                    if (p.Type == PacketType.Message)
                    {
                        this.packets.Add(JsonSerializer.Deserialize<ChatPacket>(packet.ToString())); // Add read-in packets to the active chat log
                    }
                }
            }
        }

        public void clearLog(bool confirm = false)
        {
            if(confirm == true) // Very basic confirmation of intent.
            {
                packets.Clear(); // Clear the chat log
            }
            else
            {
                Console.WriteLine("ERROR - SECURITY VIOLATION. Attempted to clear log without confirmation.");
            }
        }

        /* PLANNING STUFF BELOW */
        // The below comments have helped me get things working the way I intended them to

        // Have an ArrayList of ChatPackets.
        // The size of the ArrayList will be used to synchronize the clients with the server.
        // If a client sends that they only contain a limited amount of data from the server, the entire chat log will be returned.
        // The server will store every message in a file with the day's date.
        // Messages will not be encrypted.

        // Client:
        // The client will send an object that contains a ChatPacket as defined in Packets.cs, as well as the current number of messages that the client contains.
        // In return, the client will recieve an object that either contains the entire chat log or simply an 'OK'.
        // The messages the clients are allowed to send will be limited to 140 characters, a la Twitter 2006.
        // Every message being sent to the server will not actually be the user's message. Instead, it will be their chosen 10-character nickname prepended to their message.
    }
}
