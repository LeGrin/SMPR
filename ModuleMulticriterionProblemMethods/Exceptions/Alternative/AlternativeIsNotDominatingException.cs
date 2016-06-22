using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeIsNotDominatingException : AlternativeComparingException
    {
        public AlternativeIsNotDominatingException()
            : base ( "Альтернатива не э домінуючою!" )
        { }

        public AlternativeIsNotDominatingException(string message)
            : base ( "Альтернатива не э домінуючою: " + message )
        { }

        public AlternativeIsNotDominatingException(string message, Exception innerException)
            : base ( "Альтернатива не э домінуючою: " + message, innerException )
        { }
    }
}
