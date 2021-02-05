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
    public partial class FAbout : Form
    {
        private FAbout()
        {
            InitializeComponent();
        }

        public static void Execute()
        {
            using (FAbout f = new FAbout())
                f.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/XWolfOverride/DuckDNS");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FAbout_Paint(object sender, PaintEventArgs e)
        {
            int w = Size.Width - 1;
            int h = Size.Height - 1;
            e.Graphics.DrawRectangle(Windows.framePen, 0, 0, w, h);
            h -= 20;
            e.Graphics.DrawLine(Windows.framePen, 3, h, w - 3, h);
        }

        private void pTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Windows.DragWindow(Handle);
            }
        }
    }
}
