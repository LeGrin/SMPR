using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.Workflow.Validation;

namespace Modules.MulticriterionProblemMethods.Workflow
{
    internal static class ValidatorProvider
    {
        public static IValidationResult Validate<T> ( ValidationKind validationKind, T[] validationParameters, T checkedObject )
        {
            switch ( validationKind )
            {
                case ValidationKind.Unique:
                    object[] validationParametersObjectArray = new object[validationParameters.Length];
                    validationParameters.CopyTo(validationParametersObjectArray, 0);
                    UniqueValidator<T> validator = new UniqueValidator<T>(validationParametersObjectArray, checkedObject);
                    return validator.Validate ( );
                    
                default: throw new NotImplementedException ( "Not implemented switch in ValidatorProvider.Validate()" );
            }
        }
    }
}
