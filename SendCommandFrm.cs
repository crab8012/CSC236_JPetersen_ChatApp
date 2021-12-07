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
    public partial class SendCommandFrm : Form
    {
        Preferences userPrefs = null;
        public SendCommandFrm()
        {
            InitializeComponent();
        }
        public SendCommandFrm(Preferences prefs)
        {
            userPrefs = prefs;
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(userPrefs != null)
            {
                Client.sendCommand(new CSC236_JPetersen_ChatAppServer.CommandPacket("save"), userPrefs.ServerAddress, userPrefs.ServerPort); // Send the save command to the server
            }
            this.Close();
        }

        private void shutdownBtn_Click(object sender, EventArgs e)
        {
            if (userPrefs != null)
            {
                Client.sendCommand(new CSC236_JPetersen_ChatAppServer.CommandPacket("shutdown"), userPrefs.ServerAddress, userPrefs.ServerPort); // Send the shutdown command to the server
            }
            this.Close();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        { 
            this.Close(); // Close the Commands window
        }
    }
}
