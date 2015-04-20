using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeConstraintException : AlternativeComparingException
    {
        public AlternativeConstraintException()
            : base ( "���������� ������ ������������! " )
        {
        }

        public AlternativeConstraintException(string message)
            : base ( "���������� ������ ������������: " + message )
        {
        }

        public AlternativeConstraintException(string message, Exception innerException)
            : base ( "���������� ������ ������������!: " + message, innerException )
        {
        }
    }
}
