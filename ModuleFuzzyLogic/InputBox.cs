using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modules.ModuleFuzzyLogic
{
    public partial class InputBox : Form
    {
        public InputBox(string label, bool nullable = true) {
            InitializeComponent();

            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            label1.Text = label;
            if (!nullable)
                textBox1.Validating += textBox1_Validating;
        }

        public string Value {
            get {
                return textBox1.Text;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e) {
            if (textBox1.Text.Equals(string.Empty))
                e.Cancel = true;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Visible = false;
        }
    }
}
