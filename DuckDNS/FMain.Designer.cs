namespace DuckDNS
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.installStartupShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbInterval = new System.Windows.Forms.ComboBox();
            this.btAbout = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btClose = new System.Windows.Forms.Button();
            this.btIconify = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.pHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pTitleBar = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Text = "DuckDNS";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateNowToolStripMenuItem,
            this.toolStripSeparator1,
            this.installStartupShortcutToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(193, 82);
            // 
            // updateNowToolStripMenuItem
            // 
            this.updateNowToolStripMenuItem.Name = "updateNowToolStripMenuItem";
            this.updateNowToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.updateNowToolStripMenuItem.Text = "Update Now!";
            this.updateNowToolStripMenuItem.Click += new System.EventHandler(this.updateNowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // installStartupShortcutToolStripMenuItem
            // 
            this.installStartupShortcutToolStripMenuItem.Name = "installStartupShortcutToolStripMenuItem";
            this.installStartupShortcutToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.installStartupShortcutToolStripMenuItem.Text = "Install startup shortcut";
            this.installStartupShortcutToolStripMenuItem.Click += new System.EventHandler(this.installStartupShortcutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btOk.FlatAppearance.BorderSize = 0;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.White;
            this.btOk.Location = new System.Drawing.Point(451, 207);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(82, 31);
            this.btOk.TabIndex = 3;
            this.btOk.Text = "Ok";
            this.toolTip.SetToolTip(this.btOk, "Accept, Save and Check");
            this.btOk.UseVisualStyleBackColor = false;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Domain";
            // 
            // tbDomain
            // 
            this.tbDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbDomain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tbDomain.Location = new System.Drawing.Point(92, 119);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(441, 21);
            this.tbDomain.TabIndex = 0;
            this.toolTip.SetToolTip(this.tbDomain, "DuckDNS domain to update");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label2.Location = new System.Drawing.Point(12, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Token";
            // 
            // tbToken
            // 
            this.tbToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tbToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tbToken.Location = new System.Drawing.Point(92, 153);
            this.tbToken.Name = "tbToken";
            this.tbToken.Size = new System.Drawing.Size(441, 21);
            this.tbToken.TabIndex = 1;
            this.toolTip.SetToolTip(this.tbToken, "User Token (see DuckDNS user page)");
            this.tbToken.UseSystemPasswordChar = true;
            this.tbToken.TextChanged += new System.EventHandler(this.valueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.label3.Location = new System.Drawing.Point(12, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interval";
            // 
            // cbInterval
            // 
            this.cbInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cbInterval.FormattingEnabled = true;
            this.cbInterval.Items.AddRange(new object[] {
            "10s",
            "30s",
            "1m",
            "5m",
            "10m",
            "30m",
            "1h",
            "2h",
            "5h",
            "10h",
            "1d"});
            this.cbInterval.Location = new System.Drawing.Point(92, 188);
            this.cbInterval.Name = "cbInterval";
            this.cbInterval.Size = new System.Drawing.Size(233, 23);
            this.cbInterval.TabIndex = 2;
            this.toolTip.SetToolTip(this.cbInterval, "Update interval (number and unit)\r\nUse a tailing letter to define time unit\r\ns fo" +
        "r seconds.\r\nm for minutes.\r\nh for hours.\r\nd for days.");
            this.cbInterval.TextChanged += new System.EventHandler(this.cbInterval_TextChanged);
            // 
            // btAbout
            // 
            this.btAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btAbout.FlatAppearance.BorderSize = 0;
            this.btAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.btAbout.Location = new System.Drawing.Point(432, 2);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(52, 23);
            this.btAbout.TabIndex = 0;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Calibri", 14F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(223)))));
            this.lblInfo.Location = new System.Drawing.Point(16, 67);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(519, 23);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Please, complete your dynamic DNS info";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btClose.Image = ((System.Drawing.Image)(resources.GetObject("btClose.Image")));
            this.btClose.Location = new System.Drawing.Point(518, 2);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(28, 23);
            this.btClose.TabIndex = 2;
            this.toolTip.SetToolTip(this.btClose, "Close");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btIconify
            // 
            this.btIconify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btIconify.FlatAppearance.BorderSize = 0;
            this.btIconify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btIconify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btIconify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btIconify.Image = global::DuckDNS.Properties.Resources.iconify;
            this.btIconify.Location = new System.Drawing.Point(487, 2);
            this.btIconify.Name = "btIconify";
            this.btIconify.Size = new System.Drawing.Size(28, 23);
            this.btIconify.TabIndex = 1;
            this.toolTip.SetToolTip(this.btIconify, "Close");
            this.btIconify.UseVisualStyleBackColor = true;
            this.btIconify.Click += new System.EventHandler(this.btIconify_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btSettings.FlatAppearance.BorderSize = 0;
            this.btSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btSettings.ForeColor = System.Drawing.Color.White;
            this.btSettings.Image = global::DuckDNS.Properties.Resources.settings;
            this.btSettings.Location = new System.Drawing.Point(414, 207);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(31, 31);
            this.btSettings.TabIndex = 10;
            this.toolTip.SetToolTip(this.btSettings, "Advanced settings");
            this.btSettings.UseVisualStyleBackColor = false;
            this.btSettings.Visible = false;
            // 
            // pHeader
            // 
            this.pHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.pHeader.Controls.Add(this.label4);
            this.pHeader.Controls.Add(this.pTitleBar);
            this.pHeader.Controls.Add(this.lblInfo);
            this.pHeader.Location = new System.Drawing.Point(1, 1);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(548, 100);
            this.pHeader.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 19F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "DuckDNS Updater";
            // 
            // pTitleBar
            // 
            this.pTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.pTitleBar.Controls.Add(this.btIconify);
            this.pTitleBar.Controls.Add(this.btClose);
            this.pTitleBar.Controls.Add(this.btAbout);
            this.pTitleBar.Location = new System.Drawing.Point(0, 0);
            this.pTitleBar.Name = "pTitleBar";
            this.pTitleBar.Size = new System.Drawing.Size(548, 27);
            this.pTitleBar.TabIndex = 7;
            this.pTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pTitleBar_MouseMove);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 256);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.cbInterval);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbDomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DuckDNS";
            this.Deactivate += new System.EventHandler(this.FMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FMain_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbInterval;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installStartupShortcutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pTitleBar;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btIconify;
        private System.Windows.Forms.Button btSettings;
    }
}

