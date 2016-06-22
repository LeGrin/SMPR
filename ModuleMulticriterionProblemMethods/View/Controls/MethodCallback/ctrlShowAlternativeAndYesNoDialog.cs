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
    /// Показує альтернативи, і запитує, чи задовільняє його це.
    /// </summary>
    internal partial class ctrlShowAlternativeAndYesNoDialog : ctrlMethodCallbackBase
    {
        /// <summary>
        /// Показує альтернативи, і запитує, чи задовільняє його це.
        /// </summary>
        public ctrlShowAlternativeAndYesNoDialog ( Alternative[ ] alternatives )
        {
            InitializeComponent ( );
            ctrlMatrix.Matrix = MatrixConverter.Current.GetMatrix ( alternatives );
        }
        /// <summary>
        /// Повертає об"єкт, в якому запаковано булевське значення(Тру == "Так").
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
