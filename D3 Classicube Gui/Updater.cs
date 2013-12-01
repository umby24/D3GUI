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
        string serverUrl = "http://umby.d3s.co/CCD3/server";
        string thisVersion = "1.0.9";
        string serverVersion = "";
        string thisServer = "";
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

        #region Server Updater
        public string getVersionServer() {
            // -- Returns the most up-to-date version of the GUI.
            WebClient check = new WebClient();
            string version = check.DownloadString(serverUrl);
            version = version.Replace("\n", "");
            return version;
        }
        public void checkUpdatesServer(string server) {
            thisServer = server;
            serverVersion = getVersionServer();
            if (server != serverVersion) {
                DialogResult b = MessageBox.Show("There is an updated server available! Would you like to download?", "Update", MessageBoxButtons.YesNo);
                if (b == DialogResult.Yes) {
                    MessageBox.Show("The update will now download in the background. Progress will be shown. Please do not start server.", "Update");
                    doUpdateServer();
                }
            }
        }
        public void doUpdateServer() {
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged_Server;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted_Server;

            UriBuilder ub = new UriBuilder(fileUrl + thisServer + ".exe");
            downloader.DownloadFileAsync(ub.Uri, thisServer + "_Server.exe");

            mainForm.serverVersion = thisServer;
            mainForm.saveSettings();
        }

        void downloader_DownloadFileCompleted_Server(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            mainForm.updateProgress.Visible = false;

            System.IO.File.Delete("Minecraft.Server.x86.exe");
            System.IO.File.Move(thisServer + "_Server.exe", "Minecraft.Server.x86.exe");
            MessageBox.Show("Update complete, You may now start your server.\n\nNOTE: You may need to download additional files for the server to fully function!\n\nVisit the website news section for details.", "Update");
        }

        void downloader_DownloadProgressChanged_Server(object sender, DownloadProgressChangedEventArgs e) {
            mainForm.updateProgress.Visible = true;
            mainForm.updateProgress.Value = e.ProgressPercentage;
        }
        #endregion
    }
}
