using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;

namespace D3_Classicube_Gui {
    public partial class Form1 : Form {
        #region Variables
        #region Map Related
        D3Map _isoMap;
        Map _tempMap;
        #endregion
        #region GUI Related
        Process _serverProc;
        int _curX = 8;
        int _curY = 3;
        bool _mini;
        bool _removing;
        string _tempEid;
        Rank _currentRank;
        MiniForm _mf;
        Dictionary<string, string> _cButtons;
        public bool[] CSettings; // -- 0 = Heartbeat, 1 = Chat, 2 = Command, 3 = Mapsave, 4 = Player login, 5 = LUA Messages 6 = Timestamps
        #endregion
        #region Server Settings
        string _lastHeartbeat = "";
        int _online;
        public string ServerVersion = "1014";
        string _serverName = "";
        string _motd = "";
        string _clickDistance = "";
        string _welcomeMessage = "";
        string _maxPlayers = "0";
        byte _nameVerify;
        string _port = "25565";
        byte _pub;
        List<Rank> _ranks;
        List<Command> _commands;
        List<Block> _blocks;
        List<Map> _maps;
        #endregion
        #endregion
        #region Button Clicks
        #region Main Tab
        private void btnSend_Click(object sender, EventArgs e) {
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.Write("System_Message_Network_Send_2_All(-1, \"&c[Console]&f: " + boxChat.Text + "\")");
            fileWriter.Close();

            PutMessage("[Console]: " + boxChat.Text);
            boxChat.Clear();
        }
        private void button1_Click(object sender, EventArgs e) {
            var tm = new TimedMessages {File = "Data\\Answer.txt"};
            tm.Show();
        }
        private void btnUndo_Click(object sender, EventArgs e) {
            var tm = new TimedMessages {File = "Data\\Undo.txt"};
            tm.Show();
        }
        private void btnStart_Click(object sender, EventArgs e) {
            _serverProc.Start();
            _serverProc.BeginOutputReadLine();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = "ONLINE";
            PutMessage("Server started.");
        }
        private void btnStop_Click(object sender, EventArgs e) {

            _serverProc.Kill();
            _serverProc.CancelOutputRead();
            _serverProc.Close();

            lblStatus.Text = "OFFLINE";
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            // -- Clear players..
            _online = 0;
            lstPlayers.Items.Clear();
            lblHeartbeat.Text = "Last Hearbeat:";

            PutMessage("Server stopped.");
        }
        private void btnLua_Click(object sender, EventArgs e) {
            var luaCommand = Interaction.InputBox("Enter the LUA command to be run", "LUA run");

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.Write(luaCommand);
            fileWriter.Close();

            PutMessage("LUA Command has been run.");
        }
        private void btnTimed_Click(object sender, EventArgs e) {
            var tm = new TimedMessages {File = "Data\\Timed_Messages.txt"};
            tm.Show();
        }
        private void btnFilter_Click(object sender, EventArgs e) {
            var cs = new ConsoleSettings
            {
                Mainform = this,
                chkHeartbeat = {Checked = CSettings[0]},
                chkChat = {Checked = CSettings[1]},
                chkCommands = {Checked = CSettings[2]},
                chkMapSave = {Checked = CSettings[3]},
                chkPlayers = {Checked = CSettings[4]},
                chkLua = {Checked = CSettings[5]},
                chkTimes = {Checked = CSettings[6]}
            };

            cs.Show();
        }
        private void btnMini_Click(object sender, EventArgs e) {
            _mf = new MiniForm
            {
                lblMotd = {Text = _motd},
                lblName = {Text = _serverName},
                lblOnline = {Text = _online + "/" + _maxPlayers},
                lblPublic = {Text = _pub.ToString()},
                lblVerify = {Text = _nameVerify.ToString()},
                lblHeartbeat = {Text = _lastHeartbeat},
                Mainform = this
            };

            _mini = true;
            _mf.Show();
            Hide();
        }
        private void btnTray_Click(object sender, EventArgs e) {
            Hide();
            notifyIcon1.Visible = true;
        }
        private void btnSave_Click(object sender, EventArgs e) {
            SaveSettings();
        }
        #endregion
        #region Custom Luas Tab
        private void btnAddLua_Click(object sender, EventArgs e) {
            var fileName = "";
            var p = MessageBox.Show("Would you like to create a new script, or run an existing one? Yes for new.", "New LUA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (p == DialogResult.Cancel)
                return;

            if (p == DialogResult.Yes) {
                var newFile = new SaveFileDialog
                {
                    InitialDirectory = _serverProc.StartInfo.WorkingDirectory + "\\Lua\\",
                    Filter = "Lua Scripts | *.lua"
                };

                newFile.ShowDialog();
                fileName = newFile.FileName;

                var sNewFile = new StreamWriter(newFile.FileName);
                sNewFile.Write(" ");
                sNewFile.Close();

                if (fileName == "")
                    return;
            }
            if (p == DialogResult.No) {
                var newFile = new OpenFileDialog
                {
                    InitialDirectory = _serverProc.StartInfo.WorkingDirectory + "\\Lua\\",
                    Filter = "Lua Scripts | *.lua"
                };

                newFile.ShowDialog();
                fileName = newFile.FileName;

                if (fileName == "")
                    return;
            }
            var buttonName = Interaction.InputBox("Please give a name for the custom button", "Adding LUA");

            if (buttonName == "")
                return;

            var thisresult = MessageBox.Show("Would you like to edit the file now?", "Lua Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (thisresult == DialogResult.Yes) {
                var tm = new TimedMessages {File = fileName};
                tm.Show();
            }

            SettingsReader rc;

            if (!File.Exists("GUI.ini"))
                rc = new SettingsReader("GUI.ini", true);
            else {
                rc = new SettingsReader("GUI.ini");
                rc.ReadSettings();
            }

            var oldButtons = "";

            if (rc.Settings.ContainsKey("luas"))
                oldButtons = rc.Settings["luas"];
            

            oldButtons += buttonName + "," + fileName + "|";
            rc.Settings["luas"] = oldButtons;

            rc.SaveSettings();

            AddButton(buttonName, fileName);
        }
        private void btnDelLua_Click(object sender, EventArgs e) {
            _removing = true;
            MessageBox.Show("Click the button you want to remove.");
        }
        #endregion
        #region Ranks Tab
        private void btnSaveRanks_Click(object sender, EventArgs e) {
            //blocks = blocks.OrderBy(x => int.Parse(x.internalID)).ToList();
            _ranks = _ranks.OrderBy(x => int.Parse(x.Number)).ToList();
            SaveRanks();
            LoadRanks();
        }
        private void btnRevert_Click(object sender, EventArgs e) {
            LoadRanks();
        }
        private void btnAddRank_Click(object sender, EventArgs e) {
            var initName = Interaction.InputBox("Please provide an initial name for this rank.", "Add rank");

            if (initName == "")
                return;

            var initRank = Interaction.InputBox("Please provide an initial rank number for this rank.", "Add rank", "40");

            if (initRank == "")
                return;

            _ranks.Add(new Rank(initRank, initName, "", ""));
            _ranks = _ranks.OrderBy(x => int.Parse(x.Number)).ToList();
            lstRanks.Items.Clear();

            foreach (var b in _ranks) {
                lstRanks.Items.Add(b.Name);
            }
        }
        private void btnRemRank_Click(object sender, EventArgs e) {
            Rank myrank = null;

            foreach (var b in _ranks) {
                if (b.Name == (string)lstRanks.SelectedItem) {
                    myrank = b;
                    break;
                }
            }

            if (myrank == null)
                return;

            _ranks.Remove(myrank);
            lstRanks.Items.Clear();

            _ranks = _ranks.OrderBy(x => int.Parse(x.Number)).ToList();

            foreach (var b in _ranks) {
                lstRanks.Items.Add(b.Name);
            }
        }
        #endregion
        #region Worlds Tab
        private void btnAddMap_Click(object sender, EventArgs e) {
            var name = Interaction.InputBox("Provide a name for the new map", "New Map");

            if (name == "")
                return;

            var size = Interaction.InputBox("Enter a size for the new map", "New Map", "64,64,64");

            if (size == "")
                return;

            // -- Check if the size is valid
            if (!size.Contains(",")) {
                MessageBox.Show("Incorrect format for map size.");
                return;
            }

            var splits = size.Replace(" ", "").Split(new[] { ',' });

            if (splits.Length != 3) {
                MessageBox.Show("Incorrect format for map size, please provide an X,Y,Z");
                return;
            }

            _maps = _maps.OrderBy(o => o.MapId).ToList();

            // -- Next, get a unique map ID to use..
            var id = 0;

            foreach (var m in _maps)
            {
                if ((m.MapId - id) > 1) {
                    id += 1;
                    break;
                }

                id += 1;
            }

            // -- Generate lua code to make the map, fill it, save it, and resend it.
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Add(" + id + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ", \"" + name + "\")");
            fileWriter.WriteLine("Mapfill_standart(" + id + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ")"); // -- Fill the map to flatgrass for them too :D
            fileWriter.WriteLine("Map_Action_Add_Save(" + id + ", \"\")");
            //fileWriter.WriteLine("Map_Resend(" + id.ToString() + ")");
            fileWriter.Close();
            fileWriter.Dispose();

            LoadMaps();
        }
        private void btnUnloadMap_Click(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");

            if (thisMap != null) 
                fileWriter.WriteLine("Map_Action_Add_Delete(" + thisMap.MapId + ")");

            fileWriter.Close();
            LoadMaps();
        }
        private void btnDeleteMap_Click(object sender, EventArgs e) {
            // -- Unload map and delete its files.
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");

            if (thisMap != null)
            {
                fileWriter.WriteLine("Map_Action_Add_Delete(" + thisMap.MapId + ")");
                fileWriter.Close();
                Directory.Delete(thisMap.MapDirectory, true);
            }

            LoadMaps();
        }
        private void btnRenameMap_Click(object sender, EventArgs e) {
            var mapname = Interaction.InputBox("Enter a new name for the map", "Rename map");

            if (mapname == "")
                return;

            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");

            if (thisMap != null)
            {
                fileWriter.WriteLine("Map_Set_Name(" + thisMap.MapId + ", \"" + mapname + "\")");
                fileWriter.Close();
                thisMap.MapName = mapname;
            }

            LoadMaps();
        }
        private void btnRegenPrev_Click(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");

            if (thisMap != null)
            {
                fileWriter.WriteLine("Map_Action_Add_Save(" + thisMap.MapId + ")");
                fileWriter.Close();

                Thread.Sleep(3000); // -- Attempt to prevent map resizing..


                var mymap = new D3Map();
                mymap.ReadConfig(thisMap.MapDirectory + "\\Config.txt");
                mymap.LoadBlockColors("Data\\Block.txt");
                mymap.Unzip(thisMap.MapDirectory + "\\Data-Layer.gz");





                if ((string)dropOverType.SelectedItem == "ISO") {
                    var mgen = new Thread(mymap.generate_iso);
                    mgen.Start();
                } else if ((string)dropOverType.SelectedItem == "2D") {
                    var mapGen = new Thread(mymap.generate_Heightmap); // -- Only 2d requires Heightmap
                    mapGen.Start();
                    mapGen.Join(2000);

                    var mgen = new Thread(mymap.generate_2D);
                    mgen.Start();
                } else {
                    MessageBox.Show("Please select and overview type.");
                    return;
                }
                _isoMap = mymap;
                _tempMap = thisMap;
            }
            lblGen.Text = "Generating...";
            var wait = new Thread(Waiter);
            wait.Start();

        }

        private void Waiter() {
            while (_isoMap.GeneratedImage == null) {
            }

            picOverview.Image = _isoMap.GeneratedImage;
            lblGen.Text = "Generated in " + _isoMap.Time2D + _isoMap.Time3D + "s";
            _isoMap.Time2D = "";
            _isoMap.Time3D = "";
            _tempMap.Preview = _isoMap.GeneratedImage;
            _tempMap = null;
            GC.Collect();
        }
        private void btnMapRez_Click(object sender, EventArgs e) {
            var size = Interaction.InputBox("Enter a new size for the map", "Map Resize", "64,64,64");
            if (size == "")
                return;
            // -- Check if the size is valid
            if (!size.Contains(",")) {
                MessageBox.Show("Incorrect format for map size.");
                return;
            }
            var splits = size.Replace(" ", "").Split(new[] { ',' });
            if (splits.Length != 3) {
                MessageBox.Show("Incorrect format for map size, please provide an X,Y,Z");
                return;
            }

            Map thisMap = null;
            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");

            if (thisMap != null)
                fileWriter.WriteLine("Map_Action_Add_Resize(" + thisMap.MapId + ", " + splits[0] + ", " + splits[1] + ", " + splits[2] + ")");

            fileWriter.Close();
        }

        private void btnMapReloads_Click(object sender, EventArgs e) {
            LoadMaps();
        }

        private void btnRegenMap_Click(object sender, EventArgs e) {
            var args = Interaction.InputBox("Please enter any additional arguments you would like to pass to the map generator (if supported)", "Mapfill");
            Map thisMap = null;
            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            if (thisMap != null)
            {
                fileWriter.WriteLine("Map_Action_Add_Fill(" + thisMap.MapId + ", \"" + (string)dropMapGen.SelectedItem + "\", \"" + args + "\")");
                fileWriter.WriteLine("System_Message_Network_Send_2_All(" + thisMap.MapId + ", \"Map filled from console.\")");
            }
            fileWriter.Close();
        }
        private void btnSavePreview_Click(object sender, EventArgs e) {
            var sd = new SaveFileDialog();
            sd.Filter = "PNG Image | *.png";
            var dr = sd.ShowDialog();

            if (dr == DialogResult.OK)
                picOverview.Image.Save(sd.FileName);

        }
        #endregion
        #region Commands Tab
        private void btnCSave_Click(object sender, EventArgs e) {
            var sw = new StreamWriter("Data\\Command.txt");

            foreach (var c in _commands) {
                sw.WriteLine("[" + c.InternalName + "]");
                sw.WriteLine("Name = " + c.Name);
                sw.WriteLine("Rank = " + c.Rank);
                sw.WriteLine("Rank_Show = " + c.RankShow);
                sw.WriteLine("Plugin = " + c.Plugin);
                sw.WriteLine("Group = " + c.Group);
                sw.WriteLine("Description = " + c.Description);
                sw.WriteLine("");
            }

            sw.Close();
        }
        private void btnCRevert_Click(object sender, EventArgs e) {
            LoadCommands();
        }
        private void btnAddCom_Click(object sender, EventArgs e) {
            var iName = Interaction.InputBox("What is the internal name for this command?", "Internal");
            var name = Interaction.InputBox("What will be the command that players use to activate this command?", "Command");
            var newC = new Command(iName, name, "0", "0", "", "", "");

            _commands.Add(newC);
            lstCmd.Items.Clear();

            foreach (var b in _commands) {
                lstCmd.Items.Add(b.Name);
            }
        }
        private void btnRemCom_Click(object sender, EventArgs e) {
            var selected = (string)lstCmd.SelectedItem;

            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == selected) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;

            _commands.Remove(myCommand);

            lstCmd.Items.Clear();
            foreach (var b in _commands) {
                lstCmd.Items.Add(b.Name);
            }
        }
        #endregion
        #region Blocks Tab
        private void pictureBox2_Click(object sender, EventArgs e) {
            colorDialog1.Color = picOColor.BackColor;
            var d = colorDialog1.ShowDialog();
            if (d == DialogResult.OK) {
                var newColor = colorDialog1.Color;
                picOColor.BackColor = newColor;
                int decValue = newColor.B;
                var hex = "";
                hex += string.Format("{0:x}", decValue).PadLeft(2, '0');
                decValue = newColor.G; hex += string.Format("{0:x}", decValue).PadLeft(2, '0');
                decValue = newColor.R; hex += string.Format("{0:x}", decValue).PadLeft(2, '0');

                var d3Number = Convert.ToInt64(hex, 16);
                foreach (var b in _blocks) {
                    if (b.BlockName == (string)lstBlock.SelectedItem) {
                        b.OverviewColor = d3Number.ToString();
                        break;
                    }
                }
                chkTransparent.Checked = false;
            }

        }
        private void btnBSave_Click(object sender, EventArgs e) {
            var sw = new StreamWriter("Data\\Block.txt");
            foreach (var b in _blocks) {
                if (b.BlockName != "--Reserved--") {
                    sw.WriteLine("[" + b.InternalId + "]");
                    sw.WriteLine("Name = " + b.BlockName);
                    sw.WriteLine("On_Client = " + b.ClientId);
                    sw.WriteLine("Physic = " + b.Physic);
                    sw.WriteLine("Physic_Plugin = " + b.PhysicPlugin);
                    sw.WriteLine("Do_Time = " + b.DoTime);
                    sw.WriteLine("Do_Time_Random = " + b.DoTimeRandom);
                    sw.WriteLine("Do_Repeat = " + b.DoRepeat);
                    sw.WriteLine("Do_By_Load = " + b.DobyLoad);
                    sw.WriteLine("Create_Plugin = " + b.CreatePlugin);
                    sw.WriteLine("Delete_Plugin = " + b.DelPlugin);
                    sw.WriteLine("Rank_Place = " + b.RankPlace);
                    sw.WriteLine("Rank_Delete = " + b.RankDelete);
                    sw.WriteLine("After_Delete = " + b.AfterDelete);
                    sw.WriteLine("Killer = " + b.Killer);
                    sw.WriteLine("Special = " + b.Special);
                    sw.WriteLine("Color_Overview = " + b.OverviewColor);

                    if (!string.IsNullOrEmpty(b.Rbl))
                        sw.WriteLine("Replace_By_Load = " + b.Rbl);

                    if (!string.IsNullOrEmpty(b.CpeLevel))
                        sw.WriteLine("CPE_Level = " + b.CpeLevel);

                    if (!string.IsNullOrEmpty(b.CpeReplace))
                        sw.WriteLine("CPE_Replace = " + b.CpeReplace);

                    sw.WriteLine("");
                } else {
                    sw.WriteLine("[" + b.InternalId + "]");
                    sw.WriteLine("Replace_By_Load = " + b.Rbl);
                    sw.WriteLine("");
                }
            }
            sw.Close();
        }
        private void btnBRevert_Click(object sender, EventArgs e) {
            LoadBlocks();
        }
        private void btnAddBlock_Click(object sender, EventArgs e) {
            var blockName = Interaction.InputBox("Please enter a name for the new block.", "New block");

            if (blockName == "")
                return;
            // First need to find a new ID to use on the server for this block.
            var internalId = 0;
            var broke = false;

            foreach (var b in _blocks)
            {
                if (int.Parse(b.InternalId) - internalId > 1) {
                    internalId += 1;
                    broke = true;
                    break;
                }

                internalId += 1;
            }
            if (!broke)
                internalId += 1;

            var newBlock = new Block(internalId.ToString(), blockName, "0", "0", "", "0", "0", "0", "0", "", "", "0", "0", "0", "0", "0", "-1");
            _blocks.Add(newBlock);
            _blocks = _blocks.OrderBy(x => int.Parse(x.InternalId)).ToList();
            lstBlock.Items.Clear();

            foreach (var b in _blocks) {
                lstBlock.Items.Add(b.BlockName);
            }

        }
        private void btnRemBlock_Click(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            Block myblock = null;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    myblock = b;
                    break;
                }
            }
            if (myblock != null) {
                _blocks.Remove(myblock);
                lstBlock.Items.Clear();
                foreach (var b in _blocks) {
                    lstBlock.Items.Add(b.BlockName);
                }
            }
        }
        #endregion
        #region About Tab
        private void button1_Click_1(object sender, EventArgs e) {
            Process.Start("http://umby.d3s.co/CCD3/index.php?page=lua");
        }
        #endregion
        #region Menu Strips
        // -- Notify Icon..
        private void bShowToolStripMenuItem_Click(object sender, EventArgs e) {
            Show();
            notifyIcon1.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
            notifyIcon1.Visible = false;
        }
        // -- Players Right Click Context menu
        private void setRankToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var answer = Interaction.InputBox("What rank do you wish to set this player to? (-32767-32767)", "Set Rank", "100");
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Set_Rank(Entity_Get_Player(Client_Get_Entity(" + eid + ")), " + answer + ")");
            fileWriter.Close();
        }
        private void kickToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var answer = Interaction.InputBox("Please enter a kick message", "Kick Player", "Kicked by Console");
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Kick(Entity_Get_Player(Client_Get_Entity(" + eid + ")), \"" + answer + "\", 1, 1, 1)");
            fileWriter.Close();
        }
        private void banToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var answer = Interaction.InputBox("Please enter a ban message", "Ban Player", "Banned by Console");
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Ban(Entity_Get_Player(Client_Get_Entity(" + eid + ")), \"" + answer + "\")");
            fileWriter.Close();
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var answer = Interaction.InputBox("Please enter a reason for stopping this player.", "Stop Player", "Stopped by Console");
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Stop(Entity_Get_Player(Client_Get_Entity(" + eid + ")), \"" + answer + "\")");
            fileWriter.Close();
        }
        private void unstopToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Unstop(Entity_Get_Player(Client_Get_Entity(" + eid + ")))");
            fileWriter.Close();
        }
        private void muteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var answer = Interaction.InputBox("Please enter a duration to mute in minutes (0 for indefinate)", "Mute Player", "30");
            var answer2 = Interaction.InputBox("Please enter a mute message", "Mute Player", "Muted by Console");
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Mute(Entity_Get_Player(Client_Get_Entity(" + eid + ")), " + answer + ", \"" + answer2 + "\")");
            fileWriter.Close();
        }
        private void unmuteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstPlayers.SelectedItem == null)
                return;

            var selected = lstPlayers.SelectedItem.ToString();
            var eid = selected.Substring(selected.IndexOf(":") + 1, selected.Length - (selected.IndexOf(":") + 1));

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Player_Unmute(Entity_Get_Player(Client_Get_Entity(" + eid + ")))");
            fileWriter.Close();
        }
        #endregion
        #endregion
        #region Helping Functions
        private void FilterMessage(string message) {
            if (message == null)
                return;

            var parts = message.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            if (!(parts.Length > 3))
                return;

            boxConsole.Text += parts[2] + ": " + parts[3] + Environment.NewLine;
            boxConsole.Select(boxConsole.Text.Length, boxConsole.Text.Length);
            boxConsole.ScrollToCaret();

            
            switch (parts[0].Replace(" ", "")) {
                case "Chat.pbi":
                    if ((parts[1].Replace(" ", "") == "45"  || parts[1].Replace(" ","") == "75") && CSettings[1]) {
                        PutMessage(parts[3]);
                    }
                    break;
                case "Heartbeat.pb":
                    if (CSettings[0]) {
                        PutMessage("Heartbeat Sent.");
                    }

                    _lastHeartbeat = DateTime.Now.Hour.ToString().PadLeft(2,'0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2,'0') + ":" + DateTime.Now.Second.ToString().PadLeft(2,'0');
                    lblHeartbeat.Text = "Last Heartbeat: " + _lastHeartbeat;

                    if (_mini) {
                        _mf.lblHeartbeat.Text = _lastHeartbeat;
                    }
                    break;
                case "Map.pbi":
                    if (parts[1].Replace(" ", "") == "748" && CSettings[3]) { // 
                        PutMessage(parts[3]);
                    }

                    break;
                case "Command.pbi":
                    if (parts[1].Replace(" ", "") == "2225" && CSettings[2]) {
                        PutMessage(parts[3]);
                    }

                    break;
                case "Client.pbi":
                    if ((parts[1].Replace(" ", "") == "114" || parts[1].Replace(" ", "") == "164") && CSettings[4]) {
                        var name = parts[3].Substring(parts[3].IndexOf("'") + 1, parts[3].IndexOf("'",parts[3].IndexOf("'") + 1) - (parts[3].IndexOf("'") + 1));

                        if (parts[3].Contains("logged in")) {
                            PutMessage(name + " logged in.");
                            lstPlayers.Items.Add(name + ":" + _tempEid);
                            _online += 1;
                        } else {
                            PutMessage(name + " logged out.");
                            _tempEid = name;
                            if (lstPlayers.Items.Contains(name + ":" + _tempEid)) {
                                lstPlayers.Items.Remove(name + ":" + _tempEid);
                                _tempEid = name;
                                _online -= 1;
                            }
                        }
                        lblPlayers.Text = "Players: " + lstPlayers.Items.Count;

                        if (_mini) {
                            _mf.lblOnline.Text = _online + "/" + _maxPlayers;
                        }
                    }
                    break;
                case "Network.pbi":
                    if (parts[1].Replace(" ", "") == "84") {
                        PutMessage("WARNING: Unable to start server networking! Make sure there are no port conflicts.");
                    }
                    if (parts[1].Replace(" ", "") == "235") {
                        var entityId = parts[3].Substring(parts[3].IndexOf("ID:") + 3, parts[3].Length - (parts[3].IndexOf("ID:") + 3));
                        entityId = entityId.Substring(0, entityId.IndexOf(","));
                        _tempEid = entityId.Replace(" ","");
                    }
                    if (parts[1].Replace(" ", "") == "252") {
                        var entityId = parts[3].Substring(parts[3].IndexOf("ID:") + 3, parts[3].Length - (parts[3].IndexOf("ID:") + 3));
                        entityId = entityId.Substring(0, entityId.IndexOf(","));
                        lstPlayers.Items.Remove(_tempEid + ":" + entityId); // -- Fixed bug
                        _tempEid = entityId.Replace(" ","");
                        lblPlayers.Text = "Players: " + lstPlayers.Items.Count;
                    }
                    break;
                case "Lua.pbi":
                    if (CSettings[5]) {
                        PutMessage("");
                        PutMessage("LUA: " + parts[3]);
                        PutMessage("");
                    }
                    break;
            
            }

        }
        private void LoadSettings() {
            // -- Load settings in from the various .txt files.
            var files = new List<string> { "Data\\System.txt", "Data\\Player.txt", "Data\\Network.txt", "Data\\Heartbeat.txt" };

            foreach (var file in files) {
                var fileReader = new StreamReader(file);

                do {
                    string myLine = fileReader.ReadLine();

                    if (myLine == "")
                        continue;


                    var instruction = myLine.Substring(0, myLine.IndexOf(" "));
                    var data = myLine.Substring(myLine.IndexOf("=") + 2, myLine.Length - (myLine.IndexOf("=") + 2));

                    switch (instruction) {
                        case "Server_Name":
                            _serverName = data;
                            break;
                        case "MOTD":
                            _motd = data;
                            break;
                        case "Click_Distance":
                            _clickDistance = data;
                            break;
                        case "Message_Welcome":
                            _welcomeMessage = data;
                            break;
                        case "Players_Max":
                            _maxPlayers = data;
                            break;
                        case "Name_Verification":
                            _nameVerify = (byte)int.Parse(data);
                            break;
                        case "Port":
                            _port = data;
                            break;
                        case "Public":
                            _pub = (byte)int.Parse(data);
                            break;
                    }
                    
                } while (!fileReader.EndOfStream);
                fileReader.Close();
            }

            boxMax.Text = _maxPlayers;
            boxMOTD.Text = _motd;
            boxSName.Text = _serverName;
            boxLogin.Text = _welcomeMessage;
            boxPort.Text = _port;
            txtClickDistance.Text = _clickDistance;

            chkNameVerif.Checked = BitConverter.ToBoolean(new[] { _nameVerify }, 0);
            chkPub.Checked = BitConverter.ToBoolean(new[] { _pub }, 0);

            // -- Now load settings specific to the GUI.
            byte settings = 62;
            var buttons = "";

            if (File.Exists("GUI.ini")) {
                var sc = new SettingsReader("GUI.ini");
                sc.ReadSettings();
                if (sc.Settings.ContainsKey("Console"))
                    settings = (byte)int.Parse(sc.Settings["Console"]);
                if (sc.Settings.ContainsKey("luas"))
                    buttons = sc.Settings["luas"];
                if (sc.Settings.ContainsKey("server"))
                    ServerVersion = sc.Settings["server"];
            }
            
            CSettings = new[] { Convert.ToBoolean(settings & 0x1), Convert.ToBoolean(settings & 0x2), Convert.ToBoolean(settings & 0x4), Convert.ToBoolean(settings & 0x8), Convert.ToBoolean(settings & 0x10), Convert.ToBoolean(settings & 0x20), Convert.ToBoolean(settings & 0x40) };
            
            // -- Custom buttons...


            if (buttons == "")
                return;

            var splits = buttons.Split(new[] { '|' },StringSplitOptions.RemoveEmptyEntries);

            foreach (var c in splits) {
                var name = c.Substring(0, c.IndexOf(","));
                var fileName = c.Substring(c.IndexOf(",") + 1, c.Length - (c.IndexOf(",") + 1));
                AddButton(name, fileName);
            }

        }
        public void SaveSettings() {
            // -- Save bot settings
            SettingsReader rc;

            if (!File.Exists("GUI.ini"))
                rc = new SettingsReader("GUI.ini", true);
            else {
                rc = new SettingsReader("GUI.ini");
                rc.ReadSettings();
            }

            var settings = new byte[1];
            new BitArray(CSettings).CopyTo(settings, 0);

            if (!rc.Settings.ContainsKey("Console"))
                rc.Settings.Add("Console", settings[0].ToString());
            else
                rc.Settings["Console"] = settings[0].ToString();

            if (!rc.Settings.ContainsKey("server"))
                rc.Settings.Add("server", ServerVersion);
            else
                rc.Settings["server"] = ServerVersion;

            rc.SaveSettings();

            // -- Save server settings.

            var files = new List<string> { "Data\\System.txt", "Data\\Player.txt", "Data\\Network.txt", "Data\\Heartbeat.txt" }; // -- The files the contain GUI configurable items.
            var tempFile = "";

            foreach (var file in files) {
                var fileReader = new StreamReader(file);

                do {
                    string myLine = fileReader.ReadLine();

                    if (myLine == "") {
                        continue;
                    }

                    var instruction = myLine.Substring(0, myLine.IndexOf(" "));

                    switch (instruction) {
                        case "Server_Name":
                            myLine = "Server_Name = " + boxSName.Text;
                            break;
                        case "MOTD":
                            myLine = "MOTD = " + boxMOTD.Text;
                            break;
                        case "Click_Distance":
                            myLine = "Click_Distance = " + txtClickDistance.Text;
                            break;
                        case "Message_Welcome":
                            myLine = "Message_Welcome = " + boxLogin.Text;
                            break;
                        case "Players_Max":
                            myLine = "Players_Max = " + boxMax.Text;
                            break;
                        case "Name_Verification":
                            myLine = "Name_Verification = " + Convert.ToByte(chkNameVerif.Checked);
                            break;
                        case "Port":
                            myLine = "Port = " + boxPort.Text;
                            break;
                        case "Public":
                            myLine = "Public = " + Convert.ToByte(chkPub.Checked);
                            break;
                    }
                    tempFile += myLine + "\n";
                } while (!fileReader.EndOfStream);

                tempFile = tempFile.Substring(0, tempFile.Length - 1); // -- Remove the extra new line.
                fileReader.Close();

                var fileWriter = new StreamWriter(file); // -- Write the settings to file.
                fileWriter.Write(tempFile);
                fileWriter.Close();
                tempFile = "";
            }
            LoadSettings(); // -- Reload the settings so the GUI's variables are all updated accordingly.
        }
        private void LoadRanks() {
            _ranks = new List<Rank>();
            var fileReader = new StreamReader("Data\\Rank.txt");
            var tempRank = "";
            var tempName = "";
            var tempPrefix = "";
            var tempSuffix = "";
            var tempClient = "0";

            do {
                var thisLine = fileReader.ReadLine();

                if (thisLine == "")
                    continue;

                if (thisLine != null && (thisLine.StartsWith("[") && thisLine.Contains("]"))) {
                    if (tempRank != "") {
                        _ranks.Add(new Rank(tempRank, tempName, tempPrefix,tempSuffix, tempClient));
                    }
                    tempRank = thisLine.Substring(1, thisLine.IndexOf("]") - 1);
                    tempSuffix = "";
                } else if (thisLine != null && thisLine.Contains("=")) {
                    var command = thisLine.Substring(0, thisLine.IndexOf(" "));
                    var value = thisLine.Substring(thisLine.IndexOf("=") + 2, thisLine.Length - (thisLine.IndexOf("=") + 2));

                    switch (command) {
                        case "Name":
                            tempName = value;
                            break;
                        case "Prefix":
                            tempPrefix = value;
                            break;
                        case "Suffix":
                            tempSuffix = value;
                            break;
                        case "On_Client":
                            tempClient = value;
                            break;
                    }
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            _ranks.Add(new Rank(tempRank, tempName, tempPrefix, tempSuffix, tempClient));
            lstRanks.Items.Clear();

            foreach (var b in _ranks) {
                lstRanks.Items.Add(b.Name);
            }
        }
        private void SaveRanks() {
            var fileWriter = new StreamWriter("Data\\Rank.txt");

            foreach (var b in _ranks) {
                fileWriter.WriteLine("[" + b.Number + "]");
                fileWriter.WriteLine("Name = " + b.Name);
                fileWriter.WriteLine("Prefix = " + b.Prefix);

                if (b.Suffix != "")
                    fileWriter.WriteLine("Suffix = " + b.Suffix);

                if (b.Onclient == "100")
                    fileWriter.WriteLine("On_Client = 100");
            }

            fileWriter.Close();
        }
        private void LoadCommands() {
            _commands = new List<Command>();
            var fileReader = new StreamReader("Data\\Command.txt");
            var iName = "";
            var name = "";
            var rank = "";
            var rankShow = "";
            var plugin = "";
            var group = "";
            var descrip = "";

            do {
                var line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line != null && (line.StartsWith("[") && line.Contains("]"))) {
                    if (iName != "") {
                        _commands.Add(new Command(iName, name, rank, rankShow, plugin, group, descrip));
                    }
                    iName = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line != null && line.Contains("=")) {
                    var command = line.Substring(0, line.IndexOf(" "));
                    var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

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
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            _commands.Add(new Command(iName, name, rank, rankShow, plugin, group, descrip));
            lstCmd.Items.Clear();

            foreach (var c in _commands) {
                lstCmd.Items.Add(c.Name);
            }
        }
        private void LoadBlocks() {
            _blocks = new List<Block>();
            var fileReader = new StreamReader("Data\\Block.txt");
            var internalId = "";
            var blockName = "";
            var clientId = "";
            var physic = "";
            var physicPlugin = "";
            var doTime = "";
            var doTimeRandom = "";
            var doRepeat = "";
            var dobyLoad = "";
            var createPlugin = "";
            var delPlugin = "";
            var rankPlace = "";
            var rankDelete = "";
            var afterDelete = "";
            var killer = "";
            var special = "";
            var overviewColor = "";
            var rbl = "";
            var cpeLevel = "";
            var cpeReplace = "";

            do {
                var line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line != null && (line.StartsWith("[") && line.Contains("]"))) {
                    if (internalId != "") {
                        if (blockName != "")
                            _blocks.Add(new Block(internalId, blockName, clientId, physic, physicPlugin, doTime, doTimeRandom, doRepeat, dobyLoad, createPlugin, delPlugin, rankPlace, rankDelete, afterDelete, killer, special, overviewColor));
                        if (rbl != "") 
                            _blocks[_blocks.Count - 1].Rbl = rbl;
                        if (cpeLevel != "")
                            _blocks[_blocks.Count - 1].CpeLevel = cpeLevel;

                        if (cpeReplace != "")
                            _blocks[_blocks.Count - 1].CpeReplace = cpeReplace;

                        blockName = "";
                        clientId = "";
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
                        rbl = "";
                        cpeLevel = "";
                        cpeReplace = "";
                    }
                    internalId = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line != null && line.Contains("=")) {
                    var command = line.Substring(0, line.IndexOf(" "));
                    var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Replace_By_Load":
                            if (blockName == "")
                                 blockName = "--Reserved--";
                            rbl = value;
                            
                             break;
                        case "CPE_Level":
                             cpeLevel = value;
                             break;
                        case "CPE_Replace":
                             cpeReplace = value;
                             break;
                        case "Name":
                            blockName = value;
                            break;
                        case "On_Client":
                            clientId = value;
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
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            _blocks.Add(new Block(internalId, blockName, clientId, physic, physicPlugin, doTime, doTimeRandom, doRepeat, dobyLoad, createPlugin, delPlugin, rankPlace, rankDelete, afterDelete, killer, special, overviewColor));
            lstBlock.Items.Clear();

            foreach (var b in _blocks) {
                lstBlock.Items.Add(b.BlockName);
            }
        }
        private void LoadMaps() {
            // -- This loads Data\Map_List.txt to get all loaded maps
            // -- Then loads them into the GUI.
            _maps = new List<Map>();
            var fileReader = new StreamReader("Data\\Map_List.txt");
            var id = "";
            var name = "";
            var dir = "";
            var del = "";
            var reload = "";

            do {
                var line = fileReader.ReadLine();

                if (line == "")
                    continue;

                if (line != null && (line.StartsWith("[") && line.Contains("]"))) {
                    if (id != "") {
                        _maps.Add(new Map(int.Parse(id),name,dir,del,reload));
                    }
                    id = line.Substring(1, line.IndexOf("]") - 1);
                } else if (line != null && line.Contains("=")) {
                    var command = line.Substring(0, line.IndexOf(" "));
                    var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

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
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
            _maps.Add(new Map(int.Parse(id), name, dir, del, reload));
            lstMaps.Items.Clear();

            foreach (var m in _maps) {
                lstMaps.Items.Add(m.MapName);
                loadMapConfig(m);
            }
            btnUnloadMap.Enabled = false;
            btnDeleteMap.Enabled = false;
            btnRenameMap.Enabled = false;
            btnRegenMap.Enabled = false;
            btnRegenPrev.Enabled = false;
            btnMapRez.Enabled = false;
            btnMapSave.Enabled = false;
        }
        private void loadMapConfig(Map map) {
            StreamReader fileReader;
            try {
                 fileReader = new StreamReader(map.MapDirectory + "Config.txt");
            } catch {
                return;
            }

            do
            {
                string line = fileReader.ReadLine();

                if (line.Contains("=")) {
                    var command = line.Substring(0, line.IndexOf(" "));
                    var value = line.Substring(line.IndexOf("=") + 2, line.Length - (line.IndexOf("=") + 2));

                    switch (command) {
                        case "Server_Version":
                            map.MapVersion = value;
                            break;
                        case "Unique_ID":
                            map.UniqueId = value;
                            break;
                        case "Rank_Build":
                            map.RankBuild = value;
                            break;
                        case "Rank_Join":
                            map.RankJoin = value;
                            break;
                        case "Rank_Show":
                            map.RankShow = value;
                            break;
                        case "Physic_Stopped":
                            map.Physics = value;
                            break;
                        case "MOTD_Override":
                            map.Motd = value;
                            break;
                        case "Save_Intervall":
                            map.SaveInt = value;
                            break;
                        case "Overview_Type":
                            map.Overview = value;
                            break;
                        case "Size_X":
                            map.SizeX = value;
                            break;
                        case "Size_Y":
                            map.SizeY = value;
                            break;
                        case "Size_Z":
                            map.SizeZ = value;
                            break;
                        case "Spawn_X":
                            map.Spawnx = value;
                            break;
                        case "Spawn_Y":
                            map.Spawny = value;
                            break;
                        case "Spawn_Z":
                            map.Spawnz = value;
                            break;
                        case "Spawn_Rot":
                            map.Spawnrot = value;
                            break;
                        case "Spawn_Look":
                            map.Spawnlook = value;
                            break;
                    }
                }
            } while (!fileReader.EndOfStream);
            fileReader.Close();
        }
        private void saveMapSettings(Map map) {
            var sw = new StreamWriter(map.MapDirectory + "/Config.txt");
            sw.WriteLine("Server_Version = " + map.MapVersion);
            sw.WriteLine("Unique_ID = " + map.UniqueId);
            sw.WriteLine("Name = " + map.MapName);
            sw.WriteLine("Rank_Build = " + map.RankBuild);
            sw.WriteLine("Rank_Join = " + map.RankJoin);
            sw.WriteLine("Rank_Show = " + map.RankShow);
            sw.WriteLine("Physic_Stopped = " + map.Physics);
            sw.WriteLine("MOTD_Override = " + map.Motd);
            sw.WriteLine("Save_Intervall = " + map.SaveInt);
            sw.WriteLine("Overview_Type = " + map.Overview);
            sw.WriteLine("Size_X = " + map.SizeX);
            sw.WriteLine("Size_Y = " + map.SizeY);
            sw.WriteLine("Size_Z = " + map.SizeZ);
            sw.WriteLine("Spawn_X = " + map.Spawnx);
            sw.WriteLine("Spawn_Y = " + map.Spawny);
            sw.WriteLine("Spawn_Z = " + map.Spawnz);
            sw.WriteLine("Spawn_Rot = " + map.Spawnrot);
            sw.WriteLine("Spawn_Look = " + map.Spawnlook);
            sw.Close();
        }
        private delegate void PHandleMessage(object sender, DataReceivedEventArgs args);
        private void HandleMessage(object sender, DataReceivedEventArgs args) {
            if (InvokeRequired) {
                Invoke(new PHandleMessage(HandleMessage), sender, args);
                return;
            }

            FilterMessage(args.Data);
        }
        private void PutMessage(string message) {
            if (CSettings[6])
                message = "[" + DateTime.Now.Hour + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + "]" + message;

            boxFiltered.Text += message + Environment.NewLine;
            boxFiltered.Select(boxFiltered.Text.Length, boxFiltered.Text.Length);
            boxFiltered.ScrollToCaret();
        }
        private void AddButton(string name, string file) {
            if (_cButtons == null)
                _cButtons = new Dictionary<string, string>();

            if (_cButtons.Keys.Contains(name))
                return;

            _cButtons.Add(name, file); // -- for tracking purposes..

            var newButton = new Button
            {
                Text = name,
                Location = new Point(_curX, _curY),
                Size = new Size(110, 23),
                Visible = true,
                Enabled = true
            };

            newButton.BringToFront();
            newButton.Click += HandleButtons;
            Controls.Add(newButton);
            tabPage9.Controls.Add(newButton);

            if (_curY == 235) {
                _curY = 3;
                if (_curX == 583) {
                    MessageBox.Show("That's a lot of LUAS, you've reached the limit!");
                    return;
                }
                _curX += 116;
            } else {
                _curY += 29;
            }
        }
        private void HandleButtons(object sender, EventArgs e) {
            var clicked = (Button)sender;

            string fileName;
            _cButtons.TryGetValue(clicked.Text, out fileName);

            if (fileName == "") {
                MessageBox.Show("An error has occured.");
                return;
            }
            if (_removing) {
                _removing = false;
                var sc = new SettingsReader("GUI.ini");
                sc.ReadSettings();

                var oldString = "";
                if (sc.Settings.ContainsKey("luas"))
                    oldString = sc.Settings["luas"];

                oldString = oldString.Replace(clicked.Text + "," + fileName + "|", "");
                sc.Settings["luas"] = oldString;
                sc.SaveSettings();

                Controls.Remove(clicked);
                tabPage9.Controls.Remove(clicked);
                clicked.Dispose();
                return;
            }

            if (fileName != null) File.SetLastWriteTime(fileName, DateTime.Now);
        }
        #endregion
        #region Form Events
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            if (!File.Exists("Minecraft-Server.x86.exe")) {
                MessageBox.Show("Please place in the same folder as your D3 Server.", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            LoadSettings();
            LoadRanks();
            LoadCommands();
            LoadBlocks();
            LoadMaps();
            var psi = new ProcessStartInfo("Minecraft-Server.x86.exe")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                WindowStyle = ProcessWindowStyle.Minimized
            };

            _serverProc = new Process {StartInfo = psi};
            _serverProc.OutputDataReceived += HandleMessage;

            // -- Check for updates
            //var ud = new Updater {MainForm = this};
            //ud.CheckUpdates();
            //ud.CheckUpdatesServer(ServerVersion);
        }
        private void Form1_Closing(object sender, FormClosingEventArgs e) {
            try {
                _serverProc.Kill();
                _serverProc.CancelOutputRead();
                _serverProc.Close();
                _serverProc.Dispose();
            } catch {
                return;
            }
            var sw = new StreamWriter("Lua\\GUI_Control.lua"); // -- Clear our lua so stuff doesn't run at startup.
            sw.Write("");
            sw.Close();
        }
        #endregion
        #region Text Changed
        #region Ranks Tab
        private void boxRName_TextChanged(object sender, EventArgs e) {
            if (_currentRank != null)
                _currentRank.Name = boxRName.Text;
        }
        private void boxRPrefix_TextChanged(object sender, EventArgs e) {
            if (_currentRank != null)
                _currentRank.Prefix = boxRPrefix.Text;
        }
        private void chkIsOp_CheckedChanged(object sender, EventArgs e) {

            if (_currentRank != null) {
                _currentRank.Onclient = chkIsOp.Checked ? "100" : "0";
            }
        }
        private void boxRank_TextChanged(object sender, EventArgs e) {
            if (_currentRank != null)
                _currentRank.Number = boxRank.Text;
        }
        private void boxRSuffix_TextChanged(object sender, EventArgs e) {
            if (_currentRank != null)
                _currentRank.Suffix = boxRSuffix.Text;
        }
        #endregion
        #region Worlds tab
        private void boxBuildRank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap != null) 
                thisMap.RankBuild = boxBuildRank.Text;
        }
        private void boxJoinRank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap != null) 
                thisMap.RankJoin = boxJoinRank.Text;
        }
        private void boxVisrank_TextChanged(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap != null) 
                thisMap.RankShow = boxVisrank.Text;
        }
        private void btnMapSave_Click(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            if (thisMap != null)
            {
                fileWriter.WriteLine("Map_Set_Rank_Build(" + thisMap.MapId + ", " + boxBuildRank.Text + ")");
                fileWriter.WriteLine("Map_Set_Rank_Join(" + thisMap.MapId + ", " + boxJoinRank.Text + ")");
                fileWriter.WriteLine("Map_Set_Rank_Show(" + thisMap.MapId + ", " + boxVisrank.Text + ")");
                fileWriter.WriteLine("Map_Action_Add_Save(" + thisMap.MapId + ", \"" + thisMap.MapDirectory + "\")");
            }
            fileWriter.Close();
        }
        #endregion
        #region Commands Tab
        private void boxCommand_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
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
                foreach (var b in _commands) {
                    lstCmd.Items.Add(b.Name);
                }
                lstCmd.SelectedItem = myCommand.Name;
            }
        }
        private void boxCRank_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.Rank = boxCRank.Text;
        }
        private void boxShowRank_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.RankShow = boxShowRank.Text;
        }
        private void boxPlugin_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.Plugin = boxPlugin.Text;
        }
        private void boxGroup_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.Group = boxGroup.Text;
        }
        private void boxDescript_TextChanged(object sender, EventArgs e) {
            Command myCommand = null;
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    myCommand = c;
                    break;
                }
            }
            if (myCommand == null)
                return;
            myCommand.Description = boxDescript.Text;
        }
        #endregion
        #region Blocks Tab
        private void boxBName_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    b.BlockName = boxBName.Text;
                    if (b.BlockName != (string)lstBlock.SelectedItem) {
                        lstBlock.Items.Clear();
                        foreach (var c in _blocks) {
                            lstBlock.Items.Add(c.BlockName);
                        }
                        lstBlock.SelectedItem = b.BlockName;
                        break;
                    }
                }
            }
        }
        private void boxBID_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    b.ClientId = boxBID.Text;
                    break;
                }
            }
        }
        private void boxCPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    b.CreatePlugin = boxCPlugin.Text;
                    break;
                }
            }
        }
        private void boxDPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    b.DelPlugin = boxDPlugin.Text;
                    break;
                }
            }
        }
        private void boxRankPlace_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;
                b.RankPlace = boxRankPlace.Text;
                break;
            }
        }
        private void boxRankDelete_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;
                b.RankDelete = boxRankDelete.Text;
                break;
            }
        }
        private void boxPDelay_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;
                b.DoTime = boxPDelay.Text;
                break;
            }
        }
        private void boxPhysRand_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;
                b.DoTimeRandom = boxPhysRand.Text;
                break;
            }
        }
        private void boxPPlugin_TextChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;

            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;

                b.PhysicPlugin = boxPPlugin.Text;
                break;
            }
        }

        #endregion
        #region Index Changed
        private void lstMaps_SelectedIndexChanged(object sender, EventArgs e) {
            btnUnloadMap.Enabled = true;
            btnDeleteMap.Enabled = true;
            btnRenameMap.Enabled = true;
            btnRegenMap.Enabled = true;
            btnRegenPrev.Enabled = true;
            btnMapRez.Enabled = true;
            btnMapSave.Enabled = true;

            foreach (var m in _maps) {
                if (m.MapName != (string) lstMaps.SelectedItem) 
                    continue;

                boxBuildRank.Text = m.RankBuild;
                boxJoinRank.Text = m.RankJoin;
                boxVisrank.Text = m.RankShow;
                numInterval.Value = decimal.Parse(m.SaveInt);

                dropPhysStop.SelectedIndex = m.Physics == "0" ? 1 : 0;

                switch (m.Overview)
                {
                    case "0":
                        dropOverType.SelectedIndex = 0;
                        break;
                    case "1":
                        dropOverType.SelectedIndex = 1;
                        break;
                    default:
                        dropOverType.SelectedIndex = 2;
                        break;
                }

                lblMapSize.Text = "Map Size: " + m.SizeX + "x" + m.SizeY + "x" + m.SizeZ;
                picOverview.Image = m.Preview;
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
        private void dropOverType_SelectedIndexChanged(object sender, EventArgs e) {
            Map thisMap = null;

            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap == null)
                return;
            
            switch ((string)dropOverType.SelectedItem)
            {
                case "ISO":
                    thisMap.Overview = "2";
                    break;
                case "2D":
                    thisMap.Overview = "1";
                    break;
                default:
                    thisMap.Overview = "0";
                    break;
            }

            saveMapSettings(thisMap);
        }
        private void dropPhysStop_SelectedIndexChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap == null) 
                return;

            thisMap.Physics = (String)dropPhysStop.SelectedItem == "Yes" ? "1" : "0";
            saveMapSettings(thisMap);
            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Load(" + thisMap.MapId + ", " + thisMap.MapName + ")");
            fileWriter.Close();
        }
        private void numInterval_ValueChanged(object sender, EventArgs e) {
            Map thisMap = null;
            foreach (var m in _maps) {
                if (m.MapName == (string)lstMaps.SelectedItem) {
                    thisMap = m;
                    break;
                }
            }

            if (thisMap == null) 
                return;

            thisMap.SaveInt = Convert.ToInt32(numInterval.Value).ToString();
            saveMapSettings(thisMap);

            var fileWriter = new StreamWriter("LUA\\GUI_Control.lua");
            fileWriter.WriteLine("Map_Action_Add_Load(" + thisMap.MapId + ", " + thisMap.MapName + ")");
            fileWriter.Close();
        }

        private void dropRepPhys_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;

            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    b.DoRepeat = (string)dropRepPhys.SelectedItem == "Yes" ? "1" : "0";
                }
            }

        }

        private void lstBlock_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;

                lblIID.Text = "Internal ID: " + b.InternalId;
                boxBName.Text = b.BlockName;
                boxBID.Text = b.ClientId;

                if (b.OverviewColor == "-1") {
                    chkTransparent.Checked = true;
                    picOColor.BackColor = Color.FromKnownColor(KnownColor.Control);
                } else {
                    chkTransparent.Checked = false;
                    var hexValue = int.Parse(b.OverviewColor).ToString("X"); // Swap last, with the center.
                    hexValue = hexValue.PadLeft(6, '0');
                    hexValue = hexValue.Substring(4, 2) + hexValue.Substring(2, 2) + hexValue.Substring(0, 2);

                    var oColor = ColorTranslator.FromHtml("#" + hexValue);
                    picOColor.BackColor = oColor;
                }

                boxCPlugin.Text = b.CreatePlugin;
                boxDPlugin.Text = b.DelPlugin;
                boxRankPlace.Text = b.RankPlace;
                boxRankDelete.Text = b.RankDelete;

                dropKills.SelectedIndex = b.Killer == "1" ? 0 : 1;

                dropSpecial.SelectedIndex = b.Special == "1" ? 0 : 1;

                switch (b.Physic) {
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

                boxPDelay.Text = b.DoTime;
                boxPhysRand.Text = b.DoTimeRandom;

                dropRepPhys.SelectedIndex = b.DoRepeat == "1" ? 0 : 1;

                boxPPlugin.Text = b.PhysicPlugin;

                dropMaploadPhys.SelectedIndex = b.DobyLoad == "1" ? 0 : 1;
            }
        }
        private void chkTransparent_CheckedChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;

                if (b.OverviewColor != "-1" && chkTransparent.Checked) {
                    b.OverviewColor = "-1";
                    picOColor.BackColor = Color.White;
                }
                break;
            }
        }
        private void dropKills_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;

            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) 
                    b.Killer = (string)dropKills.SelectedItem == "Yes" ? "1" : "0";
            }
        }

        private void dropSpecial_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;

            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem)
                    b.Special = (string)dropSpecial.SelectedItem == "Yes" ? "1" : "0";
            }
        }

        private void dropPhysics_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;
            foreach (var b in _blocks) {
                if (b.BlockName == (string)lstBlock.SelectedItem) {
                    switch ((string)dropPhysics.SelectedItem) {
                        case "No Physics":
                            b.Physic = "0";
                            break;
                        case "Original Sand (Falling)":
                            b.Physic = "10";
                            break;
                        case "New Sand":
                            b.Physic = "11";
                            break;
                        case "Infinite Water":
                            b.Physic = "20";
                            break;
                        case "Finite Water":
                            b.Physic = "21";
                            break;

                    }
                }
            }
        }

        private void dropMaploadPhys_SelectedIndexChanged(object sender, EventArgs e) {
            if ((string)lstBlock.SelectedItem == "--Reserved--")
                return;

            foreach (var b in _blocks) {
                if (b.BlockName != (string) lstBlock.SelectedItem) 
                    continue;

                b.DobyLoad = (string)dropMaploadPhys.SelectedItem == "Yes" ? "1" : "0";
                break;
            }
        }

        private void lstCmd_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (var c in _commands) {
                if (c.Name == (string)lstCmd.SelectedItem) {
                    boxCommand.Text = c.Name;
                    boxCRank.Text = c.Rank;
                    boxShowRank.Text = c.RankShow;
                    boxPlugin.Text = c.Plugin;
                    boxGroup.Text = c.Group;
                    boxDescript.Text = c.Description;
                    //break;
                }
            }
        }

        private void lstRanks_SelectedIndexChanged(object sender, EventArgs e) {
            foreach (var f in _ranks) {
                if (f.Name != (string) lstRanks.SelectedItem) 
                    continue;

                _currentRank = f;
                boxRName.Text = f.Name;
                boxRPrefix.Text = f.Prefix;
                boxRank.Text = f.Number;
                boxRSuffix.Text = f.Suffix;

                chkIsOp.Checked = f.Onclient == "100";
                break;
            }
        }
        #endregion


        #region Other

        #endregion
        #endregion
    }
}
