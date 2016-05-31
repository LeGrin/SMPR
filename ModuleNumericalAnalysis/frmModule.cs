using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modules.ModuleNumericalAnalysis
{
    public partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
        }

        private void btnFixedPointIteration_Click(object sender, EventArgs e)
        {
            new frmFixedPointIteration().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmSeidelMethod().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmPicardIteration().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmParameterContinuation().Show();
        }
    }
}
