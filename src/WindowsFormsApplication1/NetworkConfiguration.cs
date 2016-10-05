using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IntraChat
{
    class NetworkConfiguration
    {

        private static IntraSqlConnection.IntraSqlConnection con = new IntraSqlConnection.IntraSqlConnection();

        public static string getLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public static int getPortNumber()
        {
            int port = 0;

            List<int> dbPort = con.retrievePortNumber();

            for(int i = 0; i < dbPort.Count; i++)
            {
                int portTemp = NextFreeTcpPort();
                if ( portTemp != dbPort[i])
                {
                    port = portTemp;
                }
            }

            return port;
        }

        public static int NextFreeTcpPort()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            
            l.Stop();
            return port;

        }


    }
}
