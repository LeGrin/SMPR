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
    public partial class frmMamdaniAlgorithm : Form
    {
        public frmMamdaniAlgorithm()
        {
            InitializeComponent();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SortCompare += CellValueValidator.SortCompare;
        }

        private void onCellValidation(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                CellValueValidator.ValidateValue(e.FormattedValue.ToString());
            }
            catch (ArgumentException ex)
            {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = ex.Message;
            }
        }
        void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;
        }

        private void onCompute(object sender, EventArgs e)
        {
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
            InputBox prompt = new InputBox(Resourses.LocalStrings.GetX0);
            do
            {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out x0));

            prompt = new InputBox(Resourses.LocalStrings.GetY0);
            do
            {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out y0));

            Methods.MamdaniAlgorithm algo = new Methods.MamdaniAlgorithm();

            List<Tuple<FuzzySet1D, FuzzySet1D>> conditions = new List<Tuple<FuzzySet1D, FuzzySet1D>>();
            List<FuzzySet1D> conclusions = new List<FuzzySet1D>();

            conditions.Add(new Tuple<FuzzySet1D, FuzzySet1D>(A1, B1));
            conditions.Add(new Tuple<FuzzySet1D, FuzzySet1D>(A2, B2));

            conclusions.Add(C1);
            conclusions.Add(C2);

            double ans = algo.calcAnswer(conditions, conclusions, x0, y0);

            MessageBox.Show("z0 = " + ans.ToString());
        }


        private void onGenRandom(object sender, EventArgs e)
        {
            CellValueValidator.CreateRandomSets(dataGridView1, 6);
        }

        private void onClearRows(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void onSaveToBuffer(object sender, EventArgs e)
        {
            List<KeyValuePair<string, int>> vals = new List<KeyValuePair<string, int>> {
                new KeyValuePair<string, int>("A1", 0),
                new KeyValuePair<string, int>("A2", 1),
                new KeyValuePair<string, int>("B1", 2),
                new KeyValuePair<string, int>("B2", 3),
                new KeyValuePair<string, int>("C1", 4),
                new KeyValuePair<string, int>("C2", 5)
            };

            InputComboBox prompt = new InputComboBox(Resourses.LocalStrings.ChooseSet);
            prompt.SetItems<int>(vals);
            if (prompt.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int colNum = prompt.GetValue<int>();

            FuzzySet1D set = CellValueValidator.DecipherSet(dataGridView1, colNum);
            if (set == null) return;

            Common.DataTypes.Matrix<double> m = new Common.DataTypes.Matrix<double>(set.toMassiv());
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void onLoadFromBuffer(object sender, EventArgs e)
        {
            List<KeyValuePair<string, int>> vals = new List<KeyValuePair<string, int>> {
                new KeyValuePair<string, int>("A1", 0),
                new KeyValuePair<string, int>("A2", 1),
                new KeyValuePair<string, int>("B1", 2),
                new KeyValuePair<string, int>("B2", 3),
                new KeyValuePair<string, int>("C1", 4),
                new KeyValuePair<string, int>("C2", 5)
            };

            InputComboBox prompt = new InputComboBox(Resourses.LocalStrings.ChooseSet);
            prompt.SetItems<int>(vals);
            if (prompt.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int colNum = prompt.GetValue<int>();

            Common.DataTypes.BufferData t = Common.DataBuffer.Instance.LoadDialog(FuzzySets.FuzzySet1D.ValidationCallback);
            if (t == null) return;

            FuzzySets.FuzzySet1D setB = new FuzzySets.FuzzySet1D(((Common.DataTypes.Matrix<double>)t).Value);
            CellValueValidator.FromFuzzySetToDataGridView(dataGridView1, colNum, setB);
        }
    }
}
