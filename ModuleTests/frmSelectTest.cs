using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.Tests
{
    partial class frmSelectTest : Form
    {
        public List<Method> methods = new List<Method>();

        public Method SelectedMethod 
        {
            get 
            {
                return comboBox1.SelectedItem as Method;
            }
        }

        public frmSelectTest(List<Method> methods)
        {
            InitializeComponent();
            comboBox1.DataSource = methods;
        }

        /// <summary>
        /// Run TestForm with OptimistTest.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("You must choose some test!", "Error!", MessageBoxButtons.OK);
                return;
            }
            Method method1=comboBox1.SelectedItem as Method;
            if (method1 == null)
                MessageBox.Show("Sorry! Couldn't find test \"" + comboBox1.Text + "\"!\n Try another please...",
                                "Error!", MessageBoxButtons.OK);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}