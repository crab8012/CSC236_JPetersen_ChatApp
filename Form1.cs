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
            
            Thread.Sleep(5000); // Show the splash screen for 5000 seconds.

            t.Abort(); // Close the splash screen

            InitializeComponent(); // Get the main window working


            userPrefs.readFromFile("prefs.json"); // Read in user preferences from file.
        }

        public void ShowSplash()
        {
            Application.Run(new SplashFrm()); // Show the splash screen
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

            ChatPacket toSend = new ChatPacket(outMsgTxt.Text, userPrefs.DisplayName); // Create outgoing message packet
            ArrayList msgs = Client.sendMessage(toSend, userPrefs.ServerAddress, userPrefs.ServerPort); // Send and recieve data from server

            // Add all recieved messages to the textbox
            foreach (ChatPacket c in msgs)
            {
                incomingMsgTxt.Text = incomingMsgTxt.Text + "\n" + c.ToString();
            }

            outMsgTxt.Text = "";
        }

        private void sendCMDBtn_Click(object sender, EventArgs e)
        {
            SendCommandFrm cmdFrm = new SendCommandFrm(userPrefs); // Show the command form
            cmdFrm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Close the program.
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
            colorDialog1.ShowDialog(); // Show a color picker dialog box
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
            // If the user hits enter in the textbox
            if(e.KeyCode == Keys.Enter)
            {
                sendMessageBtn_Click(sender, null); // Send the message
            }
        }

        private void refreshChatBtn_Click(object sender, EventArgs e)
        {
            // Send a null command to the server to get all of the messages
            ArrayList msgs = Client.sendNull(userPrefs.ServerAddress, userPrefs.ServerPort);

            // Display the messages in the Textbox
            foreach (ChatPacket c in msgs)
            {
                incomingMsgTxt.Text = incomingMsgTxt.Text + "\n" + c.ToString();
            }
        }
    }
}
