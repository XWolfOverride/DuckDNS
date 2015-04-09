using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DuckDNS
{
    public partial class Form1 : Form
    {
        private _DDns ddns = new _DDns();
        private int intervalMS;

        public Form1()
        {
            InitializeComponent();
            notifyIcon.Icon = Icon;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - (Height + 25);
            Left = Screen.PrimaryScreen.WorkingArea.Right - (Width + 25);            
        }

        private void ParseInterval()
        {
            string istr = cbInterval.Text.ToLower();
            int iint=0;
            bool error=false;

            if (istr.Length==0 && !int.TryParse(istr.Substring(0, istr.Length - 1), out iint))
                error = true;
            else
            {
                switch (istr[istr.Length - 1])
                {
                    case 's':
                        intervalMS = iint * 1000;
                        break;
                    case 'm':
                        intervalMS = iint * 60000;
                        break;
                    case 'h':
                        intervalMS = iint * 3600000;
                        break;
                    case 'd':
                        intervalMS = iint * 86400000;
                        break;
                    default:
                        error = true;
                        break;
                }
            }
            cbInterval.BackColor = error ? Color.LightPink : SystemColors.Window;

        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ddns.Update();
        }

        private void cbInterval_TextChanged(object sender, EventArgs e)
        {
            ParseInterval();
        }
    }
}
