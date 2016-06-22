using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;

namespace Modules.MulticriterionProblemMethods.Methods
{
    /// <summary>
    /// Іра
    /// </summary>
    internal class MethodDominativeCriteria : Method
    {

        internal override Alternative[ ] Do ( )
        {
            int[ , ] qar = new int[ 1000, 1000 ];
            int[ ] qarmax = new int[ 1000 ];
            int i = 0;
            int j = 0;
            ////// Формуємо матрицю q
            foreach ( Alternative a in Matrix.Alternatives )
            {
                qarmax[ i ] = 0;
                j = 0;
                foreach ( Alternative b in Matrix.Alternatives )
                {
                    qar[ i, j ] = 0;
                    foreach ( Criterium c in Matrix.Criteriums )
                        if ( a[ c ] < b[ c ] )
                            qar[ i, j ]++;

                    if ( qar[ i, j ] > qarmax[ i ] )
                        qarmax[ i ] = qar[ i, j ];
                    ++j;
                }
                ++i;
            }
            //////
            int an = i;  // kilkist alternative
            int ira_min = qarmax[ 0 ];

            for (i = 0; i < an; ++i)
                if (qarmax[i] < ira_min)
                    ira_min = qarmax[i];

            int[ ] alt_mas = new int[ 1000 ];
            int alt_mas_kol = 0;

            for ( i = 0; i < an; ++i )
                if ( qarmax[ i ] == ira_min )
                {
                    alt_mas_kol++;
                    alt_mas[ alt_mas_kol-1 ] = i;
                }
            List<Alternative> alternatives = new List<Alternative>();
            if (alt_mas_kol == 0)
            {
                alt_mas_kol = 1; 
                alt_mas[0] = 0;
            }
            for (int alt_index = 0; alt_index < alt_mas_kol; alt_index++)
               alternatives.Add(Matrix.GetAlternativeByIndex(alt_mas[alt_index]));
            return alternatives.ToArray();
        }

        public override string Name
        {
            get { return Properties.Resources.MethodDominativeCriteriaName; }
        }
    }
}
