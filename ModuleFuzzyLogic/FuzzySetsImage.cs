using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modules.ModuleFuzzyLogic.Methods;
using Common.DataTypes;

namespace Modules.ModuleFuzzyLogic
{
    public partial class FuzzySetsImage : Form
    {
        FuzzySetsImageMethod method;
        Dictionary<double, double> OperSet = new Dictionary<double, double>();
        Dictionary<double, double>[] SubSet = new Dictionary<double,double>[100];
        Dictionary<double, double> SetC = new Dictionary<double, double>();
        int sizeSet = 1;
        private static Random rand = new Random();
        public FuzzySetsImage()
        {
            InitializeComponent();
            dataGridViewSets.RowCount = 2;
            comboBoxClearImage.Enabled = false;
            numericUpDownClearImage.Enabled = false;
            comboBoxFuzzyImage.Enabled = false;
            numericUpDownFuzzyImage.Enabled = false;
            radioButtonRatio.Enabled = false;
            radioButtonSubsets.Enabled = false;
            dataGridViewFuzzyImage.Enabled = false;
            dataGridViewSetC.Enabled = false;
            //textBoxRatio.Enabled = false;
            numericUpDowSetC.Enabled = false;
            numericUpDownSizeSubset.Enabled = false;
            dataGridViewSets.Rows[0].HeaderCell.Value = "x";
            dataGridViewSets.Rows[1].HeaderCell.Value = "m(x)";
            comboBoxClearImage.SelectedIndex = 0;
            comboBoxFuzzyImage.SelectedIndex = 0;
         
           
            method = new FuzzySetsImageMethod();
        }
 
        private void FuzzySetsImage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewSets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void numericUpDownElements_ValueChanged(object sender, EventArgs e)
        {
            dataGridViewSets.ColumnCount = (int)numericUpDownElements.Value;
            foreach (DataGridViewCell cell in dataGridViewSets.Rows[0].Cells)
            {
                cell.Value = (rand.Next(1, 100)).ToString("0");
            }
            foreach (DataGridViewCell cell in dataGridViewSets.Rows[1].Cells)
             {
                cell.Value = (1.0 / rand.Next(1, 100)).ToString("0.00"); 
             }
        }

        private void radioButtonClear_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownClearImage.Enabled = true;
            comboBoxClearImage.Enabled = true;
            radioButtonRatio.Enabled = false;
            radioButtonSubsets.Enabled = false;
            dataGridViewFuzzyImage.Enabled = false;
            dataGridViewSetC.Enabled = false;
            numericUpDowSetC.Enabled = false;
            numericUpDownSizeSubset.Enabled = false;
        }

