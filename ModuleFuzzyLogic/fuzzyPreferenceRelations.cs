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



        private void changeMatrixSize(int n)
        {
            blockValidating = true;
            int oldN = dataGridViewMu.Columns.Count-1;
            while (dataGridViewMu.Columns.Count < n+1)
            {
                string nm = "X" + dataGridViewMu.Columns.Count;
                if (dataGridViewMu.Columns.Count == 0)
                    nm = "";
                dataGridViewMu.Columns.Add(nm,nm);
                dataGridViewMu.Columns[dataGridViewMu.Columns.Count - 1].Width = 35;
            }
            while (dataGridViewMu.Columns.Count > n+1)
            {
                dataGridViewMu.Columns.RemoveAt(dataGridViewMu.Columns.Count - 1);
            }

            while (dataGridViewMu.RowCount > n) {
                dataGridViewMu.Rows.RemoveAt(dataGridViewMu.RowCount - 1);
            }

            while (dataGridViewMu.RowCount < n)
            {
                string nm = "X" + dataGridViewMu.Columns.Count;
                if (dataGridViewMu.Columns.Count == 0)
                    nm = "";
                
                dataGridViewMu.Rows.Add();
                dataGridViewMu[0, dataGridViewMu.RowCount - 1].Value = "X" + dataGridViewMu.RowCount;
            }
            Random generator = new Random();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (i < oldN && j < oldN) continue;
                    if (i == j)
                    {
                        dataGridViewMu[i + 1, j].Value = 1;
                    }
                    else
                    {
                        dataGridViewMu[i + 1, j].Value = generator.Next(0, 100) / 100.0;
                    }
                }
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    dataGridViewMu[j, i].ReadOnly = false;
                }
            }


            for (int i = 0; i < n; ++i)
            {
                dataGridViewMu[0, i].ReadOnly = true;
                dataGridViewMu[i+1, i].ReadOnly = true;
            }
            blockValidating = false;
        }

        private void numericUpAndDownElementsCount_ValueChanged(object sender, EventArgs e)
        {
            elementsCount = decimal.ToInt32(numericUpAndDownElementsCount.Value);
            changeMatrixSize(elementsCount);
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
                        dataGridViewMu[i + 1, j].Value = 1;
                    }
                    else
                    {
                        dataGridViewMu[i + 1, j].Value = generator.Next(0, 100) / 100.0;
                    }
                }
            }
        }

        private void dataGridViewMu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (blockValidating) return;
            string w = dataGridViewMu[e.ColumnIndex, e.RowIndex].Value.ToString();
            double q;
            if (!Double.TryParse(w, out q))
            {
                throw new Exception("BAD ARGIMENT");
            }
            if (q<0 || q>1)
            {
                throw new Exception("BAD ARGIMENT");
            }
            string str = dataGridViewMu[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (str.Length > 5)
            {
                dataGridViewMu[e.ColumnIndex, e.RowIndex].Value = str.Substring(0, 5);
            }
            
        }
    }
}
