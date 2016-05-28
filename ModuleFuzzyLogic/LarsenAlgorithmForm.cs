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
            if (e.FormattedValue.Equals(String.Empty)) return;

            string[] nums = e.FormattedValue.ToString().Split(new char[] { '/' });
            if (nums.Length != 2) {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "Values should be in VALUE/PROBABILITY format";
                return;
            }
       
            double value, prob;
            if (!Double.TryParse(nums[0], out value)) {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "Value should be real number";
                return;
            }
            if (!Double.TryParse(nums[1], out prob) || !(0 <= prob && prob <= 1)) {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "Probability should be real number between 0 and 1";
                return;
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
