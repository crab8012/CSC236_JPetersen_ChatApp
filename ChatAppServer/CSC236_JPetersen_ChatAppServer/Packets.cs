using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSC236_JPetersen_ChatAppServer
{
    // Used on the Server Side to help determine what type of packet has been recieved.
    public enum PacketType
    {
        Message, Command, Registration, AdminCommand, None
    }

    // Used client-side only if a message has a different color other than the default text color.
    public enum Color
    {
        None, Red, Orange, Yellow, Green, Blue, Pink, Purple, Black, White
    }

    // Used client-side only if a message has a sound associated with it.
    public enum Sounds
    {
        None, Pop, Boom, Ding, Chime, Error, Success, Scare, Alert
    }

    [Serializable]
    public class Packet
    {
        public PacketType Type { get; set; }
    }

    [Serializable]
    public class CommandPacket : Packet
    {
        public string Command { get; set; }
        public int AdminHash { get; set; }
        public CommandPacket()
        {

        }

        public CommandPacket(string command)
        {
            this.Type = PacketType.Command;
            this.Command = command;
        }

        public CommandPacket(string command, int adminHash)
        {
            this.Type = PacketType.AdminCommand;
            this.Command = command;
            this.AdminHash = adminHash;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Command, this.AdminHash);
        }
    }

    [Serializable]
    public class ChatPacket : Packet
    {
        // ALL fields that are to be serialized must be PUBLIC
        public string User { get; set; }
        public string Message { get; set; }
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public Color FontColor { get; set; }
        public Sounds MessageSounds { get; set; }
        public ChatPacket()
        {
            this.Type = PacketType.Message;
        }

        public ChatPacket(string message) : this()
        {
            this.User = "SERVER";
            this.Message = message;
        }

        public ChatPacket(string message, string user) : this()
        {
            this.Message = message;
            this.User = user;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", User, Message);
        }
    }
}
