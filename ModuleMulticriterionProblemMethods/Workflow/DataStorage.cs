using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.View.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Workflow
{
    /// <summary>
    /// Зберігає в собі введену користувачем матрицю та останній результат обчислень.
    /// </summary>
    internal class DataStorage
    {
        internal Matrix _matrix = null;
        /// <summary>
        /// Матриця
        /// </summary>
        public Matrix Matrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        private Alternative[] _lastResult = null;
        /// <summary>
        /// Останній результат
        /// </summary>
        public Alternative[] LastResult
        {
            get { return _lastResult; }
            set { _lastResult = value; }
        }
        /// <summary>
        /// Повертає тру, якщо клас містить результат        
        /// </summary>
        public bool HasResult
        {
            get { return _lastResult != null && _lastResult.Length > 0; }
        }

        /// <summary>
        /// Повертаэ тру, якщо дані введено
        /// </summary>
        public bool HasData
        {
            get
            {
                return _matrix != null
                    && _matrix.AlternativesCount > 0
                    && _matrix.CriteriumsCount > 0;
            }
        }
    }
}