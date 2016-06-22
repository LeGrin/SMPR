using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.Inerfaces
{
    internal interface INameEditor
    {
        void Show ( NameKind nameKind );
        string Name { get; }        
    }
}
