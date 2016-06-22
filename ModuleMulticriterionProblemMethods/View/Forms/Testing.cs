using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    partial class Testing : Form
    {
        frmModule module;
        int curm = 0;
        int rightans = 0;
        LinkedList<int> curRes = null;
        
        public Testing(frmModule module)
        {
            this.module = module;
            InitializeComponent();
            this.label1.Text = Properties.Resources.testingMethod + module.module.Methods[0].Name;
        }

        private void Testing_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modules.MulticriterionProblemMethods.Method m = module.module.Methods[curm];
            //MessageBox.Show(module.module._dataStorage.Matrix.ToString());
            module.module._dataStorage.Matrix = module.module._parrentForm.Matrix;
            m.Init(module.module._dataStorage.Matrix);
            Modules.MulticriterionProblemMethods.DataTypes.Alternative[] results = m.Do();
            LinkedList<int> rows = new LinkedList<int>();
            if (results != null)
            {
                foreach (Modules.MulticriterionProblemMethods.DataTypes.Alternative alt in results)
                {
                    int row = 0;
                    for (int r = 0; r < module.module._parrentForm.ctrlMatrix._gridView.RowCount; r++)
                    {
                        if (module.module._parrentForm.ctrlMatrix._gridView[0, r].Value.ToString() == alt.Name)
                        {
                            rows.AddLast(row);
                            break;
                        }
                    }
                }
            }
            curRes = rows;
            button1.Enabled = false;
            button2.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (curRes.Contains((int)numericUpDown1.Value))
            {
                rightans++;
                MessageBox.Show("Вірно!");
            }
            else
            {
                MessageBox.Show("Не вірно!");
            }
            curm++;
            if (curm == module.module.Methods.Count)
            {
                MessageBox.Show("Тестування закінчено. Ваш результат: " + rightans + " з " + module.module.Methods.Count);
                this.Hide();
            }
            else
            {
                this.label1.Text = "Тестування за методом " + module.module.Methods[curm].Name;
                button1.Enabled = true;
                button2.Enabled = false;
                numericUpDown1.Enabled = false;
            }
        }
    }
}
