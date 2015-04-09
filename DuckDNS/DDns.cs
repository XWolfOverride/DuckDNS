using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DuckDNS
{
    class DDns
    {
        private const string FILENAME = "DuckDNS.cfg";
        public string Domain;
        public string Token;
        public string Interval;
        private WebClient cli = new WebClient();

        public bool Update(){
            string url="https://www.duckdns.org/update?domains="+Domain+"&token="+Token+"&ip=";
            string data = cli.DownloadString(url);
            return data == "OK";
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
