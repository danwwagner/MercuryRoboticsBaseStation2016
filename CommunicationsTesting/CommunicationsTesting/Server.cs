using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


/* Courtesy of http://stackoverflow.com/questions/10182751/server-client-send-receive-simple-text */
namespace CommunicationsTesting
{

    class Server
    {

        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        public void StartServer()
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            while (true)
            {
                Console.Write("Server listening...Type your message: ");
                listener.Start();

                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                if (dataReceived == "stop") break;
                Console.WriteLine('\n' + "Server received : " + dataReceived);

                //---write back the text to the client---
                //  Console.WriteLine("Server sending back : " + dataReceived);
                nwStream.Write(buffer, 0, bytesRead);

            }
            client.Close();
            listener.Stop();
            Console.WriteLine("Server dead.");
        }

        
    }
}
