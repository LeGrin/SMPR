using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.Inerfaces
{
    internal interface IAlternativeComparer : IComparer<Alternative>
    {
        bool IsEqual ( Alternative x, Alternative y );
        bool IsComparable ( Alternative x, Alternative y );
        bool IsInComparable ( Alternative x, Alternative y );
        bool IsDominating ( Alternative x, Alternative y, bool isStrongDomination );
        int DominationLevel ( Alternative x, Alternative y );
    }
}