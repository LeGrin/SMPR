using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    internal partial class ctrlMethodLimiting : ctrlMethodCallbackBase
    {
        MulticriterionProblemMethods.DataTypes.Matrix mMatrix;
        int limit;
        MulticriterionProblemMethods.DataTypes.Alternative[] ans;

        public ctrlMethodLimiting(MulticriterionProblemMethods.DataTypes.Matrix matrix)
        {
            InitializeComponent();

            mMatrix = matrix;
            ctrlMatrix1.Matrix = mMatrix;

        }

        public override object Value
        {
            get
            {

                return ans;
            }
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidateControl(txtLimit))
            {
                double[] delt = new double[mMatrix.CriteriumsCount];
                double[] temp = new double[mMatrix.AlternativesCount];
                double[] alpha = new double[mMatrix.CriteriumsCount];
                ArrayList maxCrit = GetOptimalValues();
                int i = 0;

                foreach (Criterium crit in mMatrix.Criteriums)
                {
                    ArrayList critVect = GetCritVector(crit);
                    double max = GetMaxValVector(critVect);
                    double min = GetMinValVector(critVect);
                    int j = 0;
                    ArrayList vect = BuildVect(crit);
                    foreach (int val in vect)
                    {

                        temp[j++] = (max - val) / (max - min);
                    }
                    delt[i++] = GetMaxVal(temp);
                }
                double sum = Sum(delt);
                i = 0;
                foreach (double d in delt)
                {
                    alpha[i++] = d / sum;
                }

                ans = Maximize(alpha);
                lstAltern.Items.Clear();
                foreach (MulticriterionProblemMethods.DataTypes.Alternative alt in ans)
                    lstAltern.Items.Add(alt.Name.ToString() + " <" + GetAltComponents(alt) + "> ");
            }
            else
            {
                txtLimit.Clear();
                return;
            }
        }

        private string GetAltComponents(MulticriterionProblemMethods.DataTypes.Alternative alt)
        {
            StringBuilder builder = new StringBuilder();
            bool isFirst = true;

            foreach (MulticriterionProblemMethods.DataTypes.Criterium crit in alt.Criteriums)
            {
                if (!isFirst) builder.Append(" ,");
                builder.Append(mMatrix[alt.Name, crit.Name].ToString());
                isFirst = false;

            }
            return builder.ToString();
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
                if (Convert.ToInt32(txtBox.Text) < 0)
                {
                    MessageBox.Show("Треба, щоб введене значеня було > 0", Properties.Resources.Er);
                    return false;
                }
                if (Convert.ToInt32(txtBox.Text) >= 0)
                {
                    limit = Convert.ToInt32(txtBox.Text);
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

        private double Sum(double[] temp)
        {
            double sum = 0;
            foreach (double d in temp)
            {
                sum += d;
            }
            return sum;
        }

        private ArrayList BuildVect(MulticriterionProblemMethods.DataTypes.Criterium criter)
        {
            ArrayList res = new ArrayList();
            ArrayList vect = new ArrayList();
            foreach (MulticriterionProblemMethods.DataTypes.Criterium crit in mMatrix.Criteriums)
            {
                ArrayList critVect = GetCritVector(crit);
                int ind = GetMaxIndex(critVect);
                vect.Add(ind);
            }
            ArrayList uVector = GetCritVector(criter);
            foreach (int j in vect)
            {
                res.Add(uVector[j]);
            }

            return res;
        }

        private int GetMaxIndex(ArrayList vect)
        {
            double maxVal = GetMaxValVector(vect);
            int i = 0;
            foreach (int d in vect)
            {
                if (d == maxVal)
                    return i;
                i++;
            }

            return i;
        }

        private ArrayList Mult(double mult, ArrayList temp)
        {
            for (int i = 0; i < temp.Count; ++i)
            {
                double dtemp = Convert.ToDouble(temp[i]);
                dtemp *= mult;
                temp[i] = dtemp;
            }
            return temp;
        }

        private double SumVect(ArrayList vect)
        {
            double sum = 0;
            foreach (double d in vect)
            {
                sum += d;
            }
            return sum;

        }

        private ArrayList Add(ArrayList temp1, ArrayList temp2)
        {
            int i = 0;
            foreach (double d in temp1)
            {
                double dtemp = Convert.ToDouble(temp2[i]);
                dtemp += d;
                temp2[i++] = dtemp;
            }
            return temp2;
        }

        private ArrayList GetMaxValMarks(Dictionary<int, double> marks)
        {
            double max = -1;
            ArrayList indeces = new ArrayList();
            foreach (KeyValuePair<int, double> markVal in marks)
            {
                if (Convert.ToDouble(markVal.Value) > max)
                    max = Convert.ToDouble(markVal.Value);
            }

            foreach (KeyValuePair<int, double> markVal in marks)
            {
                if (Convert.ToDouble(markVal.Value) == max)
                    indeces.Add(markVal.Key);
            }

            return indeces;
        }

        private double Normalize(ArrayList temp)
        {
            double sum = 0;
            for (int i = 0; i < temp.Count; ++i)
            {
                double dtemp = Convert.ToDouble(temp[i]);
                dtemp *= dtemp;
                sum += dtemp;
            }
            return Math.Sqrt(sum);
        }

        //getting maximum value from our vector
        private double GetMaxVal(double[] temp)
        {
            double maxVal = 0;
            foreach (double i in temp)
            {
                if (i > maxVal)
                    maxVal = i;
            }
            return maxVal;
        }



        private ArrayList GetOptimalValues()
        {
            ArrayList result = new ArrayList();
            int maxVal = 0;
            foreach (MulticriterionProblemMethods.DataTypes.Alternative alt in mMatrix.Alternatives)
            {
                foreach (Criterium crit in alt.Criteriums)
                {
                    if (mMatrix[alt.Name, crit.Name] > maxVal)
                        maxVal = mMatrix[alt.Name, crit.Name];
                }
                result.Add(maxVal);
            }
            return result;
        }

        private ArrayList GetCritVector(MulticriterionProblemMethods.DataTypes.Criterium crit)
        {
            ArrayList result = new ArrayList();
            foreach (MulticriterionProblemMethods.DataTypes.Alternative alt in mMatrix.Alternatives)
            {
                result.Add(mMatrix[alt.Name, crit.Name]);
            }

            return result;
        }

        private ArrayList GetAltVector(MulticriterionProblemMethods.DataTypes.Alternative alt)
        {
            ArrayList result = new ArrayList();
            foreach (MulticriterionProblemMethods.DataTypes.Criterium crit in mMatrix.Criteriums)
            {
                result.Add(mMatrix[alt.Name, crit.Name]);
            }
            return result;
        }

        private double GetMaxValVector(ArrayList v)
        {
            double maxVal = 0;
            foreach (int i in v.ToArray())
            {
                if (i > maxVal)
                    maxVal = i;
            }

            return maxVal;
        }

        private double GetMinValVector(ArrayList v)
        {
            double minVal = GetMaxValVector(v);

            foreach (int i in v.ToArray())
            {
                if (i < minVal)
                    minVal = i;
            }

            return minVal;
        }

        private bool AlternativeValidation(MulticriterionProblemMethods.DataTypes.Alternative alt)
        {
            foreach (MulticriterionProblemMethods.DataTypes.Criterium crit in alt.Criteriums)
            {
                if (mMatrix[alt.Name, crit.Name] <= limit)
                    return false;
            }
            return true;

        }

        private MulticriterionProblemMethods.DataTypes.Alternative[] Maximize(double[] temp)
        {
            List<Alternative> altsRes = new List<Alternative>();
            Dictionary<int, ArrayList> vects = new Dictionary<int, ArrayList>();
            Dictionary<int, double> marks = new Dictionary<int, double>();
            ArrayList vectCount = new ArrayList();
            int i = 0;
            foreach (MulticriterionProblemMethods.DataTypes.Alternative alt in mMatrix.Alternatives)
            {
                ArrayList altVect = GetAltVector(alt);
                if (i > temp.Length - 1)
                {
                    break;
                }
                ArrayList newVect = Mult(temp[i], altVect);
                vects.Add(i++, newVect);
            }

            foreach (KeyValuePair<int, ArrayList> vect in vects)
            {
                marks.Add(vect.Key, SumVect((ArrayList)vect.Value));
            }

            ArrayList indeces = GetMaxValMarks(marks);

            foreach (int j in indeces)
            {
                MulticriterionProblemMethods.DataTypes.Alternative alt = mMatrix.GetAlternativeByIndex(j);
                if (AlternativeValidation(alt))
                    altsRes.Add(alt);
            }

            return altsRes.ToArray();
        }


    }
}
