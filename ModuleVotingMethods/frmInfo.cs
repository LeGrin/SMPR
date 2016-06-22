using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Modules.VotingMethods
{
    public partial class frmInfo : Form
    {
        public frmInfo(String st)
        {
           InitializeComponent();
           richTextBox1.Rtf = Properties.Resources.ResourceManager.GetString(st);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}