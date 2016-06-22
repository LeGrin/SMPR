using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Collections;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;

namespace Modules.MulticriterionProblemMethods.Methods
{
    internal class MethodLimiting : Method
    {
        Matrix mMatrix;
        Alternative[ ] ans;

        internal override void Init ( Modules.MulticriterionProblemMethods.DataTypes.Matrix matrix )
        {
            mMatrix = matrix;
        }
        internal override Alternative[ ] Do ( )
        {
            ctrlMethodLimiting ctrl = new ctrlMethodLimiting ( mMatrix );
            return ( Alternative[ ] ) DoCallback ( ctrl );

        }

        public override string Name
        {
            get { return Properties.Resources.MethodLimitingName; }
        }
    }
}
