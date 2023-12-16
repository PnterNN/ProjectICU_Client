using ProjectICU_Server.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectICU_Client.Net
{
    internal class Server
    {
        private static TcpClient _client;
        public PacketReader PacketReader;
        public Server()
        {
            _client = new TcpClient();
            _client.Connect("127.0.0.1", 9001);//46.31.77.173

            PacketReader = new PacketReader(_client.GetStream());

            Task.Delay(3000);

            PacketBuilder LoginPacket = new PacketBuilder();
            LoginPacket.WriteOpCode(0);
            LoginPacket.WriteMessage("pnternn@hotmail.com");
            LoginPacket.WriteMessage("asd123Hh");
            _client.Client.Send(LoginPacket.GetPacketBytes());
            ReadPackets();

        }

        public void ReadPackets()
        {
            Task.Run(() => 
            { 
                var opcode = PacketReader.ReadByte();
                switch (opcode)
                {
                    case 0:
                        string username = PacketReader.ReadString();
                        string uid = PacketReader.ReadString();
                        MessageBox.Show(username + " " + uid);
                        break;
                }
            });
        }
    }
}
