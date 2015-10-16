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
            const int PORT_NO = 5000;
            const string SERVER_IP = "127.0.0.1";
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);

            //---data to send to the server---
            string textToSend = DateTime.Now.ToString();

            while (textToSend != "stop")
            {
                //---create a TCPClient object at the IP and port no.---
                //---TCPClient moved above this loop to cause continuous communication between the two classes.---
                NetworkStream nwStream = client.GetStream();


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
                // Console.WriteLine("Client received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
           }

            client.Close();
            Console.WriteLine("Client dead.");
            Console.ReadLine();
        }
    }
}
