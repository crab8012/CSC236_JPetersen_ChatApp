
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.recentsTab = new System.Windows.Forms.TabPage();
            this.contactsTab = new System.Windows.Forms.TabPage();
            this.openConversationBtn = new System.Windows.Forms.Button();
            this.searchConversationBtn = new System.Windows.Forms.Button();
            this.searchConversationTxt = new System.Windows.Forms.TextBox();
            this.conversationListBox = new System.Windows.Forms.ListBox();
            this.searchContactsBtn = new System.Windows.Forms.Button();
            this.searchContactsTxt = new System.Windows.Forms.TextBox();
            this.contactsListBox = new System.Windows.Forms.ListBox();
            this.addContactBtn = new System.Windows.Forms.Button();
            this.editContactBtn = new System.Windows.Forms.Button();
            this.deleteConversationBtn = new System.Windows.Forms.Button();
            this.startConversationBtn = new System.Windows.Forms.Button();
            this.addContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editContactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConversationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startConversationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.recentsTab.SuspendLayout();
            this.contactsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(270, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContactToolStripMenuItem,
            this.editContactToolStripMenuItem,
            this.deleteConversationToolStripMenuItem,
            this.startConversationToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.recentsTab);
            this.tabControl1.Controls.Add(this.contactsTab);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(270, 378);
            this.tabControl1.TabIndex = 2;
            // 
            // recentsTab
            // 
            this.recentsTab.Controls.Add(this.deleteConversationBtn);
            this.recentsTab.Controls.Add(this.openConversationBtn);
            this.recentsTab.Controls.Add(this.searchConversationBtn);
            this.recentsTab.Controls.Add(this.searchConversationTxt);
            this.recentsTab.Controls.Add(this.conversationListBox);
            this.recentsTab.Location = new System.Drawing.Point(4, 22);
            this.recentsTab.Name = "recentsTab";
            this.recentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.recentsTab.Size = new System.Drawing.Size(262, 352);
            this.recentsTab.TabIndex = 0;
            this.recentsTab.Text = "Recent";
            this.recentsTab.UseVisualStyleBackColor = true;
            this.recentsTab.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // contactsTab
            // 
            this.contactsTab.Controls.Add(this.startConversationBtn);
            this.contactsTab.Controls.Add(this.editContactBtn);
            this.contactsTab.Controls.Add(this.addContactBtn);
            this.contactsTab.Controls.Add(this.contactsListBox);
            this.contactsTab.Controls.Add(this.searchContactsTxt);
            this.contactsTab.Controls.Add(this.searchContactsBtn);
            this.contactsTab.Location = new System.Drawing.Point(4, 22);
            this.contactsTab.Name = "contactsTab";
            this.contactsTab.Padding = new System.Windows.Forms.Padding(3);
            this.contactsTab.Size = new System.Drawing.Size(262, 352);
            this.contactsTab.TabIndex = 1;
            this.contactsTab.Text = "Contacts";
            this.contactsTab.UseVisualStyleBackColor = true;
            // 
            // openConversationBtn
            // 
            this.openConversationBtn.Location = new System.Drawing.Point(127, 323);
            this.openConversationBtn.Name = "openConversationBtn";
            this.openConversationBtn.Size = new System.Drawing.Size(127, 23);
            this.openConversationBtn.TabIndex = 15;
            this.openConversationBtn.Text = "Open Conversation";
            this.openConversationBtn.UseVisualStyleBackColor = true;
            // 
            // searchConversationBtn
            // 
            this.searchConversationBtn.Location = new System.Drawing.Point(184, 4);
            this.searchConversationBtn.Name = "searchConversationBtn";
            this.searchConversationBtn.Size = new System.Drawing.Size(70, 23);
            this.searchConversationBtn.TabIndex = 13;
            this.searchConversationBtn.Text = "Search";
            this.searchConversationBtn.UseVisualStyleBackColor = true;
            // 
            // searchConversationTxt
            // 
            this.searchConversationTxt.Location = new System.Drawing.Point(3, 6);
            this.searchConversationTxt.Name = "searchConversationTxt";
            this.searchConversationTxt.Size = new System.Drawing.Size(175, 20);
            this.searchConversationTxt.TabIndex = 12;
            // 
            // conversationListBox
            // 
            this.conversationListBox.FormattingEnabled = true;
            this.conversationListBox.Location = new System.Drawing.Point(8, 30);
            this.conversationListBox.Name = "conversationListBox";
            this.conversationListBox.Size = new System.Drawing.Size(246, 290);
            this.conversationListBox.TabIndex = 10;
            // 
            // searchContactsBtn
            // 
            this.searchContactsBtn.Location = new System.Drawing.Point(179, 3);
            this.searchContactsBtn.Name = "searchContactsBtn";
            this.searchContactsBtn.Size = new System.Drawing.Size(75, 23);
            this.searchContactsBtn.TabIndex = 0;
            this.searchContactsBtn.Text = "Search";
            this.searchContactsBtn.UseVisualStyleBackColor = true;
            // 
            // searchContactsTxt
            // 
            this.searchContactsTxt.Location = new System.Drawing.Point(4, 4);
            this.searchContactsTxt.Name = "searchContactsTxt";
            this.searchContactsTxt.Size = new System.Drawing.Size(169, 20);
            this.searchContactsTxt.TabIndex = 1;
            // 
            // contactsListBox
            // 
            this.contactsListBox.FormattingEnabled = true;
            this.contactsListBox.Location = new System.Drawing.Point(4, 31);
            this.contactsListBox.Name = "contactsListBox";
            this.contactsListBox.Size = new System.Drawing.Size(250, 290);
            this.contactsListBox.TabIndex = 2;
            // 
            // addContactBtn
            // 
            this.addContactBtn.Location = new System.Drawing.Point(4, 326);
            this.addContactBtn.Name = "addContactBtn";
            this.addContactBtn.Size = new System.Drawing.Size(82, 23);
            this.addContactBtn.TabIndex = 3;
            this.addContactBtn.Text = "Add New";
            this.addContactBtn.UseVisualStyleBackColor = true;
            // 
            // editContactBtn
            // 
            this.editContactBtn.Location = new System.Drawing.Point(173, 326);
            this.editContactBtn.Name = "editContactBtn";
            this.editContactBtn.Size = new System.Drawing.Size(81, 23);
            this.editContactBtn.TabIndex = 4;
            this.editContactBtn.Text = "Edit Contact";
            this.editContactBtn.UseVisualStyleBackColor = true;
            // 
            // deleteConversationBtn
            // 
            this.deleteConversationBtn.Location = new System.Drawing.Point(8, 323);
            this.deleteConversationBtn.Name = "deleteConversationBtn";
            this.deleteConversationBtn.Size = new System.Drawing.Size(113, 23);
            this.deleteConversationBtn.TabIndex = 16;
            this.deleteConversationBtn.Text = "Delete Conversation";
            this.deleteConversationBtn.UseVisualStyleBackColor = true;
            // 
            // startConversationBtn
            // 
            this.startConversationBtn.Location = new System.Drawing.Point(92, 326);
            this.startConversationBtn.Name = "startConversationBtn";
            this.startConversationBtn.Size = new System.Drawing.Size(75, 23);
            this.startConversationBtn.TabIndex = 5;
            this.startConversationBtn.Text = "Chat";
            this.startConversationBtn.UseVisualStyleBackColor = true;
            // 
            // addContactToolStripMenuItem
            // 
            this.addContactToolStripMenuItem.Name = "addContactToolStripMenuItem";
            this.addContactToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addContactToolStripMenuItem.Text = "Add Contact";
            // 
            // editContactToolStripMenuItem
            // 
            this.editContactToolStripMenuItem.Name = "editContactToolStripMenuItem";
            this.editContactToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editContactToolStripMenuItem.Text = "Edit Contact";
            // 
            // deleteConversationToolStripMenuItem
            // 
            this.deleteConversationToolStripMenuItem.Name = "deleteConversationToolStripMenuItem";
            this.deleteConversationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteConversationToolStripMenuItem.Text = "Delete Conversation";
            // 
            // startConversationToolStripMenuItem
            // 
            this.startConversationToolStripMenuItem.Name = "startConversationToolStripMenuItem";
            this.startConversationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startConversationToolStripMenuItem.Text = "Start Conversation";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.recentsTab.ResumeLayout(false);
            this.recentsTab.PerformLayout();
            this.contactsTab.ResumeLayout(false);
            this.contactsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage recentsTab;
        private System.Windows.Forms.TabPage contactsTab;
        private System.Windows.Forms.Button openConversationBtn;
        private System.Windows.Forms.Button searchConversationBtn;
        private System.Windows.Forms.TextBox searchConversationTxt;
        private System.Windows.Forms.ListBox conversationListBox;
        private System.Windows.Forms.Button deleteConversationBtn;
        private System.Windows.Forms.Button editContactBtn;
        private System.Windows.Forms.Button addContactBtn;
        private System.Windows.Forms.ListBox contactsListBox;
        private System.Windows.Forms.TextBox searchContactsTxt;
        private System.Windows.Forms.Button searchContactsBtn;
        private System.Windows.Forms.Button startConversationBtn;
        private System.Windows.Forms.ToolStripMenuItem addContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editContactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConversationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startConversationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

