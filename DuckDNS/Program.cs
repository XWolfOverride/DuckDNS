﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DuckDNS
{
    static class Program
    {
        public const string VERSION = "2.2";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                Windows.SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FMain());
        }
    }
}
