using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.Workflow
{
    internal class MatrixConverter
    {
        #region Singleton

        private static MatrixConverter _theOnly = new MatrixConverter ( );

        private MatrixConverter ( )
        { }

        public static MatrixConverter Current
        {
            get { return _theOnly; }
        }

        #endregion

        /// <summary>
        /// ������ �������, ��������� ������ �����������
        /// </summary>
        /// <param name="alternatives">������������</param>
        /// <returns>�������</returns>
        public Matrix GetMatrix ( Alternative[] alternatives )
        {
            if ( alternatives.Length == 0 ) return null;

            // get vriteriums
            List<Criterium> criteriums = new List<Criterium> ( );
            foreach ( Criterium criterum in alternatives[ 0 ].Criteriums )
                criteriums.Add ( criterum );
            // creating matrix
            Matrix matrix = new Matrix ( );
            matrix.SetCriteriums ( criteriums );
            // adding alternatives
            foreach ( Alternative alternative in alternatives )
                matrix.AddAlternative ( alternative );

            return matrix;
        }
        /// <summary>
        /// ������� ������������ �������
        /// </summary>
        /// <param name="matrix">�������</param>
        /// <returns>������������ �������</returns>
        public Alternative[] GetAlternatives ( Matrix matrix )
        {
            // creating alternatives
            List<Alternative> result = new List<Alternative> ( matrix.Alternatives );
            return result.ToArray ( );
        }
    }
}