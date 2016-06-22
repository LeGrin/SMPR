using System;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Collections;

namespace Modules.MulticriterionProblemMethods.View.Controls
{
    internal interface IMatrixPresenter
    {
        void AddAlternative ( string AlternativeNameColumnName );
        void AddCriterium ( string criteriumName );
        IEnumerable Alternatives { get; }
        void ClearMatrix ( );
        IEnumerable Criteriums { get; }
        Matrix Matrix { get; set; }
        bool ReadOnly { get; set; }
        void RemoveAlternative ( );
        void RemoveCriterium ( );
    }
}