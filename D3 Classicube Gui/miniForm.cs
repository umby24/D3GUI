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
    public partial class miniForm : Form {
        public Form1 Mainform;
        public miniForm() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            Mainform.Show();
            this.Close();
        }

        private void miniForm_Load(object sender, EventArgs e) {

        }
    }
}
