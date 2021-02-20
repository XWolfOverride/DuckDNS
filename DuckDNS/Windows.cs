using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace DuckDNS
{
    class Windows
    {
        #region Windows API

        private const int CSIDL_STARTUP = 0x7;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("shell32.dll")]
        private static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);

        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();

        #endregion

        public static Pen framePen = new Pen(Color.FromArgb(96, 125, 139));

        public static string GetStartupPath()
        {
            StringBuilder path = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, path, CSIDL_STARTUP, false);
            return path.ToString();
        }

        public static void DragWindow(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public static List<IpInfo> ListInterfacesIPs()
        {
            List<IpInfo> result = new List<IpInfo>();
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
                if (item.NetworkInterfaceType != NetworkInterfaceType.Loopback && item.OperationalStatus == OperationalStatus.Up)
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            result.Add(new IpInfo(item, ip.Address.ToString()));
            return result;
        }
    }

    class IpInfo
    {
        private NetworkInterface iface;
        private string ip;

        public IpInfo(NetworkInterface iface, string ip)
        {
            this.iface = iface;
            this.ip = ip;
        }

        public override string ToString()
        {
            return iface.Name + ": " + ip;
        }

        public string InterfaceName { get { return iface.Name; } }
        public NetworkInterfaceType InterfaceType { get { return iface.NetworkInterfaceType; } }
        public string Address { get { return ip; } }
    }
}
