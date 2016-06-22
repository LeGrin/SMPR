using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    internal class ValidatioResult : IValidationResult
    {
        private readonly string _errorMessage;       

        public bool IsSucces
        {
            get { return string.IsNullOrEmpty ( _errorMessage ); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
        }

        public ValidatioResult ( )
        {
            _errorMessage = string.Empty;
        }

        public ValidatioResult ( string errorMessage )
        {
            _errorMessage = errorMessage;
        }
    }
}
