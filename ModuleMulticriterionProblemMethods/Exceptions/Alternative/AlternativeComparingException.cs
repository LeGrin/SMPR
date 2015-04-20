using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeComparingException : ModuleException
    {
        public AlternativeComparingException()
            :base("������� ��� �������� �����������! ")
        { 
        }

        public AlternativeComparingException(string message)
            : base ( "������� ��� �������� �����������: " + message )
        {
        }

        public AlternativeComparingException(string message, Exception innerException)
            : base ( "������� ��� �������� �����������: " + message, innerException )
        {
        }        
    }
}
