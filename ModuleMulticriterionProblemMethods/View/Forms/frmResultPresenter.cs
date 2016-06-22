using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.View.Controls;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    /// <summary>
    /// Форма, призначена для показу результату(списку альтернатив)
    /// </summary>
    internal partial class frmResultPresenter : frmBase
    {
        /// <summary>
        /// Форма, призначена для показу результату(списку альтернатив)
        /// </summary>
        public frmResultPresenter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Ініціалізація форми
        /// </summary>
        /// <param name="alternatives">Список альтернатив, що будуть відображатися</param>
        public void Init(Alternative[] alternatives)
        {
            if (alternatives != null && alternatives.Length > 0)// if result exists
            {
                Matrix matrix = MatrixConverter.Current.GetMatrix(alternatives);
                ctrlMultiCriteriaMatrix1.Matrix = matrix;
                ctrlMultiCriteriaMatrix1.ReadOnly = true;
            }
            else
            {
                ctrlThereIsNoData ctrlNoData = new ctrlThereIsNoData();
                ctrlNoData.Init("Ефективних альтернатив не знайдено.", ctrlMultiCriteriaMatrix1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}