using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Alternative
{
    internal class AlternativeComparingException : ModuleException
    {
        public AlternativeComparingException()
            :base("Помилка при порівнянні альтернатив! ")
        { 
        }

        public AlternativeComparingException(string message)
            : base ( "Помилка при порівнянні альтернатив: " + message )
        {
        }

        public AlternativeComparingException(string message, Exception innerException)
            : base ( "Помилка при порівнянні альтернатив: " + message, innerException )
        {
        }        
    }
}
