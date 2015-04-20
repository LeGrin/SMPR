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
    /// �����, ���������� ��� ������ ����������(������ �����������)
    /// </summary>
    internal partial class frmResultPresenter : frmBase
    {
        /// <summary>
        /// �����, ���������� ��� ������ ����������(������ �����������)
        /// </summary>
        public frmResultPresenter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ����������� �����
        /// </summary>
        /// <param name="alternatives">������ �����������, �� ������ ������������</param>
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
                ctrlNoData.Init("���������� ����������� �� ��������.", ctrlMultiCriteriaMatrix1);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}