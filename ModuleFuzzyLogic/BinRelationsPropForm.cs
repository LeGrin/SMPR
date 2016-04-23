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
using System.Collections.Specialized;

namespace Modules.ModuleFuzzyLogic
{
    public partial class BinRelationsPropForm : Form
    {
        private static Random rand = new Random();
        public BinRelationsPropForm()
        {
            InitializeComponent();
            matrix.RowCount = 0;
            matrix.ColumnCount = 0;
        }

        private void addDim_Click(object sender, EventArgs e)
        {
            matrix.ColumnCount = (matrix.ColumnCount < 10) ? matrix.ColumnCount + 1 : matrix.ColumnCount;
            matrix.RowCount = (matrix.RowCount < 10) ? matrix.RowCount + 1 : matrix.RowCount;
        }

        private void removeDim_Click(object sender, EventArgs e)
        {
            matrix.ColumnCount =  (matrix.ColumnCount > 0) ? matrix.ColumnCount - 1 : matrix.ColumnCount;
            matrix.RowCount = (matrix.RowCount > 0) ? matrix.RowCount - 1 : matrix.RowCount;
        }

        private void matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void matrix_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string userInput = e.FormattedValue.ToString();
            double userValue;
            bool isNumeric = double.TryParse(userInput, out userValue);
            if((!isNumeric || userValue < 0 || userValue > 1) && userInput != "")
            {
                // may be alert of error
                e.Cancel = true;
            }
        }

        private void matrix_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.Width = 50;
            foreach(DataGridViewRow row in matrix.Rows)
            {
                row.Cells[e.Column.Index].Value = (1.0 / rand.Next(1, 10)).ToString("0.00");
            }
        }

        private void matrix_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            matrix.Rows[e.RowIndex].Height = 50;
            foreach (DataGridViewCell cell in matrix.Rows[e.RowIndex].Cells)
            {
                cell.Value = (1.0 / rand.Next(1, 10)).ToString("0.00"); 
            }
        }

        private void matrix_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void analyzeMatrixButton_Click(object sender, EventArgs e)
        {
            NameValueCollection relationProperties = matrix.Analyze();
            resultList.Items.Clear();
            string[] x;
            for (int i = 0; i < relationProperties.Count; i++)
            {
                x = relationProperties.GetValues(i);
                resultList.Items.Add(new ListViewItem(relationProperties.Keys[i] + ": " + '\t' + x[0]));
            }
        }

        private void transitiveClosureButton_Click(object sender, EventArgs e)
        {
            matrix.TransitiveClosure();
        }


    }
}
