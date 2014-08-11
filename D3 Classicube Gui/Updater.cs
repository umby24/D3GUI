using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace D3_Classicube_Gui {
    class Updater {
        private const string UpdateUrl = "http://umby.d3s.co/CCD3/gui";
        private const string FileUrl = "http://umby.d3s.co/CCD3/";
        private const string ServerUrl = "http://umby.d3s.co/CCD3/server";
        private const string ThisVersion = "1.0.15";
        string _serverVersion = "";
        string _thisServer = "";
        public Form1 MainForm;

        public string GetVersion() {
            // -- Returns the most up-to-date version of the GUI.
            var check = new WebClient();
            string version = check.DownloadString(UpdateUrl);
            version = version.Replace("\n", "");
            return version;
        }
        public void CheckUpdates() {
            _serverVersion = GetVersion();

            if (_serverVersion == ThisVersion) 
                return;

            var b = MessageBox.Show("There is an update available! Would you like to download?", "Update", MessageBoxButtons.YesNo);

            if (b != DialogResult.Yes) 
                return;

            MessageBox.Show("The update will now download in the background. Progress will be shown.", "Update");
            doUpdate();
        }
        public void doUpdate() {
            var downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted;

            var ub = new UriBuilder(FileUrl + _serverVersion + ".exe");
            downloader.DownloadFileAsync(ub.Uri, _serverVersion + " Gui.exe");
            
        }

        void downloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            MainForm.updateProgress.Visible = false;
            MessageBox.Show("Update complete, filename is " + _serverVersion + " Gui.exe", "Update");
        }

        void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            MainForm.updateProgress.Visible = true;
            MainForm.updateProgress.Value = e.ProgressPercentage;
        }

        #region Server Updater
        public string GetVersionServer() {
            // -- Returns the most up-to-date version of the GUI.
            var check = new WebClient();
            string version = check.DownloadString(ServerUrl);
            version = version.Replace("\n", "");
            return version;
        }
        public void CheckUpdatesServer(string server) {
            _thisServer = server;
            _serverVersion = GetVersionServer();
            if (server != _serverVersion) {
                DialogResult b = MessageBox.Show("There is an updated server available! Would you like to download?", "Update", MessageBoxButtons.YesNo);
                if (b == DialogResult.Yes) {
                    MessageBox.Show("The update will now download in the background. Progress will be shown. Please do not start server.", "Update");
                    DoUpdateServer();
                }
            }
        }
        public void DoUpdateServer() {
            WebClient downloader = new WebClient();
            downloader.DownloadProgressChanged += downloader_DownloadProgressChanged_Server;
            downloader.DownloadFileCompleted += downloader_DownloadFileCompleted_Server;

            UriBuilder ub = new UriBuilder(FileUrl + _thisServer + ".exe");
            downloader.DownloadFileAsync(ub.Uri, _thisServer + "_Server.exe");

            MainForm.serverVersion = _thisServer;
            MainForm.saveSettings();
        }

        void downloader_DownloadFileCompleted_Server(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            MainForm.updateProgress.Visible = false;

            System.IO.File.Delete("Minecraft-Server.x86.exe");
            System.IO.File.Move(_thisServer + "_Server.exe", "Minecraft-Server.x86.exe");
            MessageBox.Show("Update complete, You may now start your server.\n\nNOTE: You may need to download additional files for the server to fully function!\n\nVisit the website news section for details.", "Update");
        }

        void downloader_DownloadProgressChanged_Server(object sender, DownloadProgressChangedEventArgs e) {
            MainForm.updateProgress.Visible = true;
            MainForm.updateProgress.Value = e.ProgressPercentage;
        }
        #endregion
    }
}
