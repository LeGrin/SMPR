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
    public partial class frmParameterContinuation : Form
    {
        public frmParameterContinuation()
        {
            InitializeComponent();
            dgvFunctions.Rows.Add();
        }

        private void variableNumber_ValueChanged(object sender, EventArgs e)
        {
            dgvFunctions.Rows.Clear();
            for (int i = 0; i < variableNumber.Value; i++)
            {
                dgvFunctions.Rows.Add();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> last_values = new List<double>();
            List<double> new_values = new List<double>();
            List<string> variables = new List<string>();
            List<double> con = new List<double>();
            List<Expression> expressions = new List<Expression>();
            bool first = true;

            for (int i = 0; i < dgvFunctions.Rows.Count; i++)
            {
                Expression expression = new Expression((string)dgvFunctions.Rows[i].Cells["function"].Value);
                expressions.Add(expression);
                variables.Add((string)dgvFunctions.Rows[i].Cells["Variable"].Value);
                new_values.Add(Convert.ToDouble((string)dgvFunctions.Rows[i].Cells["firstValue"].Value));
            }

            int max_iter = Convert.ToInt32(max_iter_numeric.Value);
            for (int iter = 0; iter < max_iter; iter++)
            {

                for (int i = 0; i < dgvFunctions.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvFunctions.Rows.Count; j++)
                    {
                        expressions[i].Parameters[variables[j]] = new_values[j];
                    }
                    con.Add((double)expressions[i].Evaluate());
                }
                
                for (int _ = 0; _ < 10000; _++)
                {
                    last_values = new List<double>(new_values);
                    new_values.Clear();
                    for (int i = 0; i < dgvFunctions.Rows.Count; i++)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            expressions[i].Parameters[variables[j]] = new_values[j];
                        }
                        for (int j = i; j < dgvFunctions.Rows.Count; j++)
                        {
                            expressions[i].Parameters[variables[j]] = last_values[j];
                        }
                        new_values.Add((double)expressions[i].Evaluate() - (1 - (iter * ((double) 1 / max_iter))) * con[i]);
                    }
                }
       
            }
            answer.Text = "";
            for (int i = 0; i < new_values.Count; i++)
            {
                answer.Text += variables[i] + "=" + new_values[i].ToString() + ";";
            }
        }
    }
}

