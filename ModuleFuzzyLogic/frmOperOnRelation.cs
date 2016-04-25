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
    public partial class frmOperOnRelation : Form
    {
        private List<int> sizeMatrix;
        private List<int> sizeMatrixComp1;
        private List<int> sizeMatrixComp2;
        public frmOperOnRelation()
        {
            InitializeComponent();
            initilizeMatrix(dataGV_Matrix1);
            initilizeMatrix(dataGV_Matrix2);
            initilizeMatrix(dataGV_MatrixRes);
            sizeMatrix = new List<int>();
            sizeMatrixComp1 = new List<int>(2);
            sizeMatrixComp2 = new List<int>(2);
            numUD_Sz1.Enabled = numUD_Sz2.Enabled = numUD_Sz3.Enabled = numUD_Sz4.Enabled = numUD_Sz5.Enabled = false;
            numUD_Sz1.Maximum = numUD_Sz2.Maximum = numUD_Sz3.Maximum = numUD_Sz4.Maximum = numUD_Sz5.Maximum = 5;
            numUD_Comp11.Maximum = numUD_Comp12.Maximum = numUD_Comp21.Maximum = numUD_Comp22.Maximum = 5;
            numUD_Comp11.Minimum = numUD_Comp12.Minimum = numUD_Comp21.Minimum = numUD_Comp22.Minimum = 1;
            numUD_Comp21.Enabled = false;
            radioButton1.Text = "Перетин"; //intersection
            radioButton2.Text = "Об'єднання"; //association
            radioButton3.Text = "Різниця"; // difference
            radioButton4.Text = "Симетрична різниця"; //symmetric difference
            radioButton5.Text = "Доповнення до матриці 1"; //addition
            radioButton6.Text = "Доповнення до матриці 2"; //addition
            checkBoxComp.Text = "Композиція";
            tableLayoutPanelComp.Enabled = false;
            buttonGetComp.Enabled = false;

            buttonM1_Load.Text = buttonM2_Load.Text = buttonMRes_Load.Text = "Завантажити";
            buttonM1_Save.Text = buttonM2_Save.Text = buttonMRes_Save.Text = "Зберегти";
        }

        private void initilizeMatrix(DataGridView matrix)
        {
            matrix.Width = 195;
            matrix.Height = 300;
            matrix.ColumnCount = 2;
            matrix.Columns[0].Name = "x";
            matrix.Columns[0].Width = 70;
            matrix.Columns[1].Name = "m(x)";
            matrix.Columns[1].Width = 70;
            matrix.AllowUserToAddRows = false;
            matrix.RowHeadersVisible = false;
            matrix.Columns[0].ReadOnly = true;
            foreach (DataGridViewColumn column in matrix.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            ((DataGridViewTextBoxColumn)matrix.Columns[1]).MaxInputLength = 4;
        }

        private void numUD_Size_ValueChanged(object sender, EventArgs e)
        {
            int n = (int)numUD_Size.Value;
            numUD_Sz1.Enabled = numUD_Sz2.Enabled = numUD_Sz3.Enabled = numUD_Sz4.Enabled = numUD_Sz5.Enabled = false;
            sizeMatrix = new List<int>(n);
            if(n>=1)
            {
                numUD_Sz1.Enabled = true;
                sizeMatrix.Add((int)numUD_Sz1.Value);
                if(n>=2)
                {
                    numUD_Sz2.Enabled = true;
                    sizeMatrix.Add((int)numUD_Sz2.Value);
                    if(n>=3)
                    {
                        numUD_Sz3.Enabled = true;
                        sizeMatrix.Add((int)numUD_Sz3.Value);
                        if(n>=4)
                        {
                            numUD_Sz4.Enabled = true;
                            sizeMatrix.Add((int)numUD_Sz4.Value);
                            if(n>=5)
                            {
                                numUD_Sz5.Enabled = true;
                                sizeMatrix.Add((int)numUD_Sz5.Value);
                            }
                        }
                    }
                }
            }
            fillMatrix();
        }
        private void fillMatrix()
        {
            int m = 1;
            foreach(int k in sizeMatrix)
            {
                m *= k;
            }
            dataGV_Matrix1.RowCount = dataGV_Matrix2.RowCount = dataGV_MatrixRes.RowCount = m;
            int n = (int)numUD_Size.Value;

            List<string> res = new List<string>();
            makeNamesDGV(ref res, "(", 0, sizeMatrix.Count, sizeMatrix);
            for(int i=0;i<m;i++)
            {
                dataGV_Matrix1[0, i].Value = res[i];
                dataGV_Matrix2[0, i].Value = res[i];
                dataGV_MatrixRes[0, i].Value = res[i];
            }
        }
        private void makeNamesDGV(ref List<string> res, string str, int k, int sz, List<int> matrix)
        {
            if (k >= sz)
            {
                str = str.Substring(0, str.Length - 2);
                str = str + ")";
                res.Add(str);
                return;
            }
            for (int i = 1; i <= matrix[k]; i++)
            {
                makeNamesDGV(ref res, str + i.ToString() + ", ", k+1, sz, matrix);
            }
        }

        private void numUD_Sz1_ValueChanged(object sender, EventArgs e)
        {
            sizeMatrix[0] = (int)numUD_Sz1.Value;
            fillMatrix();
        }
        private void numUD_Sz2_ValueChanged(object sender, EventArgs e)
        {
            sizeMatrix[1] = (int)numUD_Sz2.Value;
            fillMatrix();
        }
        private void numUD_Sz3_ValueChanged(object sender, EventArgs e)
        {
            sizeMatrix[2] = (int)numUD_Sz3.Value;
            fillMatrix();
        }
        private void numUD_Sz4_ValueChanged(object sender, EventArgs e)
        {
            sizeMatrix[3] = (int)numUD_Sz4.Value;
            fillMatrix();
        }
        private void numUD_Sz5_ValueChanged(object sender, EventArgs e)
        {
            sizeMatrix[4] = (int)numUD_Sz5.Value;
            fillMatrix();
        }

        private void dataGV_Matrix1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            matrix_CellValidating(sender, e);
        }
        private void dataGV_Matrix2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            matrix_CellValidating(sender, e);
        }
        private void dataGV_MatrixRes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            matrix_CellValidating(sender, e);
        }
        private void matrix_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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

        private void buttonGetAnswer_Click(object sender, EventArgs e)
        {
            OperOnRelaionMethods meth = new OperOnRelaionMethods();
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> res = new List<double>();
            foreach (DataGridViewRow item in dataGV_Matrix1.Rows)
            {
                list1.Add(Convert.ToDouble(item.Cells[1].Value));
            }
            foreach (DataGridViewRow item in dataGV_Matrix2.Rows)
            {
                list2.Add(Convert.ToDouble(item.Cells[1].Value));
            }

            if(radioButton1.Checked)
            {
                res = meth.intersection(list1, list2);
            }
            if (radioButton2.Checked)
            {
                res = meth.association(list1, list2);
            }
            if (radioButton3.Checked)
            {
                res = meth.difference(list1, list2);
            }
            if (radioButton4.Checked)
            {
                res = meth.symmetricDifference(list1, list2);
            }
            if (radioButton5.Checked)
            {
                res = meth.addition(list1);
            }
            if (radioButton6.Checked)
            {
                res = meth.addition(list2);
            }
            for(int i=0;i<res.Count;i++)
            {
                dataGV_MatrixRes[1, i].Value = res[i].ToString();
            }
        }

        private void checkBoxComp_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxComp.Checked == true)
            {
                sizeMatrixComp1 = new List<int>(2);
                sizeMatrixComp2 = new List<int>(2);
                sizeMatrixComp1.Add((int)numUD_Comp11.Value);
                sizeMatrixComp1.Add((int)numUD_Comp12.Value);
                sizeMatrixComp2.Add((int)numUD_Comp21.Value);
                sizeMatrixComp2.Add((int)numUD_Comp22.Value);
                tableLayoutPanelComp.Enabled = true;
                tableLayoutPanelN.Enabled = false;
                tableLayoutPanelMethods.Enabled = false;
                numUD_Size.Value = 2;
                numUD_Size.Enabled = false;
                buttonGetComp.Enabled = true;
            }
            else
            {
                tableLayoutPanelComp.Enabled = false;
                tableLayoutPanelN.Enabled = true;
                tableLayoutPanelMethods.Enabled = true;
                numUD_Size.Enabled = true;
                buttonGetComp.Enabled = false;
            }
        }
        private void numUD_Comp11_ValueChanged(object sender, EventArgs e)
        {
            if (sizeMatrixComp1.Count < 2) return;
            sizeMatrixComp1[0] = (int)numUD_Comp11.Value;
            fillMatrixComp();
        }
        private void numUD_Comp12_ValueChanged(object sender, EventArgs e)
        {
            if (sizeMatrixComp2.Count < 2 || sizeMatrixComp1.Count < 2) return;
            sizeMatrixComp1[1] = sizeMatrixComp2[0] = (int)numUD_Comp12.Value;
            numUD_Comp21.Value = numUD_Comp12.Value;
            fillMatrixComp();
        }
        private void numUD_Comp22_ValueChanged(object sender, EventArgs e)
        {
            if (sizeMatrixComp2.Count < 2) return;
            sizeMatrixComp2[1] = (int)numUD_Comp22.Value;
            fillMatrixComp();
        }
        private void fillMatrixComp()
        {
            int m1 = sizeMatrixComp1[0] * sizeMatrixComp1[1];
            int m2 = sizeMatrixComp2[0] * sizeMatrixComp2[1];
            int mres = sizeMatrixComp1[0] * sizeMatrixComp2[1];
            dataGV_Matrix1.RowCount = m1;
            dataGV_Matrix2.RowCount = m2;
            dataGV_MatrixRes.RowCount = mres;

            List<string> res;
            res = new List<string>();
            makeNamesDGV(ref res, "(", 0, 2, sizeMatrixComp1);
            for (int i = 0; i < m1; i++)
            {
                dataGV_Matrix1[0, i].Value = res[i];
            }
            res = new List<string>();
            makeNamesDGV(ref res, "(", 0, 2, sizeMatrixComp2);
            for (int i = 0; i < m2; i++)
            {
                dataGV_Matrix2[0, i].Value = res[i];
            }
            res = new List<string>();
            List<int> list = new List<int>(2);
            list.Add(sizeMatrixComp1[0]);
            list.Add(sizeMatrixComp2[1]);
            makeNamesDGV(ref res, "(", 0, 2, list);
            for (int i = 0; i < mres; i++)
            {
                dataGV_MatrixRes[0, i].Value = res[i];
            }
        }

        private void buttonGetComp_Click(object sender, EventArgs e)
        {
            OperOnRelaionMethods meth = new OperOnRelaionMethods();
            int m11 = sizeMatrixComp1[0];
            int m12 = sizeMatrixComp1[1];
            int m21 = m12;
            int m22 = sizeMatrixComp2[1];
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> res = new List<double>();
            foreach (DataGridViewRow item in dataGV_Matrix1.Rows)
            {
                list1.Add(Convert.ToDouble(item.Cells[1].Value));
            }
            foreach (DataGridViewRow item in dataGV_Matrix2.Rows)
            {
                list2.Add(Convert.ToDouble(item.Cells[1].Value));
            }
            res = meth.composition(list1, m11, m12, list2, m21, m22);
            for (int i = 0; i < res.Count; i++)
            {
                dataGV_MatrixRes[1, i].Value = res[i].ToString();
            }
        }

        private void buttonGener_M1_Click(object sender, EventArgs e)
        {
            Random rnm = new Random();
            foreach (DataGridViewRow item in dataGV_Matrix1.Rows)
            {
                item.Cells[1].Value = 0.01 * rnm.Next(0, 100);
            }
        }

        private void buttonGener_M2_Click(object sender, EventArgs e)
        {
            Random rnm = new Random();
            foreach (DataGridViewRow item in dataGV_Matrix2.Rows)
            {
                item.Cells[1].Value = 0.01 * rnm.Next(0, 100);
            }
        }

        private void buttonM1_Save_Click(object sender, EventArgs e)
        {
            double[] prob = new double[dataGV_Matrix1.RowCount];
            int i = 0;
            foreach (DataGridViewRow item in dataGV_Matrix1.Rows)
            {
                if (item.Cells[1].Value == null)
                    prob[i++] = 0;
                else
                    prob[i++] = Convert.ToDouble(item.Cells[1].Value.ToString());
            }
            Vector<double> vect = new Vector<double>(prob);
            Common.DataBuffer.Instance.SaveDialog(vect);
        }

        private void buttonM2_Save_Click(object sender, EventArgs e)
        {
            double[] prob = new double[dataGV_Matrix1.RowCount];
            int i = 0;
            foreach (DataGridViewRow item in dataGV_Matrix2.Rows)
            {
                prob[i++] = Double.Parse(item.Cells[1].Value.ToString());
            }
            Vector<double> vect = new Vector<double>(prob);
            Common.DataBuffer.Instance.SaveDialog(vect);
        }

        private void buttonMRes_Save_Click(object sender, EventArgs e)
        {
            double[] prob = new double[dataGV_Matrix1.RowCount];
            int i = 0;
            foreach (DataGridViewRow item in dataGV_MatrixRes.Rows)
            {
                prob[i++] = Double.Parse(item.Cells[1].Value.ToString());
            }
            Vector<double> vect = new Vector<double>(prob);
            Common.DataBuffer.Instance.SaveDialog(vect);
        }

        private void buttonM1_Load_Click(object sender, EventArgs e)
        {
            Vector<double> t = (Vector<double>)Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegateP1);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали вектор");
            else
                InputVect(t, dataGV_Matrix1);

        }
        private void buttonM2_Load_Click(object sender, EventArgs e)
        {
            Vector<double> t = (Vector<double>)Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegateP2);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали вектор");
            else
                InputVect(t, dataGV_Matrix2);

        }
        private void buttonMRes_Load_Click(object sender, EventArgs e)
        {
            Vector<double> t = (Vector<double>)Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegatePRes);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали вектор");
            else
                InputVect(t, dataGV_MatrixRes);

        }
        private void InputVect(Vector<double> buff, DataGridView matrix)
        {
            int i = 0;
            foreach (DataGridViewRow item in matrix.Rows)
            {
                item.Cells[1].Value = buff.Value[i++];
            }
        }
        public bool ValidationCallbackDelegateP1(BufferData obj)
        {
            if (obj is Vector<double>)
            {
                Vector<double> vect = (Vector<double>)obj;
                int m = 1;
                if (checkBoxComp.Checked == false)
                {
                    foreach (int k in sizeMatrix)
                        m *= k;
                }
                else
                {
                    foreach (int k in sizeMatrixComp1)
                        m *= k;
                }
                if (vect.Value.Length != m)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public bool ValidationCallbackDelegateP2(BufferData obj)
        {
            if (obj is Vector<double>)
            {
                Vector<double> vect = (Vector<double>)obj;
                int m = 1;
                if (checkBoxComp.Checked == false)
                {
                    foreach (int k in sizeMatrix)
                        m *= k;
                }
                else
                {
                    foreach (int k in sizeMatrixComp2)
                        m *= k;
                }
                if (vect.Value.Length != m)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public bool ValidationCallbackDelegatePRes(BufferData obj)
        {
            if (obj is Vector<double>)
            {
                Vector<double> vect = (Vector<double>)obj;
                int m = 1;
                if (checkBoxComp.Checked == false)
                {
                    foreach (int k in sizeMatrix)
                        m *= k;
                }
                else
                {
                    m = sizeMatrixComp1[0] * sizeMatrixComp2[1];
                }
                if (vect.Value.Length != m)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}
