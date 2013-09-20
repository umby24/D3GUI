using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace D3_Classicube_Gui {
    public partial class timedMessages : Form {
        public string file;
        public timedMessages() {
            InitializeComponent();
        }
        private void formClosing(object sender, FormClosingEventArgs e) {
            StreamWriter fileWriter = new StreamWriter(file);
            fileWriter.Write(textBox1.Text);
            fileWriter.Close();
        }

        private void timedMessages_Load(object sender, EventArgs e) {
            StreamReader fileReader = new StreamReader(file);
            textBox1.Text = fileReader.ReadToEnd();
            fileReader.Close();
        }
    }
}
