using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D3_Classicube_Gui {
    public partial class consoleSettings : Form {
        public Form1 Mainform;

        public consoleSettings() {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e) {
            Mainform.cSettings = new bool[] { chkHeartbeat.Checked, chkChat.Checked, chkCommands.Checked, chkMapSave.Checked, chkPlayers.Checked, chkLua.Checked };
            Mainform.saveSettings();
            this.Close();
        }
    }
}
