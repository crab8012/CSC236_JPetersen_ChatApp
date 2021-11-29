
namespace CSC236_JPetersen_ChatApp
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.conversationTab = new System.Windows.Forms.TabPage();
            this.incomingMsgRTxt = new System.Windows.Forms.RichTextBox();
            this.sendCMDBtn = new System.Windows.Forms.Button();
            this.outMsgTxt = new System.Windows.Forms.TextBox();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.preferencesTab = new System.Windows.Forms.TabPage();
            this.displayNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.savePreferencesBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverAddressTxt = new System.Windows.Forms.TextBox();
            this.serverPortTxt = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.globalTextColorBtn = new System.Windows.Forms.Button();
            this.userHashBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.conversationTab.SuspendLayout();
            this.preferencesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(270, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.wikiToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // wikiToolStripMenuItem
            // 
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.wikiToolStripMenuItem.Text = "Wiki";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 412);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(270, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.conversationTab);
            this.tabControl1.Controls.Add(this.preferencesTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 378);
            this.tabControl1.TabIndex = 2;
            // 
            // conversationTab
            // 
            this.conversationTab.Controls.Add(this.incomingMsgRTxt);
            this.conversationTab.Controls.Add(this.sendCMDBtn);
            this.conversationTab.Controls.Add(this.outMsgTxt);
            this.conversationTab.Controls.Add(this.sendMessageBtn);
            this.conversationTab.Location = new System.Drawing.Point(4, 22);
            this.conversationTab.Name = "conversationTab";
            this.conversationTab.Padding = new System.Windows.Forms.Padding(3);
            this.conversationTab.Size = new System.Drawing.Size(262, 352);
            this.conversationTab.TabIndex = 0;
            this.conversationTab.Text = "Conversation";
            this.conversationTab.UseVisualStyleBackColor = true;
            this.conversationTab.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // incomingMsgRTxt
            // 
            this.incomingMsgRTxt.Location = new System.Drawing.Point(6, 6);
            this.incomingMsgRTxt.Name = "incomingMsgRTxt";
            this.incomingMsgRTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.incomingMsgRTxt.Size = new System.Drawing.Size(247, 277);
            this.incomingMsgRTxt.TabIndex = 18;
            this.incomingMsgRTxt.Text = resources.GetString("incomingMsgRTxt.Text");
            // 
            // sendCMDBtn
            // 
            this.sendCMDBtn.BackColor = System.Drawing.Color.Transparent;
            this.sendCMDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendCMDBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendCMDBtn.Location = new System.Drawing.Point(209, 290);
            this.sendCMDBtn.Margin = new System.Windows.Forms.Padding(1);
            this.sendCMDBtn.Name = "sendCMDBtn";
            this.sendCMDBtn.Size = new System.Drawing.Size(45, 19);
            this.sendCMDBtn.TabIndex = 17;
            this.sendCMDBtn.Text = "CMD";
            this.sendCMDBtn.UseVisualStyleBackColor = false;
            this.sendCMDBtn.Click += new System.EventHandler(this.sendCMDBtn_Click);
            // 
            // outMsgTxt
            // 
            this.outMsgTxt.Location = new System.Drawing.Point(3, 290);
            this.outMsgTxt.MaxLength = 140;
            this.outMsgTxt.Multiline = true;
            this.outMsgTxt.Name = "outMsgTxt";
            this.outMsgTxt.Size = new System.Drawing.Size(200, 56);
            this.outMsgTxt.TabIndex = 16;
            this.outMsgTxt.Text = "Aenean purus mi, volutpat non eleifend at, rutrum sit amet arcu. Vivamus molestie" +
    " sit amet odio vitae egestas. Phasellus vel arcu nisi nunc.";
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Location = new System.Drawing.Point(209, 313);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(45, 33);
            this.sendMessageBtn.TabIndex = 15;
            this.sendMessageBtn.Text = "SEND";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            this.sendMessageBtn.Click += new System.EventHandler(this.sendMessageBtn_Click);
            // 
            // preferencesTab
            // 
            this.preferencesTab.Controls.Add(this.label4);
            this.preferencesTab.Controls.Add(this.userHashBox);
            this.preferencesTab.Controls.Add(this.globalTextColorBtn);
            this.preferencesTab.Controls.Add(this.serverPortTxt);
            this.preferencesTab.Controls.Add(this.serverAddressTxt);
            this.preferencesTab.Controls.Add(this.label3);
            this.preferencesTab.Controls.Add(this.label2);
            this.preferencesTab.Controls.Add(this.savePreferencesBtn);
            this.preferencesTab.Controls.Add(this.label1);
            this.preferencesTab.Controls.Add(this.displayNameTxt);
            this.preferencesTab.Location = new System.Drawing.Point(4, 22);
            this.preferencesTab.Name = "preferencesTab";
            this.preferencesTab.Padding = new System.Windows.Forms.Padding(3);
            this.preferencesTab.Size = new System.Drawing.Size(262, 352);
            this.preferencesTab.TabIndex = 1;
            this.preferencesTab.Text = "Preferences";
            this.preferencesTab.UseVisualStyleBackColor = true;
            // 
            // displayNameTxt
            // 
            this.displayNameTxt.Location = new System.Drawing.Point(114, 6);
            this.displayNameTxt.Name = "displayNameTxt";
            this.displayNameTxt.Size = new System.Drawing.Size(140, 20);
            this.displayNameTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Screen Name:";
            // 
            // savePreferencesBtn
            // 
            this.savePreferencesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePreferencesBtn.Location = new System.Drawing.Point(179, 323);
            this.savePreferencesBtn.Name = "savePreferencesBtn";
            this.savePreferencesBtn.Size = new System.Drawing.Size(75, 23);
            this.savePreferencesBtn.TabIndex = 2;
            this.savePreferencesBtn.Text = "SAVE";
            this.savePreferencesBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Server Port:";
            // 
            // serverAddressTxt
            // 
            this.serverAddressTxt.Location = new System.Drawing.Point(114, 32);
            this.serverAddressTxt.Name = "serverAddressTxt";
            this.serverAddressTxt.Size = new System.Drawing.Size(140, 20);
            this.serverAddressTxt.TabIndex = 5;
            // 
            // serverPortTxt
            // 
            this.serverPortTxt.Location = new System.Drawing.Point(114, 58);
            this.serverPortTxt.MaxLength = 5;
            this.serverPortTxt.Name = "serverPortTxt";
            this.serverPortTxt.Size = new System.Drawing.Size(140, 20);
            this.serverPortTxt.TabIndex = 6;
            // 
            // globalTextColorBtn
            // 
            this.globalTextColorBtn.Location = new System.Drawing.Point(114, 85);
            this.globalTextColorBtn.Name = "globalTextColorBtn";
            this.globalTextColorBtn.Size = new System.Drawing.Size(139, 23);
            this.globalTextColorBtn.TabIndex = 7;
            this.globalTextColorBtn.Text = "Global Text Color";
            this.globalTextColorBtn.UseVisualStyleBackColor = true;
            this.globalTextColorBtn.Click += new System.EventHandler(this.globalTextColorBtn_Click);
            // 
            // userHashBox
            // 
            this.userHashBox.Location = new System.Drawing.Point(114, 115);
            this.userHashBox.Name = "userHashBox";
            this.userHashBox.Size = new System.Drawing.Size(138, 20);
            this.userHashBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "User Hash:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Chat App";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.conversationTab.ResumeLayout(false);
            this.conversationTab.PerformLayout();
            this.preferencesTab.ResumeLayout(false);
            this.preferencesTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage conversationTab;
        private System.Windows.Forms.TabPage preferencesTab;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button sendCMDBtn;
        private System.Windows.Forms.TextBox outMsgTxt;
        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.RichTextBox incomingMsgRTxt;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        private System.Windows.Forms.Button savePreferencesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox displayNameTxt;
        private System.Windows.Forms.Button globalTextColorBtn;
        private System.Windows.Forms.TextBox serverPortTxt;
        private System.Windows.Forms.TextBox serverAddressTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox userHashBox;
    }
}

