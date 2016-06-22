using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativesIncomparableException : AlternativeComparingException
    {
        public AlternativesIncomparableException()
            : base ( "Альтернативи э непорівнювальними !!!" )
        {
        }

        public AlternativesIncomparableException(Exception innerException)
            : base ( "Альтернативи э непорівнювальними !!!", innerException )
        { }

        public AlternativesIncomparableException(string message, Exception innerException)
            : base ( message, innerException )
        {
        }
    }
}
