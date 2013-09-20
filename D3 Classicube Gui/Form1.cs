using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using C_Minebot;

namespace D3_Classicube_Gui {
    public partial class Form1 : Form {
        #region Variables
        Process serverProc;
        bool mini = false;
        miniForm mf;
        bool running = false;
        int online = 0;
        string lastHeartbeat = "";
        public bool[] cSettings; // -- 0 = Heartbeat, 1 = Chat, 2 = Command, 3 = Mapsave, 4 = Player login, 5 = LUA Messages
        #region Server Settings
        string serverName = "";
        string motd = "";
        string welcomeMessage = "";
        string maxPlayers = "0";
        byte nameVerify = 0;
        string port = "25565";
        byte pub = 0;
        #endregion
        #endregion
        #region Button Clicks
        private void btnMini_Click(object sender, EventArgs e) {
            mf = new miniForm();
            mf.lblMotd.Text = motd;
            mf.lblName.Text = serverName;
            mf.lblOnline.Text = online + "/" + maxPlayers;
            mf.lblPublic.Text = pub.ToString();
            mf.lblVerify.Text = nameVerify.ToString();
            mf.lblHeartbeat.Text = lastHeartbeat;
            mf.Mainform = this;
            mini = true;
            mf.Show();
            this.Hide();
        }
        private void bShowToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnFilter_Click(object sender, EventArgs e) {
            consoleSettings cs = new consoleSettings();
            cs.Mainform = this;
            cs.chkHeartbeat.Checked = cSettings[0];
            cs.chkChat.Checked = cSettings[1];
            cs.chkCommands.Checked = cSettings[2];
            cs.chkMapSave.Checked = cSettings[3];
            cs.chkPlayers.Checked = cSettings[4];
            cs.chkLua.Checked = cSettings[5];
            cs.Show();
        }

        private void btnTimed_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Timed_Messages.txt";
            tm.Show();
        }
        private void btnTray_Click(object sender, EventArgs e) {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            notifyIcon1.Visible = false;
        }
        private void btnStart_Click(object sender, EventArgs e) {
            serverProc.Start();
            serverProc.BeginOutputReadLine();
            running = true;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "ONLINE";
            putMessage("Server started.");
        }

