using ProjectICU_Server.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProjectICU_Client.Net
{
    internal class Server
    {
        private static TcpClient _client;
        public Server()
        {
            _client = new TcpClient();
            _client.Connect("127.0.0.1", 9001);//46.31.77.173

            Task.Delay(3000);

            var LoginPacket = new PacketBuilder();
            LoginPacket.WriteOpCode(0);
            LoginPacket.WriteMessage("Deneme1");
            LoginPacket.WriteMessage("Deneme2");
            _client.Client.Send(LoginPacket.GetPacketBytes());
        }
    }
}
