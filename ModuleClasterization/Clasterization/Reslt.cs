using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clasterization
{
    public partial class Reslt : Form
    {
        public Reslt()
        {
            InitializeComponent();
        }

        public void Write(String a){
            richTextBox1.AppendText(a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
