using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions
{
    internal class ModuleException : Exception
    {
        public ModuleException ( string message )
            : base ( message            )
        { }

        public ModuleException ( string message, Exception innerException)
            : base(message, innerException)
        { }        
    }
}
