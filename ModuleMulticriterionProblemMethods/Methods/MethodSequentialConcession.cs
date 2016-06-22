using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;

namespace Modules.MulticriterionProblemMethods.Methods
{
    /// <summary>
    /// Коля
    /// </summary>
    internal class MethodSequentialConcession : Method
    {
        Modules.MulticriterionProblemMethods.DataTypes.Matrix mMatrix;
        internal override void Init ( Modules.MulticriterionProblemMethods.DataTypes.Matrix matrix )
        {
            mMatrix = matrix;
        }

        internal override Alternative[ ] Do ( )
        {
            List<Alternative> alterns = new List<Alternative> ( );

            ctrlMethodSequentialConcession ctrl = new ctrlMethodSequentialConcession ( mMatrix );
            return ( Alternative[ ] ) DoCallback ( ctrl, false, true, "Виберіть найважливіший критерій" );
        }

        public override string Name
        {
            get { return Properties.Resources.MethodSequentialConcession; }
        }
    }
}