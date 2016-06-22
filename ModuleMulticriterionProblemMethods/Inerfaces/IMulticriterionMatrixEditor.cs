using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Inerfaces
{
    internal interface IMatrixEditor
    {
        void Init ( Matrix matrix );
        Matrix Matrix { get;}
    }
}