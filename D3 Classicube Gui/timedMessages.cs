using System;
using System.Windows.Forms;
using System.IO;

namespace D3_Classicube_Gui {
    public partial class TimedMessages : Form {
        public string File;

        public TimedMessages() {
            InitializeComponent();
        }

        private void timedMessages_Load(object sender, EventArgs e) {
            var fileReader = new StreamReader(File);
            textBox1.Text = fileReader.ReadToEnd();
            fileReader.Close();
        }
    }
}
