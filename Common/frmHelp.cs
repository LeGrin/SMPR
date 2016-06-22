using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();            
        }

        public static void ShowHelp(string helpString)
        {
            frmHelp hp = new frmHelp();
            //MessageBox.Show(helpString);
            hp.rtbHelp.Rtf = helpString;
            hp.Show();
        }

        public static void ShowCHMHelp(string chmPath)
        {
            System.Diagnostics.Process.Start(chmPath);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}