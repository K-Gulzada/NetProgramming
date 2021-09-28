using System;
using System.Net.NetworkInformation;
using System.Text;

namespace TcpInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            IPGlobalProperties globalProperties = IPGlobalProperties.GetIPGlobalProperties();

            TcpConnectionInformation[] connections = globalProperties.GetActiveTcpConnections();

            foreach(var item in connections)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Local endpoint: \t" + item.LocalEndPoint.Address.ToString());

                stringBuilder.Append("\nRemote Port:  " + item.RemoteEndPoint.Port.ToString());

                stringBuilder.Append("\nState:\t\t" + item.State.ToString());

                Console.WriteLine(stringBuilder.ToString());

            }

        }
    }
}
