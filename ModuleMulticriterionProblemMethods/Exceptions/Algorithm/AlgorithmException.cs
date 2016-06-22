using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Algorithm
{
    internal class AlgorithmException : ModuleException
    {
        public AlgorithmException ( )
            : base ( "Помилка при обчисленні !" )
        { }

        public AlgorithmException ( string message )
            : base ( "Помилка при обчисленні: " + message )
        { }

        public AlgorithmException ( string message, Exception innerException )
            : base ( "Помилка при обчисленні: " + message, innerException )
        { }
    }
}
