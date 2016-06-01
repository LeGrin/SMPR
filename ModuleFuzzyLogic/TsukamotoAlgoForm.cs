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
    public partial class TsukamotoAlgoForm : Form
    {
        public TsukamotoAlgoForm() {
            InitializeComponent();

            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.SortCompare += CellValueValidator.SortCompare;
        }

         private void TsukamotoAlgoForm_Load(object sender, EventArgs e)
        {

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
                dataGridView2.Rows[e.RowIndex].ErrorText = ex.Message;
            }
        }
        private void onCompute(object sender, EventArgs e)
        {
            FuzzySet1D A1 = CellValueValidator.DecipherSet(dataGridView2, 0);
            FuzzySet1D A2 = CellValueValidator.DecipherSet(dataGridView2, 1);
            FuzzySet1D B1 = CellValueValidator.DecipherSet(dataGridView2, 2);
            FuzzySet1D B2 = CellValueValidator.DecipherSet(dataGridView2, 3);
            FuzzySet1D C1 = CellValueValidator.DecipherSet(dataGridView2, 4);
            FuzzySet1D C2 = CellValueValidator.DecipherSet(dataGridView2, 5);
            if (A1 == null || B1 == null || C1 == null
                || A2 == null || B2 == null || C2 == null) return;
            
            KeyValuePair<double, double>[] check1 = new SortedDictionary<double, double>(C1.Dots).ToArray();
            KeyValuePair<double, double>[] check2 = new SortedDictionary<double, double>(C2.Dots).ToArray();
            Boolean boolCheckC1 = boolCheck(check1);
            Boolean boolCheckC2 = boolCheck(check2);
            

            DialogResult dialRes;
            double x0, y0;
            InputBox prompt = new InputBox("Введіть значення X0");
            do
            {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out x0));

            prompt = new InputBox("Введіть значення Y0");
            do
            {
                dialRes = prompt.ShowDialog();
                if (dialRes != System.Windows.Forms.DialogResult.OK) return;
            } while (!Double.TryParse(prompt.Value, out y0));

            List<Tuple<FuzzySet1D, FuzzySet1D>> conditions = new List<Tuple<FuzzySet1D, FuzzySet1D>>();
            List<FuzzySet1D> conclusions = new List<FuzzySet1D>();

           Methods.TsucamotoAlgo algo = new Methods.TsucamotoAlgo();
           double z0 = 0.0;
           if (boolCheckC1 && boolCheckC2)
           {
               z0 = algo.CalcAlgo(A1, A2, B1, B2, C1, C2, x0, y0);
               MessageBox.Show("z0 = " + z0);
           }
           else if (!boolCheckC1 && !boolCheckC2)
               MessageBox.Show("C1 і C2 не монотонні.");
           else if (boolCheckC1)
               MessageBox.Show("C2 не монотонна.");
           else if (boolCheckC2)
               MessageBox.Show("C1 не монотонна.");
             
        }

        private bool boolCheck(KeyValuePair<double, double>[] check1)
        {
            Boolean znak = true;
            Boolean n = true;
            if(check1.Length>1)
                if (check1[0].Value < check1[1].Value)
                 znak = false;
            for (int i = 0; i < check1.Length - 1; i++)
            {
                if (znak)
                {
                    if (check1[i].Value < check1[i + 1].Value)
                        n = false;
                }
                else
                {
                    if (check1[i].Value > check1[i + 1].Value)
                        n = false;
                }
            }
            return n;
        }


        private void onGenRandom(object sender, EventArgs e)
        {
            CellValueValidator.CreateRandomSets(dataGridView2, 6);
        }

        private void onClearRows(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
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

            InputComboBox prompt = new InputComboBox("Виберіть множину");
            prompt.SetItems<int>(vals);
            if (prompt.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int colNum = prompt.GetValue<int>();

            FuzzySet1D set = CellValueValidator.DecipherSet(dataGridView2, colNum);
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

            InputComboBox prompt = new InputComboBox("Виберіть множину");
            prompt.SetItems<int>(vals);
            if (prompt.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            int colNum = prompt.GetValue<int>();

            Common.DataTypes.BufferData t = Common.DataBuffer.Instance.LoadDialog(FuzzySets.FuzzySet1D.ValidationCallback);
            if (t == null) return;

            FuzzySets.FuzzySet1D setB = new FuzzySets.FuzzySet1D(((Common.DataTypes.Matrix<double>)t).Value);
            CellValueValidator.FromFuzzySetToDataGridView(dataGridView2, colNum, setB);
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            dataGridView2.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
