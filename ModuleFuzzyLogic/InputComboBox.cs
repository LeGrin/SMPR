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
    public partial class InputComboBox : Form
    {
        public InputComboBox(string label) {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            label1.Text = label;
        }
        
        public void SetItems<F>(List<KeyValuePair<string, F>> values) {
            comboBox1.DataSource = values;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Key";
        }

        public T GetValue<T>() {
            return ((KeyValuePair<string, T>)comboBox1.SelectedItem).Value;
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Visible = false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                e.Handled = true;
                buttonOk_Click(this, new EventArgs());
            } else if (e.KeyChar == (char)Keys.Escape) {
                e.Handled = true;
                buttonCancel_Click(this, new EventArgs());
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Visible = false;
        }


    }
}
