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
        public bool OwnResolveOfIPs;
        private WebClient cli = new WebClient();
        private string confPath;

        /// <summary>
        /// This method updates the Duck DNS Subdomain IP address.
        /// </summary>
        /// <returns>Boolean value whether it suceeds to update the subdomain IP address</returns>
        public bool Update()
        {
            string ipv4 = "";
            string ipv6 = "";
            if (OwnResolveOfIPs)
                getIPs(out ipv4, out ipv6);
            string url = "https://www.duckdns.org/update?domains=" + Domain + "&token=" + Token + "&ip=" + ipv4 + "&ipv6=" + ipv6;
            return cli.DownloadString(url) == "OK";
        }

        /// <summary>
        /// This method gets the current public IPv6 addresses of the machine on which it is running.
        /// </summary>
        /// <returns>An ArrayList containing public IPv6 addresses.</returns>
        private void getIPs(out string ipv4, out string ipv6)
        {
            ipv4 = "";
            ipv6 = "";
            try
            {
                IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (ipv6.Length == 0 && curAdd.AddressFamily == AddressFamily.InterNetworkV6 && (!curAdd.IsIPv6Multicast) && (!curAdd.IsIPv6LinkLocal) && (!curAdd.IsIPv6SiteLocal))
                        ipv6 = curAdd.ToString();
                    if (ipv4.Length == 0 && curAdd.AddressFamily == AddressFamily.InterNetwork)
                        ipv4 = curAdd.ToString();
                    if (ipv4.Length > 0 && ipv6.Length > 0)
                        return;
                }
            }
            catch
            {
            }
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
            OwnResolveOfIPs = data != null && data.Length > 3 ? data[3] == "OwnResolveIpv6" || data[3] == "OwnResolveIPs" : false;
        }

        public bool Save()
        {
            string[] data = { Domain, CharSwitch(Token), Interval, OwnResolveOfIPs ? "OwnResolveIPs" : "DuckResolveIPs" };
            try
            {
                File.WriteAllLines(getConfPath(), data);
                return true;
            }
            catch
            {
                return false;
            }
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
