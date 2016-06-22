using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.Workflow.Validation
{
    /// <summary>
    /// Базовий клас для валыдації матриці
    /// </summary>
    internal abstract class MatrixValidator : IValidator
    {
        private Matrix _matrix;

        protected Matrix Matrix
        {
            get { return _matrix; }
        }

        /// <summary>
        /// Ініціалізація
        /// </summary>
        /// <param name="matrix">Матриця, що буде валідуватись</param>
        public virtual void Init ( Matrix matrix )
        {
            if ( matrix == null ) throw new ArgumentNullException ( "matrix" );

            _matrix = matrix;
        }
        /// <summary>
        /// Валідація!
        /// </summary>
        /// <returns>Результат валідації</returns>
        public abstract IValidationResult Validate ( );
    }
}
