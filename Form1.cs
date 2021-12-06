using CSC236_JPetersen_ChatAppServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC236_JPetersen_ChatApp
{
    public partial class mainForm : Form
    {
        public Preferences userPrefs = new Preferences();
        public mainForm()
        {
            // Splash Screen Stuff
            Thread t = new Thread(new ThreadStart(ShowSplash));
            t.Start();
            Thread.Sleep(5000);

            InitializeComponent(); // Get the main window working

            t.Abort();

            userPrefs.readFromFile("prefs.json");
        }

        public void ShowSplash()
        {
            Application.Run(new SplashFrm());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1]; // Go to the Settings tab
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the "About" dialog box
            AboutFrm frm = new AboutFrm();
            frm.Show();
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Send the user to the GitHub repository
            System.Diagnostics.Process.Start("https://github.com/crab8012/CSC236_JPetersen_ChatApp");
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            // Clear out all old messages
            incomingMsgTxt.Text = "";
            // Send the message
            ChatPacket toSend = new ChatPacket(outMsgTxt.Text, userPrefs.DisplayName);
            ArrayList msgs = Client.sendMessage(toSend, userPrefs.ServerAddress, userPrefs.ServerPort);

            foreach(ChatPacket c in msgs)
            {
                incomingMsgTxt.Text = incomingMsgTxt.Text + "\n" + c.ToString();
            }

            outMsgTxt.Text = "";
        }

        private void sendCMDBtn_Click(object sender, EventArgs e)
        {
            SendCommandFrm cmdFrm = new SendCommandFrm(userPrefs);
            cmdFrm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Load user preferences
            userPrefs.readFromFile("prefs.json");

            // Display user preferences in Preferences tab
            displayNameTxt.Text = userPrefs.DisplayName;

            serverAddressTxt.Text = userPrefs.ServerAddress;

            serverPortTxt.Text = userPrefs.ServerPort.ToString();

            colorDialog1.Color = userPrefs.GlobalTextColor;

            userHashTxt.Text = userPrefs.UserHash.ToString();

            // Empty the message boxes
            incomingMsgTxt.Text = "";
            outMsgTxt.Text = "";
        }

        private void globalTextColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void savePreferencesBtn_Click(object sender, EventArgs e)
        {
            // Get all inputs from the Preferences tab, add them to the preferences object, and save to file.
            userPrefs.DisplayName = displayNameTxt.Text;
            
            userPrefs.ServerAddress = serverAddressTxt.Text;
            
            int port = 0;
            int.TryParse(serverPortTxt.Text, out port);
            userPrefs.ServerPort = port;
            
            userPrefs.GlobalTextColor = colorDialog1.Color;
            
            int hash = 0;
            int.TryParse(userHashTxt.Text, out hash);
            userPrefs.UserHash = hash;

            userPrefs.saveToFile("prefs.json");
        }

        private void outMsgTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sendMessageBtn_Click(sender, null);
            }
        }

        private void refreshChatBtn_Click(object sender, EventArgs e)
        {
            ArrayList msgs = Client.sendNull(userPrefs.ServerAddress, userPrefs.ServerPort);

            foreach (ChatPacket c in msgs)
            {
                incomingMsgTxt.Text = incomingMsgTxt.Text + "\n" + c.ToString();
            }
        }
    }
}
