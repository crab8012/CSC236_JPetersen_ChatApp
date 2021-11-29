using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // To use, must install System.Text.Json from NuGet.

namespace CSC236_JPetersen_ChatApp
{
    class ClientAndFiles
    {
        // Serialize a preferences object and then save to a file.
        public static void savePreferences()
        {

        }
        
        // Load from a file and deserialize to a preferences object.
        public static void loadPreferences()
        {

        }
    }
    
    // Preferences Class - Serializable, contains preference data for the application.
    class Preferences
    {
        System.Drawing.Color GlobalTextColor { get; set; }
        string DisplayName { get; set; }
        string ServerAddress { get; set; }
        int ServerPort { get; set; }
        int UserHash { get; set; }

        public void saveToFile(string fileName)
        {
            using (StreamWriter outWriter = new StreamWriter(fileName))
            {
                outWriter.Write(JsonSerializer.Serialize(this));
            }
        }

        public void readFromFile(string fileName)
        {
            using (StreamReader inReader = new StreamReader(fileName))
            {
                // Read in data from the preferences file.
                Preferences tempPrefs = JsonSerializer.Deserialize<Preferences>(inReader.ReadToEnd());

                // Apply preferences to current application instance.
                this.GlobalTextColor = tempPrefs.GlobalTextColor;
                this.DisplayName = tempPrefs.DisplayName;
                this.ServerAddress = tempPrefs.ServerAddress;
                this.ServerPort = tempPrefs.ServerPort;
                this.UserHash = tempPrefs.UserHash;
            }
        }
    }

    // Client Class - Used for all communication with the server
}
