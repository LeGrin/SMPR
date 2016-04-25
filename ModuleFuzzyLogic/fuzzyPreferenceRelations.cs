using Common.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleFuzzyLogic
{
    public partial class fuzzyPreferenceRelations : Form
    {
        public fuzzyPreferenceRelations()
        {
            InitializeComponent();
               
        }
        private int elementsCount;
        private bool blockValidating = false;
        private double[,] laxPreferencesMatrix;
        private double[,] strictPreferencesMatrix;
        private double[,] indifferenceMatrix;
        private double[,] quasiEquivalentMatrix;
        private double[] degreeOfPermissibilityArray;
        private double[] nonDominatedSetArray;



        private void resizeMatrixInDataGridView(int n, DataGridView dataGridView)
        {
            while (dataGridView.Columns.Count < n + 1)
            {
                string nm = "X" + dataGridView.Columns.Count;
                if (dataGridView.Columns.Count == 0)
                    nm = "";
                dataGridView.Columns.Add(nm, nm);
                dataGridView.Columns[dataGridView.Columns.Count - 1].Width = 35;
            }
            while (dataGridView.Columns.Count > n + 1)
            {
                dataGridView.Columns.RemoveAt(dataGridView.Columns.Count - 1);
            }

            while (dataGridView.RowCount > n)
            {
                dataGridView.Rows.RemoveAt(dataGridView.RowCount - 1);
            }

            while (dataGridView.RowCount < n)
            {
                string nm = "X" + (dataGridView.Rows.Count+1);
                dataGridView.Rows.Add();
                dataGridView[0, dataGridView.RowCount - 1].Value = nm;
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    dataGridViewLaxPreferences[j, i].ReadOnly = false;
                }
            }
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void changeMatrixSize(int n)
        {
            blockValidating = true;
            int oldN = dataGridViewLaxPreferences.Columns.Count-1;
            resizeMatrixInDataGridView(n, dataGridViewLaxPreferences);
            Random generator = new Random();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i < oldN && j < oldN) continue;
                    if (i == j)
                    {
                        dataGridViewLaxPreferences[i + 1, j].Value = 1;
                    }
                    else
                    {
                        dataGridViewLaxPreferences[i + 1, j].Value = generator.Next(0, 100) / 100.0;
                    }
                }
            }
            for (int i = 0; i < n; ++i)
            {
                dataGridViewLaxPreferences[0, i].ReadOnly = true;
                dataGridViewLaxPreferences[i+1, i].ReadOnly = true;
            }
            blockValidating = false;

            refreshLaxPreferencesMatrix();
        }

        private void numericUpAndDownElementsCount_ValueChanged(object sender, EventArgs e)
        {
            elementsCount = decimal.ToInt32(numericUpAndDownElementsCount.Value);
            if (elementsCount > 12)
            {
                elementsCount = 12;
                numericUpAndDownElementsCount.Value = 12;
            }
            changeMatrixSize(elementsCount);
            rerender();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            for (int i = 0; i < elementsCount; i++)
            {
                for (int j = 0; j < elementsCount; j++)
                {
                    if (i == j)
                    {
                        dataGridViewLaxPreferences[i + 1, j].Value = 1;
                    }
                    else
                    {
                        dataGridViewLaxPreferences[i + 1, j].Value = generator.Next(0, 100) / 100.0;
                    }
                }
            }
            rerender();
        }

        private void refreshLaxPreferencesMatrix()
        {
            int n = this.elementsCount;
            laxPreferencesMatrix = new double[n,n];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Double.TryParse(dataGridViewLaxPreferences[j+1,i].Value.ToString(), out laxPreferencesMatrix[i,j]);
                }
            }
        }

        private void refreshStrictPreferencesMatrix()
        {
            refreshLaxPreferencesMatrix();
            strictPreferencesMatrix = new double[elementsCount,elementsCount];
            int n = elementsCount;
            for (int i = 0;i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    double x = laxPreferencesMatrix[i,j];
                    double y = laxPreferencesMatrix[j,i];
                    if (x>=y)
                    {
                        strictPreferencesMatrix[i, j] = x - y;
                    }
                    else
                    {
                        strictPreferencesMatrix[i, j] = 0;
                    }
                }
            }
        }

        private void renderDataGridViewFromMatrix(double[,] matrix, DataGridView dataGridView)
        {
            resizeMatrixInDataGridView(elementsCount, dataGridView);
            int n = elementsCount;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    dataGridView[j + 1, i].Value = matrix[i,j];
                }
            }
        }

        private void renderStrictPreferences()
        {
            refreshStrictPreferencesMatrix();
            renderDataGridViewFromMatrix(strictPreferencesMatrix, dataGridViewStrictPreferences);
        }

        private void refreshIndifferenceMatrix()
        {
            refreshLaxPreferencesMatrix();
            indifferenceMatrix = new double[elementsCount, elementsCount];
            int n = elementsCount;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    double x = laxPreferencesMatrix[i, j];
                    double y = laxPreferencesMatrix[j, i];
                    indifferenceMatrix[i, j] = Math.Max(1-Math.Max(x,y),Math.Min(x,y));
                }
            }
        }
        private void renderIndifference()
        {
            refreshIndifferenceMatrix();

            renderDataGridViewFromMatrix(indifferenceMatrix, dataGridViewIndifference);
        }

        private void refreshQuasiEquivalentMatrix()
        {
            refreshLaxPreferencesMatrix();
            quasiEquivalentMatrix = new double[elementsCount, elementsCount];
            int n = elementsCount;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    double x = laxPreferencesMatrix[i, j];
                    double y = laxPreferencesMatrix[j, i];
                    quasiEquivalentMatrix[i, j] = Math.Min(x, y);
                }
            }

        }
        private void renderQuasiEquivalent()
        {
            refreshQuasiEquivalentMatrix();

            renderDataGridViewFromMatrix(quasiEquivalentMatrix, dataGridViewQuasiEquivalence);
        }
        private void refreshNonDominatedSet()
        {
        }

        private void renderNonDominatedSet()
        {
            blockValidating = true;
            int oldN = dataGridViewDegreeOfPermissibility.Columns.Count;
            int n = elementsCount;

            while (dataGridViewDegreeOfPermissibility.Columns.Count > n)
            {
                dataGridViewDegreeOfPermissibility.Columns.RemoveAt(dataGridViewDegreeOfPermissibility.Columns.Count - 1);
            }

            while (dataGridViewDegreeOfPermissibility.Columns.Count < n)
            {
                string nm = "X" + (dataGridViewDegreeOfPermissibility.Columns.Count + 1);
                dataGridViewDegreeOfPermissibility.Columns.Add(nm, nm);
                dataGridViewDegreeOfPermissibility.Columns[dataGridViewDegreeOfPermissibility.Columns.Count - 1].Width = 35;
            }


            
            while (n>0 && dataGridViewDegreeOfPermissibility.RowCount < 1)
            {
                dataGridViewDegreeOfPermissibility.Rows.Add();
            }

            for (int i = oldN; i < n; ++i)
            {
                dataGridViewDegreeOfPermissibility[i, 0].Value = "1";
                dataGridViewDegreeOfPermissibility[i, 0].ReadOnly = false;
            }






            refreshLaxPreferencesMatrix();
            
            nonDominatedSetArray = new double[n];
            for (int i = 0; i < n; ++i)
            {
                double q = 0;
                for (int j = 0; j < n; ++j)
                {
                    double x = laxPreferencesMatrix[i, j];
                    double y = laxPreferencesMatrix[j, i];
                    q = Math.Max(q, y - x);
                }
                nonDominatedSetArray[i] = 1-q;
            }





            while (dataGridViewNonDominatedSet.Columns.Count > n)
            {
                dataGridViewNonDominatedSet.Columns.RemoveAt(dataGridViewNonDominatedSet.Columns.Count - 1);
            }

            while (dataGridViewNonDominatedSet.Columns.Count < n)
            {
                string nm = "X" + (dataGridViewNonDominatedSet.Columns.Count + 1);
                dataGridViewNonDominatedSet.Columns.Add(nm, nm);
                dataGridViewNonDominatedSet.Columns[dataGridViewNonDominatedSet.Columns.Count - 1].Width = 35;
                
            }

            while (n>0 && dataGridViewNonDominatedSet.RowCount < 1)
            {
                dataGridViewNonDominatedSet.Rows.Add();
            }

            for (int i = 0; i < n; ++i)
            {
                dataGridViewNonDominatedSet[i, 0].ReadOnly = true;
                dataGridViewNonDominatedSet[i, 0].Value = nonDominatedSetArray[i];

            }


            double bestDegreeOfNonDomination = -1;
            int bestAlternative = 0;
            for (int i = 0; i < n; ++i)
            {
                double q = Math.Min(nonDominatedSetArray[i], Double.Parse(dataGridViewDegreeOfPermissibility[i, 0].Value.ToString()));
                if (q>bestDegreeOfNonDomination)
                {
                    bestDegreeOfNonDomination = q;
                    bestAlternative = i;
                }
            }

            textBoxBestAlternative.Text = "X" + (bestAlternative + 1);
            textBoxDegreeOfNonDomination.Text = bestDegreeOfNonDomination.ToString();
            blockValidating = false;
        }


        private void dataGridViewMu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (blockValidating) return;
            string w = dataGridViewLaxPreferences[e.ColumnIndex, e.RowIndex].Value.ToString();
            double q;
            
            string str = dataGridViewLaxPreferences[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (str.Length > 5)
            {
                dataGridViewLaxPreferences[e.ColumnIndex, e.RowIndex].Value = str.Substring(0, 5);
            }
            refreshLaxPreferencesMatrix();
        }

        private void rerender()
        {
            renderStrictPreferences();
            renderIndifference();
            renderQuasiEquivalent();
            renderNonDominatedSet();
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rerender();
        }

        private void dataGridViewDegreeOfPermissibility_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewDegreeOfPermissibility_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (blockValidating) return;
            string w = dataGridViewDegreeOfPermissibility[e.ColumnIndex, e.RowIndex].Value.ToString();
            double q;
            
            string str = dataGridViewDegreeOfPermissibility[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (str.Length > 5)
            {
                dataGridViewDegreeOfPermissibility[e.ColumnIndex, e.RowIndex].Value = str.Substring(0, 5);
            }
            renderNonDominatedSet();
        }

        private void dataGridViewLaxPreferences_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string userInput = e.FormattedValue.ToString();
            double userValue;
            bool isNumeric = double.TryParse(userInput, out userValue);
            if ((!isNumeric || userValue < 0 || userValue > 1) && userInput != "")
            {
                // may be alert of error
                e.Cancel = true;
                MessageBox.Show("Неправильний ввід! Необхідно ввести число від 0 до 1!");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Matrix<double> m = new Matrix<double>();
            refreshLaxPreferencesMatrix();
            m.Value = laxPreferencesMatrix;
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            BufferData t = Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegate);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали матрицю");
            else
                loadMatrixFromBuffer(t);
        }

        private void loadMatrixFromBuffer(BufferData buff)
        {
            Matrix<double> t = (Matrix<double>)buff;
            int n = t.RowCount;
            elementsCount = n;
            changeMatrixSize(n);

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    dataGridViewLaxPreferences[i + 1, j].Value = t[i,j];
                }
            }
        }

        public bool ValidationCallbackDelegate(BufferData obj)
        {
            if (obj is Matrix<double>)
            {
                Matrix<double> m = (Matrix<double>)obj;
                if (m.Value.GetLength(0) > 10 || m.Value.GetLength(0) != m.Value.GetLength(1))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < m.Value.GetLength(0); i++)
                        for (int j = 0; j < m.Value.GetLength(1); j++)
                            if (m[i, j] > 1 || m[i, j] < 0)
                                return false;
                }
                return true;
            }
            else
                return false;
        }

        private void dataGridViewDegreeOfPermissibility_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0) return;
            string userInput = e.FormattedValue.ToString();
            double userValue;
            bool isNumeric = double.TryParse(userInput, out userValue);
            if ((!isNumeric || userValue < 0 || userValue > 1) && userInput != "")
            {
                // may be alert of error
                e.Cancel = true;
                MessageBox.Show("Неправильний ввід! Необхідно ввести число від 0 до 1!");
            }
        }
    }
}
