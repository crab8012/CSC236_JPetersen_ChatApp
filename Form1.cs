using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSC236_JPetersen_ChatApp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            // Get the address from the textbox
            // Separate the port and the address
            // Send a 'None' packet to the server
            // Format and display messages.
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1]; // Go to the Settings tab
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the "About" dialog box
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Send the user to the GitHub repository
        }

        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            // Send the message
        }

        private void sendCMDBtn_Click(object sender, EventArgs e)
        {
            // Open the Send Command dialog box
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // Load the preferences from the Preferences Object
        }

        private void globalTextColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
    }
}
