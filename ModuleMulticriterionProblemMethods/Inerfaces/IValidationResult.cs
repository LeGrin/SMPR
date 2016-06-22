using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Inerfaces
{
    internal interface IValidationResult
    {
        bool IsSucces { get;}
        string ErrorMessage { get;}
    }
}
