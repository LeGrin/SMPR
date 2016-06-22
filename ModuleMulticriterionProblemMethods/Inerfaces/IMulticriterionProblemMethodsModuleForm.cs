using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Inerfaces
{
    internal interface IMulticriterionProblemMethodsModuleForm
    {
        void Init ( Control[] controlsToRunMethod );

        void Show ( );
        DialogResult ShowDialog ( );

        event EventHandler DataEditing;
        event EventHandler ShowResult;
        event EventHandler SavingToBuffer;
        event EventHandler LoadingFromBuffer;
    }
}
