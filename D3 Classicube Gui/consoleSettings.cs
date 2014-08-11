using System;
using System.Windows.Forms;

namespace D3_Classicube_Gui {
    public partial class ConsoleSettings : Form {
        public Form1 Mainform;

        public ConsoleSettings() {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e) {
            Mainform.CSettings = new[] { chkHeartbeat.Checked, chkChat.Checked, chkCommands.Checked, chkMapSave.Checked, chkPlayers.Checked, chkLua.Checked, chkTimes.Checked };
            Mainform.SaveSettings();
            Close();
        }

        private void ConsoleSettings_Load(object sender, EventArgs e) {

        }
    }
}
