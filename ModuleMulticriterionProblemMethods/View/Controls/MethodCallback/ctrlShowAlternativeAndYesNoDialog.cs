using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    /// <summary>
    /// ������ ������������, � ������, �� ���������� ���� ��.
    /// </summary>
    internal partial class ctrlShowAlternativeAndYesNoDialog : ctrlMethodCallbackBase
    {
        /// <summary>
        /// ������ ������������, � ������, �� ���������� ���� ��.
        /// </summary>
        public ctrlShowAlternativeAndYesNoDialog ( Alternative[ ] alternatives )
        {
            InitializeComponent ( );
            ctrlMatrix.Matrix = MatrixConverter.Current.GetMatrix ( alternatives );
        }
        /// <summary>
        /// ������� ��"���, � ����� ���������� ��������� ��������(��� == "���").
        /// </summary>
        public override object Value
        {
            get
            {
                return ctrlYesNoDialog.Value;
            }
        }
    }
}
