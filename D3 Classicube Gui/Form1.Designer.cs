namespace D3_Classicube_Gui {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPlayers = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHeartbeat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblGen = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.boxPhysRand = new System.Windows.Forms.TextBox();
            this.lblPhysRand = new System.Windows.Forms.Label();
            this.boxPPlugin = new System.Windows.Forms.TextBox();
            this.lblPhysPlug = new System.Windows.Forms.Label();
            this.lblPhysDelay = new System.Windows.Forms.Label();
            this.lblRepPhys = new System.Windows.Forms.Label();
            this.dropRepPhys = new System.Windows.Forms.ComboBox();
            this.dropMaploadPhys = new System.Windows.Forms.ComboBox();
            this.boxPDelay = new System.Windows.Forms.TextBox();
            this.lblMapPhys = new System.Windows.Forms.Label();
            this.dropPhysics = new System.Windows.Forms.ComboBox();
            this.lblPhysics = new System.Windows.Forms.Label();
            this.btnBRevert = new System.Windows.Forms.Button();
            this.btnBSave = new System.Windows.Forms.Button();
            this.chkTransparent = new System.Windows.Forms.CheckBox();
            this.lblOColor = new System.Windows.Forms.Label();
            this.dropSpecial = new System.Windows.Forms.ComboBox();
            this.dropKills = new System.Windows.Forms.ComboBox();
            this.boxRankDelete = new System.Windows.Forms.TextBox();
            this.boxRankPlace = new System.Windows.Forms.TextBox();
            this.boxDPlugin = new System.Windows.Forms.TextBox();
            this.boxCPlugin = new System.Windows.Forms.TextBox();
            this.boxBID = new System.Windows.Forms.TextBox();
            this.boxBName = new System.Windows.Forms.TextBox();
            this.lblSpec = new System.Windows.Forms.Label();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblRDel = new System.Windows.Forms.Label();
            this.lblRPlace = new System.Windows.Forms.Label();
            this.lblDPlugin = new System.Windows.Forms.Label();
            this.lblCPlugin = new System.Windows.Forms.Label();
            this.lblBID = new System.Windows.Forms.Label();
            this.lblBName = new System.Windows.Forms.Label();
            this.lblIID = new System.Windows.Forms.Label();
            this.btnRemBlock = new System.Windows.Forms.Button();
            this.btnAddBlock = new System.Windows.Forms.Button();
            this.lstBlock = new System.Windows.Forms.ListBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.btnRemCom = new System.Windows.Forms.Button();
            this.btnAddCom = new System.Windows.Forms.Button();
            this.btnCRevert = new System.Windows.Forms.Button();
            this.btnCSave = new System.Windows.Forms.Button();
            this.boxDescript = new System.Windows.Forms.TextBox();
            this.lblDescript = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.boxGroup = new System.Windows.Forms.TextBox();
            this.lblPlugin = new System.Windows.Forms.Label();
            this.boxPlugin = new System.Windows.Forms.TextBox();
            this.boxShowRank = new System.Windows.Forms.TextBox();
            this.lblShowRank = new System.Windows.Forms.Label();
            this.boxCRank = new System.Windows.Forms.TextBox();
            this.lblCRank = new System.Windows.Forms.Label();
            this.lblCommand = new System.Windows.Forms.Label();
            this.boxCommand = new System.Windows.Forms.TextBox();
            this.lstCmd = new System.Windows.Forms.ListBox();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.lblMapSize = new System.Windows.Forms.Label();
            this.btnSavePreview = new System.Windows.Forms.Button();
            this.dropMapGen = new System.Windows.Forms.ComboBox();
            this.lblMapGen = new System.Windows.Forms.Label();
            this.btnMapReloads = new System.Windows.Forms.Button();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.dropOverType = new System.Windows.Forms.ComboBox();
            this.dropPhysStop = new System.Windows.Forms.ComboBox();
            this.boxVisrank = new System.Windows.Forms.TextBox();
            this.boxJoinRank = new System.Windows.Forms.TextBox();
            this.boxBuildRank = new System.Windows.Forms.TextBox();
            this.lblOvertype = new System.Windows.Forms.Label();
            this.lblPhysStop = new System.Windows.Forms.Label();
            this.lblSaveInt = new System.Windows.Forms.Label();
            this.lblVisRank = new System.Windows.Forms.Label();
            this.lblJoinRank = new System.Windows.Forms.Label();
            this.lblBuildRank = new System.Windows.Forms.Label();
            this.btnMapRez = new System.Windows.Forms.Button();
            this.btnRegenPrev = new System.Windows.Forms.Button();
            this.btnRegenMap = new System.Windows.Forms.Button();
            this.btnRenameMap = new System.Windows.Forms.Button();
            this.btnDeleteMap = new System.Windows.Forms.Button();
            this.btnUnloadMap = new System.Windows.Forms.Button();
            this.btnAddMap = new System.Windows.Forms.Button();
            this.lstMaps = new System.Windows.Forms.ListBox();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.boxRSuffix = new System.Windows.Forms.TextBox();
            this.lblSuffix = new System.Windows.Forms.Label();
            this.btnRevert = new System.Windows.Forms.Button();
            this.boxRank = new System.Windows.Forms.TextBox();
            this.lblRank = new System.Windows.Forms.Label();
            this.chkIsOp = new System.Windows.Forms.CheckBox();
            this.lblRPrefix = new System.Windows.Forms.Label();
            this.boxRPrefix = new System.Windows.Forms.TextBox();
            this.lblRName = new System.Windows.Forms.Label();
            this.boxRName = new System.Windows.Forms.TextBox();
            this.btnSaveRanks = new System.Windows.Forms.Button();
            this.btnRemRank = new System.Windows.Forms.Button();
            this.btnAddRank = new System.Windows.Forms.Button();
            this.lstRanks = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLuaApi = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblUmby = new System.Windows.Forms.Label();
            this.lblBanner = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.btnDelLua = new System.Windows.Forms.Button();
            this.btnAddLua = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.boxConsole = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.boxChat = new System.Windows.Forms.TextBox();
            this.boxFiltered = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setRankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unstopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unmuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnQA = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnTray = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnTimed = new System.Windows.Forms.Button();
            this.btnLua = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClickDistance = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkNameVerif = new System.Windows.Forms.CheckBox();
            this.chkPub = new System.Windows.Forms.CheckBox();
            this.boxPort = new System.Windows.Forms.TextBox();
            this.boxMax = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblMaxPlayers = new System.Windows.Forms.Label();
            this.boxLogin = new System.Windows.Forms.TextBox();
            this.lblLoginMsg = new System.Windows.Forms.Label();
            this.boxMOTD = new System.Windows.Forms.TextBox();
            this.lblMotd = new System.Windows.Forms.Label();
            this.boxSName = new System.Windows.Forms.TextBox();
            this.lblSName = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picOverview = new System.Windows.Forms.PictureBox();
            this.picOColor = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            this.contextIcon.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.tabPage10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblPlayers,
            this.lblHeartbeat,
            this.lblGen,
            this.updateProgress});
            this.statusStrip.Location = new System.Drawing.Point(0, 289);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(777, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "stripStatus";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 19);
            this.lblStatus.Text = "OFFLINE";
            // 
            // lblPlayers
            // 
            this.lblPlayers.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(60, 19);
            this.lblPlayers.Text = "Players: 0";
            // 
            // lblHeartbeat
            // 
            this.lblHeartbeat.Name = "lblHeartbeat";
            this.lblHeartbeat.Size = new System.Drawing.Size(82, 19);
            this.lblHeartbeat.Text = "Last Heatbeat:";
            // 
            // lblGen
            // 
            this.lblGen.Name = "lblGen";
            this.lblGen.Size = new System.Drawing.Size(0, 19);
            // 
            // updateProgress
            // 
            this.updateProgress.Name = "updateProgress";
            this.updateProgress.Size = new System.Drawing.Size(100, 18);
            this.updateProgress.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextIcon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "D3 Server";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextIcon
            // 
            this.contextIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bShowToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextIcon.Name = "contextIcon";
            this.contextIcon.Size = new System.Drawing.Size(104, 54);
            // 
            // bShowToolStripMenuItem
            // 
            this.bShowToolStripMenuItem.Name = "bShowToolStripMenuItem";
            this.bShowToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.bShowToolStripMenuItem.Text = "&Show";
            this.bShowToolStripMenuItem.Click += new System.EventHandler(this.bShowToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.groupBox1);
            this.tabPage14.Controls.Add(this.btnBRevert);
            this.tabPage14.Controls.Add(this.btnBSave);
            this.tabPage14.Controls.Add(this.chkTransparent);
            this.tabPage14.Controls.Add(this.lblOColor);
            this.tabPage14.Controls.Add(this.dropSpecial);
            this.tabPage14.Controls.Add(this.dropKills);
            this.tabPage14.Controls.Add(this.boxRankDelete);
            this.tabPage14.Controls.Add(this.boxRankPlace);
            this.tabPage14.Controls.Add(this.boxDPlugin);
            this.tabPage14.Controls.Add(this.boxCPlugin);
            this.tabPage14.Controls.Add(this.boxBID);
            this.tabPage14.Controls.Add(this.boxBName);
            this.tabPage14.Controls.Add(this.lblSpec);
            this.tabPage14.Controls.Add(this.lblKills);
            this.tabPage14.Controls.Add(this.lblRDel);
            this.tabPage14.Controls.Add(this.lblRPlace);
            this.tabPage14.Controls.Add(this.lblDPlugin);
            this.tabPage14.Controls.Add(this.lblCPlugin);
            this.tabPage14.Controls.Add(this.lblBID);
            this.tabPage14.Controls.Add(this.lblBName);
            this.tabPage14.Controls.Add(this.lblIID);
            this.tabPage14.Controls.Add(this.btnRemBlock);
            this.tabPage14.Controls.Add(this.btnAddBlock);
            this.tabPage14.Controls.Add(this.picOColor);
            this.tabPage14.Controls.Add(this.lstBlock);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Size = new System.Drawing.Size(769, 287);
            this.tabPage14.TabIndex = 7;
            this.tabPage14.Text = "Blocks";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.boxPhysRand);
            this.groupBox1.Controls.Add(this.lblPhysRand);
            this.groupBox1.Controls.Add(this.boxPPlugin);
            this.groupBox1.Controls.Add(this.lblPhysPlug);
            this.groupBox1.Controls.Add(this.lblPhysDelay);
            this.groupBox1.Controls.Add(this.lblRepPhys);
            this.groupBox1.Controls.Add(this.dropRepPhys);
            this.groupBox1.Controls.Add(this.dropMaploadPhys);
            this.groupBox1.Controls.Add(this.boxPDelay);
            this.groupBox1.Controls.Add(this.lblMapPhys);
            this.groupBox1.Controls.Add(this.dropPhysics);
            this.groupBox1.Controls.Add(this.lblPhysics);
            this.groupBox1.Location = new System.Drawing.Point(473, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 188);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Physics";
            // 
            // boxPhysRand
            // 
            this.boxPhysRand.Location = new System.Drawing.Point(101, 63);
            this.boxPhysRand.Name = "boxPhysRand";
            this.boxPhysRand.Size = new System.Drawing.Size(137, 20);
            this.boxPhysRand.TabIndex = 47;
            this.toolTip1.SetToolTip(this.boxPhysRand, "A random time added to the physics delay");
            this.boxPhysRand.TextChanged += new System.EventHandler(this.boxPhysRand_TextChanged);
            // 
            // lblPhysRand
            // 
            this.lblPhysRand.AutoSize = true;
            this.lblPhysRand.Location = new System.Drawing.Point(9, 66);
            this.lblPhysRand.Name = "lblPhysRand";
            this.lblPhysRand.Size = new System.Drawing.Size(86, 13);
            this.lblPhysRand.TabIndex = 46;
            this.lblPhysRand.Text = "Physics Random";
            // 
            // boxPPlugin
            // 
            this.boxPPlugin.Location = new System.Drawing.Point(101, 116);
            this.boxPPlugin.Name = "boxPPlugin";
            this.boxPPlugin.Size = new System.Drawing.Size(137, 20);
            this.boxPPlugin.TabIndex = 45;
            this.toolTip1.SetToolTip(this.boxPPlugin, "The Lua plugin for handling this block\'s physics.");
            this.boxPPlugin.TextChanged += new System.EventHandler(this.boxPPlugin_TextChanged);
            // 
            // lblPhysPlug
            // 
            this.lblPhysPlug.AutoSize = true;
            this.lblPhysPlug.Location = new System.Drawing.Point(20, 119);
            this.lblPhysPlug.Name = "lblPhysPlug";
            this.lblPhysPlug.Size = new System.Drawing.Size(75, 13);
            this.lblPhysPlug.TabIndex = 44;
            this.lblPhysPlug.Text = "Physics Plugin";
            // 
            // lblPhysDelay
            // 
            this.lblPhysDelay.AutoSize = true;
            this.lblPhysDelay.Location = new System.Drawing.Point(22, 40);
            this.lblPhysDelay.Name = "lblPhysDelay";
            this.lblPhysDelay.Size = new System.Drawing.Size(73, 13);
            this.lblPhysDelay.TabIndex = 29;
            this.lblPhysDelay.Text = "Physics Delay";
            // 
            // lblRepPhys
            // 
            this.lblRepPhys.AutoSize = true;
            this.lblRepPhys.Location = new System.Drawing.Point(11, 92);
            this.lblRepPhys.Name = "lblRepPhys";
            this.lblRepPhys.Size = new System.Drawing.Size(84, 13);
            this.lblRepPhys.TabIndex = 30;
            this.lblRepPhys.Text = "Repeat Physics:";
            // 
            // dropRepPhys
            // 
            this.dropRepPhys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropRepPhys.FormattingEnabled = true;
            this.dropRepPhys.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.dropRepPhys.Location = new System.Drawing.Point(101, 89);
            this.dropRepPhys.Name = "dropRepPhys";
            this.dropRepPhys.Size = new System.Drawing.Size(137, 21);
            this.dropRepPhys.TabIndex = 42;
            this.toolTip1.SetToolTip(this.dropRepPhys, "Will physics be applied multiple times to the block?");
            this.dropRepPhys.SelectedIndexChanged += new System.EventHandler(this.dropRepPhys_SelectedIndexChanged);
            // 
            // dropMaploadPhys
            // 
            this.dropMaploadPhys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropMaploadPhys.FormattingEnabled = true;
            this.dropMaploadPhys.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.dropMaploadPhys.Location = new System.Drawing.Point(184, 142);
            this.dropMaploadPhys.Name = "dropMaploadPhys";
            this.dropMaploadPhys.Size = new System.Drawing.Size(83, 21);
            this.dropMaploadPhys.TabIndex = 43;
            this.toolTip1.SetToolTip(this.dropMaploadPhys, "After /mapload, is the block allowed to process physics right away?");
            this.dropMaploadPhys.SelectedIndexChanged += new System.EventHandler(this.dropMaploadPhys_SelectedIndexChanged);
            // 
            // boxPDelay
            // 
            this.boxPDelay.Location = new System.Drawing.Point(101, 37);
            this.boxPDelay.Name = "boxPDelay";
            this.boxPDelay.Size = new System.Drawing.Size(137, 20);
            this.boxPDelay.TabIndex = 41;
            this.toolTip1.SetToolTip(this.boxPDelay, "The time in ms between each physics tick for this block");
            this.boxPDelay.TextChanged += new System.EventHandler(this.boxPDelay_TextChanged);
            // 
            // lblMapPhys
            // 
            this.lblMapPhys.AutoSize = true;
            this.lblMapPhys.Location = new System.Drawing.Point(11, 149);
            this.lblMapPhys.Name = "lblMapPhys";
            this.lblMapPhys.Size = new System.Drawing.Size(167, 13);
            this.lblMapPhys.TabIndex = 31;
            this.lblMapPhys.Text = "Allowed to physics after mapload?";
            // 
            // dropPhysics
            // 
            this.dropPhysics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropPhysics.FormattingEnabled = true;
            this.dropPhysics.Items.AddRange(new object[] {
            "No Physics",
            "Original Sand (Falling)",
            "New Sand",
            "Infinite Water",
            "Finite Water"});
            this.dropPhysics.Location = new System.Drawing.Point(101, 10);
            this.dropPhysics.Name = "dropPhysics";
            this.dropPhysics.Size = new System.Drawing.Size(137, 21);
            this.dropPhysics.TabIndex = 34;
            this.toolTip1.SetToolTip(this.dropPhysics, "What kind of built in physics is applied to this block?");
            this.dropPhysics.SelectedIndexChanged += new System.EventHandler(this.dropPhysics_SelectedIndexChanged);
            // 
            // lblPhysics
            // 
            this.lblPhysics.AutoSize = true;
            this.lblPhysics.Location = new System.Drawing.Point(49, 13);
            this.lblPhysics.Name = "lblPhysics";
            this.lblPhysics.Size = new System.Drawing.Size(46, 13);
            this.lblPhysics.TabIndex = 22;
            this.lblPhysics.Text = "Physics:";
            // 
            // btnBRevert
            // 
            this.btnBRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBRevert.Location = new System.Drawing.Point(574, 241);
            this.btnBRevert.Name = "btnBRevert";
            this.btnBRevert.Size = new System.Drawing.Size(187, 23);
            this.btnBRevert.TabIndex = 49;
            this.btnBRevert.Text = "Revert";
            this.toolTip1.SetToolTip(this.btnBRevert, "Revert to the on-disk version of the blocks file.");
            this.btnBRevert.UseVisualStyleBackColor = true;
            this.btnBRevert.Click += new System.EventHandler(this.btnBRevert_Click);
            // 
            // btnBSave
            // 
            this.btnBSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBSave.Location = new System.Drawing.Point(574, 212);
            this.btnBSave.Name = "btnBSave";
            this.btnBSave.Size = new System.Drawing.Size(187, 23);
            this.btnBSave.TabIndex = 48;
            this.btnBSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnBSave, "Save all blocks to the server and reload them.");
            this.btnBSave.UseVisualStyleBackColor = true;
            this.btnBSave.Click += new System.EventHandler(this.btnBSave_Click);
            // 
            // chkTransparent
            // 
            this.chkTransparent.AutoSize = true;
            this.chkTransparent.Location = new System.Drawing.Point(255, 76);
            this.chkTransparent.Name = "chkTransparent";
            this.chkTransparent.Size = new System.Drawing.Size(83, 17);
            this.chkTransparent.TabIndex = 47;
            this.chkTransparent.Text = "Transparent";
            this.chkTransparent.UseVisualStyleBackColor = true;
            this.chkTransparent.CheckedChanged += new System.EventHandler(this.chkTransparent_CheckedChanged);
            // 
            // lblOColor
            // 
            this.lblOColor.AutoSize = true;
            this.lblOColor.Location = new System.Drawing.Point(144, 77);
            this.lblOColor.Name = "lblOColor";
            this.lblOColor.Size = new System.Drawing.Size(79, 13);
            this.lblOColor.TabIndex = 45;
            this.lblOColor.Text = "Overview Color";
            // 
            // dropSpecial
            // 
            this.dropSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropSpecial.FormattingEnabled = true;
            this.dropSpecial.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.dropSpecial.Location = new System.Drawing.Point(229, 233);
            this.dropSpecial.Name = "dropSpecial";
            this.dropSpecial.Size = new System.Drawing.Size(137, 21);
            this.dropSpecial.TabIndex = 40;
            this.toolTip1.SetToolTip(this.dropSpecial, "Will this block show up under /materials?");
            this.dropSpecial.SelectedIndexChanged += new System.EventHandler(this.dropSpecial_SelectedIndexChanged);
            // 
            // dropKills
            // 
            this.dropKills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropKills.FormattingEnabled = true;
            this.dropKills.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.dropKills.Location = new System.Drawing.Point(229, 206);
            this.dropKills.Name = "dropKills";
            this.dropKills.Size = new System.Drawing.Size(137, 21);
            this.dropKills.TabIndex = 39;
            this.toolTip1.SetToolTip(this.dropKills, "Does this block Kill the player when touching it?");
            this.dropKills.SelectedIndexChanged += new System.EventHandler(this.dropKills_SelectedIndexChanged);
            // 
            // boxRankDelete
            // 
            this.boxRankDelete.Location = new System.Drawing.Point(229, 180);
            this.boxRankDelete.Name = "boxRankDelete";
            this.boxRankDelete.Size = new System.Drawing.Size(137, 20);
            this.boxRankDelete.TabIndex = 38;
            this.toolTip1.SetToolTip(this.boxRankDelete, "The rank at which you can delete this block");
            this.boxRankDelete.TextChanged += new System.EventHandler(this.boxRankDelete_TextChanged);
            // 
            // boxRankPlace
            // 
            this.boxRankPlace.Location = new System.Drawing.Point(229, 154);
            this.boxRankPlace.Name = "boxRankPlace";
            this.boxRankPlace.Size = new System.Drawing.Size(137, 20);
            this.boxRankPlace.TabIndex = 37;
            this.toolTip1.SetToolTip(this.boxRankPlace, "The rank at which you can place this block");
            this.boxRankPlace.TextChanged += new System.EventHandler(this.boxRankPlace_TextChanged);
            // 
            // boxDPlugin
            // 
            this.boxDPlugin.Location = new System.Drawing.Point(229, 128);
            this.boxDPlugin.Name = "boxDPlugin";
            this.boxDPlugin.Size = new System.Drawing.Size(137, 20);
            this.boxDPlugin.TabIndex = 36;
            this.toolTip1.SetToolTip(this.boxDPlugin, "The Lua plugin that runs when this block is deleted");
            this.boxDPlugin.TextChanged += new System.EventHandler(this.boxDPlugin_TextChanged);
            // 
            // boxCPlugin
            // 
            this.boxCPlugin.Location = new System.Drawing.Point(229, 102);
            this.boxCPlugin.Name = "boxCPlugin";
            this.boxCPlugin.Size = new System.Drawing.Size(137, 20);
            this.boxCPlugin.TabIndex = 35;
            this.toolTip1.SetToolTip(this.boxCPlugin, "The Lua plugin that is run when this block is created");
            this.boxCPlugin.TextChanged += new System.EventHandler(this.boxCPlugin_TextChanged);
            // 
            // boxBID
            // 
            this.boxBID.Location = new System.Drawing.Point(229, 49);
            this.boxBID.Name = "boxBID";
            this.boxBID.Size = new System.Drawing.Size(137, 20);
            this.boxBID.TabIndex = 33;
            this.toolTip1.SetToolTip(this.boxBID, "The block ID that is sent to the client");
            this.boxBID.TextChanged += new System.EventHandler(this.boxBID_TextChanged);
            // 
            // boxBName
            // 
            this.boxBName.Location = new System.Drawing.Point(229, 23);
            this.boxBName.Name = "boxBName";
            this.boxBName.Size = new System.Drawing.Size(137, 20);
            this.boxBName.TabIndex = 32;
            this.toolTip1.SetToolTip(this.boxBName, "The name of the block");
            this.boxBName.TextChanged += new System.EventHandler(this.boxBName_TextChanged);
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(181, 236);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(42, 13);
            this.lblSpec.TabIndex = 28;
            this.lblSpec.Text = "Special";
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Location = new System.Drawing.Point(198, 209);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(25, 13);
            this.lblKills.TabIndex = 27;
            this.lblKills.Text = "Kills";
            // 
            // lblRDel
            // 
            this.lblRDel.AutoSize = true;
            this.lblRDel.Location = new System.Drawing.Point(156, 183);
            this.lblRDel.Name = "lblRDel";
            this.lblRDel.Size = new System.Drawing.Size(67, 13);
            this.lblRDel.TabIndex = 26;
            this.lblRDel.Text = "Rank Delete";
            // 
            // lblRPlace
            // 
            this.lblRPlace.AutoSize = true;
            this.lblRPlace.Location = new System.Drawing.Point(160, 157);
            this.lblRPlace.Name = "lblRPlace";
            this.lblRPlace.Size = new System.Drawing.Size(63, 13);
            this.lblRPlace.TabIndex = 25;
            this.lblRPlace.Text = "Rank Place";
            // 
            // lblDPlugin
            // 
            this.lblDPlugin.AutoSize = true;
            this.lblDPlugin.Location = new System.Drawing.Point(138, 131);
            this.lblDPlugin.Name = "lblDPlugin";
            this.lblDPlugin.Size = new System.Drawing.Size(85, 13);
            this.lblDPlugin.TabIndex = 24;
            this.lblDPlugin.Text = "Plugin on Delete";
            // 
            // lblCPlugin
            // 
            this.lblCPlugin.AutoSize = true;
            this.lblCPlugin.Location = new System.Drawing.Point(138, 105);
            this.lblCPlugin.Name = "lblCPlugin";
            this.lblCPlugin.Size = new System.Drawing.Size(85, 13);
            this.lblCPlugin.TabIndex = 23;
            this.lblCPlugin.Text = "Plugin on Create";
            // 
            // lblBID
            // 
            this.lblBID.AutoSize = true;
            this.lblBID.Location = new System.Drawing.Point(158, 52);
            this.lblBID.Name = "lblBID";
            this.lblBID.Size = new System.Drawing.Size(65, 13);
            this.lblBID.TabIndex = 21;
            this.lblBID.Text = "ID on Client:";
            // 
            // lblBName
            // 
            this.lblBName.AutoSize = true;
            this.lblBName.Location = new System.Drawing.Point(185, 25);
            this.lblBName.Name = "lblBName";
            this.lblBName.Size = new System.Drawing.Size(38, 13);
            this.lblBName.TabIndex = 20;
            this.lblBName.Text = "Name:";
            // 
            // lblIID
            // 
            this.lblIID.AutoSize = true;
            this.lblIID.Location = new System.Drawing.Point(185, 3);
            this.lblIID.Name = "lblIID";
            this.lblIID.Size = new System.Drawing.Size(56, 13);
            this.lblIID.TabIndex = 19;
            this.lblIID.Text = "Internal ID";
            // 
            // btnRemBlock
            // 
            this.btnRemBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemBlock.Location = new System.Drawing.Point(77, 241);
            this.btnRemBlock.Name = "btnRemBlock";
            this.btnRemBlock.Size = new System.Drawing.Size(59, 23);
            this.btnRemBlock.TabIndex = 18;
            this.btnRemBlock.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemBlock, "Delete the currently selected block");
            this.btnRemBlock.UseVisualStyleBackColor = true;
            this.btnRemBlock.Click += new System.EventHandler(this.btnRemBlock_Click);
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddBlock.Location = new System.Drawing.Point(8, 241);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(63, 23);
            this.btnAddBlock.TabIndex = 17;
            this.btnAddBlock.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddBlock, "Create a new block");
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // lstBlock
            // 
            this.lstBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBlock.FormattingEnabled = true;
            this.lstBlock.Location = new System.Drawing.Point(8, 3);
            this.lstBlock.Name = "lstBlock";
            this.lstBlock.Size = new System.Drawing.Size(128, 238);
            this.lstBlock.TabIndex = 0;
            this.lstBlock.SelectedIndexChanged += new System.EventHandler(this.lstBlock_SelectedIndexChanged);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.btnRemCom);
            this.tabPage12.Controls.Add(this.btnAddCom);
            this.tabPage12.Controls.Add(this.btnCRevert);
            this.tabPage12.Controls.Add(this.btnCSave);
            this.tabPage12.Controls.Add(this.boxDescript);
            this.tabPage12.Controls.Add(this.lblDescript);
            this.tabPage12.Controls.Add(this.lblGroup);
            this.tabPage12.Controls.Add(this.boxGroup);
            this.tabPage12.Controls.Add(this.lblPlugin);
            this.tabPage12.Controls.Add(this.boxPlugin);
            this.tabPage12.Controls.Add(this.boxShowRank);
            this.tabPage12.Controls.Add(this.lblShowRank);
            this.tabPage12.Controls.Add(this.boxCRank);
            this.tabPage12.Controls.Add(this.lblCRank);
            this.tabPage12.Controls.Add(this.lblCommand);
            this.tabPage12.Controls.Add(this.boxCommand);
            this.tabPage12.Controls.Add(this.lstCmd);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(769, 287);
            this.tabPage12.TabIndex = 5;
            this.tabPage12.Text = "Commands";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // btnRemCom
            // 
            this.btnRemCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemCom.Location = new System.Drawing.Point(77, 241);
            this.btnRemCom.Name = "btnRemCom";
            this.btnRemCom.Size = new System.Drawing.Size(59, 23);
            this.btnRemCom.TabIndex = 16;
            this.btnRemCom.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemCom, "Remove the currently selected command.");
            this.btnRemCom.UseVisualStyleBackColor = true;
            this.btnRemCom.Click += new System.EventHandler(this.btnRemCom_Click);
            // 
            // btnAddCom
            // 
            this.btnAddCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCom.Location = new System.Drawing.Point(8, 241);
            this.btnAddCom.Name = "btnAddCom";
            this.btnAddCom.Size = new System.Drawing.Size(63, 23);
            this.btnAddCom.TabIndex = 15;
            this.btnAddCom.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddCom, "Add a new command");
            this.btnAddCom.UseVisualStyleBackColor = true;
            this.btnAddCom.Click += new System.EventHandler(this.btnAddCom_Click);
            // 
            // btnCRevert
            // 
            this.btnCRevert.Location = new System.Drawing.Point(211, 197);
            this.btnCRevert.Name = "btnCRevert";
            this.btnCRevert.Size = new System.Drawing.Size(158, 23);
            this.btnCRevert.TabIndex = 14;
            this.btnCRevert.Text = "Revert";
            this.toolTip1.SetToolTip(this.btnCRevert, "Loads the commands file from disk");
            this.btnCRevert.UseVisualStyleBackColor = true;
            this.btnCRevert.Click += new System.EventHandler(this.btnCRevert_Click);
            // 
            // btnCSave
            // 
            this.btnCSave.Location = new System.Drawing.Point(211, 168);
            this.btnCSave.Name = "btnCSave";
            this.btnCSave.Size = new System.Drawing.Size(158, 23);
            this.btnCSave.TabIndex = 13;
            this.btnCSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnCSave, "Saves the commands to file (Causes server to reload the file)");
            this.btnCSave.UseVisualStyleBackColor = true;
            this.btnCSave.Click += new System.EventHandler(this.btnCSave_Click);
            // 
            // boxDescript
            // 
            this.boxDescript.Location = new System.Drawing.Point(211, 142);
            this.boxDescript.Name = "boxDescript";
            this.boxDescript.Size = new System.Drawing.Size(158, 20);
            this.boxDescript.TabIndex = 12;
            this.toolTip1.SetToolTip(this.boxDescript, "Description for the command. Supports color codes and line breaks.");
            this.boxDescript.TextChanged += new System.EventHandler(this.boxDescript_TextChanged);
            // 
            // lblDescript
            // 
            this.lblDescript.AutoSize = true;
            this.lblDescript.Location = new System.Drawing.Point(145, 145);
            this.lblDescript.Name = "lblDescript";
            this.lblDescript.Size = new System.Drawing.Size(60, 13);
            this.lblDescript.TabIndex = 11;
            this.lblDescript.Text = "Description";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(169, 119);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "Group";
            // 
            // boxGroup
            // 
            this.boxGroup.Location = new System.Drawing.Point(211, 116);
            this.boxGroup.Name = "boxGroup";
            this.boxGroup.Size = new System.Drawing.Size(158, 20);
            this.boxGroup.TabIndex = 9;
            this.toolTip1.SetToolTip(this.boxGroup, "The group that the command will be held under, such as map, op, build, ect.");
            this.boxGroup.TextChanged += new System.EventHandler(this.boxGroup_TextChanged);
            // 
            // lblPlugin
            // 
            this.lblPlugin.AutoSize = true;
            this.lblPlugin.Location = new System.Drawing.Point(169, 93);
            this.lblPlugin.Name = "lblPlugin";
            this.lblPlugin.Size = new System.Drawing.Size(36, 13);
            this.lblPlugin.TabIndex = 8;
            this.lblPlugin.Text = "Plugin";
            // 
            // boxPlugin
            // 
            this.boxPlugin.Location = new System.Drawing.Point(211, 90);
            this.boxPlugin.Name = "boxPlugin";
            this.boxPlugin.Size = new System.Drawing.Size(158, 20);
            this.boxPlugin.TabIndex = 7;
            this.toolTip1.SetToolTip(this.boxPlugin, "The Lua plugin that will be run when this command is run ");
            this.boxPlugin.TextChanged += new System.EventHandler(this.boxPlugin_TextChanged);
            // 
            // boxShowRank
            // 
            this.boxShowRank.Location = new System.Drawing.Point(211, 64);
            this.boxShowRank.Name = "boxShowRank";
            this.boxShowRank.Size = new System.Drawing.Size(158, 20);
            this.boxShowRank.TabIndex = 6;
            this.toolTip1.SetToolTip(this.boxShowRank, "The first rank at which players will be able to see that this command exists.");
            this.boxShowRank.TextChanged += new System.EventHandler(this.boxShowRank_TextChanged);
            // 
            // lblShowRank
            // 
            this.lblShowRank.AutoSize = true;
            this.lblShowRank.Location = new System.Drawing.Point(142, 67);
            this.lblShowRank.Name = "lblShowRank";
            this.lblShowRank.Size = new System.Drawing.Size(63, 13);
            this.lblShowRank.TabIndex = 5;
            this.lblShowRank.Text = "Show Rank";
            // 
            // boxCRank
            // 
            this.boxCRank.Location = new System.Drawing.Point(211, 37);
            this.boxCRank.Name = "boxCRank";
            this.boxCRank.Size = new System.Drawing.Size(158, 20);
            this.boxCRank.TabIndex = 4;
            this.toolTip1.SetToolTip(this.boxCRank, "The first rank that can use this command. All higher ranks will be able to use it" +
        " as well.");
            this.boxCRank.TextChanged += new System.EventHandler(this.boxCRank_TextChanged);
            // 
            // lblCRank
            // 
            this.lblCRank.AutoSize = true;
            this.lblCRank.Location = new System.Drawing.Point(172, 40);
            this.lblCRank.Name = "lblCRank";
            this.lblCRank.Size = new System.Drawing.Size(33, 13);
            this.lblCRank.TabIndex = 3;
            this.lblCRank.Text = "Rank";
            // 
            // lblCommand
            // 
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(151, 11);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 2;
            this.lblCommand.Text = "Command";
            // 
            // boxCommand
            // 
            this.boxCommand.Location = new System.Drawing.Point(211, 8);
            this.boxCommand.Name = "boxCommand";
            this.boxCommand.Size = new System.Drawing.Size(158, 20);
            this.boxCommand.TabIndex = 1;
            this.toolTip1.SetToolTip(this.boxCommand, "What a user types to activate the command.");
            this.boxCommand.TextChanged += new System.EventHandler(this.boxCommand_TextChanged);
            // 
            // lstCmd
            // 
            this.lstCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstCmd.FormattingEnabled = true;
            this.lstCmd.Location = new System.Drawing.Point(8, 8);
            this.lstCmd.Name = "lstCmd";
            this.lstCmd.Size = new System.Drawing.Size(128, 225);
            this.lstCmd.TabIndex = 0;
            this.lstCmd.SelectedIndexChanged += new System.EventHandler(this.lstCmd_SelectedIndexChanged);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.lblMapSize);
            this.tabPage11.Controls.Add(this.btnSavePreview);
            this.tabPage11.Controls.Add(this.dropMapGen);
            this.tabPage11.Controls.Add(this.lblMapGen);
            this.tabPage11.Controls.Add(this.btnMapReloads);
            this.tabPage11.Controls.Add(this.numInterval);
            this.tabPage11.Controls.Add(this.dropOverType);
            this.tabPage11.Controls.Add(this.dropPhysStop);
            this.tabPage11.Controls.Add(this.boxVisrank);
            this.tabPage11.Controls.Add(this.boxJoinRank);
            this.tabPage11.Controls.Add(this.boxBuildRank);
            this.tabPage11.Controls.Add(this.lblOvertype);
            this.tabPage11.Controls.Add(this.lblPhysStop);
            this.tabPage11.Controls.Add(this.lblSaveInt);
            this.tabPage11.Controls.Add(this.lblVisRank);
            this.tabPage11.Controls.Add(this.lblJoinRank);
            this.tabPage11.Controls.Add(this.lblBuildRank);
            this.tabPage11.Controls.Add(this.btnMapRez);
            this.tabPage11.Controls.Add(this.btnRegenPrev);
            this.tabPage11.Controls.Add(this.btnRegenMap);
            this.tabPage11.Controls.Add(this.btnRenameMap);
            this.tabPage11.Controls.Add(this.btnDeleteMap);
            this.tabPage11.Controls.Add(this.btnUnloadMap);
            this.tabPage11.Controls.Add(this.btnAddMap);
            this.tabPage11.Controls.Add(this.lstMaps);
            this.tabPage11.Controls.Add(this.picOverview);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Size = new System.Drawing.Size(769, 287);
            this.tabPage11.TabIndex = 4;
            this.tabPage11.Text = "Worlds";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // lblMapSize
            // 
            this.lblMapSize.AutoSize = true;
            this.lblMapSize.Location = new System.Drawing.Point(270, 241);
            this.lblMapSize.Name = "lblMapSize";
            this.lblMapSize.Size = new System.Drawing.Size(54, 13);
            this.lblMapSize.TabIndex = 27;
            this.lblMapSize.Text = "Map Size:";
            // 
            // btnSavePreview
            // 
            this.btnSavePreview.Location = new System.Drawing.Point(134, 231);
            this.btnSavePreview.Name = "btnSavePreview";
            this.btnSavePreview.Size = new System.Drawing.Size(120, 23);
            this.btnSavePreview.TabIndex = 26;
            this.btnSavePreview.Text = "Save Preview Image";
            this.toolTip1.SetToolTip(this.btnSavePreview, "Saves the preview image shown to the right.");
            this.btnSavePreview.UseVisualStyleBackColor = true;
            this.btnSavePreview.Click += new System.EventHandler(this.btnSavePreview_Click);
            // 
            // dropMapGen
            // 
            this.dropMapGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropMapGen.FormattingEnabled = true;
            this.dropMapGen.Items.AddRange(new object[] {
            "Candy",
            "City",
            "Colored",
            "Default",
            "Desert",
            "Dungeon",
            "Empty",
            "Fractal",
            "hSpace",
            "Island",
            "Normal",
            "Ocean",
            "Standart",
            "Space",
            "Terrabyte",
            "Tilegen",
            "White",
            "Wireworld",
            "yltgen"});
            this.dropMapGen.Location = new System.Drawing.Point(320, 179);
            this.dropMapGen.Name = "dropMapGen";
            this.dropMapGen.Size = new System.Drawing.Size(125, 21);
            this.dropMapGen.TabIndex = 25;
            // 
            // lblMapGen
            // 
            this.lblMapGen.AutoSize = true;
            this.lblMapGen.Location = new System.Drawing.Point(342, 160);
            this.lblMapGen.Name = "lblMapGen";
            this.lblMapGen.Size = new System.Drawing.Size(78, 13);
            this.lblMapGen.TabIndex = 24;
            this.lblMapGen.Text = "Map Generator";
            // 
            // btnMapReloads
            // 
            this.btnMapReloads.Location = new System.Drawing.Point(134, 177);
            this.btnMapReloads.Name = "btnMapReloads";
            this.btnMapReloads.Size = new System.Drawing.Size(96, 23);
            this.btnMapReloads.TabIndex = 23;
            this.btnMapReloads.Text = "Reload Maps";
            this.toolTip1.SetToolTip(this.btnMapReloads, "Reloads the list of maps");
            this.btnMapReloads.UseVisualStyleBackColor = true;
            this.btnMapReloads.Click += new System.EventHandler(this.btnMapReloads_Click);
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(346, 83);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(101, 20);
            this.numInterval.TabIndex = 22;
            this.toolTip1.SetToolTip(this.numInterval, "Set to 0 to disable saving. Will only take effect if you change while the server " +
        "is stopped.");
            this.numInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            // 
            // dropOverType
            // 
            this.dropOverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropOverType.FormattingEnabled = true;
            this.dropOverType.Items.AddRange(new object[] {
            "None",
            "2D",
            "ISO"});
            this.dropOverType.Location = new System.Drawing.Point(326, 136);
            this.dropOverType.Name = "dropOverType";
            this.dropOverType.Size = new System.Drawing.Size(121, 21);
            this.dropOverType.TabIndex = 21;
            this.toolTip1.SetToolTip(this.dropOverType, "Will only take effect if you change while the server is off.");
            this.dropOverType.SelectedIndexChanged += new System.EventHandler(this.dropOverType_SelectedIndexChanged);
            // 
            // dropPhysStop
            // 
            this.dropPhysStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropPhysStop.FormattingEnabled = true;
            this.dropPhysStop.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.dropPhysStop.Location = new System.Drawing.Point(326, 109);
            this.dropPhysStop.Name = "dropPhysStop";
            this.dropPhysStop.Size = new System.Drawing.Size(121, 21);
            this.dropPhysStop.TabIndex = 20;
            this.toolTip1.SetToolTip(this.dropPhysStop, "Will only take effect if the server is off when you change the setting.");
            this.dropPhysStop.SelectedIndexChanged += new System.EventHandler(this.dropPhysStop_SelectedIndexChanged);
            // 
            // boxVisrank
            // 
            this.boxVisrank.Location = new System.Drawing.Point(346, 57);
            this.boxVisrank.Name = "boxVisrank";
            this.boxVisrank.Size = new System.Drawing.Size(100, 20);
            this.boxVisrank.TabIndex = 18;
            this.toolTip1.SetToolTip(this.boxVisrank, "The rank at which this map is visible on /maps");
            this.boxVisrank.TextChanged += new System.EventHandler(this.boxVisrank_TextChanged);
            // 
            // boxJoinRank
            // 
            this.boxJoinRank.Location = new System.Drawing.Point(345, 31);
            this.boxJoinRank.Name = "boxJoinRank";
            this.boxJoinRank.Size = new System.Drawing.Size(100, 20);
            this.boxJoinRank.TabIndex = 17;
            this.toolTip1.SetToolTip(this.boxJoinRank, "The minimum rank at which someone can join this map");
            this.boxJoinRank.TextChanged += new System.EventHandler(this.boxJoinRank_TextChanged);
            // 
            // boxBuildRank
            // 
            this.boxBuildRank.Location = new System.Drawing.Point(345, 5);
            this.boxBuildRank.Name = "boxBuildRank";
            this.boxBuildRank.Size = new System.Drawing.Size(100, 20);
            this.boxBuildRank.TabIndex = 16;
            this.toolTip1.SetToolTip(this.boxBuildRank, "The minimum rank at which someone can build on this map");
            this.boxBuildRank.TextChanged += new System.EventHandler(this.boxBuildRank_TextChanged);
            // 
            // lblOvertype
            // 
            this.lblOvertype.AutoSize = true;
            this.lblOvertype.Location = new System.Drawing.Point(241, 139);
            this.lblOvertype.Name = "lblOvertype";
            this.lblOvertype.Size = new System.Drawing.Size(79, 13);
            this.lblOvertype.TabIndex = 15;
            this.lblOvertype.Text = "Overview Type";
            // 
            // lblPhysStop
            // 
            this.lblPhysStop.AutoSize = true;
            this.lblPhysStop.Location = new System.Drawing.Point(236, 112);
            this.lblPhysStop.Name = "lblPhysStop";
            this.lblPhysStop.Size = new System.Drawing.Size(84, 13);
            this.lblPhysStop.TabIndex = 14;
            this.lblPhysStop.Text = "Physics stopped";
            // 
            // lblSaveInt
            // 
            this.lblSaveInt.AutoSize = true;
            this.lblSaveInt.Location = new System.Drawing.Point(230, 85);
            this.lblSaveInt.Name = "lblSaveInt";
            this.lblSaveInt.Size = new System.Drawing.Size(116, 13);
            this.lblSaveInt.TabIndex = 13;
            this.lblSaveInt.Text = "Save Interval (Minutes)";
            // 
            // lblVisRank
            // 
            this.lblVisRank.AutoSize = true;
            this.lblVisRank.Location = new System.Drawing.Point(230, 60);
            this.lblVisRank.Name = "lblVisRank";
            this.lblVisRank.Size = new System.Drawing.Size(110, 13);
            this.lblVisRank.TabIndex = 11;
            this.lblVisRank.Text = "Minimum Visible Rank";
            // 
            // lblJoinRank
            // 
            this.lblJoinRank.AutoSize = true;
            this.lblJoinRank.Location = new System.Drawing.Point(240, 34);
            this.lblJoinRank.Name = "lblJoinRank";
            this.lblJoinRank.Size = new System.Drawing.Size(99, 13);
            this.lblJoinRank.TabIndex = 10;
            this.lblJoinRank.Text = "Minimum Join Rank";
            // 
            // lblBuildRank
            // 
            this.lblBuildRank.AutoSize = true;
            this.lblBuildRank.Location = new System.Drawing.Point(236, 8);
            this.lblBuildRank.Name = "lblBuildRank";
            this.lblBuildRank.Size = new System.Drawing.Size(103, 13);
            this.lblBuildRank.TabIndex = 2;
            this.lblBuildRank.Text = "Minimum Build Rank";
            // 
            // btnMapRez
            // 
            this.btnMapRez.Enabled = false;
            this.btnMapRez.Location = new System.Drawing.Point(134, 148);
            this.btnMapRez.Name = "btnMapRez";
            this.btnMapRez.Size = new System.Drawing.Size(96, 23);
            this.btnMapRez.TabIndex = 9;
            this.btnMapRez.Text = "Resize Map";
            this.toolTip1.SetToolTip(this.btnMapRez, "Calls the server to resize the selected map.");
            this.btnMapRez.UseVisualStyleBackColor = true;
            this.btnMapRez.Click += new System.EventHandler(this.btnMapRez_Click);
            // 
            // btnRegenPrev
            // 
            this.btnRegenPrev.Enabled = false;
            this.btnRegenPrev.Location = new System.Drawing.Point(134, 119);
            this.btnRegenPrev.Name = "btnRegenPrev";
            this.btnRegenPrev.Size = new System.Drawing.Size(96, 23);
            this.btnRegenPrev.TabIndex = 8;
            this.btnRegenPrev.Text = "(Re)gen Preview";
            this.toolTip1.SetToolTip(this.btnRegenPrev, "This also saves the map");
            this.btnRegenPrev.UseVisualStyleBackColor = true;
            this.btnRegenPrev.Click += new System.EventHandler(this.btnRegenPrev_Click);
            // 
            // btnRegenMap
            // 
            this.btnRegenMap.Enabled = false;
            this.btnRegenMap.Location = new System.Drawing.Point(336, 206);
            this.btnRegenMap.Name = "btnRegenMap";
            this.btnRegenMap.Size = new System.Drawing.Size(96, 23);
            this.btnRegenMap.TabIndex = 7;
            this.btnRegenMap.Text = "Regenerate Map";
            this.toolTip1.SetToolTip(this.btnRegenMap, "Calls the server to regenerate the map. Standart = flatgrass");
            this.btnRegenMap.UseVisualStyleBackColor = true;
            this.btnRegenMap.Click += new System.EventHandler(this.btnRegenMap_Click);
            // 
            // btnRenameMap
            // 
            this.btnRenameMap.Enabled = false;
            this.btnRenameMap.Location = new System.Drawing.Point(134, 90);
            this.btnRenameMap.Name = "btnRenameMap";
            this.btnRenameMap.Size = new System.Drawing.Size(96, 23);
            this.btnRenameMap.TabIndex = 5;
            this.btnRenameMap.Text = "Rename Map";
            this.toolTip1.SetToolTip(this.btnRenameMap, "Note that the folder name for this map will remain the same.");
            this.btnRenameMap.UseVisualStyleBackColor = true;
            this.btnRenameMap.Click += new System.EventHandler(this.btnRenameMap_Click);
            // 
            // btnDeleteMap
            // 
            this.btnDeleteMap.Enabled = false;
            this.btnDeleteMap.Location = new System.Drawing.Point(134, 61);
            this.btnDeleteMap.Name = "btnDeleteMap";
            this.btnDeleteMap.Size = new System.Drawing.Size(96, 23);
            this.btnDeleteMap.TabIndex = 4;
            this.btnDeleteMap.Text = "Delete Map";
            this.toolTip1.SetToolTip(this.btnDeleteMap, "Unloads the map and deletes all of its files");
            this.btnDeleteMap.UseVisualStyleBackColor = true;
            this.btnDeleteMap.Click += new System.EventHandler(this.btnDeleteMap_Click);
            // 
            // btnUnloadMap
            // 
            this.btnUnloadMap.Enabled = false;
            this.btnUnloadMap.Location = new System.Drawing.Point(134, 32);
            this.btnUnloadMap.Name = "btnUnloadMap";
            this.btnUnloadMap.Size = new System.Drawing.Size(96, 23);
            this.btnUnloadMap.TabIndex = 3;
            this.btnUnloadMap.Text = "Unload Map";
            this.toolTip1.SetToolTip(this.btnUnloadMap, "Just unloads the map, and leaves all the files");
            this.btnUnloadMap.UseVisualStyleBackColor = true;
            this.btnUnloadMap.Click += new System.EventHandler(this.btnUnloadMap_Click);
            // 
            // btnAddMap
            // 
            this.btnAddMap.Location = new System.Drawing.Point(134, 3);
            this.btnAddMap.Name = "btnAddMap";
            this.btnAddMap.Size = new System.Drawing.Size(96, 23);
            this.btnAddMap.TabIndex = 2;
            this.btnAddMap.Text = "Add Map";
            this.toolTip1.SetToolTip(this.btnAddMap, "Creates a new map, and does a flatgrass fill to it.");
            this.btnAddMap.UseVisualStyleBackColor = true;
            this.btnAddMap.Click += new System.EventHandler(this.btnAddMap_Click);
            // 
            // lstMaps
            // 
            this.lstMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstMaps.FormattingEnabled = true;
            this.lstMaps.Location = new System.Drawing.Point(8, 3);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(120, 251);
            this.lstMaps.TabIndex = 1;
            this.lstMaps.SelectedIndexChanged += new System.EventHandler(this.lstMaps_SelectedIndexChanged);
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.boxRSuffix);
            this.tabPage10.Controls.Add(this.lblSuffix);
            this.tabPage10.Controls.Add(this.btnRevert);
            this.tabPage10.Controls.Add(this.boxRank);
            this.tabPage10.Controls.Add(this.lblRank);
            this.tabPage10.Controls.Add(this.chkIsOp);
            this.tabPage10.Controls.Add(this.lblRPrefix);
            this.tabPage10.Controls.Add(this.boxRPrefix);
            this.tabPage10.Controls.Add(this.lblRName);
            this.tabPage10.Controls.Add(this.boxRName);
            this.tabPage10.Controls.Add(this.btnSaveRanks);
            this.tabPage10.Controls.Add(this.btnRemRank);
            this.tabPage10.Controls.Add(this.btnAddRank);
            this.tabPage10.Controls.Add(this.pictureBox1);
            this.tabPage10.Controls.Add(this.lstRanks);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Size = new System.Drawing.Size(769, 287);
            this.tabPage10.TabIndex = 3;
            this.tabPage10.Text = "Ranks";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // boxRSuffix
            // 
            this.boxRSuffix.Location = new System.Drawing.Point(175, 78);
            this.boxRSuffix.Name = "boxRSuffix";
            this.boxRSuffix.Size = new System.Drawing.Size(100, 20);
            this.boxRSuffix.TabIndex = 14;
            this.toolTip1.SetToolTip(this.boxRSuffix, "The color and/or text suffix for this rank.");
            this.boxRSuffix.TextChanged += new System.EventHandler(this.boxRSuffix_TextChanged);
            // 
            // lblSuffix
            // 
            this.lblSuffix.AutoSize = true;
            this.lblSuffix.Location = new System.Drawing.Point(138, 81);
            this.lblSuffix.Name = "lblSuffix";
            this.lblSuffix.Size = new System.Drawing.Size(33, 13);
            this.lblSuffix.TabIndex = 13;
            this.lblSuffix.Text = "Suffix";
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(138, 156);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(138, 23);
            this.btnRevert.TabIndex = 12;
            this.btnRevert.Text = "Revert";
            this.toolTip1.SetToolTip(this.btnRevert, "Revert all changes to the ranks file on disk");
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // boxRank
            // 
            this.boxRank.Location = new System.Drawing.Point(175, 32);
            this.boxRank.Name = "boxRank";
            this.boxRank.Size = new System.Drawing.Size(100, 20);
            this.boxRank.TabIndex = 10;
            this.toolTip1.SetToolTip(this.boxRank, "The actual numerical value for the rank");
            this.boxRank.TextChanged += new System.EventHandler(this.boxRank_TextChanged);
            // 
            // lblRank
            // 
            this.lblRank.AutoSize = true;
            this.lblRank.Location = new System.Drawing.Point(138, 35);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(33, 13);
            this.lblRank.TabIndex = 9;
            this.lblRank.Text = "Rank";
            // 
            // chkIsOp
            // 
            this.chkIsOp.AutoSize = true;
            this.chkIsOp.Location = new System.Drawing.Point(175, 104);
            this.chkIsOp.Name = "chkIsOp";
            this.chkIsOp.Size = new System.Drawing.Size(101, 17);
            this.chkIsOp.TabIndex = 8;
            this.chkIsOp.Text = "Is Operator (Op)";
            this.toolTip1.SetToolTip(this.chkIsOp, "If checked, this rank will be concidered \'Op\' (allows use of +ophax)");
            this.chkIsOp.UseVisualStyleBackColor = true;
            this.chkIsOp.CheckedChanged += new System.EventHandler(this.chkIsOp_CheckedChanged);
            // 
            // lblRPrefix
            // 
            this.lblRPrefix.AutoSize = true;
            this.lblRPrefix.Location = new System.Drawing.Point(138, 58);
            this.lblRPrefix.Name = "lblRPrefix";
            this.lblRPrefix.Size = new System.Drawing.Size(33, 13);
            this.lblRPrefix.TabIndex = 7;
            this.lblRPrefix.Text = "Prefix";
            // 
            // boxRPrefix
            // 
            this.boxRPrefix.Location = new System.Drawing.Point(175, 55);
            this.boxRPrefix.Name = "boxRPrefix";
            this.boxRPrefix.Size = new System.Drawing.Size(100, 20);
            this.boxRPrefix.TabIndex = 6;
            this.toolTip1.SetToolTip(this.boxRPrefix, "The color and/or text prefix for this rank.");
            this.boxRPrefix.TextChanged += new System.EventHandler(this.boxRPrefix_TextChanged);
            // 
            // lblRName
            // 
            this.lblRName.AutoSize = true;
            this.lblRName.Location = new System.Drawing.Point(136, 11);
            this.lblRName.Name = "lblRName";
            this.lblRName.Size = new System.Drawing.Size(35, 13);
            this.lblRName.TabIndex = 5;
            this.lblRName.Text = "Name";
            // 
            // boxRName
            // 
            this.boxRName.Location = new System.Drawing.Point(175, 8);
            this.boxRName.Name = "boxRName";
            this.boxRName.Size = new System.Drawing.Size(100, 20);
            this.boxRName.TabIndex = 4;
            this.toolTip1.SetToolTip(this.boxRName, "The name of the rank");
            this.boxRName.TextChanged += new System.EventHandler(this.boxRName_TextChanged);
            // 
            // btnSaveRanks
            // 
            this.btnSaveRanks.Location = new System.Drawing.Point(139, 127);
            this.btnSaveRanks.Name = "btnSaveRanks";
            this.btnSaveRanks.Size = new System.Drawing.Size(138, 23);
            this.btnSaveRanks.TabIndex = 3;
            this.btnSaveRanks.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSaveRanks, "Save the ranks file");
            this.btnSaveRanks.UseVisualStyleBackColor = true;
            this.btnSaveRanks.Click += new System.EventHandler(this.btnSaveRanks_Click);
            // 
            // btnRemRank
            // 
            this.btnRemRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemRank.Location = new System.Drawing.Point(73, 239);
            this.btnRemRank.Name = "btnRemRank";
            this.btnRemRank.Size = new System.Drawing.Size(55, 23);
            this.btnRemRank.TabIndex = 2;
            this.btnRemRank.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemRank, "Remove the currently selected rank");
            this.btnRemRank.UseVisualStyleBackColor = true;
            this.btnRemRank.Click += new System.EventHandler(this.btnRemRank_Click);
            // 
            // btnAddRank
            // 
            this.btnAddRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRank.Location = new System.Drawing.Point(8, 239);
            this.btnAddRank.Name = "btnAddRank";
            this.btnAddRank.Size = new System.Drawing.Size(59, 23);
            this.btnAddRank.TabIndex = 1;
            this.btnAddRank.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddRank, "Add a new rank");
            this.btnAddRank.UseVisualStyleBackColor = true;
            this.btnAddRank.Click += new System.EventHandler(this.btnAddRank_Click);
            // 
            // lstRanks
            // 
            this.lstRanks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstRanks.FormattingEnabled = true;
            this.lstRanks.Location = new System.Drawing.Point(8, 8);
            this.lstRanks.Name = "lstRanks";
            this.lstRanks.Size = new System.Drawing.Size(120, 225);
            this.lstRanks.TabIndex = 0;
            this.lstRanks.SelectedIndexChanged += new System.EventHandler(this.lstRanks_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.btnLuaApi);
            this.tabPage2.Controls.Add(this.lblInfo);
            this.tabPage2.Controls.Add(this.lblUmby);
            this.tabPage2.Controls.Add(this.lblBanner);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(769, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "      About      ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLuaApi
            // 
            this.btnLuaApi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuaApi.Location = new System.Drawing.Point(608, 241);
            this.btnLuaApi.Name = "btnLuaApi";
            this.btnLuaApi.Size = new System.Drawing.Size(153, 23);
            this.btnLuaApi.TabIndex = 3;
            this.btnLuaApi.Text = "LUA API Documentation";
            this.btnLuaApi.UseVisualStyleBackColor = true;
            this.btnLuaApi.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(8, 73);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(188, 78);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Server Software by: Dadido3, Umby24\r\n\r\nServer software written in PureBasic\r\nGUI " +
    "written in C#\r\n\r\nv1.0.9";
            // 
            // lblUmby
            // 
            this.lblUmby.AutoSize = true;
            this.lblUmby.Location = new System.Drawing.Point(696, 133);
            this.lblUmby.Name = "lblUmby";
            this.lblUmby.Size = new System.Drawing.Size(63, 13);
            this.lblUmby.TabIndex = 4;
            this.lblUmby.Text = "by: Umby24";
            // 
            // lblBanner
            // 
            this.lblBanner.AutoSize = true;
            this.lblBanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanner.Location = new System.Drawing.Point(172, 0);
            this.lblBanner.Name = "lblBanner";
            this.lblBanner.Size = new System.Drawing.Size(451, 73);
            this.lblBanner.TabIndex = 3;
            this.lblBanner.Text = "D3 Server GUI";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.btnDelLua);
            this.tabPage9.Controls.Add(this.btnAddLua);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(769, 287);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "  Custom Luas  ";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // btnDelLua
            // 
            this.btnDelLua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelLua.Location = new System.Drawing.Point(731, 32);
            this.btnDelLua.Name = "btnDelLua";
            this.btnDelLua.Size = new System.Drawing.Size(30, 23);
            this.btnDelLua.TabIndex = 1;
            this.btnDelLua.Text = "-";
            this.btnDelLua.UseVisualStyleBackColor = true;
            this.btnDelLua.Click += new System.EventHandler(this.btnDelLua_Click);
            // 
            // btnAddLua
            // 
            this.btnAddLua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLua.Location = new System.Drawing.Point(731, 3);
            this.btnAddLua.Name = "btnAddLua";
            this.btnAddLua.Size = new System.Drawing.Size(30, 23);
            this.btnAddLua.TabIndex = 0;
            this.btnAddLua.Text = "+";
            this.btnAddLua.UseVisualStyleBackColor = true;
            this.btnAddLua.Click += new System.EventHandler(this.btnAddLua_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl3);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(769, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "      Main      ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Controls.Add(this.tabPage6);
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(536, 260);
            this.tabControl3.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.boxConsole);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(528, 234);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "      Console     ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // boxConsole
            // 
            this.boxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.boxConsole.Location = new System.Drawing.Point(3, 3);
            this.boxConsole.Multiline = true;
            this.boxConsole.Name = "boxConsole";
            this.boxConsole.ReadOnly = true;
            this.boxConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.boxConsole.Size = new System.Drawing.Size(522, 228);
            this.boxConsole.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.btnSend);
            this.tabPage6.Controls.Add(this.boxChat);
            this.tabPage6.Controls.Add(this.boxFiltered);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(528, 234);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "  Filtered Console  ";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(447, 208);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // boxChat
            // 
            this.boxChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxChat.Location = new System.Drawing.Point(6, 211);
            this.boxChat.Name = "boxChat";
            this.boxChat.Size = new System.Drawing.Size(434, 20);
            this.boxChat.TabIndex = 1;
            // 
            // boxFiltered
            // 
            this.boxFiltered.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxFiltered.BackColor = System.Drawing.SystemColors.ControlDark;
            this.boxFiltered.Location = new System.Drawing.Point(6, 3);
            this.boxFiltered.Name = "boxFiltered";
            this.boxFiltered.ReadOnly = true;
            this.boxFiltered.Size = new System.Drawing.Size(519, 202);
            this.boxFiltered.TabIndex = 0;
            this.boxFiltered.Text = "";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.lstPlayers);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(528, 234);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "      Players      ";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // lstPlayers
            // 
            this.lstPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPlayers.ContextMenuStrip = this.contextMenuStrip1;
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(8, 8);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(517, 225);
            this.lstPlayers.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setRankToolStripMenuItem,
            this.kickToolStripMenuItem,
            this.banToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.unstopToolStripMenuItem,
            this.muteToolStripMenuItem,
            this.unmuteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 158);
            // 
            // setRankToolStripMenuItem
            // 
            this.setRankToolStripMenuItem.Name = "setRankToolStripMenuItem";
            this.setRankToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.setRankToolStripMenuItem.Text = "&Set Rank";
            this.setRankToolStripMenuItem.Click += new System.EventHandler(this.setRankToolStripMenuItem_Click);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.kickToolStripMenuItem.Text = "&Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // banToolStripMenuItem
            // 
            this.banToolStripMenuItem.Name = "banToolStripMenuItem";
            this.banToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.banToolStripMenuItem.Text = "&Ban";
            this.banToolStripMenuItem.Click += new System.EventHandler(this.banToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.stopToolStripMenuItem.Text = "&Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // unstopToolStripMenuItem
            // 
            this.unstopToolStripMenuItem.Name = "unstopToolStripMenuItem";
            this.unstopToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.unstopToolStripMenuItem.Text = "&Unstop";
            this.unstopToolStripMenuItem.Click += new System.EventHandler(this.unstopToolStripMenuItem_Click);
            // 
            // muteToolStripMenuItem
            // 
            this.muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            this.muteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.muteToolStripMenuItem.Text = "&Mute";
            this.muteToolStripMenuItem.Click += new System.EventHandler(this.muteToolStripMenuItem_Click);
            // 
            // unmuteToolStripMenuItem
            // 
            this.unmuteToolStripMenuItem.Name = "unmuteToolStripMenuItem";
            this.unmuteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.unmuteToolStripMenuItem.Text = "U&nmute";
            this.unmuteToolStripMenuItem.Click += new System.EventHandler(this.unmuteToolStripMenuItem_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.btnUndo);
            this.tabPage8.Controls.Add(this.btnQA);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(528, 234);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Advanced Settings";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(152, 8);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(138, 23);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Edit Undo Steps";
            this.toolTip1.SetToolTip(this.btnUndo, "Sets the maximum number of steps back the server will remember for /undo");
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnQA
            // 
            this.btnQA.Location = new System.Drawing.Point(8, 8);
            this.btnQA.Name = "btnQA";
            this.btnQA.Size = new System.Drawing.Size(138, 23);
            this.btnQA.TabIndex = 0;
            this.btnQA.Text = "Change QA commands";
            this.toolTip1.SetToolTip(this.btnQA, "These are commands like /rules, /faq, and you can add more.");
            this.btnQA.UseVisualStyleBackColor = true;
            this.btnQA.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(542, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(219, 258);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnTray);
            this.tabPage3.Controls.Add(this.btnMini);
            this.tabPage3.Controls.Add(this.btnFilter);
            this.tabPage3.Controls.Add(this.btnTimed);
            this.tabPage3.Controls.Add(this.btnLua);
            this.tabPage3.Controls.Add(this.btnStop);
            this.tabPage3.Controls.Add(this.btnStart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(211, 232);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "      Control      ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnTray
            // 
            this.btnTray.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTray.Location = new System.Drawing.Point(0, 174);
            this.btnTray.Name = "btnTray";
            this.btnTray.Size = new System.Drawing.Size(211, 23);
            this.btnTray.TabIndex = 6;
            this.btnTray.Text = "Minimize to Tray";
            this.toolTip1.SetToolTip(this.btnTray, "Minimize to the system tray");
            this.btnTray.UseVisualStyleBackColor = true;
            this.btnTray.Click += new System.EventHandler(this.btnTray_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.Location = new System.Drawing.Point(0, 145);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(211, 23);
            this.btnMini.TabIndex = 5;
            this.btnMini.Text = "Mini Mode";
            this.toolTip1.SetToolTip(this.btnMini, "Turn the GUI into a smaller form.");
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(0, 116);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(211, 23);
            this.btnFilter.TabIndex = 4;
            this.btnFilter.Text = "Filtered Console Settings";
            this.toolTip1.SetToolTip(this.btnFilter, "Edit the settings for the filtered console.");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnTimed
            // 
            this.btnTimed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimed.Location = new System.Drawing.Point(0, 87);
            this.btnTimed.Name = "btnTimed";
            this.btnTimed.Size = new System.Drawing.Size(211, 23);
            this.btnTimed.TabIndex = 3;
            this.btnTimed.Text = "Manage Timed Messages";
            this.toolTip1.SetToolTip(this.btnTimed, "Each new line = a new timed message");
            this.btnTimed.UseVisualStyleBackColor = true;
            this.btnTimed.Click += new System.EventHandler(this.btnTimed_Click);
            // 
            // btnLua
            // 
            this.btnLua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLua.Location = new System.Drawing.Point(0, 58);
            this.btnLua.Name = "btnLua";
            this.btnLua.Size = new System.Drawing.Size(211, 23);
            this.btnLua.TabIndex = 2;
            this.btnLua.Text = "Run Lua Command";
            this.toolTip1.SetToolTip(this.btnLua, "Allows you to enter and run a lua command.");
            this.btnLua.UseVisualStyleBackColor = true;
            this.btnLua.Click += new System.EventHandler(this.btnLua_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(0, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(211, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Server";
            this.toolTip1.SetToolTip(this.btnStop, "Stops the D3 Server");
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(211, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Server";
            this.toolTip1.SetToolTip(this.btnStart, "Starts the D3 Server");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.txtClickDistance);
            this.tabPage4.Controls.Add(this.btnSave);
            this.tabPage4.Controls.Add(this.chkNameVerif);
            this.tabPage4.Controls.Add(this.chkPub);
            this.tabPage4.Controls.Add(this.boxPort);
            this.tabPage4.Controls.Add(this.boxMax);
            this.tabPage4.Controls.Add(this.lblPort);
            this.tabPage4.Controls.Add(this.lblMaxPlayers);
            this.tabPage4.Controls.Add(this.boxLogin);
            this.tabPage4.Controls.Add(this.lblLoginMsg);
            this.tabPage4.Controls.Add(this.boxMOTD);
            this.tabPage4.Controls.Add(this.lblMotd);
            this.tabPage4.Controls.Add(this.boxSName);
            this.tabPage4.Controls.Add(this.lblSName);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(211, 232);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "     Settings     ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Click Distance:";
            // 
            // txtClickDistance
            // 
            this.txtClickDistance.Location = new System.Drawing.Point(151, 179);
            this.txtClickDistance.Name = "txtClickDistance";
            this.txtClickDistance.Size = new System.Drawing.Size(54, 20);
            this.txtClickDistance.TabIndex = 14;
            this.toolTip1.SetToolTip(this.txtClickDistance, "32 per block, 160 is default.");
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.toolTip1.SetToolTip(this.btnSave, "Saves the above settings.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkNameVerif
            // 
            this.chkNameVerif.AutoSize = true;
            this.chkNameVerif.Location = new System.Drawing.Point(6, 182);
            this.chkNameVerif.Name = "chkNameVerif";
            this.chkNameVerif.Size = new System.Drawing.Size(109, 17);
            this.chkNameVerif.TabIndex = 12;
            this.chkNameVerif.Text = "Name Verification";
            this.toolTip1.SetToolTip(this.chkNameVerif, "Ensures no one can steal names.");
            this.chkNameVerif.UseVisualStyleBackColor = true;
            // 
            // chkPub
            // 
            this.chkPub.AutoSize = true;
            this.chkPub.Location = new System.Drawing.Point(6, 159);
            this.chkPub.Name = "chkPub";
            this.chkPub.Size = new System.Drawing.Size(89, 17);
            this.chkPub.TabIndex = 11;
            this.chkPub.Text = "Public Server";
            this.toolTip1.SetToolTip(this.chkPub, "Checked = Show server in server list.");
            this.chkPub.UseVisualStyleBackColor = true;
            // 
            // boxPort
            // 
            this.boxPort.Location = new System.Drawing.Point(130, 133);
            this.boxPort.MaxLength = 5;
            this.boxPort.Name = "boxPort";
            this.boxPort.Size = new System.Drawing.Size(67, 20);
            this.boxPort.TabIndex = 10;
            this.toolTip1.SetToolTip(this.boxPort, "The port the server will listen on.");
            // 
            // boxMax
            // 
            this.boxMax.Location = new System.Drawing.Point(6, 133);
            this.boxMax.MaxLength = 5;
            this.boxMax.Name = "boxMax";
            this.boxMax.Size = new System.Drawing.Size(67, 20);
            this.boxMax.TabIndex = 9;
            this.toolTip1.SetToolTip(this.boxMax, "Maximum players");
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(127, 117);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 8;
            this.lblPort.Text = "Port:";
            // 
            // lblMaxPlayers
            // 
            this.lblMaxPlayers.AutoSize = true;
            this.lblMaxPlayers.Location = new System.Drawing.Point(6, 117);
            this.lblMaxPlayers.Name = "lblMaxPlayers";
            this.lblMaxPlayers.Size = new System.Drawing.Size(67, 13);
            this.lblMaxPlayers.TabIndex = 7;
            this.lblMaxPlayers.Text = "Max Players:";
            // 
            // boxLogin
            // 
            this.boxLogin.Location = new System.Drawing.Point(6, 94);
            this.boxLogin.Name = "boxLogin";
            this.boxLogin.Size = new System.Drawing.Size(199, 20);
            this.boxLogin.TabIndex = 6;
            this.toolTip1.SetToolTip(this.boxLogin, "The message all players receive when logging in.");
            // 
            // lblLoginMsg
            // 
            this.lblLoginMsg.AutoSize = true;
            this.lblLoginMsg.Location = new System.Drawing.Point(3, 78);
            this.lblLoginMsg.Name = "lblLoginMsg";
            this.lblLoginMsg.Size = new System.Drawing.Size(82, 13);
            this.lblLoginMsg.TabIndex = 5;
            this.lblLoginMsg.Text = "Login Message:";
            // 
            // boxMOTD
            // 
            this.boxMOTD.Location = new System.Drawing.Point(6, 55);
            this.boxMOTD.Name = "boxMOTD";
            this.boxMOTD.Size = new System.Drawing.Size(199, 20);
            this.boxMOTD.TabIndex = 4;
            this.toolTip1.SetToolTip(this.boxMOTD, "The default MOTD used when logging in or changing maps");
            // 
            // lblMotd
            // 
            this.lblMotd.AutoSize = true;
            this.lblMotd.Location = new System.Drawing.Point(3, 39);
            this.lblMotd.Name = "lblMotd";
            this.lblMotd.Size = new System.Drawing.Size(42, 13);
            this.lblMotd.TabIndex = 3;
            this.lblMotd.Text = "MOTD:";
            // 
            // boxSName
            // 
            this.boxSName.Location = new System.Drawing.Point(6, 16);
            this.boxSName.Name = "boxSName";
            this.boxSName.Size = new System.Drawing.Size(199, 20);
            this.boxSName.TabIndex = 2;
            this.toolTip1.SetToolTip(this.boxSName, "The server name as shown in the server list");
            // 
            // lblSName
            // 
            this.lblSName.AutoSize = true;
            this.lblSName.Location = new System.Drawing.Point(3, 0);
            this.lblSName.Name = "lblSName";
            this.lblSName.Size = new System.Drawing.Size(72, 13);
            this.lblSName.TabIndex = 1;
            this.lblSName.Text = "Server Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(777, 313);
            this.tabControl1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::D3_Classicube_Gui.Properties.Resources.minecraft_color_chart;
            this.pictureBox1.Location = new System.Drawing.Point(324, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(445, 264);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // picOverview
            // 
            this.picOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picOverview.Location = new System.Drawing.Point(452, 3);
            this.picOverview.Name = "picOverview";
            this.picOverview.Size = new System.Drawing.Size(309, 261);
            this.picOverview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOverview.TabIndex = 0;
            this.picOverview.TabStop = false;
            // 
            // picOColor
            // 
            this.picOColor.Location = new System.Drawing.Point(229, 75);
            this.picOColor.Name = "picOColor";
            this.picOColor.Size = new System.Drawing.Size(20, 20);
            this.picOColor.TabIndex = 46;
            this.picOColor.TabStop = false;
            this.toolTip1.SetToolTip(this.picOColor, "The color of the block in map previews");
            this.picOColor.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::D3_Classicube_Gui.Properties.Resources._128;
            this.pictureBox2.Location = new System.Drawing.Point(629, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 127);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 313);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Dadido3 Server GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextIcon.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.tabPage14.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage12.ResumeLayout(false);
            this.tabPage12.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.tabPage10.ResumeLayout(false);
            this.tabPage10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblPlayers;
        private System.Windows.Forms.ToolStripStatusLabel lblHeartbeat;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextIcon;
        private System.Windows.Forms.ToolStripMenuItem bShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLuaApi;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblUmby;
        private System.Windows.Forms.Label lblBanner;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnDelLua;
        private System.Windows.Forms.Button btnAddLua;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox boxConsole;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox boxChat;
        private System.Windows.Forms.RichTextBox boxFiltered;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnQA;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnTray;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnTimed;
        private System.Windows.Forms.Button btnLua;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkNameVerif;
        private System.Windows.Forms.CheckBox chkPub;
        private System.Windows.Forms.TextBox boxPort;
        private System.Windows.Forms.TextBox boxMax;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblMaxPlayers;
        private System.Windows.Forms.TextBox boxLogin;
        private System.Windows.Forms.Label lblLoginMsg;
        private System.Windows.Forms.TextBox boxMOTD;
        private System.Windows.Forms.Label lblMotd;
        private System.Windows.Forms.TextBox boxSName;
        private System.Windows.Forms.Label lblSName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnRemRank;
        private System.Windows.Forms.Button btnAddRank;
        private System.Windows.Forms.ListBox lstRanks;
        private System.Windows.Forms.CheckBox chkIsOp;
        private System.Windows.Forms.Label lblRPrefix;
        private System.Windows.Forms.TextBox boxRPrefix;
        private System.Windows.Forms.Label lblRName;
        private System.Windows.Forms.TextBox boxRName;
        private System.Windows.Forms.Button btnSaveRanks;
        private System.Windows.Forms.TextBox boxRank;
        private System.Windows.Forms.Label lblRank;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.ListBox lstCmd;
        private System.Windows.Forms.Label lblCRank;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.TextBox boxCommand;
        private System.Windows.Forms.TextBox boxCRank;
        private System.Windows.Forms.TextBox boxPlugin;
        private System.Windows.Forms.TextBox boxShowRank;
        private System.Windows.Forms.Label lblShowRank;
        private System.Windows.Forms.Label lblPlugin;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox boxGroup;
        private System.Windows.Forms.TextBox boxDescript;
        private System.Windows.Forms.Label lblDescript;
        private System.Windows.Forms.Button btnCRevert;
        private System.Windows.Forms.Button btnCSave;
        private System.Windows.Forms.Button btnRemCom;
        private System.Windows.Forms.Button btnAddCom;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblOColor;
        private System.Windows.Forms.ComboBox dropMaploadPhys;
        private System.Windows.Forms.ComboBox dropRepPhys;
        private System.Windows.Forms.TextBox boxPDelay;
        private System.Windows.Forms.ComboBox dropSpecial;
        private System.Windows.Forms.ComboBox dropKills;
        private System.Windows.Forms.TextBox boxRankDelete;
        private System.Windows.Forms.TextBox boxRankPlace;
        private System.Windows.Forms.TextBox boxDPlugin;
        private System.Windows.Forms.TextBox boxCPlugin;
        private System.Windows.Forms.ComboBox dropPhysics;
        private System.Windows.Forms.TextBox boxBID;
        private System.Windows.Forms.TextBox boxBName;
        private System.Windows.Forms.Label lblMapPhys;
        private System.Windows.Forms.Label lblRepPhys;
        private System.Windows.Forms.Label lblPhysDelay;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblRDel;
        private System.Windows.Forms.Label lblRPlace;
        private System.Windows.Forms.Label lblDPlugin;
        private System.Windows.Forms.Label lblCPlugin;
        private System.Windows.Forms.Label lblPhysics;
        private System.Windows.Forms.Label lblBID;
        private System.Windows.Forms.Label lblBName;
        private System.Windows.Forms.Label lblIID;
        private System.Windows.Forms.Button btnRemBlock;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.ListBox lstBlock;
        private System.Windows.Forms.CheckBox chkTransparent;
        private System.Windows.Forms.PictureBox picOColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnBRevert;
        private System.Windows.Forms.Button btnBSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox boxPPlugin;
        private System.Windows.Forms.Label lblPhysPlug;
        private System.Windows.Forms.TextBox boxPhysRand;
        private System.Windows.Forms.Label lblPhysRand;
        private System.Windows.Forms.PictureBox picOverview;
        private System.Windows.Forms.ListBox lstMaps;
        private System.Windows.Forms.Button btnMapRez;
        private System.Windows.Forms.Button btnRegenPrev;
        private System.Windows.Forms.Button btnRegenMap;
        private System.Windows.Forms.Button btnRenameMap;
        private System.Windows.Forms.Button btnDeleteMap;
        private System.Windows.Forms.Button btnUnloadMap;
        private System.Windows.Forms.Button btnAddMap;
        private System.Windows.Forms.Label lblOvertype;
        private System.Windows.Forms.Label lblPhysStop;
        private System.Windows.Forms.Label lblSaveInt;
        private System.Windows.Forms.Label lblVisRank;
        private System.Windows.Forms.Label lblJoinRank;
        private System.Windows.Forms.Label lblBuildRank;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.ComboBox dropOverType;
        private System.Windows.Forms.ComboBox dropPhysStop;
        private System.Windows.Forms.TextBox boxVisrank;
        private System.Windows.Forms.TextBox boxJoinRank;
        private System.Windows.Forms.TextBox boxBuildRank;
        private System.Windows.Forms.Button btnMapReloads;
        private System.Windows.Forms.ComboBox dropMapGen;
        private System.Windows.Forms.Label lblMapGen;
        private System.Windows.Forms.ToolStripStatusLabel lblGen;
        private System.Windows.Forms.Button btnSavePreview;
        public System.Windows.Forms.ToolStripProgressBar updateProgress;
        private System.Windows.Forms.Label lblMapSize;
        private System.Windows.Forms.TextBox boxRSuffix;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setRankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unstopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unmuteToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClickDistance;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

