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
    class Client
    {
        public void StartClient()
        {
            const int PORT_NO = 4444;
            const string SERVER_IP = "25.14.182.86";
            // TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            UdpClient client = new UdpClient(SERVER_IP, PORT_NO);
            IPEndPoint end = new IPEndPoint(IPAddress.Parse(SERVER_IP), PORT_NO);
            client.Connect(end);
            //---data to send to the server---
            string textToSend = DateTime.Now.ToString();

            // Add a uint to the byte buffer or some crap like 
            while (true)
            {
                //---create a TCPClient object at the IP and port no.---
                //---TCPClient moved above this loop to cause continuous communication between the two classes.---

                //NetworkStream nwStream = client.GetStream();

                // UDP Testing
                Console.Write("Type word to send: ");
                string response = Console.ReadLine();
                byte[] data = ASCIIEncoding.ASCII.GetBytes(response + "\n");
                if (response == "quit") return;
                else
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        data = ASCIIEncoding.ASCII.GetBytes(response + i + "\n");
                        client.Send(data, data.Length);
                    }

                    data = ASCIIEncoding.ASCII.GetBytes("last" + "\n");
                    client.Send(data, data.Length);
                }


                //byte[] b = client.Receive(ref end);
               // Console.WriteLine("Recieved data from Client:  " + ByteToString(b) + "\n");
                /*
                                //---write the text to send---
                                if (textToSend == "stop") break;
                                textToSend = Console.ReadLine();
                                if (textToSend == "") textToSend = "NULL";
                                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                                //---send the text---
                                // Console.WriteLine("Client sending : " + textToSend);
                                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                                //---read back the text---
                                byte[] bytesToRead = new byte[client.ReceiveBufferSize];
                                int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
                                // Console.WriteLine("Client received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead)); */
            }

      //      client.Close();
       //     Console.WriteLine("Client dead.");
       //     Console.ReadLine();
        }

        public string ByteToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(b);
            }

            return sb.ToString();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
