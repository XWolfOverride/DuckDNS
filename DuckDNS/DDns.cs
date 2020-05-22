using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Reflection;

namespace DuckDNS
{
    class DDns
    {
        private const string FILENAME = "DuckDNS.cfg";
        public string Domain;
        public string Token;
        public string Interval;
        public bool OwnResolveOfIPv6;
        private WebClient cli = new WebClient();
        private string confPath;

        /// <summary>
        /// This method updates the Duck DNS Subdomain IP address.
        /// </summary>
        /// <returns>Boolean value whether it suceeds to update the subdomain IP address</returns>
        public bool Update()
        {
            //Updating IPv4
            string urlIPv4 = "https://www.duckdns.org/update?domains=" + Domain + "&token=" + Token + "&ip=";
            string dataIPv4 = cli.DownloadString(urlIPv4);

            //Updating IPv6, thanks to Henriquemcc + version with DuckDNS address resolution.
            string urlIPv6 = "https://www.duckdns.org/update?domains=" + Domain + "&token=" + Token + "&ipv6=" + (OwnResolveOfIPv6 ? getIPv6() : "");
            string dataIPv6 = cli.DownloadString(urlIPv6);

            return (dataIPv4 == "OK" || dataIPv6 == "OK");
        }

        /// <summary>
        /// This method gets the current public IPv6 addresses of the machine on which it is running.
        /// </summary>
        /// <returns>An ArrayList containing public IPv6 addresses.</returns>
        private string getIPv6()
        {
            //Creating the ArrayList.
            List<string> IPv6Addresses = new List<string>();

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
                            IPv6Addresses.Add(curAdd.ToString());
                        }
                    }
                }
                catch
                {
                }
            }
            return IPv6Addresses.Count > 0 ? IPv6Addresses[0] : null;
        }

        private string getConfPath()
        {
            if (confPath == null)
            {
                if (File.Exists(FILENAME))
                    confPath = FILENAME; // If located on current path use current path
                else
                {// If not use the path at the same directory of DuckDNS.exe
                    string basepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string filepath = Path.Combine(basepath, FILENAME);
                    confPath = filepath;
                }
            }
            return confPath;
        }

        public void Load()
        {
            string filepath = getConfPath();
            string[] data = null;
            if (File.Exists(filepath)) try
                {
                    data = File.ReadAllLines(filepath);
                }
                catch { } //Silent read errors
            Domain = data != null && data.Length > 0 ? data[0] : "";
            Token = data != null && data.Length > 1 ? CharSwitch(data[1]) : "";
            Interval = data != null && data.Length > 2 ? data[2] : "30m";
            OwnResolveOfIPv6 = data != null && data.Length > 3 ? data[3] == "OwnResolveIpv6" : false;
        }

        public void Save()
        {
            string[] data = { Domain, CharSwitch(Token), Interval, OwnResolveOfIPv6 ? "OwnResolveIpv6" : "DuckResolveIpv6" };
            try
            {
                File.WriteAllLines(getConfPath(), data);
            }
            catch { }; //Silent write errors (for read-only fs)
        }

        private string CharSwitch(string str)
        { // Super basic, but more than nothing
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
