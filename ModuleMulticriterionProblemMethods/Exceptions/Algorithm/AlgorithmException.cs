using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.Exceptions.Algorithm
{
    internal class AlgorithmException : ModuleException
    {
        public AlgorithmException ( )
            : base ( "������� ��� ��������� !" )
        { }

        public AlgorithmException ( string message )
            : base ( "������� ��� ���������: " + message )
        { }

        public AlgorithmException ( string message, Exception innerException )
            : base ( "������� ��� ���������: " + message, innerException )
        { }
    }
}
