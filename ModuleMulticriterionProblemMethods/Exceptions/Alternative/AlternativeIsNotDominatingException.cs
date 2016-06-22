using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeIsNotDominatingException : AlternativeComparingException
    {
        public AlternativeIsNotDominatingException()
            : base ( "������������ �� � ���������!" )
        { }

        public AlternativeIsNotDominatingException(string message)
            : base ( "������������ �� � ���������: " + message )
        { }

        public AlternativeIsNotDominatingException(string message, Exception innerException)
            : base ( "������������ �� � ���������: " + message, innerException )
        { }
    }
}
