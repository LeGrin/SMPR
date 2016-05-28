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
    public partial class LarsenAlgorithmForm : Form
    {
        public LarsenAlgorithmForm() {
            InitializeComponent();
        }

        private void onCellValidation(object sender, DataGridViewCellValidatingEventArgs e) {
            try {
                CellValueValidator.ValidateValue(e.FormattedValue.ToString());
            } catch (ArgumentException ex) {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = ex.Message;
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e) {

        }
    }
}