        private void radioButtonFuzzy_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxClearImage.Enabled = false;
            numericUpDownClearImage.Enabled = false;
            radioButtonRatio.Enabled = true;
            radioButtonSubsets.Enabled = true;
            dataGridViewFuzzyImage.Enabled = false;
            dataGridViewSetC.Enabled = false;
            comboBoxFuzzyImage.Enabled = false;
            numericUpDownFuzzyImage.Enabled = false;
            numericUpDowSetC.Enabled = false;
            numericUpDownSizeSubset.Enabled = false;
        }

        private void dataGridViewFuzzyImage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSubsets_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewFuzzyImage.Enabled = true;
            numericUpDownSizeSubset.Enabled = true;
            numericUpDownClearImage.Enabled = false;
            comboBoxClearImage.Enabled = false;
            dataGridViewSetC.Enabled = false;
            comboBoxFuzzyImage.Enabled = false;
            numericUpDownFuzzyImage.Enabled = false;
            numericUpDowSetC.Enabled = false;
            
            sizeSet = (int)numericUpDownElements.Value;
            dataGridViewFuzzyImage.RowCount = 2 * sizeSet;
            for(int i=0; i<2*sizeSet; i+=2)
            {
                dataGridViewFuzzyImage.Rows[i].HeaderCell.Value = "x";
                dataGridViewFuzzyImage.Rows[i+1].HeaderCell.Value = "m(x)";
            }
        }

        private void radioButtonRatio_CheckedChanged(object sender, EventArgs e)
        {
            dataGridViewFuzzyImage.Enabled = false;
            comboBoxFuzzyImage.Enabled = true;
            numericUpDownFuzzyImage.Enabled = true;
            numericUpDownSizeSubset.Enabled = false;
            numericUpDownClearImage.Enabled = false;
            comboBoxClearImage.Enabled = false;
            dataGridViewSetC.Enabled = true;
            numericUpDowSetC.Enabled = true;
            
            dataGridViewSetC.RowCount = 2;
            dataGridViewSetC.Rows[0].HeaderCell.Value = "x";
            dataGridViewSetC.Rows[1].HeaderCell.Value = "m(x)";
            
        }
        private void buttonProsses_Click(object sender, EventArgs e)
        {
            getSet();
            if(radioButtonClear.Checked)
            {
                double koef = (double)numericUpDownClearImage.Value;
                int func = comboBoxClearImage.SelectedIndex;
                showResult(method.resultClearImage(OperSet, func, koef));
                
            }
            if(radioButtonSubsets.Checked)
                {
                   int i = 0;
                   int sizeSet1 = (int)numericUpDownElements.Value;
                    for (int rows = 0; rows < dataGridViewFuzzyImage.Rows.Count; rows+=2)
                    {
                        for (int col = 0; col < dataGridViewFuzzyImage.Rows[rows].Cells.Count; col++)
                        {
                            double a, b;
                            a = Convert.ToDouble(dataGridViewFuzzyImage.Rows[rows].Cells[col].Value);
                            b = Convert.ToDouble(dataGridViewFuzzyImage.Rows[rows+1].Cells[col].Value);

                            if(SubSet[i] == null)
                                SubSet[i] = new Dictionary<double,double>();
                            SubSet[i].Add(a, b);
                            
                        }
                      i++;
                    } 
                    showResult(method.resultFuzzyImage1(SubSet, OperSet, sizeSet1));
                }
             if(radioButtonRatio.Checked)
                {
                    for (int col = 0; col < dataGridViewSetC.Rows[0].Cells.Count; col++)
                    {
                        double a, b;
                        a = Convert.ToDouble(dataGridViewSetC.Rows[0].Cells[col].Value);
                        b = Convert.ToDouble(dataGridViewSetC.Rows[1].Cells[col].Value);
                        SetC.Add(a, b);
                    }
                    double koef = (double)numericUpDownFuzzyImage.Value;
                    int func = comboBoxFuzzyImage.SelectedIndex;
                    showResult(method.resultFuzzyImage2(OperSet, SetC, func, koef));
                }
         }
       
        public void showResult(Dictionary<double, double> res)
        {
            dataGridViewAnswer.Columns.Add("x", "x");
            dataGridViewAnswer.Rows.Add("Key", "x");
            dataGridViewAnswer.Rows.Add("Values", "m(x)");
            int i = 0;
            foreach (KeyValuePair<double, double> item in res)
            {

                 if(i != 0) dataGridViewAnswer.Columns.Add("x", "");
                 dataGridViewAnswer.Rows[0].Cells[i].Value = Math.Round(item.Key, 2);
                 dataGridViewAnswer.Rows[1].Cells[i].Value = Math.Round(item.Value, 2);
                 i++;
                 
            }
        }
       
        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        private Dictionary<double, double> getSet()
        {
            for (int col = 0; col < dataGridViewSets.Rows[0].Cells.Count; col++)
            {
                double a, b;
                a = Convert.ToDouble(dataGridViewSets.Rows[0].Cells[col].Value);
                b = Convert.ToDouble(dataGridViewSets.Rows[1].Cells[col].Value);
                OperSet.Add(a, b);
            }
            return OperSet;
        }
        
        private void numericUpDownSizeSubset_ValueChanged(object sender, EventArgs e)
        {
            dataGridViewFuzzyImage.ColumnCount = (int)numericUpDownSizeSubset.Value;
            sizeSet = (int)numericUpDownElements.Value;
            for(int i = 0; i < 2*sizeSet; i+=2)
            {
            foreach (DataGridViewCell cell in dataGridViewFuzzyImage.Rows[i].Cells)
            {
                cell.Value = (rand.Next(1, 100)).ToString("0");
            }
            foreach (DataGridViewCell cell in dataGridViewFuzzyImage.Rows[i+1].Cells)
            {
                cell.Value = (1.0 / rand.Next(1, 100)).ToString("0.00");
            }
            }

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            OperSet = new Dictionary<double, double>();
            SubSet = new Dictionary<double, double>[100];
            SetC = new Dictionary<double, double>();
           
            dataGridViewSets.Rows.Clear();
            dataGridViewSets.Columns.Clear();
            dataGridViewSets.RowCount = 2;
            dataGridViewSets.Rows[0].HeaderCell.Value = "x";
            dataGridViewSets.Rows[1].HeaderCell.Value = "m(x)";
            numericUpDownElements.Value = 1;
            numericUpDownClearImage.Value = 0;
            numericUpDownClearImage.Enabled = false;
            comboBoxClearImage.SelectedIndex = 0;
            comboBoxClearImage.Enabled = false;
            dataGridViewAnswer.Rows.Clear();
            dataGridViewAnswer.Columns.Clear();
            dataGridViewSetC.Enabled = false;
            numericUpDowSetC.Value = 1;
            comboBoxFuzzyImage.SelectedIndex = 0;
            comboBoxFuzzyImage.Enabled = false;
            numericUpDownFuzzyImage.Value = 0;
            numericUpDownFuzzyImage.Enabled = false;
            dataGridViewFuzzyImage.Enabled = false;
            numericUpDownSizeSubset.Enabled = false;
            
            
            if(radioButtonRatio.Checked)
            {
                SetC = new Dictionary<double, double>();
                dataGridViewSetC.Rows.Clear();
                dataGridViewSetC.Columns.Clear();
                dataGridViewSetC.RowCount = 2;
                dataGridViewSetC.Rows[0].HeaderCell.Value = "x";
                dataGridViewSetC.Rows[1].HeaderCell.Value = "m(x)";
                
            }
            if(radioButtonSubsets.Checked)
            {
               
                numericUpDownSizeSubset.Value = 1;
                dataGridViewFuzzyImage.Rows.Clear();
                dataGridViewFuzzyImage.Columns.Clear();
                

            }
            radioButtonRatio.Enabled = false;
            radioButtonSubsets.Enabled = false;
            radioButtonRatio.Checked = false;
            radioButtonSubsets.Checked = false;

            
        }

        private void dataGridViewSets_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                string userInput = e.FormattedValue.ToString();
                double userValue;
                bool isNumeric = double.TryParse(userInput, out userValue);
                if ((!isNumeric) && userInput != "")
                {
                    // may be alert of error
                    e.Cancel = true;
                    MessageBox.Show("Некорректний ввід! Лише числа!");
                }
            }
            else
            {
                string userInput = e.FormattedValue.ToString();
                double userValue;
                bool isNumeric = double.TryParse(userInput, out userValue);
                if ((!isNumeric || userValue < 0 || userValue > 1) && userInput != "")
                {
                    // may be alert of error
                    e.Cancel = true;
                    MessageBox.Show("Wrong input! Number must be less than 1 and bigger than 0!");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDowSetC_ValueChanged(object sender, EventArgs e)
        {
            dataGridViewSetC.ColumnCount = (int)numericUpDowSetC.Value;
            foreach (DataGridViewCell cell in dataGridViewSetC.Rows[0].Cells)
            {
                cell.Value = (rand.Next(1, 10)).ToString("0");
            }
            foreach (DataGridViewCell cell in dataGridViewSetC.Rows[1].Cells)
            {
                cell.Value = (1.0 / rand.Next(1, 10)).ToString("0.00");
            }
        }

        private void dataGridViewSetC_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == 0) return;
            string userInput = e.FormattedValue.ToString();
            double userValue;
            bool isNumeric = double.TryParse(userInput, out userValue);
            if ((!isNumeric || userValue < 0 || userValue > 1) && userInput != "")
            {
                // may be alert of error
                e.Cancel = true;
                MessageBox.Show("Wrong input! Number must be less than 1 and bigger than 0!");
            }
        }

        private void dataGridViewAnswer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAddB_Click(object sender, EventArgs e)
        {
            Matrix<double> m = new Matrix<double>(ToDouble(dataGridViewAnswer));
            Common.DataBuffer.Instance.SaveDialog(m);
        }
        public static double[,] ToDouble( DataGridView gridView)
        {
            int matrixSize = gridView.ColumnCount;
            double[,] result = new double[2, matrixSize];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result[i, j] = double.Parse(gridView[j, i].Value.ToString());
                }
            }
            return result;
        }
        
        private void loadMatrixFromBuffer(BufferData buff)
        {
            Matrix<double> t = (Matrix<double>)buff;
            dataGridViewSets.RowCount = t.RowCount;
            dataGridViewSets.ColumnCount = t.ColumnCount;
            foreach (DataGridViewRow row in dataGridViewSets.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = t.Value[cell.ColumnIndex, cell.RowIndex];
                }
        }
        public bool ValidationCallbackDelegate(BufferData obj)
        {
            if (obj is Matrix<double>)
            {
                Matrix<double> m = (Matrix<double>)obj;
                if(m.Value.GetLength(0) != 2) return false;
                if(m.Value.GetLength(1) != (int)numericUpDownElements.Value)
                for (int j = 0; j < m.Value.GetLength(1); j++)
                    if (m[1, j] > 1 || m[1, j] < 0)
                        return false;
                
                return true;
            }
            else
                return false;
        }

        private void buttonLoadB_Click(object sender, EventArgs e)
        {
            BufferData t = Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegate);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали матрицю");
            else
                loadMatrixFromBuffer(t);
        }

    }
}
