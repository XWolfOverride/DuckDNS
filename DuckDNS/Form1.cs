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
        private DDns ddns = new DDns();
        private int intervalMS;
        private bool allowshowdisplay = false;
        private bool canClose = false;

        public Form1()
        {
            InitializeComponent();
            notifyIcon.Icon = Icon;
            Top = Screen.PrimaryScreen.WorkingArea.Bottom - (Height + 200);
            Left = Screen.PrimaryScreen.WorkingArea.Right - (Width + 25);
            ddns.Load();
            tbDomain.Text = ddns.Domain;
            tbToken.Text = ddns.Token;
            cbInterval.Text = ddns.Interval;
            ParseInterval();
            RefreshTimer();
            UpdateDNS();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void UpdateDNS()
        {
            bool update=ddns.Update();
            lblInfo.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " (" + (update ? "OK" : "FAILED") + ")";
            if (!update)
            {
                MessageBox.Show("Error updating domain","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Show();
            }
        }

        private void ParseInterval()
        {
            string istr = cbInterval.Text.ToLower();
            int iint=0;
            bool error=false;

            if (istr.Length==0 || !int.TryParse(istr.Substring(0, istr.Length - 1), out iint))
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

        private void RefreshTimer()
        {
            timer.Enabled = false;
            timer.Interval = intervalMS;
            timer.Enabled = true;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ddns.Domain = tbDomain.Text;
            ddns.Token = tbToken.Text;
            ddns.Interval = cbInterval.Text;
            ddns.Save();
            Hide();
            UpdateDNS();
            RefreshTimer();
        }

        private void cbInterval_TextChanged(object sender, EventArgs e)
        {
            ParseInterval();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            allowshowdisplay = true;
            Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !canClose)
            {
                e.Cancel = true;
                Hide();
                // Reset values (discard)
                tbDomain.Text = ddns.Domain;
                tbToken.Text = ddns.Token;
                cbInterval.Text = ddns.Interval;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateDNS();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canClose = true;
            Close();
        }

        private void updateNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDNS();
        }
    }
}
