using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace D3_Classicube_Gui {
    class Updater {
        string updateUrl = "http://umby.d3s.co/CCD3/gui";
        string fileUrl = "http://umby.d3s.co/CCD3/";
        string thisVersion = "1.0.4";
        string serverVersion = "";
        public Form1 mainForm;

        public string getVersion() {
            // -- Returns the most up-to-date version of the GUI.
            WebClient check = new WebClient();
            string version = check.DownloadString(updateUrl);
            version = version.Replace("\n", "");
            return version;
        }
        public void checkUpdates() {
            serverVersion = getVersion();
            if (serverVersion != thisVersion) {
                DialogResult b = MessageBox.Show("There is an update available! Would you like to download?", "Update", MessageBoxButtons.YesNo);
                if (b == DialogResult.Yes) {
                    MessageBox.Show("The update will now download in the background. Progress will be shown.", "Update");
                    doUpdate();
                }
            }
        }
        public void doUpdate() {
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            UriBuilder ub = new UriBuilder(fileUrl + serverVersion + ".exe");
            downloader.DownloadFileAsync(ub.Uri, serverVersion + " Gui.exe");
            
        }

        void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            mainForm.updateProgress.Visible = false;
            MessageBox.Show("Update complete, filename is " + serverVersion + " Gui.exe", "Update");
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            mainForm.updateProgress.Visible = true;
            mainForm.updateProgress.Value = e.ProgressPercentage;
        }
    }
}
