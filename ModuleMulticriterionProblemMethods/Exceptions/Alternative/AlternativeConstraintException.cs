using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeConstraintException : AlternativeComparingException
    {
        public AlternativeConstraintException()
            : base ( "Некоректно задана альтернатива! " )
        {
        }

        public AlternativeConstraintException(string message)
            : base ( "Некоректно задана альтернатива: " + message )
        {
        }

        public AlternativeConstraintException(string message, Exception innerException)
            : base ( "Некоректно задана альтернатива!: " + message, innerException )
        {
        }
    }
}
