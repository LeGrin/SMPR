using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;

namespace Modules.ModuleNumericalAnalysis
{
    public partial class frmSeidelMethod : Form
    {
        public frmSeidelMethod()
        {
            InitializeComponent();
            dgvFunctions.Rows.Add();
        }

        private void frmSeidelMethod_Load(object sender, EventArgs e)
        {

        }

        private void variableNumber_ValueChanged(object sender, EventArgs e)
        {
            dgvFunctions.Rows.Clear();
            for (int i = 0; i < variableNumber.Value; i++)
            {
                dgvFunctions.Rows.Add();
            }
        }
        private double get_diff(List<double> v1, List<double> v2)
        {
            double res = 0;
            for (int i = 0; i < v1.Count; i++)
            {
                res += (v1[i] - v2[i]) * (v1[i] - v2[i]);
            }
            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<double> last_values = new List<double>();
            List<double> new_values = new List<double>();
            List<string> variables = new List<string>();
            List<Expression> expressions = new List<Expression>();
            double eps = Convert.ToDouble(epsilon.Text);
            bool first = true;

            for (int i = 0; i < dgvFunctions.Rows.Count; i++)
            {
                Expression expression = new Expression((string)dgvFunctions.Rows[i].Cells["function"].Value);
                expressions.Add(expression);
                variables.Add((string)dgvFunctions.Rows[i].Cells["Variable"].Value);
                new_values.Add(Convert.ToDouble((string)dgvFunctions.Rows[i].Cells["firstValue"].Value));
            }
            int iter = 0;
            int max_iter = Convert.ToInt32(max_iter_numeric.Value);
            while (iter < max_iter && (first || (get_diff(last_values, new_values) > eps * eps)))
            {
                first = false;
                iter++;
                last_values = new List<double>(new_values);
                new_values.Clear();
                for (int i = 0; i < dgvFunctions.Rows.Count; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        expressions[i].Parameters[variables[j]] = new_values[j];
                    }
                    for (int j =i; j< dgvFunctions.Rows.Count;j++)
                    {
                        expressions[i].Parameters[variables[j]] = last_values[j];
                    }
                    new_values.Add((double)expressions[i].Evaluate());
                }
            }
            if (iter == max_iter)
            {
                MessageBox.Show("Max iter");
            }
            else
            {
                answer.Text = "";
                for (int i = 0; i < new_values.Count; i++)
                {
                    answer.Text += variables[i] + "=" + new_values[i].ToString() + ";";
                }
            }
        }
    }
}
