using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace CommunicationsTesting
{
    public class Communications
    {
        public IPAddress IP
        {
            get;
            private set;
        }

        private TcpListener server;
        private int port;
        private Byte[] bytes;
        string data;

        public Communications()   //IPAddress IP)
        {
            IP = IPAddress.Parse("192.168.1.0");
            server = new TcpListener(IP, port);
            port = 5050;
            bytes = new Byte[256];
            data = null;
        }

        public void InitiateConnection()
        {
            try
            {
                server.Start();

                while (true)
                {
                    TcpClient client = new TcpClient("192.168.1.0", port);
                    Console.WriteLine("Web server is running! Yay!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }

            catch (SocketException se)
            {
                Console.WriteLine("SocketException: " + se.ToString());
            }
        }
    }
}
