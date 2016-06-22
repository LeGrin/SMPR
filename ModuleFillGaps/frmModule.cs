using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.ModuleCooperativeProblemSolving.Methods;

namespace Modules.ModuleCooperativeProblemSolving
{
    public partial class frmModule : Form
    {
        Strategies strategies;

        public frmModule()
        {
            InitializeComponent();
        }

        private void frmModule_Load(object sender, EventArgs e)
        {
            strategies = new Strategies(this);
            strategies.PlayerCount = 2;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            strategies.PlayerCount = (int)numericUpDown1.Value;
        }

        private void frmModule_Resize(object sender, EventArgs e)
        {
            if (ClientSize.Width - 10 > wins.Left)
                wins.Width = ClientSize.Width - 10 - wins.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Method m = new MethodSNE();
            m.Init(strategies);
            m.Execute();
            resultsBox.Text = m.ResultComment;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Method m = new MethodAK();
            m.Init(strategies);
            m.Execute();
            resultsBox.Text = m.ResultComment;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Method m = new MethodBK();
            m.Init(strategies);
            m.Execute();
            resultsBox.Text = m.ResultComment;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
