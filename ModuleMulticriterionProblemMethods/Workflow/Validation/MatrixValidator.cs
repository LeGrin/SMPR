using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.Workflow.Validation
{
    /// <summary>
    /// ������� ���� ��� ��������� �������
    /// </summary>
    internal abstract class MatrixValidator : IValidator
    {
        private Matrix _matrix;

        protected Matrix Matrix
        {
            get { return _matrix; }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="matrix">�������, �� ���� �����������</param>
        public virtual void Init ( Matrix matrix )
        {
            if ( matrix == null ) throw new ArgumentNullException ( "matrix" );

            _matrix = matrix;
        }
        /// <summary>
        /// ��������!
        /// </summary>
        /// <returns>��������� ��������</returns>
        public abstract IValidationResult Validate ( );
    }
}
