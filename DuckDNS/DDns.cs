using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace DuckDNS
{
    class DDns
    {
        private const string FILENAME = "DuckDNS.cfg";
        public string Domain;
        public string Token;
        public string Interval;
        private WebClient cli = new WebClient();

        /// <summary>
        /// This method updates the Duck DNS Subdomain IP address.
        /// </summary>
        /// <returns>Boolean value whether it suceeds to update the subdomain IP address</returns>
        public bool Update()
        {
            //Updating IPv4
            string urlIPv4 = "https://www.duckdns.org/update?domains=" + Domain + "&token=" + Token + "&ip=";
            string dataIPv4 = cli.DownloadString(urlIPv4);
            

            string dataIPv6 = "";

            //Getting IPv6 addresses
            ArrayList IPv6 = getIPv6();

            if (IPv6.Capacity > 0)
            {
                String urlIPv6 = "https://www.duckdns.org/update?domains=" + Domain + "&token=" + Token + "&ipv6=" + IPv6[0].ToString();
                dataIPv6 = cli.DownloadString(urlIPv6);
            }

            return (dataIPv4 == "OK" || dataIPv6 == "OK");
        }

        /// <summary>
        /// This method gets the current public IPv6 addresses of the machine on which it is running.
        /// </summary>
        /// <returns>An ArrayList containing public IPv6 addresses.</returns>
        private ArrayList getIPv6()
        {
            //Creating the ArrayList.
            ArrayList IPv6Addresses = new ArrayList();

            //Verifying if the Operating System supports IPv6.
            if (Socket.OSSupportsIPv6)
            {
                try
                {
                    //Getting IP addresses.
                    IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

                    //Finding public IPv6 addresses.
                    foreach (IPAddress curAdd in heserver.AddressList)
                    {
                        if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString() && (!curAdd.IsIPv6Multicast) && (!curAdd.IsIPv6LinkLocal) && (!curAdd.IsIPv6SiteLocal))
                        {
                            //Adding the adress to the ArrayList.
                            IPv6Addresses.Add(curAdd);
                        }
                    }
                }
                catch (NotSupportedException e)
                {
                    Console.WriteLine(e);
                }

                catch (SocketException e)
                {
                    Console.WriteLine(e);
                }
            }

            return IPv6Addresses;
        }

        public void Load()
        {
            string[] data = null;
            if (File.Exists(FILENAME)) try
                {
                    data = File.ReadAllLines(FILENAME);
                }
                catch { }; //Silent read errors
            Domain = data != null && data.Length > 0 ? data[0] : "";
            Token = data != null && data.Length > 1 ? CharSwitch(data[1]) : "";
            Interval = data != null && data.Length > 2 ? data[2] : "30m";
        }

        public void Save()
        {
            string[] data = { Domain, CharSwitch(Token), Interval };
            try
            {
                File.WriteAllLines(FILENAME, data);
            }
            catch { }; //Silent write errors (for read-only fs)
        }

        private string CharSwitch(string str){ // Super basic, but more than nothing
            string a = "abcdef0123456789";
            string b = "f9031ace7d86524b";
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < sb.Length; i++)
            {
                int chi = a.IndexOf(sb[i]);
                if (chi >= 0)
                    sb[i] = b[chi];
            }
            return sb.ToString();
        }
    }
}
