using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.Tests
{
    partial class frmModule : Form
    {
        /// <summary>
        /// Form which show for user question and variants of answers on it.
        /// </summary>
        private TestsForm FormTest;
        /// <summary>
        /// List of Method's names.
        /// </summary>
        private List<string> NamesOfMethods = new List<string>();
        public List<Method> methods = new List<Method>();

        public frmModule()
        {
            InitializeComponent();
           
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
            Method method1=null;
            foreach (Method method in methods) // List Methods: I hasn't access!!!
            {
                if (comboBox1.Text == method.Name)
                    method1 = method;
            }
            if (method1 != null)
                RunTestWithMethod(method1);
            else
                MessageBox.Show("Sorry! Couldn't find test \"" + comboBox1.Text + "\"!\n Try another please...",
                                "Error!", MessageBoxButtons.OK);
        }
        /// <summary>
        /// RunTest function.
        /// It creates, loads data for it and shows new TestForm.
        /// </summary>
        /// <param name="Method">Method for which TestForm will be run.</param>
        public void RunTestWithMethod(Method Method)
        {
            FormTest = new TestsForm();
            FormTest.CurrentMethod = Method;
            FormTest.CurrentMethod.InitMethod();
            FormTest.LoadDataFromMethod();                        
            FormTest.ShowDialog();
        }

        private void frmModule_Load(object sender, EventArgs e)
        {
           
            foreach (Method method in methods)
            {
                NamesOfMethods.Add(method.Name);
            }
            comboBox1.DataSource = NamesOfMethods;
        }
    }
}