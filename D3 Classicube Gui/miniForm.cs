using System;
using System.Windows.Forms;

namespace D3_Classicube_Gui {
    public partial class MiniForm : Form {
        public Form1 Mainform;
        public MiniForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Mainform.Show();
            Close();
        }

        private void miniForm_Load(object sender, EventArgs e) {

        }
    }
}
