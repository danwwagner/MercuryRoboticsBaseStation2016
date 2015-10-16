using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace CommunicationsTesting
{


    class Program
    {
        static Server server = new Server();
        static Client client = new Client();

        static void Main(string[] args)
        {   
            Thread serverThread = new Thread(ServThread);
            serverThread.Start();
            Thread clientThread = new Thread(CliThread);
            clientThread.Start();
        }

        static void ServThread()
        {
            server.StartServer();
        }

        static void CliThread()
        {
            client.StartClient();
        }

    }
}
