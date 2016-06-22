using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods
{
    public partial class TestDialog : Form
    {
        bool result = false;
        frmModule module;
        Method method;
        public TestDialog(Method method)
        {
            //this.module = module;
            this.method = method;
            InitializeComponent();
            this.label4.Text = method.GetName();
        }

        public void setMethod(frmModule module)
        {
            this.module = module;
            this.numericUpDown1.Maximum = module.GvMatr.RowCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            double[,] mat = new double[module.GvMatr.RowCount, module.GvMatr.ColumnCount];
            double[] prob = new double[module.GVP.ColumnCount];
            double alfa, a;
            foreach (DataGridViewRow row in module.GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    mat[c.RowIndex, c.ColumnIndex] = System.Double.Parse(c.Value.ToString());
                }
            module.NormProb();
            foreach (DataGridViewRow row in module.GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    prob[c.ColumnIndex] = System.Double.Parse(c.Value.ToString());
                }
            try
            {
                alfa = System.Double.Parse(module.textBox1.Text);
            }
            catch (FormatException)
            {
                alfa = 0;
            }
            try
            {
                a = System.Double.Parse(module.textBox2.Text);
            }
            catch (FormatException)
            {
                a = module.matrMin();
            }
            method.Init(mat, prob, alfa, a);
            int result = method.RunMethod();

            module.label5.Text = (result + 1).ToString();
            for (int j = 0; j < module.GvMatr.Rows.Count; ++j)
            {
                module.GvMatr.Rows[j].DefaultCellStyle.BackColor = module.GvMatr.Rows[j].DefaultCellStyle.SelectionBackColor
                    = (j == result) ? Color.Yellow : Color.White;
            }
            module.GvMatr[0, result].Selected = true;
            module.GvMatr.CurrentCell = module.GvMatr[0, result];

            if (result != ((int)numericUpDown1.Value-1))
            {
                module.GvMatr.Rows[(int)numericUpDown1.Value - 1].DefaultCellStyle.BackColor = module.GvMatr.Rows[(int)numericUpDown1.Value - 1].DefaultCellStyle.SelectionBackColor
                    = Color.Red;
                this.result = false;
                MessageBox.Show( Properties.Resources.TestWrong + (result + 1).ToString() + ".");
            }
            else
            {
                this.result = true;
                MessageBox.Show(Properties.Resources.TestRight);
            }
        }

        public bool getResult()

        {

            return result;

        }



        private void TestDialog_Load(object sender, EventArgs e)

        {



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
