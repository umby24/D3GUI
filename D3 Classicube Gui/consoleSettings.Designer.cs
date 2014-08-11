namespace D3_Classicube_Gui {
    partial class ConsoleSettings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleSettings));
            this.btnDone = new System.Windows.Forms.Button();
            this.chkHeartbeat = new System.Windows.Forms.CheckBox();
            this.chkChat = new System.Windows.Forms.CheckBox();
            this.chkCommands = new System.Windows.Forms.CheckBox();
            this.chkMapSave = new System.Windows.Forms.CheckBox();
            this.chkPlayers = new System.Windows.Forms.CheckBox();
            this.chkLua = new System.Windows.Forms.CheckBox();
            this.chkTimes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(12, 173);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(159, 23);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // chkHeartbeat
            // 
            this.chkHeartbeat.AutoSize = true;
            this.chkHeartbeat.Location = new System.Drawing.Point(12, 12);
            this.chkHeartbeat.Name = "chkHeartbeat";
            this.chkHeartbeat.Size = new System.Drawing.Size(124, 17);
            this.chkHeartbeat.TabIndex = 1;
            this.chkHeartbeat.Text = "Heartbeat Messages";
            this.chkHeartbeat.UseVisualStyleBackColor = true;
            // 
            // chkChat
            // 
            this.chkChat.AutoSize = true;
            this.chkChat.Location = new System.Drawing.Point(12, 35);
            this.chkChat.Name = "chkChat";
            this.chkChat.Size = new System.Drawing.Size(99, 17);
            this.chkChat.TabIndex = 2;
            this.chkChat.Text = "Chat Messages";
            this.chkChat.UseVisualStyleBackColor = true;
            // 
            // chkCommands
            // 
            this.chkCommands.AutoSize = true;
            this.chkCommands.Location = new System.Drawing.Point(12, 58);
            this.chkCommands.Name = "chkCommands";
            this.chkCommands.Size = new System.Drawing.Size(156, 17);
            this.chkCommands.TabIndex = 3;
            this.chkCommands.Text = "Player Command Messages";
            this.chkCommands.UseVisualStyleBackColor = true;
            // 
            // chkMapSave
            // 
            this.chkMapSave.AutoSize = true;
            this.chkMapSave.Location = new System.Drawing.Point(12, 81);
            this.chkMapSave.Name = "chkMapSave";
            this.chkMapSave.Size = new System.Drawing.Size(126, 17);
            this.chkMapSave.TabIndex = 4;
            this.chkMapSave.Text = "Map Save Messages";
            this.chkMapSave.UseVisualStyleBackColor = true;
            // 
            // chkPlayers
            // 
            this.chkPlayers.AutoSize = true;
            this.chkPlayers.Location = new System.Drawing.Point(12, 104);
            this.chkPlayers.Name = "chkPlayers";
            this.chkPlayers.Size = new System.Drawing.Size(120, 17);
            this.chkPlayers.TabIndex = 5;
            this.chkPlayers.Text = "Player login / logout";
            this.chkPlayers.UseVisualStyleBackColor = true;
            // 
            // chkLua
            // 
            this.chkLua.AutoSize = true;
            this.chkLua.Location = new System.Drawing.Point(12, 127);
            this.chkLua.Name = "chkLua";
            this.chkLua.Size = new System.Drawing.Size(77, 17);
            this.chkLua.TabIndex = 6;
            this.chkLua.Text = "LUA Errors";
            this.chkLua.UseVisualStyleBackColor = true;
            // 
            // chkTimes
            // 
            this.chkTimes.AutoSize = true;
            this.chkTimes.Location = new System.Drawing.Point(12, 150);
            this.chkTimes.Name = "chkTimes";
            this.chkTimes.Size = new System.Drawing.Size(82, 17);
            this.chkTimes.TabIndex = 7;
            this.chkTimes.Text = "Timestamps";
            this.chkTimes.UseVisualStyleBackColor = true;
            // 
            // ConsoleSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 204);
            this.ControlBox = false;
            this.Controls.Add(this.chkTimes);
            this.Controls.Add(this.chkLua);
            this.Controls.Add(this.chkPlayers);
            this.Controls.Add(this.chkMapSave);
            this.Controls.Add(this.chkCommands);
            this.Controls.Add(this.chkChat);
            this.Controls.Add(this.chkHeartbeat);
            this.Controls.Add(this.btnDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsoleSettings";
            this.Text = "Filtered Console Settings";
            this.Load += new System.EventHandler(this.ConsoleSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDone;
        public System.Windows.Forms.CheckBox chkHeartbeat;
        public System.Windows.Forms.CheckBox chkChat;
        public System.Windows.Forms.CheckBox chkCommands;
        public System.Windows.Forms.CheckBox chkMapSave;
        public System.Windows.Forms.CheckBox chkPlayers;
        public System.Windows.Forms.CheckBox chkLua;
        public System.Windows.Forms.CheckBox chkTimes;
    }
}