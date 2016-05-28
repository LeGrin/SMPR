using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuzzySets;

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
            FuzzySet1D A1 = CellValueValidator.DecipherSet(dataGridView1, 0);
            FuzzySet1D A2 = CellValueValidator.DecipherSet(dataGridView1, 1);
            FuzzySet1D B1 = CellValueValidator.DecipherSet(dataGridView1, 2);
            FuzzySet1D B2 = CellValueValidator.DecipherSet(dataGridView1, 3);
            FuzzySet1D C1 = CellValueValidator.DecipherSet(dataGridView1, 4);
            FuzzySet1D C2 = CellValueValidator.DecipherSet(dataGridView1, 5);
            if (A1 == null || B1 == null || C1 == null
                || A2 == null || B2 == null || C2 == null) return;

            DialogResult dialRes;
            double x0, y0;
            InputBox prompt = new InputBox("Введіть значення X0");
            do {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out x0));

            prompt = new InputBox("Введіть значення Y0");
            do {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out y0));

            Methods.LarsenAlgo algo = new Methods.LarsenAlgo();
            
            //algo.Defuzzificate();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            CellValueValidator.CreateRandomSets(dataGridView1, 6);
        }
    }
}
