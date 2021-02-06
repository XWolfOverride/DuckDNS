using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DuckDNS
{
    partial class FEditDomain : Form
    {
        private DDnsDomain d;
        private FEditDomain(DDnsDomain d)
        {
            InitializeComponent();
            this.d = d;
            InitMasterData();
            LoadData();
        }

        public static void Execute(DDnsDomain d)
        {
            using (FEditDomain f = new FEditDomain(d))
                f.ShowDialog();
        }

        private void InitMasterData()
        {
            cbResolve.Items.Clear();
            foreach (DDnsResolutionMode rm in Enum.GetValues(typeof(DDnsResolutionMode)))
                cbResolve.Items.Add(rm);
        }

        private void LoadData()
        {
            tbName.Text = lbName.Text = d.Domain;
            cbResolve.SelectedItem = d.ResolutionMode;
            tbRValue.Text = d.ResolutionValue;
        }

        public void SaveData()
        {
            d.Domain = tbName.Text;
            d.ResolutionMode = (DDnsResolutionMode)cbResolve.SelectedItem;
            d.ResolutionValue = tbRValue.Text;
        }

        private void LookNFeel()
        {
        }

        private void FAbout_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Windows.framePen, 0, 0, Size.Width - 1, Size.Height - 1);
        }

        private void pTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Windows.DragWindow(Handle);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveData();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            lbName.Text = tbName.Text;
        }

        private void cbResolve_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((DDnsResolutionMode)cbResolve.SelectedItem)
            {
                case DDnsResolutionMode.Server:
                    lbRModeInfo.Text = "let DuckDNS resolve the external IP address of your computer.";
                    lbRValue.Visible = false;
                    tbRValue.Visible = false;
                    break;
                case DDnsResolutionMode.Local:
                    lbRModeInfo.Text = "this client will do the IP resolving.";
                    lbRValue.Visible = false;
                    tbRValue.Visible = false;
                    break;
                case DDnsResolutionMode.Fixed:
                    lbRModeInfo.Text = "set the IP to a fixed value.";
                    lbRValue.Text = "IP address:";
                    lbRValue.Visible = true;
                    tbRValue.Visible = true;
                    break;
                case DDnsResolutionMode.Host:
                    lbRModeInfo.Text = "get the IP by host name as seen by this computer.";
                    lbRValue.Text = "Hostname:";
                    lbRValue.Visible = true;
                    tbRValue.Visible = true;
                    break;
                case DDnsResolutionMode.WebService:
                    lbRModeInfo.Text = "call a web service to retrieve the IP address (GET method).";
                    lbRValue.Text = "URL/File:";
                    lbRValue.Visible = true;
                    tbRValue.Visible = true;
                    break;
            }
        }
    }
}
