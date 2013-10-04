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
        D3_ISO_Viewer.D3_Map isoMap;
        Rank currentRank;
        Map tempMap;
        Process serverProc;
        bool mini = false;
        miniForm mf;
        bool running = false;
        int online = 0;
        string lastHeartbeat = "";
        int curX = 8;
        int curY = 3;
        Dictionary<string, string> cButtons;
        bool removing = false;
        public bool[] cSettings; // -- 0 = Heartbeat, 1 = Chat, 2 = Command, 3 = Mapsave, 4 = Player login, 5 = LUA Messages 6 = Timestamps
        #region Server Settings
        string serverName = "";
        string motd = "";
        string welcomeMessage = "";
        string maxPlayers = "0";
        byte nameVerify = 0;
        string port = "25565";
        byte pub = 0;
        List<Rank> ranks;
        List<Command> commands;
        List<Block> blocks;
        List<Map> maps;
        #endregion
        #endregion
        #region Button Clicks
        private void btnAddMap_Click(object sender, EventArgs e) {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Provide a name for the new map", "New Map");
            if (name == "")
                return;
            string size = Microsoft.VisualBasic.Interaction.InputBox("Enter a size for the new map", "New Map", "64,64,64");
            if (size == "")
                return;
            // -- Check if the size is valid
            if (!size.Contains(",")) {
                MessageBox.Show("Incorrect format for map size.");
                return;
            }
            string[] splits = size.Replace(" ", "").Split(new char[] { ',' });
            if (splits.Length != 3) {
                MessageBox.Show("Incorrect format for map size, please provide an X,Y,Z");
                return;
            }
            // -- Next, get a unique map ID to use..
            int id = 0;
            bool broke = false;
            foreach (Map m in maps) {
                if ((int.Parse(m.mapID) - id) > 1) {
                    id += 1;
                    broke = true;
                    break;
                } else {
                    id += 1;
                }
            }
            if (!broke)
                id += 1;
            // -- Generate lua code to make the map, fill it, save it, and resend it.
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Add(" + id.ToString() + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ", \"" + name + "\")");
            fileWriter.WriteLine("Mapfill_standart(" + id.ToString() + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ")"); // -- Fill the map to flatgrass for them too :D
            fileWriter.WriteLine("Map_Action_Add_Save(" + id.ToString() + ", \"\")");
            fileWriter.WriteLine("Map_Resend(" + id.ToString() + ")");
            fileWriter.Close();

            loadMaps();
        }

        private void btnMapReloads_Click(object sender, EventArgs e) {
            loadMaps();
        }

        private void btnUnloadMap_Click(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Delete(" + thisMap.mapID + ")");
            fileWriter.Close();
            loadMaps();
        }

        private void btnDeleteMap_Click(object sender, EventArgs e) {
            // -- Unload map and delete its files.
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Delete(" + thisMap.mapID + ")");
            fileWriter.Close();
            Directory.Delete(thisMap.mapDirectory, true);
            loadMaps();
        }

        private void btnRenameMap_Click(object sender, EventArgs e) {
            string mapname = Microsoft.VisualBasic.Interaction.InputBox("Enter a new name for the map", "Rename map");
            if (mapname == "")
                return;
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Set_Name(" + thisMap.mapID + ", \"" + mapname + "\")");
            fileWriter.Close();
            thisMap.mapName = mapname;
            loadMaps();
        }

        private void btnRegenPrev_Click(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Save(" + thisMap.mapID + ")");
            fileWriter.Close();

            D3_ISO_Viewer.D3_Map mymap = new D3_ISO_Viewer.D3_Map();
            mymap.readConfig(thisMap.mapDirectory + "\\Config.txt");
            mymap.loadBlockColors("Data\\Block.txt");
            mymap.unzip(thisMap.mapDirectory + "\\Data-Layer.gz");

            

            Thread mapGen = new Thread(mymap.generate_Heightmap);
            mapGen.Start();
            mapGen.Join(2000);

            if ((string)dropOverType.SelectedItem == "ISO") {
                Thread mgen = new Thread(mymap.generate_iso);
                mgen.Start();
            } else if ((string)dropOverType.SelectedItem == "2D") {
                Thread mgen = new Thread(mymap.generate_2D);
                mgen.Start();
            } else {
                MessageBox.Show("Please select and overview type.");
                return;
            }
            isoMap = mymap;
            tempMap = thisMap;
            lblGen.Text = "Generating...";
            Thread wait = new Thread(waiter);
            wait.Start();
        }

        private void waiter() {
            while (isoMap.generatedImage == null) {
                continue;
            }
            picOverview.Image = isoMap.generatedImage;
            lblGen.Text = "Generated in " + isoMap.time2d + isoMap.time3d + "s";
            isoMap.time2d = "";
            isoMap.time3d = "";
            tempMap.preview = isoMap.generatedImage;
            isoMap.generatedImage = null;
        }
        private void btnMapRez_Click(object sender, EventArgs e) {
            string size = Microsoft.VisualBasic.Interaction.InputBox("Enter a new size for the map", "Map Resize", "64,64,64");
            if (size == "")
                return;
            // -- Check if the size is valid
            if (!size.Contains(",")) {
                MessageBox.Show("Incorrect format for map size.");
                return;
            }
            string[] splits = size.Replace(" ", "").Split(new char[] { ',' });
            if (splits.Length != 3) {
                MessageBox.Show("Incorrect format for map size, please provide an X,Y,Z");
                return;
            }

            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Resize(" + thisMap.mapID + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ")");
            fileWriter.Close();
        }

        private void btnRegenMap_Click(object sender, EventArgs e) {
            string args = Microsoft.VisualBasic.Interaction.InputBox("Please enter any additional arguments you would like to pass to the map generator (if supported)", "Mapfill");
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Fill(" + thisMap.mapID + ", \"" + (string)dropMapGen.SelectedItem + "\", \"" + args + "\")");
            fileWriter.WriteLine("System_Message_Network_Send_2_All(" + thisMap.mapID + ", \"Map filled from console.\")");
            fileWriter.Close();
        }

        private void btnBSave_Click(object sender, EventArgs e) {
            StreamWriter SW = new StreamWriter("Data\\Block.txt");
            foreach (Block b in blocks) {
                if (b.blockName != "--Reserved--") {
                    SW.WriteLine("[" + b.internalID + "]");
                    SW.WriteLine("Name = " + b.blockName);
                    SW.WriteLine("On_Client = " + b.clientID);
                    SW.WriteLine("Physic = " + b.physic);
                    SW.WriteLine("Physic_Plugin = " + b.physicPlugin);
                    SW.WriteLine("Do_Time = " + b.doTime);
                    SW.WriteLine("Do_Time_Random = " + b.doTimeRandom);
                    SW.WriteLine("Do_Repeat = " + b.doRepeat);
                    SW.WriteLine("Do_By_Load = " + b.dobyLoad);
                    SW.WriteLine("Create_Plugin = " + b.createPlugin);
                    SW.WriteLine("Delete_Plugin = " + b.delPlugin);
                    SW.WriteLine("Rank_Place = " + b.rankPlace);
                    SW.WriteLine("Rank_Delete = " + b.rankDelete);
                    SW.WriteLine("After_Delete = " + b.afterDelete);
                    SW.WriteLine("Killer = " + b.killer);
                    SW.WriteLine("Special = " + b.special);
                    SW.WriteLine("Color_Overview = " + b.overviewColor);
                    if (b.RBL != "" && b.RBL != null)
                        SW.WriteLine("Replace_By_Load = " + b.RBL);
                    SW.WriteLine("");
                } else {
                    SW.WriteLine("[" + b.internalID + "]");
                    SW.WriteLine("Replace_By_Load = " + b.RBL);
                    SW.WriteLine("");
                }
            }
            SW.Close();
        }

        private void btnBRevert_Click(object sender, EventArgs e) {
            loadBlocks();
        }

        private void btnAddBlock_Click(object sender, EventArgs e) {
            string blockName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for the new block.", "New block");

            if (blockName == "")
                return;
            // First need to find a new ID to use on the server for this block.
            int internalID = 0;
            bool broke = false;
            foreach (Block b in blocks) {
                if (int.Parse(b.internalID) - internalID > 1) {
                    internalID += 1;
                    broke = true;
                    break;
                } else {
                    internalID += 1;
                }
            }
            if (!broke)
                internalID += 1;

            Block newBlock = new Block(internalID.ToString(), blockName, "0", "0", "", "0", "0", "0", "0", "", "", "0", "0", "0", "0", "0", "-1");
            blocks.Add(newBlock);
            blocks = blocks.OrderBy(x => int.Parse(x.internalID)).ToList();
            lstBlock.Items.Clear();

            foreach (Block b in blocks) {
                lstBlock.Items.Add(b.blockName);
            }

        }

        private void btnRemBlock_Click(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            Block myblock = null;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    myblock = b;
                    break;
                }
            }
            if (myblock != null) {
                blocks.Remove(myblock);
                lstBlock.Items.Clear();
                foreach (Block b in blocks) {
                    lstBlock.Items.Add(b.blockName);
                }
            }
        }
        private void btnCRevert_Click(object sender, EventArgs e) {
            loadCommands();
        }

        private void lstCmd_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    boxCommand.Text = c.Name;
                    boxCRank.Text = c.rank;
                    boxShowRank.Text = c.rankShow;
                    boxPlugin.Text = c.plugin;
                    boxGroup.Text = c.group;
                    boxDescript.Text = c.description;
                    //break;
                }
            }
        }
        private void btnCSave_Click(object sender, EventArgs e) {
            StreamWriter SW = new StreamWriter("Data\\Command.txt");
            foreach (Command c in commands) {
                SW.WriteLine("[" + c.internalName + "]");
                SW.WriteLine("Name = " + c.Name);
                SW.WriteLine("Rank = " + c.rank);
                SW.WriteLine("Rank_Show = " + c.rankShow);
                SW.WriteLine("Plugin = " + c.plugin);
                SW.WriteLine("Group = " + c.group);
                SW.WriteLine("Description = " + c.description);
                SW.WriteLine("");
            }
            SW.Close();
        }

        private void btnAddCom_Click(object sender, EventArgs e) {
            string iName = Microsoft.VisualBasic.Interaction.InputBox("What is the internal name for this command?", "Internal");
            string Name = Microsoft.VisualBasic.Interaction.InputBox("What will be the command that players use to activate this command?", "Command");
            Command newC = new Command(iName, Name, "0", "0", "", "", "");
            commands.Add(newC);
            lstCmd.Items.Clear();
            foreach (Command b in commands) {
                lstCmd.Items.Add(b.Name);
            }
        }

        private void btnRemCom_Click(object sender, EventArgs e) {
            string selected = (string)lstCmd.SelectedItem;

            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == selected) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;

            commands.Remove(myCommand);

            lstCmd.Items.Clear();
            foreach (Command b in commands) {
                lstCmd.Items.Add(b.Name);
            }
        }
        private void btnAddRank_Click(object sender, EventArgs e) {
            string initName = Microsoft.VisualBasic.Interaction.InputBox("Please provide an initial name for this rank.", "Add rank");

            if (initName == "")
                return;

            string initRank = Microsoft.VisualBasic.Interaction.InputBox("Please provide an initial rank number for this rank.", "Add rank", "40");

            if (initRank == "")
                return;

            ranks.Add(new Rank(initRank, initName, ""));
            ranks = ranks.OrderBy(x => int.Parse(x.number)).ToList();
            lstRanks.Items.Clear();

            foreach (Rank b in ranks) {
                lstRanks.Items.Add(b.name);
            }
        }

        private void btnRemRank_Click(object sender, EventArgs e) {
            Rank myrank = null;
            foreach (Rank b in ranks) {
                if (b.name == (string)lstRanks.SelectedItem) {
                    myrank = b;
                    break;
                }
            }

            if (myrank == null)
                return;

            ranks.Remove(myrank);
            lstRanks.Items.Clear();

            ranks = ranks.OrderBy(x => int.Parse(x.number)).ToList();

            foreach (Rank b in ranks) {
                lstRanks.Items.Add(b.name);
            }
        }

        private void btnRevert_Click(object sender, EventArgs e) {
            loadRanks();
        }

        private void btnAddLua_Click(object sender, EventArgs e) {
            string fileName = "";
            string buttonName = "";
            DialogResult p = MessageBox.Show("Would you like to create a new script, or run an existing one? Yes for new.", "New LUA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (p == DialogResult.Cancel)
                return;

            if (p == DialogResult.Yes) {
                SaveFileDialog newFile = new SaveFileDialog();
                newFile.InitialDirectory = serverProc.StartInfo.WorkingDirectory + "\\Lua\\";
                newFile.Filter = "Lua Scripts | *.lua";
                newFile.ShowDialog();
                fileName = newFile.FileName;

                StreamWriter sNewFile = new StreamWriter(newFile.FileName);
                sNewFile.Write("");
                sNewFile.Close();

                if (fileName == "")
                    return;
            }
            if (p == DialogResult.No) {
                OpenFileDialog newFile = new OpenFileDialog();
                newFile.InitialDirectory = serverProc.StartInfo.WorkingDirectory + "\\Lua\\";
                newFile.Filter = "Lua Scripts | *.lua";
                newFile.ShowDialog();
                fileName = newFile.FileName;

                if (fileName == "")
                    return;
            }
            buttonName = Microsoft.VisualBasic.Interaction.InputBox("Please give a name for the custom button", "Adding LUA");

            if (buttonName == "")
                return;

            DialogResult thisresult = MessageBox.Show("Would you like to edit the file now?", "Lua Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (thisresult == DialogResult.Yes) {
                timedMessages tm = new timedMessages();
                tm.file = fileName;
                tm.Show();
            }

            RegistryControl rc = new RegistryControl();
            string oldButtons = (string)rc.GetSetting("SH", "D3 GUI", "luas", "");

            oldButtons += buttonName + "," + fileName + "|";
            rc.SaveSetting("SH", "D3 GUI", "luas", oldButtons);

            addButton(buttonName, fileName);
        }
        private void btnDelLua_Click(object sender, EventArgs e) {
            removing = true;
            MessageBox.Show("Click the button you want to remove.");
        }

        private void btnSaveRanks_Click(object sender, EventArgs e) {
            //blocks = blocks.OrderBy(x => int.Parse(x.internalID)).ToList();
            ranks = ranks.OrderBy(x => int.Parse(x.number)).ToList();
            saveRanks();
            loadRanks();
        }

        private void lstRanks_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (Rank f in ranks) {
                if (f.name == (string)lstRanks.SelectedItem) {
                    currentRank = f;
                    boxRName.Text = f.name;
                    boxRPrefix.Text = f.prefix;
                    boxRank.Text = f.number;

                    if (f.onclient == "100")
                        chkIsOp.Checked = true;
                    else
                        chkIsOp.Checked = false;
                    break;
                }
            }
        }
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
            if (!(parts.Length > 1))
                return;
            switch (parts[1].Replace(" ", "")) {
                case "Chat.pbi":
                    if ((parts[2].Replace(" ", "") == "36"  || parts[2].Replace(" ","") == "75") && cSettings[1] == true) {
                        putMessage(parts[3].Replace(" Chat: ", ""));
                    }
                    break;
                case "Heartbeat.pb":
                    if (cSettings[0] == true) {
                        putMessage("Heartbeat Sent.");
                    }
                    lastHeartbeat = DateTime.Now.Hour.ToString().PadLeft(2,'0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2,'0') + ":" + DateTime.Now.Second.ToString().PadLeft(2,'0');
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
                            if (lstPlayers.Items.Contains(name)) {
                                lstPlayers.Items.Remove(name);
                                online -= 1;
                            }
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

                    if (myLine == "")
                        continue;


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
            cSettings = new bool[] { Convert.ToBoolean(settings & 0x1), Convert.ToBoolean(settings & 0x2), Convert.ToBoolean(settings & 0x4), Convert.ToBoolean(settings & 0x8), Convert.ToBoolean(settings & 0x10), Convert.ToBoolean(settings & 0x20), Convert.ToBoolean(settings & 0x40) };
            
            // -- Custom buttons...

            string buttons = (string)rc.GetSetting("SH", "D3 GUI", "luas", "");

            if (buttons == "")
                return;

            string[] splits = buttons.Split(new char[] { '|' },StringSplitOptions.RemoveEmptyEntries);

            foreach (string c in splits) {
                string name = c.Substring(0, c.IndexOf(","));
                string fileName = c.Substring(c.IndexOf(",") + 1, c.Length - (c.IndexOf(",") + 1));
                addButton(name, fileName);
            }

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
        private void loadRanks() {
            ranks = new List<Rank>();
            StreamReader fileReader = new StreamReader("Data\\Rank.txt");
            string thisLine = "";
            string tempRank = "";
            string tempName = "";
            string tempPrefix = "";
            string tempClient = "0";

            do {
                thisLine = fileReader.ReadLine();

                if (thisLine == "")
                    continue;

                if (thisLine.StartsWith("[") && thisLine.Contains("]")) {
                    if (tempRank != "") {
                        ranks.Add(new Rank(tempRank, tempName, tempPrefix,tempClient));
                    }
                    tempRank = thisLine.Substring(1, thisLine.IndexOf("]") - 1);
                } else if (thisLine.Contains("=")) {
                    string command = thisLine.Substring(0, thisLine.IndexOf(" "));
                    string value = thisLine.Substring(thisLine.IndexOf("=") + 2, thisLine.Length - (thisLine.IndexOf("=") + 2));

                    switch (command) {
                        case "Name":
                            tempName = value;
                            break;
                        case "Prefix":
                            tempPrefix = value;
                            break;
                        case "On_Client":
                            tempClient = value;
                            break;
                    }
                } else { continue; }

            } while (!fileReader.EndOfStream);
            fileReader.Close();
            ranks.Add(new Rank(tempRank, tempName, tempPrefix, tempClient));
            lstRanks.Items.Clear();

            foreach (Rank b in ranks) {
                lstRanks.Items.Add(b.name);
            }
        }
        private void saveRanks() {
            StreamWriter fileWriter = new StreamWriter("Data\\Rank.txt");

            foreach (Rank b in ranks) {
                fileWriter.WriteLine("[" + b.number + "]");
                fileWriter.WriteLine("Name = " + b.name);
                fileWriter.WriteLine("Prefix = " + b.prefix);

                if (b.onclient == "100")
                    fileWriter.WriteLine("On_Client = 100");
            }

            fileWriter.Close();
        }
        private void loadCommands() {
            commands = new List<Command>();
            StreamReader fileReader = new StreamReader("Data\\Command.txt");
            string line = "";
            string iName = "";
            string name = "";
            string rank = "";
            string rankShow = "";
            string plugin = "";
            string group = "";
            string descrip = "";

            do {
                line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line.StartsWith("[") && line.Contains("]")) {
                    if (iName != "") {
                        commands.Add(new Command(iName, name, rank, rankShow, plugin, group, descrip));
                    }
                    iName = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line.Contains("=")) {
                    string command = line.Substring(0, line.IndexOf(" "));
                    string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Name":
                            name = value;
                            break;
                        case "Rank":
                            rank = value;
                            break;
                        case "Rank_Show":
                            rankShow = value;
                            break;
                        case "Plugin":
                            plugin = value;
                            break;
                        case "Group":
                            group = value;
                            break;
                        case "Description":
                            descrip = value;
                            break;
                    }
                } else { continue; }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            commands.Add(new Command(iName, name, rank, rankShow, plugin, group, descrip));
            lstCmd.Items.Clear();

            foreach (Command c in commands) {
                lstCmd.Items.Add(c.Name);
            }
        }
        private void loadBlocks() {
            blocks = new List<Block>();
            StreamReader fileReader = new StreamReader("Data\\Block.txt");
            string line = "";
            string internalID = "";
            string blockName = "";
            string clientID = "";
            string physic = "";
            string physicPlugin = "";
            string doTime = "";
            string doTimeRandom = "";
            string doRepeat = "";
            string dobyLoad = "";
            string createPlugin = "";
            string delPlugin = "";
            string rankPlace = "";
            string rankDelete = "";
            string afterDelete = "";
            string killer = "";
            string special = "";
            string overviewColor = "";
            string RBL = "";

            do {
                line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line.StartsWith("[") && line.Contains("]")) {
                    if (internalID != "") {
                        if (blockName != "")
                            blocks.Add(new Block(internalID, blockName, clientID, physic, physicPlugin, doTime, doTimeRandom, doRepeat, dobyLoad, createPlugin, delPlugin, rankPlace, rankDelete, afterDelete, killer, special, overviewColor));
                        if (RBL != "") 
                            blocks[blocks.Count - 1].RBL = RBL;

                        blockName = "";
                        clientID = "";
                        physic = "";
                        physicPlugin = "";
                        doTime = "";
                        doTimeRandom = "";
                        doRepeat = "";
                        dobyLoad = "";
                        createPlugin = "";
                        delPlugin = "";
                        rankPlace = "";
                        rankDelete = "";
                        afterDelete = "";
                        killer = "";
                        special = "";
                        overviewColor = "";
                        RBL = "";
                    }
                    internalID = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line.Contains("=")) {
                    string command = line.Substring(0, line.IndexOf(" "));
                    string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Replace_By_Load":
                            if (blockName == "")
                                 blockName = "--Reserved--";
                            RBL = value;
                            
                             break;
                        case "Name":
                            blockName = value;
                            break;
                        case "On_Client":
                            clientID = value;
                            break;
                        case "Physic":
                            physic = value;
                            break;
                        case "Physic_Plugin":
                            physicPlugin = value;
                            break;
                        case "Do_Time":
                            doTime = value;
                            break;
                        case "Do_Time_Random":
                            doTimeRandom = value;
                            break;
                        case "Do_Repeat":
                            doRepeat = value;
                            break;
                        case "Do_By_Load":
                            dobyLoad = value;
                            break;
                        case "Create_Plugin":
                            createPlugin = value;
                            break;
                        case "Delete_Plugin":
                            delPlugin = value;
                            break;
                        case "Rank_Place":
                            rankPlace = value;
                            break;
                        case "Rank_Delete":
                            rankDelete = value;
                            break;
                        case "After_Delete":
                            afterDelete = value;
                            break;
                        case "Killer":
                            killer = value;
                            break;
                        case "Special":
                            special = value;
                            break;
                        case "Color_Overview":
                            overviewColor = value;
                            break;
                    }
                } else { continue; }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            blocks.Add(new Block(internalID, blockName, clientID, physic, physicPlugin, doTime, doTimeRandom, doRepeat, dobyLoad, createPlugin, delPlugin, rankPlace, rankDelete, afterDelete, killer, special, overviewColor));
            lstBlock.Items.Clear();

            foreach (Block b in blocks) {
                lstBlock.Items.Add(b.blockName);
            }
        }
        private void loadMaps() {
            // -- This loads Data\Map_List.txt to get all loaded maps
            // -- Then loads them into the GUI.
            maps = new List<Map>();
            StreamReader fileReader = new StreamReader("Data\\Map_List.txt");
            string line = "";
            string ID = "";
            string name = "";
            string dir = "";
            string del = "";
            string reload = "";

            do {
                line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line.StartsWith("[") && line.Contains("]")) {
                    if (ID != "") {
                        maps.Add(new Map(ID,name,dir,del,reload));
                    }
                    ID = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line.Contains("=")) {
                    string command = line.Substring(0, line.IndexOf(" "));
                    string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Name":
                            name = value;
                            break;
                        case "Directory":
                            dir = value;
                            break;
                        case "Delete":
                            del = value;
                            break;
                        case "Reload":
                            reload = value;
                            break;
                    }
                } else { continue; }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            maps.Add(new Map(ID, name, dir, del, reload));
            lstMaps.Items.Clear();

            foreach (Map m in maps) {
                lstMaps.Items.Add(m.mapName);
                loadMapConfig(m);
            }
            btnUnloadMap.Enabled = false;
            btnDeleteMap.Enabled = false;
            btnRenameMap.Enabled = false;
            btnRegenMap.Enabled = false;
            btnRegenPrev.Enabled = false;
            btnMapRez.Enabled = false;
        }
        private void loadMapConfig(Map map) {
            StreamReader fileReader = new StreamReader(map.mapDirectory + "Config.txt");
            string line = "";
            do {
                line = fileReader.ReadLine();

                if (line.Contains("=")) {
                    string command = line.Substring(0, line.IndexOf(" "));
                    string value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Server_Version":
                            map.mapVersion = value;
                            break;
                        case "Unique_ID":
                            map.uniqueID = value;
                            break;
                        case "Rank_Build":
                            map.rankBuild = value;
                            break;
                        case "Rank_Join":
                            map.rankJoin = value;
                            break;
                        case "Rank_Show":
                            map.rankShow = value;
                            break;
                        case "Physic_Stopped":
                            map.physics = value;
                            break;
                        case "MOTD_Override":
                            map.motd = value;
                            break;
                        case "Save_Intervall":
                            map.saveInt = value;
                            break;
                        case "Overview_Type":
                            map.Overview = value;
                            break;
                        case "Size_X":
                            map.size_x = value;
                            break;
                        case "Size_Y":
                            map.size_y = value;
                            break;
                        case "Size_Z":
                            map.size_z = value;
                            break;
                        case "Spawn_X":
                            map.spawnx = value;
                            break;
                        case "Spawn_Y":
                            map.spawny = value;
                            break;
                        case "Spawn_Z":
                            map.spawnz = value;
                            break;
                        case "Spawn_Rot":
                            map.spawnrot = value;
                            break;
                        case "Spawn_Look":
                            map.spawnlook = value;
                            break;
                    }
                } else { continue; }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
        }
        private void saveMapSettings(Map map) {
            StreamWriter sw = new StreamWriter(map.mapDirectory + "/Config.txt");
            sw.WriteLine("Server_Version = " + map.mapVersion);
            sw.WriteLine("Unique_ID = " + map.uniqueID);
            sw.WriteLine("Name = " + map.mapName);
            sw.WriteLine("Rank_Build = " + map.rankBuild);
            sw.WriteLine("Rank_Join = " + map.rankJoin);
            sw.WriteLine("Rank_Show = " + map.rankShow);
            sw.WriteLine("Physic_Stopped = " + map.physics);
            sw.WriteLine("MOTD_Override = " + map.motd);
            sw.WriteLine("Save_Intervall = " + map.saveInt);
            sw.WriteLine("Overview_Type = " + map.Overview);
            sw.WriteLine("Size_X = " + map.size_x);
            sw.WriteLine("Size_Y = " + map.size_y);
            sw.WriteLine("Size_Z = " + map.size_z);
            sw.WriteLine("Spawn_X = " + map.spawnx);
            sw.WriteLine("Spawn_Y = " + map.spawny);
            sw.WriteLine("Spawn_Z = " + map.spawnz);
            sw.WriteLine("Spawn_Rot = " + map.spawnrot);
            sw.WriteLine("Spawn_Look = " + map.spawnlook);
            sw.Close();
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
            if (cSettings[6] == true)
                message = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "]" + message;

            boxFiltered.Text += message + Environment.NewLine;
            boxFiltered.Select(boxFiltered.Text.Length, boxFiltered.Text.Length);
            boxFiltered.ScrollToCaret();
        }
        private void addButton(string name, string file) {
            if (cButtons == null)
                cButtons = new Dictionary<string, string>();

            if (cButtons.Keys.Contains(name))
                return;

            cButtons.Add(name, file); // -- for tracking purposes..

            Button newButton = new Button();
            newButton.Text = name;
            newButton.Location = new Point(curX, curY);
            newButton.Size = new Size(110, 23);
            newButton.Click += new EventHandler(handleButtons);
            newButton.Visible = true;
            newButton.Enabled = true;
            newButton.BringToFront();
            this.Controls.Add(newButton);
            tabPage9.Controls.Add(newButton);

            if (curY == 235) {
                curY = 3;
                if (curX == 583) {
                    MessageBox.Show("That's a lot of LUAS, you've reached the limit!");
                    return;
                }
                curX += 116;
            } else {
                curY += 29;
            }
        }
        private void handleButtons(object sender, EventArgs e) {
            Button clicked = (Button)sender;

            string fileName = "";
            cButtons.TryGetValue(clicked.Text, out fileName);

            if (fileName == "") {
                MessageBox.Show("An error has occured.");
                return;
            }
            if (removing == true) {
                removing = false;
                RegistryControl rc = new RegistryControl();
                string oldString = (string)rc.GetSetting("SH", "D3 GUI", "luas", "");
                oldString = oldString.Replace(clicked.Text + "," + fileName + "|", "");
                rc.SaveSetting("SH", "D3 GUI", "luas", oldString);
                this.Controls.Remove(clicked);
                tabPage9.Controls.Remove(clicked);
                clicked.Dispose();
                return;
            }

            File.SetLastWriteTime(fileName, DateTime.Now);
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
            loadRanks();
            loadCommands();
            loadBlocks();
            loadMaps();
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
            StreamWriter sw = new StreamWriter("Lua\\GUI_Control.lua"); // -- Clear our lua so stuff doesn't run at startup.
            sw.Write("");
            sw.Close();
        }
        #endregion
        #region Text Changed
        private void lstMaps_SelectedIndexChanged(object sender, EventArgs e) {
            btnUnloadMap.Enabled = true;
            btnDeleteMap.Enabled = true;
            btnRenameMap.Enabled = true;
            btnRegenMap.Enabled = true;
            btnRegenPrev.Enabled = true;
            btnMapRez.Enabled = true;

            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    boxBuildRank.Text = m.rankBuild;
                    boxJoinRank.Text = m.rankJoin;
                    boxVisrank.Text = m.rankShow;
                    numInterval.Value = decimal.Parse(m.saveInt);

                    if (m.physics == "0")
                        dropPhysStop.SelectedIndex = 1;
                    else
                        dropPhysStop.SelectedIndex = 0;

                    if (m.Overview == "0")
                        dropOverType.SelectedIndex = 0;
                    else if (m.Overview == "1")
                        dropOverType.SelectedIndex = 1;
                    else
                        dropOverType.SelectedIndex = 2;

                    picOverview.Image = m.preview;
                    //FileStream fs = new FileStream(m.mapDirectory + "/Overview.png", FileMode.Open, FileAccess.Read);
                    //MemoryStream ms = new MemoryStream();
                    //fs.CopyTo(ms);
                    //ms.Seek(0, SeekOrigin.Begin);
                    //picOverview.Image = Image.FromStream(ms);
                    //fs.Close();
                    //ms.Close();
                    //picOverview.Image = Image.FromFile(m.mapDirectory + "/Overview.png");  // -- This kept the file open and caused the saves to fail.

                }
            }
        }


        private void boxBuildRank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Set_Rank_Build(" + thisMap.mapID + ", " + boxBuildRank.Text + ")");
            fileWriter.Close();
        }


        private void boxJoinRank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Set_Rank_Join(" + thisMap.mapID + ", " + boxJoinRank.Text + ")");
            fileWriter.Close();
        }

        private void boxVisrank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            StreamWriter fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Set_Rank_Show(" + thisMap.mapID + ", " + boxVisrank.Text + ")");
            fileWriter.Close();
        }

        private void dropOverType_SelectedIndexChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            if ((string)dropOverType.SelectedItem == "ISO") {
                thisMap.Overview = "2";
            } else if ((string)dropOverType.SelectedItem == "2D") {
                thisMap.Overview = "1";
            } else {
                thisMap.Overview = "0";
            }
            saveMapSettings(thisMap);
        }

        private void dropPhysStop_SelectedIndexChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            if ((String)dropPhysStop.SelectedItem == "Yes") {
                thisMap.physics = "1";
            } else {
                thisMap.physics = "0";
            }
            saveMapSettings(thisMap);
        }

        private void numInterval_ValueChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (Map m in maps) {
                if (m.mapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            thisMap.saveInt = Convert.ToInt32(numInterval.Value).ToString();
            saveMapSettings(thisMap);
        }
        private void dropRepPhys_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    if ((string)dropRepPhys.SelectedItem == "Yes")
                        b.doRepeat = "1";
                    else
                        b.doRepeat = "0";
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e) {
            colorDialog1.Color = picOColor.BackColor;
            DialogResult d = colorDialog1.ShowDialog();
            if (d == System.Windows.Forms.DialogResult.OK) {
                Color newColor = colorDialog1.Color;
                picOColor.BackColor = newColor;
                int decValue = newColor.B;
                string hex = "";
                hex += string.Format("{0:x}", decValue).PadLeft(2, '0');
                decValue = newColor.G; hex += string.Format("{0:x}", decValue).PadLeft(2, '0');
                decValue = newColor.R; hex += string.Format("{0:x}", decValue).PadLeft(2, '0');

                long d3Number = Convert.ToInt64(hex, 16);
                foreach (Block b in blocks) {
                    if (b.blockName == (string)lstBlock.SelectedItem) {
                        b.overviewColor = d3Number.ToString();
                        break;
                    }
                }
            }

        }

        private void lstBlock_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    lblIID.Text = "Internal ID: " + b.internalID;
                    boxBName.Text = b.blockName;
                    boxBID.Text = b.clientID;

                    if (b.overviewColor == "-1") {
                        chkTransparent.Checked = true;
                        picOColor.BackColor = Color.FromKnownColor(KnownColor.Control);
                    } else {
                        chkTransparent.Checked = false;
                        string hexValue = int.Parse(b.overviewColor).ToString("X"); // Swap last, with the center.
                        hexValue = hexValue.PadLeft(6, '0');
                        hexValue = hexValue.Substring(4, 2) + hexValue.Substring(2, 2) + hexValue.Substring(0, 2);

                        Color oColor = ColorTranslator.FromHtml("#" + hexValue);
                        picOColor.BackColor = oColor;
                    }

                    boxCPlugin.Text = b.createPlugin;
                    boxDPlugin.Text = b.delPlugin;
                    boxRankPlace.Text = b.rankPlace;
                    boxRankDelete.Text = b.rankDelete;

                    if (b.killer == "1")
                        dropKills.SelectedIndex = 0;
                    else
                        dropKills.SelectedIndex = 1;

                    if (b.special == "1")
                        dropSpecial.SelectedIndex = 0;
                    else
                        dropSpecial.SelectedIndex = 1;

                    switch (b.physic) {
                        case "0":
                            dropPhysics.SelectedIndex = 0;
                            break;
                        case "10":
                            dropPhysics.SelectedIndex = 1;
                            break;
                        case "11":
                            dropPhysics.SelectedIndex = 2;
                            break;
                        case "20":
                            dropPhysics.SelectedIndex = 3;
                            break;
                        case "21":
                            dropPhysics.SelectedIndex = 4;
                            break;
                    }

                    boxPDelay.Text = b.doTime;
                    boxPhysRand.Text = b.doTimeRandom;

                    if (b.doRepeat == "1")
                        dropRepPhys.SelectedIndex = 0;
                    else
                        dropRepPhys.SelectedIndex = 1;

                    boxPPlugin.Text = b.physicPlugin;

                    if (b.dobyLoad == "1")
                        dropMaploadPhys.SelectedIndex = 0;
                    else
                        dropMaploadPhys.SelectedIndex = 1;
                }
            }
        }

        private void boxBName_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.blockName = boxBName.Text;
                    if (b.blockName != (string)lstBlock.SelectedItem) {
                        lstBlock.Items.Clear();
                        foreach (Block c in blocks) {
                            lstBlock.Items.Add(c.blockName);
                        }
                        lstBlock.SelectedItem = b.blockName;
                        break;
                    }
                }
            }
        }

        private void boxBID_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.clientID = boxBID.Text;
                    break;
                }
            }
        }

        private void boxCPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.createPlugin = boxCPlugin.Text;
                    break;
                }
            }
        }

        private void chkTransparent_CheckedChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    if (b.overviewColor != "-1" && chkTransparent.Checked == true) {
                        b.overviewColor = "-1";
                    }
                    break;
                }
            }
        }

        private void boxDPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.delPlugin = boxDPlugin.Text;
                    break;
                }
            }
        }

        private void boxRankPlace_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.rankPlace = boxRankPlace.Text;
                    break;
                }
            }
        }

        private void boxRankDelete_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.rankDelete = boxRankDelete.Text;
                    break;
                }
            }
        }

        private void dropKills_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    if ((string)dropKills.SelectedItem == "Yes")
                        b.killer = "1";
                    else
                        b.killer = "0";
                }
            }
        }

        private void dropSpecial_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    if ((string)dropSpecial.SelectedItem == "Yes")
                        b.special = "1";
                    else
                        b.special = "0";
                }
            }
        }

        private void dropPhysics_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    switch ((string)dropPhysics.SelectedItem) {
                        case "No Physics":
                            b.physic = "0";
                            break;
                        case "Original Sand (Falling)":
                            b.physic = "10";
                            break;
                        case "New Sand":
                            b.physic = "11";
                            break;
                        case "Infinite Water":
                            b.physic = "20";
                            break;
                        case "Finite Water":
                            b.physic = "21";
                            break;

                    }
                }
            }
        }

        private void boxPDelay_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.doTime = boxPDelay.Text;
                    break;
                }
            }
        }

        private void boxPhysRand_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.doTimeRandom = boxPhysRand.Text;
                    break;
                }
            }
        }

        private void boxPPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    b.physicPlugin = boxPPlugin.Text;
                    break;
                }
            }
        }

        private void dropMaploadPhys_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (Block b in blocks) {
                if (b.blockName == (string)lstBlock.SelectedItem) {
                    if ((string)dropMaploadPhys.SelectedItem == "Yes")
                        b.dobyLoad = "1";
                    else
                        b.dobyLoad = "0";
                    break;
                }
            }
        }
        private void boxCommand_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.Name = boxCommand.Text;

            if (myCommand.Name != (String)lstCmd.SelectedItem) {
                lstCmd.Items.Clear();
                foreach (Command b in commands) {
                    lstCmd.Items.Add(b.Name);
                }
                lstCmd.SelectedItem = myCommand.Name;
            }
        }

        private void boxCRank_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.rank = boxCRank.Text;
        }

        private void boxShowRank_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.rankShow = boxShowRank.Text;
        }

        private void boxPlugin_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.plugin = boxPlugin.Text;
        }

        private void boxGroup_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.group = boxGroup.Text;
        }

        private void boxDescript_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (Command c in commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.description = boxDescript.Text;
        }

        private void boxRName_TextChanged(object sender, EventArgs e) {
            if (currentRank != null)
                 currentRank.name = boxRName.Text;
        }

        private void boxRPrefix_TextChanged(object sender, EventArgs e) {
            if (currentRank != null)
                currentRank.prefix = boxRPrefix.Text;
        }

        private void chkIsOp_CheckedChanged(object sender, EventArgs e) {

                if (currentRank != null) {
                    if (chkIsOp.Checked)
                        currentRank.onclient = "100";
                    else
                        currentRank.onclient = "0";
                }
        }

        private void boxRank_TextChanged(object sender, EventArgs e) {
            if (currentRank != null)
                currentRank.number = boxRank.Text;
        }
        #endregion

        private void btnSavePreview_Click(object sender, EventArgs e) {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "PNG Image | *.png";
            DialogResult dr = sd.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK) 
                picOverview.Image.Save(sd.FileName);
            
        }
        
        private void tabPage10_Click(object sender, EventArgs e)
        {

        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            Form2 cs = new Form2();
            cs.Show();
        }


    }
}
