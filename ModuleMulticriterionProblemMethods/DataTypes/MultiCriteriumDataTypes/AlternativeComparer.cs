using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.Exceptions;
using Modules.MulticriterionProblemMethods.Exceptions.Alternative;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    /// <summary>
    /// Порівнює альтернативи
    /// </summary>
    internal class AlternativeComparer : IAlternativeComparer
    {
        /// <summary>
        /// Перевірка на те, чи мають критерії однакову структуру
        /// </summary>        
        private void _checkAlternativesForSameCriteriums(Alternative x, Alternative y)
        {
            string exceptionMessage = "Альтернативи містять різні критерії !!!";

            if ( x.CriteriumsCount != y.CriteriumsCount )
                throw new AlternativeConstraintException ( exceptionMessage );

            foreach ( Criterium c in x.Criteriums )
            {
                if ( !y.HasCriterium ( c ) )
                    throw new AlternativeConstraintException ( exceptionMessage );
            }
        }
        /// <summary>
        /// Перевірка на еквівалентність
        /// </summary>        
        public bool IsEqual(Alternative x, Alternative y)
        {
            _checkAlternativesForSameCriteriums ( x, y );

            foreach ( Criterium c in x.Criteriums )
                if ( x[ c ] != y[ c ] ) return false;

            return true;
        }
        /// <summary>
        /// Перевіряє, чи є дві альтернативи порівнювальними
        /// </summary>        
        public bool IsComparable ( Alternative x, Alternative y )
        {
            try
            {
                _checkAlternativesForSameCriteriums ( x, y );

                bool? xDominating = null;
                foreach ( Criterium c in x.Criteriums )
                {
                    if ( xDominating == null && x[ c ] != y[ c ] )
                    {
                        xDominating = x[ c ] > y[ c ];
                        continue;
                    }
                    else if ( x[ c ] != y[ c ] && ( ( xDominating.Value && x[ c ] < y[ c ] ) || ( !xDominating.Value && x[ c ] > y[ c ] ) ) )
                    {
                        return false;
                    }
                }

            }
            catch ( AlternativeConstraintException )
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перевірає, чи є дві альтернативи непорівнювальними
        /// </summary>        
        public bool IsInComparable(Alternative x, Alternative y)
        {
            return !IsComparable ( x, y );
        }
        /// <summary>
        /// Перевірка, чи альтернатива x домінує над альтернативою y
        /// </summary>        
        /// <param name="isStrongDomination">Якщо рівне true, то йде перевірка на строге домінування</param>
        public bool IsDominating(Alternative x, Alternative y, bool isStrongDomination)
        {
            if ( IsInComparable ( x, y ) ) return false;

            foreach ( Criterium c in x.Criteriums )
            {
                if ( x[ c ] < y[ c ] ) return false;
                if ( x[ c ] > y[ c ] || !isStrongDomination ) continue;
            }
            return true;
        }
        /// <summary>
        /// Перевіряє, наскільки сильно альтернатива x домінує над альтернативою y
        /// </summary>        
        public int DominationLevel(Alternative x, Alternative y)
        {
            _checkAlternativesForSameCriteriums ( x, y );

            if ( !IsDominating ( x, y, false ) )
                throw new AlternativeIsNotDominatingException ( );

            int dominationLevel = 0;

            foreach ( Criterium c in x.Criteriums )
                dominationLevel += x[ c ] - y[ c ];

            return dominationLevel;
        }
        /// <summary>
        /// Порівняння двох альтернатив
        /// </summary>   
        public int Compare(Alternative x, Alternative y)
        {
            int dominationLevel;
            try
            {
                dominationLevel = DominationLevel ( x, y );
            }
            catch ( AlternativeIsNotDominatingException )
            {
                dominationLevel = 0;
            }

            return dominationLevel;
        }
    }
}