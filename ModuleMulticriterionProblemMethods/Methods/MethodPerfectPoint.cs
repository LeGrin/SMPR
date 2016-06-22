using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;

namespace Modules.MulticriterionProblemMethods.Methods
{
    /// <summary>
    /// Іра
    /// </summary>
    internal class MethodPerfectPoint : Method
    {
        //private const string INFINITY = "Нескінченність";
        private const string ONE = "1";
        private const string TWO = "2";
        private int ira_s;

        public override string Name
        {
            get { return Properties.Resources.MethodPerfectPointName; }
        }
        internal override Alternative[ ] Do ( )
        {
            int i = 0;
            int j = 0;
            ira_s = 2;
            double d = _doCallback ( );
            d = d == double.PositiveInfinity ? 0 : ( int ) d;
            ira_s = ( int ) d;

            int[ ] ideal = new int[ 1000 ];
            i = j = 0;
            foreach ( Criterium a in Matrix.Criteriums )
            {
                foreach ( Alternative c in Matrix.Alternatives )
                    if ( ( j == 0 ) || ( c[ a ] > ideal[ i ] ) )
                    {
                        ideal[ i ] = c[ a ];
                        j++;
                    }
                i++;
                j = 0;
            }

            double ira_p = 0, ira_minp = -1;
            int[ ] alt_mas = new int[ 1000 ];
            int alt_mas_kol = 0;
            i = j = 0;
            if ( ira_s == 0 )
            {
                ira_s = 1;
                foreach ( Alternative a in Matrix.Alternatives )
                    foreach ( Criterium c in Matrix.Criteriums )
                        if ( a[ c ] > ira_s )
                            ira_s = a[ c ];
            }

            foreach ( Alternative a in Matrix.Alternatives )
            {
                ira_p = 0;
                i = 0;
                foreach ( Criterium c in Matrix.Criteriums )
                {
                    int abs = a[ c ] - ideal[ i ];
                    if ( abs < 0 )
                        abs = -abs;
                    for ( int ksy = 1; ksy < ira_s; ksy++ )
                        abs = abs * abs;
                    ira_p += abs;
                    i++;
                }
                //   MessageBox.Show(j.ToString() + " : ira_p " + ira_p.ToString());
                if ( ira_p == ira_minp )
                {
                    alt_mas_kol++;
                    alt_mas[ alt_mas_kol - 1 ] = j;
                };
                if ( ( ira_p < ira_minp ) || ( j == 0 ) )
                {
                    ira_minp = ira_p;
                    alt_mas_kol = 1;
                    alt_mas[ alt_mas_kol - 1 ] = j;
                };
                j++;
            }
            List<Alternative> alternatives = new List<Alternative> ( );
            for ( int alt_index = 0; alt_index < alt_mas_kol; alt_index++ )
                alternatives.Add ( Matrix.GetAlternativeByIndex ( alt_mas[ alt_index ] ) );
            return alternatives.ToArray ( );
        }

        private double _doCallback ( )
        {
            Dictionary<string, object> variants = new Dictionary<string, object> ( );
            variants.Add ( ONE, 1.0d );
            variants.Add ( TWO, 2.0d );
            variants.Add ( Properties.Resources.INFINITY, double.PositiveInfinity );

            ctrlVariantsSelector ctrl = new ctrlVariantsSelector ( );
            ctrl.Init ( variants );

            return Convert.ToDouble ( DoCallback ( ctrl ).ToString ( ) );
        }
    }
}