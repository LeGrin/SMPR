using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    /// <summary>
    /// �������, �� � ��������� � ������� "���/ͳ"
    /// </summary>
    public partial class ctrlYesNoDialog : ctrlMethodCallbackBase
    {
        public ctrlYesNoDialog ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// ������� ��"���, � ����� ���������� ��������� ��������.(true == ���)
        /// </summary>
        public override object Value
        {
            get
            {
                return rbYes.Checked;
            }
        }
    }
}
