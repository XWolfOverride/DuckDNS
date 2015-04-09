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
        private const string FILENAME = "DynDNS.cfg";
        public string Domain;
        public string Token;

        public bool Update(){
            string url="https://www.duckdns.org/update?domains="+Domain+"&token="+Token+"&ip=";
            WebClient cli = new WebClient();
            string data = cli.DownloadString(url);
            return data == "OK";
        }

        public void Load()
        {
            if (File.Exists(FILENAME)) try
                {
                    string[] data = File.ReadAllLines(FILENAME);
                    Domain = data.Length > 0 ? data[0] : "";
                    Token = data.Length > 1 ? CharSwitch(data[1]) : "";
                }
                catch { }; //Silent read errors
        }

        public void Save()
        {
            string[] data = { Domain, CharSwitch(Token) };
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
