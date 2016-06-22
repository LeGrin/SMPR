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
    /// Контрол, що є ділоалогом з вибором "Так/Ні"
    /// </summary>
    public partial class ctrlYesNoDialog : ctrlMethodCallbackBase
    {
        public ctrlYesNoDialog ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// Повертає об"єкт, в якому запаковано булевське значення.(true == так)
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
