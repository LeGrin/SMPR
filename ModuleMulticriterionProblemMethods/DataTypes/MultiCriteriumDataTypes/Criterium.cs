using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    /// <summary>
    /// Представляє собою деякий критерій
    /// </summary>
    internal struct Criterium
    {
        #region Overrides/Reloads
        /// <summary>
        /// Строкове представлення
        /// (Ім"я)
        /// </summary>        
        public override string ToString ( )
        {
            return _name.ToString ( );
        }
        /// <summary>
        /// Returns a hashcode
        /// </summary>        
        public override int GetHashCode ( )
        {
            return _name.ToUpper ( ).GetHashCode ( );
        }
        /// <summary>
        /// Check, if other object is equal
        /// Checks by name.
        /// </summary>
        public override bool Equals ( object obj )
        {
            if ( obj == null ) return false;
            try
            {
                Criterium other = ( Criterium ) obj;
                return string.Equals ( this._name, other._name, StringComparison.OrdinalIgnoreCase );
            }
            catch ( InvalidCastException )
            {
                return false;
            }
        }
        /// <summary>
        /// Reload of operator ==
        /// </summary>        
        public static bool operator == ( Criterium c1, Criterium c2 )
        {
            return c1.Equals ( c2 );
        }
        /// <summary>
        /// Reload of operator !=
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator != ( Criterium c1, Criterium c2 )
        {
            return !c1.Equals ( c2 );
        }
        #endregion

        /// <summary>
        ///  Ім"я
        /// </summary>
        private readonly string _name;
        /// <summary>
        /// Ім"я
        /// </summary>
        public string Name
        {
            get { return _name; }
        }        

        /// <summary>
        /// Створює критерій
        /// </summary>      
        /// <param name="name">Ім"я критерію</param>
        public Criterium ( string name )
        {
            if ( string.IsNullOrEmpty ( name ) ) throw new ArgumentException ( "name cannnot be null or empty!" );
            _name = name;
        }
    }
}