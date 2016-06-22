using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    internal partial class ctrlMethodSequentialConcession : ctrlMethodCallbackBase
    {
        private Matrix mMatrix;
        private Matrix cMatrix;
        private Matrix uniqueMatrix;
        private Dictionary<Criterium, int> criteriumTable;
        private Dictionary<Criterium, int> cCriteriumTable;
        private List<Alternative> altLst = new List<Alternative>();
        private int comp;

        public ctrlMethodSequentialConcession(Matrix matrix)
        {
            mMatrix = matrix;
            uniqueMatrix = matrix;
            cCriteriumTable = new Dictionary<Criterium, int>();
            criteriumTable = new Dictionary<Criterium, int>();
            InitializeComponent();
        }

        private string GetValue(Criterium crit)
        {
            foreach (KeyValuePair<Criterium, int> critPair in criteriumTable)
            {
                if (critPair.Key.Name.Equals(crit.Name))
                    return critPair.Value.ToString();
            }
            return String.Empty;
        }

        private bool IsInAlernatives(Alternative alt,
                 List<Alternative> alts)
        {
            foreach (Alternative altern in alts)
            {
                if (altern.Name.Equals(alt.Name))
                    return true;
            }
            return false;
        }

        private bool ValidateControl(TextBox txtBox)
        {
            if (txtBox.Text != "")
            {

                foreach (char c in txtBox.Text)
                {
                    if (!Char.IsDigit(c))
                    {
                        MessageBox.Show("Треба, вводити лише цифрові значення", Properties.Resources.Er);
                        return false;
                    }
                }
                if (Convert.ToInt32(txtBox.Text) > Int32.MaxValue)
                {
                    MessageBox.Show("Ви ввели занадто велике число", Properties.Resources.Er);
                    return false;
                }
                else
                {
                    int maxV = GetMaxFromMatrix();
                    if (Convert.ToInt32(txtBox.Text) > maxV)
                        MessageBox.Show("Ви ввели занадто велике число, треба ввести число в межах даної матриці", Properties.Resources.Er);

                }
                if (Convert.ToInt32(txtBox.Text) < 0)
                {
                    MessageBox.Show("Треба, щоб введене значеня було > 0", Properties.Resources.Er);
                    return false;
                }
                if (Convert.ToInt32(txtBox.Text) >= 0)
                {
                    comp = Convert.ToInt32(txtBox.Text);
                    return true;
                }
                else
                {
                    MessageBox.Show("Лише додатні значення приймаються.", Properties.Resources.Er);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Треба ввести обмеження.\n Якщо Ви не накладаєте обмежень то можете ввести число 0.", Properties.Resources.Er);
                return false;
            }
        }

        private int GetMaxFromMatrix()
        {
            int max = 0;
            foreach (Alternative alt in mMatrix.Alternatives)
                foreach (Criterium crit in alt.Criteriums)
                    if (mMatrix[alt.Name, crit.Name] > max)
                        max = mMatrix[alt.Name, crit.Name];
            return max;

        }

        private string GetCritMax(Dictionary<Criterium, int> critTable)
        {
            foreach (KeyValuePair<Criterium, int> critPair in criteriumTable)
            {
                if (critPair.Value == critTable.Count)
                    return critPair.Key.Name;
            }
            return String.Empty;
        }

        private void CloneDictionary(Dictionary<Criterium, int> d1,
            Dictionary<Criterium, int> d2)
        {
            d1.Clear();
            foreach (KeyValuePair<Criterium, int> critPair in d2)
            {
                d1.Add(critPair.Key, critPair.Value);
            }
        }

        /// <summary>
        /// Getting alternatives - our answer
        /// </summary>
        /// <param name="matr">Current MultiCriterion Matrix</param>
        /// <param name="critTable">Criterium - weight of criterium</param>
        /// <returns></returns>
        private List<Alternative> GetAlternatives(Matrix matr,
                                                Dictionary<Criterium, int> critTable)
        {
            if (critTable.Count > 0)
            {
                if (comp > 0)
                {
                    List<Alternative> alts = new List<Alternative>();
                    string critMax = GetCritMax(critTable);
                    int max = critTable.Count;
                    foreach (Criterium crit in matr.Criteriums)
                    {
                        if (crit.Name.Equals(critMax))
                            foreach (Alternative alt in matr.Alternatives)
                            {
                                if (matr[alt.Name, crit.Name] == (GetMaxValue(crit.Name, matr) - comp))
                                    alts.Add(alt);
                            }
                    }
                    cMatrix = (Matrix)mMatrix.Clone();
                    MatrixFilter(alts);
                    CloneDictionary(cCriteriumTable, criteriumTable);
                    cCriteriumTable.Remove(GetCritMaxValue(critMax));
                    return alts;
                }
                else
                {
                    List<Alternative> alts = new List<Alternative>();
                    string critMax = GetCritMax(critTable);
                    int max = critTable.Count;
                    foreach (Criterium crit in matr.Criteriums)
                    {
                        if (crit.Name.Equals(critMax))
                            foreach (Alternative alt in matr.Alternatives)
                            {
                                if (matr[alt.Name, crit.Name] == GetMaxValue(crit.Name, matr))
                                    alts.Add(alt);
                            }
                    }

                    return alts;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Using matrix filter to avoid alternetives that doesn't fit our condition
        /// </summary>
        /// <param name="alts">List of Alternatives</param>
        private void MatrixFilter(List<Alternative> alts)
        {
            //removing bad alternetives from our matrix
            List<Alternative> toRemove = new List<Alternative>();

            foreach (Alternative alt in mMatrix.Alternatives)
            {
                if (!IsInAlernatives(alt, alts))
                    toRemove.Add(alt);
            }
            foreach (Alternative alt in toRemove)
                cMatrix.RemoveAlternative(alt);
        }

        private Criterium GetCritMaxValue(string critName)
        {
            foreach (Criterium crit in mMatrix.Criteriums)
            {
                if (crit.Name.Equals(critName))
                    return crit;
            }
            Criterium c = new Criterium();
            return c;
        }


        private int GetMaxValue(string critName, Matrix matrix)
        {
            int max = 0;
            foreach (Criterium crit in matrix.Criteriums)
            {
                if (crit.Name.Equals(critName))
                {
                    foreach (Alternative alt in matrix.Alternatives)
                    {
                        if (mMatrix[alt.Name, critName] > max) max = mMatrix[alt.Name, critName];
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// Getting Max Value from Criterium list
        /// </summary>
        /// <param name="critTable">Criterium - weight of criterium</param>
        /// <returns></returns>
        private Criterium GetMaxFromCrit
            (Dictionary<Criterium, int> critTable)
        {
            int maxVal = 0;
            Criterium crit = new Criterium();
            foreach (KeyValuePair<Criterium, int> critPair in criteriumTable)
            {
                if (maxVal < critPair.Value)
                    maxVal = critPair.Value;
            }

            foreach (KeyValuePair<Criterium, int> critPair in criteriumTable)
            {
                if (critPair.Value == maxVal)
                    crit = critPair.Key;
            }

            return crit;
        }


        /// <summary>
        /// Basic Method using for comparing Alternatives
        /// </summary>
        /// <param name="matrix">MultiCriterion Matrix that we work with</param>
        private void CompareMethod(Matrix matrix)
        {
            if (altLst != null)
            {
                altLst.Clear();
            }
            if (matrix != null)
            {
                if (matrix.Equals(mMatrix))
                {
                    altLst = GetAlternatives(matrix, criteriumTable);
                }
                else
                {
                    altLst = GetAlternatives(matrix, cCriteriumTable);
                }
            }

            lstAltern.Items.Clear();
            if (altLst != null)
            {
                foreach (Alternative alt in altLst)
                {
                    lstAltern.Items.Add(alt.Name + "< " + GetCritsName(alt) + " >");
                }
            }
            else
            {
                return;
            }
        }

        private string GetCritsName(Alternative alt)
        {
            string critNames = "";
            int count = 0;
            foreach (Criterium crit in alt.Criteriums)
            {
                if (count == 0)
                    critNames += Convert.ToString(mMatrix[alt.Name, crit]);
                else
                    critNames += ", " + Convert.ToString(mMatrix[alt.Name, crit]);
                count++;
            }
            return critNames;
        }

        public override object Value
        {
            get
            {
                return (altLst == null ? null : altLst.ToArray());
            }
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comp = 0;
            if (lstAltern.Items != null)
            {
                lstAltern.Items.Clear();
            }
            if (cMatrix != null)
            {
                cMatrix.Clear();
            }
            if (cCriteriumTable != null)
            {
                cCriteriumTable.Clear();
            }
            if (txtCritName != null)
            {
                txtCritName.Clear();
            }
            if (txtCompromise != null)
            {
                txtCompromise.Clear();
            }
            mMatrix = (Matrix)ctrlMatrix.Matrix;
        }

        private void ctrlMethod3_Load(object sender, EventArgs e)
        {
            foreach (Criterium crit in mMatrix.Criteriums)
            {
                criteriumTable.Add(crit, 0);
                cmbCriterium.Items.Add(crit.Name);
            }
            ctrlMatrix.Matrix = mMatrix;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (ValidateControl(txtCompromise))
            {
                if (cMatrix == null)
                {
                    CompareMethod(mMatrix);
                    comp = 0;
                    CompareMethod(cMatrix);
                }
                else
                {
                    CompareMethod(mMatrix);
                    //comp = 0;
                    //CompareMethod(cMatrix);
                }

                button5.Enabled = true;
                txtCritName.Text = GetCritMax(cCriteriumTable);
            }
            else
            {
                txtCompromise.Clear();
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (criteriumTable.Count != 0)
                foreach (KeyValuePair<Criterium, int> critPair in criteriumTable)
                {
                    if (cmbCriterium.SelectedItem != null)
                        if (critPair.Key.Name == cmbCriterium.SelectedItem.ToString())
                        {
                            criteriumTable.Remove(critPair.Key);
                            criteriumTable.Add(critPair.Key, cmbCriterium.Items.Count);
                            cmbCriterium.Items.Remove(critPair.Key.Name);
                            cmbCriterium.Refresh();
                            lstCriterium.Items.Add(critPair.Key.Name + "-" + GetValue(critPair.Key));
                            break;
                        }
                }
            if (cmbCriterium.Items.Count == 0)
            {
                button1.Enabled = false;
                button3.Enabled = true;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            lstAltern.Items.Clear();
            CompareMethod(mMatrix);
            if (altLst.Count != 0)
            {
                txtCompromise.Enabled = true;
                button4.Enabled = true;
            }
            txtCritName.Text = GetCritMax(criteriumTable);
        }
    }
}
