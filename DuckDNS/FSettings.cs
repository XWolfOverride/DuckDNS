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
    partial class FSettings : Form
    {
        private DDns ddns;
        private FSettings(DDns ddns)
        {
            InitializeComponent();
            this.ddns = ddns;
            LoadData();
        }

        public static void Execute(DDns ddns)
        {
            using (FSettings f = new FSettings(ddns))
                f.ShowDialog();
        }

        private void LoadData()
        {
            cbMulti.Checked = ddns.Domain == "*";
            foreach (DDnsDomain d in ddns.Domains)
                ListViewItemFromDomain(d);
            LookNFeel();
        }

        public void SaveData()
        {
            bool multi = cbMulti.Checked;
            if (multi)
            {
                ddns.Domain = "*";
                ddns.Domains.Clear();
                foreach (ListViewItem lvi in lvList.Items)
                    ddns.Domains.Add(lvi.Tag as DDnsDomain);
            }
            else if (ddns.Domain == "*")
            {
                if (lvList.Items.Count > 0)
                    ddns.Domain = lvList.Items[0].Name;
                else
                    ddns.Domain = "";
            }
        }

        private void LookNFeel()
        {
            bool multi = cbMulti.Checked;
            lvList.Enabled = multi;
            btAdd.Enabled = multi;
            btDel.Enabled = multi && lvList.SelectedItems.Count == 1;
        }

        private ListViewItem ListViewItemFromDomain(DDnsDomain d)
        {
            ListViewItem lvi = lvList.Items.Add(d.Domain);
            lvi.Tag = d;
            UpdateItem(lvi);
            return lvi;
        }

        private void UpdateItem(ListViewItem lvi)
        {
            DDnsDomain d = lvi.Tag as DDnsDomain;
            if (d == null)
                return;
            lvi.Name = lvi.Text = d.Domain;
            while (lvi.SubItems.Count < 2)
                lvi.SubItems.Add("");
            string rdesc = "";
            switch (d.ResolutionMode)
            {
                case DDnsResolutionMode.Server:
                    rdesc = "by DuckDNS";
                    break;
                case DDnsResolutionMode.Local:
                    rdesc = "local";
                    break;
                case DDnsResolutionMode.Fixed:
                    rdesc = "fixed IP: " + d.ResolutionValue;
                    break;
                case DDnsResolutionMode.Host:
                    rdesc = "host " + d.ResolutionValue;
                    break;
                case DDnsResolutionMode.WebService:
                    rdesc = "url " + d.ResolutionValue;
                    break;
            }
            lvi.SubItems[1].Text = rdesc;
        }

        private ListViewItem NewDomain(string predef)
        {
            DDnsDomain dd = new DDnsDomain();
            dd.Domain = predef;
            dd.ResolutionMode = DDnsResolutionMode.Server;
            return ListViewItemFromDomain(dd);
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

        private void cbMulti_CheckedChanged(object sender, EventArgs e)
        {
            LookNFeel();
            if (cbMulti.Checked && ddns.Domain != "*" && ddns.Domain != "")
            {
                bool ta = false;
                foreach (ListViewItem lvi in lvList.Items)
                    if (ddns.Domain == lvi.Name)
                    {
                        ta = true;
                        break;
                    }
                if (!ta)
                    NewDomain(ddns.Domain);
            }
        }

        private void FSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lvi=NewDomain("");
            FEditDomain.Execute(lvi.Tag as DDnsDomain);
            UpdateItem(lvi);
        }

        private void lvList_DoubleClick(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count != 1)
                return;
            ListViewItem lvi = lvList.SelectedItems[0];
            FEditDomain.Execute(lvi.Tag as DDnsDomain);
            UpdateItem(lvi);
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookNFeel();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count != 1)
                return;
            ListViewItem lvi = lvList.SelectedItems[0];
            if (MessageBox.Show("Delete domain '" + lvi.Name + "'?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                lvi.Remove();
        }
    }
}
