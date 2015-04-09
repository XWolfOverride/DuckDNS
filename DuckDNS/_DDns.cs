using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DuckDNS
{
    class _DDns
    {
        public string Domain;
        public string Token;

        public bool Update(){
            string url="https://www.duckdns.org/update?domains="+Domain+"&token="+Token+"&ip=";
            WebClient cli = new WebClient();
            string data = cli.DownloadString(url);
            return data == "OK";
        }
    }
}
