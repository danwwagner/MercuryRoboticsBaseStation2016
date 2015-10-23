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

        const int PORT_NO = 4445;
        const string SERVER_IP = "25.6.177.110";

        public void StartServer()
        {
            //---listen at the specified IP and port no.---
      /*      IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient(); */

            // UDP Testing
            UdpClient server = new UdpClient(SERVER_IP, PORT_NO);
            while (true)
            {
                /*
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
                nwStream.Write(buffer, 0, bytesRead); */

                var remoteEP = new IPEndPoint(IPAddress.Any, PORT_NO);
                var data = server.Receive(ref remoteEP);
                Console.WriteLine("Receive data from Server:  " + data.ToString());
              //  server.Send(new byte[] { 1 }, 1, remoteEP);
              //  int i = 0;
             //   while (++i < 50000000) ;

            }
        //    client.Close();
         //   listener.Stop();
         //   Console.WriteLine("Server dead.");
        }
    }
}