        private void btnStop_Click(object sender, EventArgs e) {
            running = false;
            serverProc.Kill();
            serverProc.CancelOutputRead();
            serverProc.Close();

            lblStatus.Text = "OFFLINE";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            
            putMessage("Server stopped.");
        }
        private void btnSave_Click(object sender, EventArgs e) {
            saveSettings();
        }
        private void btnLua_Click(object sender, EventArgs e) {
            string luaCommand = Microsoft.VisualBasic.Interaction.InputBox("Enter the LUA command to be run", "LUA run");

            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.Write(luaCommand);
            fileWriter.Close();

            putMessage("LUA Command has been run.");
        }
        private void btnSend_Click(object sender, EventArgs e) {
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.Write("System_Message_Network_Send_2_All(-1, \"&c[Console]&f: " + boxChat.Text + "\")");
            fileWriter.Close();

            putMessage("[Console]: " + boxChat.Text);
            boxChat.Clear();
        }
        private void button1_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Answer.txt";
            tm.Show();
        }

        private void btnBlockTypes_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Block.txt";
            tm.Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Command.txt";
            tm.Show();
        }

        private void btnMap_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Map_Settings.txt";
            tm.Show();
        }

        private void btnRanks_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Rank.txt";
            tm.Show();
        }

        private void btnUndo_Click(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Data\\Undo.txt";
            tm.Show();
        }
        private void button1_Click_1(object sender, EventArgs e) {
            timedMessages tm = new timedMessages();
            tm.file = "Documentation\\LUA-Commands.txt";
            tm.Show();
        }
        #endregion
        #region Helping Functions
        private void filterMessage(string message) {
            if (message == null)
                return;
            string[] parts = message.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            switch (parts[1].Replace(" ", "")) {
                case "Chat.pbi":
                    if (parts[2].Replace(" ", "") == "36" && cSettings[1] == true) {
                        putMessage(parts[3].Replace(" Chat: ", ""));
                    }
                    break;
                case "Heartbeat.pb":
                    if (cSettings[0] == true) {
                        putMessage("Heartbeat Sent.");
                    }
                    lastHeartbeat = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                    lblHeartbeat.Text = "Last Heartbeat: " + lastHeartbeat;
                    if (mini == true) {
                        mf.lblHeartbeat.Text = lastHeartbeat;
                    }
                    break;
                case "Map.pbi":
                    if (parts[2].Replace(" ", "") == "712" && cSettings[3] == true) {
                        putMessage(parts[3].Replace(" Map: ", ""));
                    }
                    break;
                case "Command.pbi":
                    if (parts[2].Replace(" ", "") == "2238" && cSettings[2] == true) {
                        putMessage(parts[3].Replace(" Command: ", ""));
                    }
                    break;
                case "Client.pbi":
                    if ((parts[2].Replace(" ", "") == "88" || parts[2].Replace(" ", "") == "119") && cSettings[4] == true) {
                        string name = parts[3].Substring(parts[3].IndexOf("'") + 1, parts[3].IndexOf("'",parts[3].IndexOf("'") + 1) - (parts[3].IndexOf("'") + 1));

                        if (parts[3].Contains("logged in")) {
                            putMessage(name + " logged in.");
                            lstPlayers.Items.Add(name);
                            online += 1;
                        } else {
                            putMessage(name + " logged out.");
                            lstPlayers.Items.Remove(name);
                            online -= 1;
                        }
                        lblPlayers.Text = "Players: " + online.ToString();
                        if (mini) {
                            mf.lblOnline.Text = online + "/" + maxPlayers;
                        }
                    }
                    break;
                case "Network.pbi":
                    if (parts[2].Replace(" ", "") == "83") {
                        putMessage("WARNING: Unable to start server networking! Make sure there are no port conflicts.");
                    }
                    break;
                case "Lua.pbi":
                    if (cSettings[5] == true) {
                        putMessage("");
                        putMessage("LUA: " + parts[3]);
                        putMessage("");
                    }
                    break;
            
            }

        }
        private void loadSettings() {
            // -- Load settings in from the various .txt files.
            List<string> files = new List<string>() { "Data\\System.txt", "Data\\Player.txt", "Data\\Network.txt", "Data\\Heartbeat.txt" };

            foreach (string file in files) {
                StreamReader fileReader = new StreamReader(file);
                string myLine = "";

                do {
                    myLine = fileReader.ReadLine();

                    if (myLine == "") {
                        continue;
                    }

                    string instruction = myLine.Substring(0, myLine.IndexOf(" "));
                    string data = myLine.Substring(myLine.IndexOf("=") + 2, myLine.Length - (myLine.IndexOf("=") + 2));

                    switch (instruction) {
                        case "Server_Name":
                            serverName = data;
                            break;
                        case "MOTD":
                            motd = data;
                            break;
                        case "Message_Welcome":
                            welcomeMessage = data;
                            break;
                        case "Players_Max":
                            maxPlayers = data;
                            break;
                        case "Name_Verification":
                            nameVerify = (byte)int.Parse(data);
                            break;
                        case "Port":
                            port = data;
                            break;
                        case "Public":
                            pub = (byte)int.Parse(data);
                            break;
                    }
                    
                } while (!fileReader.EndOfStream);
                fileReader.Close();
            }

            boxMax.Text = maxPlayers;
            boxMOTD.Text = motd;
            boxSName.Text = serverName;
            boxLogin.Text = welcomeMessage;
            boxPort.Text = port;

            chkNameVerif.Checked = BitConverter.ToBoolean(new byte[] { nameVerify }, 0);
            chkPub.Checked = BitConverter.ToBoolean(new byte[] { pub }, 0);

            // -- Now load settings specific to the GUI.

            RegistryControl rc = new RegistryControl();
            byte settings = Convert.ToByte(rc.GetSetting("SH", "D3 GUI", "Console", 62));
            cSettings = new bool[] { Convert.ToBoolean(settings & 0x1), Convert.ToBoolean(settings & 0x2), Convert.ToBoolean(settings & 0x4), Convert.ToBoolean(settings & 0x8), Convert.ToBoolean(settings & 0x10), Convert.ToBoolean(settings & 0x20) };
                      

            
        }
        public void saveSettings() {
            // -- Save bot settings
            RegistryControl rc = new RegistryControl();

            byte[] settings = new byte[1];
            new BitArray(cSettings).CopyTo(settings, 0);

            rc.SaveSetting("SH", "D3 GUI", "Console", settings[0].ToString());

            // -- Save server settings.

            List<string> files = new List<string>() { "Data\\System.txt", "Data\\Player.txt", "Data\\Network.txt", "Data\\Heartbeat.txt" }; // -- The files the contain GUI configurable items.
            string tempFile = "";

            foreach (string file in files) {
                StreamReader fileReader = new StreamReader(file);
                string myLine = "";

                do {
                    myLine = fileReader.ReadLine();

                    if (myLine == "") {
                        continue;
                    }

                    string instruction = myLine.Substring(0, myLine.IndexOf(" "));
                    string data = myLine.Substring(myLine.IndexOf("=") + 2, myLine.Length - (myLine.IndexOf("=") + 2));

                    switch (instruction) {
                        case "Server_Name":
                            myLine = "Server_Name = " + boxSName.Text;
                            break;
                        case "MOTD":
                            myLine = "MOTD = " + boxMOTD.Text;
                            break;
                        case "Message_Welcome":
                            myLine = "Message_Welcome = " + boxLogin.Text;
                            break;
                        case "Players_Max":
                            myLine = "Players_Max = " + boxMax.Text;
                            break;
                        case "Name_Verification":
                            myLine = "Name_Verification = " + Convert.ToByte(chkNameVerif.Checked).ToString();
                            break;
                        case "Port":
                            myLine = "Port = " + boxPort.Text;
                            break;
                        case "Public":
                            myLine = "Public = " + Convert.ToByte(chkPub.Checked).ToString();
                            break;
                    }
                    tempFile += myLine + "\n";
                } while (!fileReader.EndOfStream);

                tempFile = tempFile.Substring(0, tempFile.Length - 1); // -- Remove the extra new line.
                fileReader.Close();

                StreamWriter fileWriter = new StreamWriter(file); // -- Write the settings to file.
                fileWriter.Write(tempFile);
                fileWriter.Close();
                tempFile = "";
            }
            loadSettings(); // -- Reload the settings so the GUI's variables are all updated accordingly.
        }

        private delegate void p_handleMessage(object sender, DataReceivedEventArgs args);

        private void handleMessage(object sender, DataReceivedEventArgs args) {
            if (this.InvokeRequired) {
                this.Invoke(new p_handleMessage(handleMessage), sender, args);
                return;
            }
            boxConsole.Text += args.Data + Environment.NewLine;
            boxConsole.Select(boxConsole.Text.Length, boxConsole.Text.Length);
            boxConsole.ScrollToCaret();
            filterMessage(args.Data);
        }
        private void putMessage(string message) {
            boxFiltered.Text += message + Environment.NewLine;
            boxFiltered.Select(boxFiltered.Text.Length, boxFiltered.Text.Length);
            boxFiltered.ScrollToCaret();
        }
        #endregion
        #region Form Events
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            if (!File.Exists("Minecraft-Server.x86.exe")) {
                MessageBox.Show("Please place in the same folder as your D3 Server.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            loadSettings();
            ProcessStartInfo psi = new ProcessStartInfo("Minecraft-Server.x86.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.WindowStyle = ProcessWindowStyle.Minimized;

            serverProc = new Process();
            serverProc.StartInfo = psi;
            serverProc.OutputDataReceived += new DataReceivedEventHandler(handleMessage);
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e) {
            try {
                serverProc.Kill();
                serverProc.CancelOutputRead();
                serverProc.Close();
                serverProc.Dispose();
            } catch {
                return;
            }
        }
        #endregion
    }
}
