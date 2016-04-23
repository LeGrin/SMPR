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

            dataGridViewElements.Rows.Clear();

            
        }
        private int elementsCount;

        private void changeMatrixSize(int n)
        {n = 
            n + 1;
            //dataGridViewMu.Columns.
            while (dataGridViewMu.Columns.Count < n)
            {
                string nm = "X" + dataGridViewMu.Columns.Count;
                if (dataGridViewMu.Columns.Count == 0)
                    nm = "";
                dataGridViewMu.Columns.Add(nm,nm);
                dataGridViewMu.Columns[dataGridViewMu.Columns.Count - 1].Width = 30;
            }
            while (dataGridViewMu.Columns.Count > n)
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

            for (int i = 0; i < n; ++i)
            {
                dataGridViewMu[0, i].ReadOnly = true;
                dataGridViewMu[i, 0].ReadOnly = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            elementsCount = decimal.ToInt32(numericUpAndDownElementsCount.Value);
            changeMatrixSize(elementsCount);
            while (dataGridViewElements.RowCount < elementsCount)
            {
                dataGridViewElements.Rows.Add();
                dataGridViewElements[0, dataGridViewElements.RowCount - 1].Value = 1;
            }

            while (dataGridViewElements.RowCount > elementsCount)
                dataGridViewElements.Rows.RemoveAt(dataGridViewElements.RowCount - 1);

            //changeExpertsCount();
        }
    }
}
