using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.VotingMethods
{
    [global::System.Serializable]
    public class ProfileException : Exception
    {
        int rowIndex = 0, colIndex = 0;

        public int RowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public int ColIndex
        {
            get { return colIndex; }
            set { colIndex = value; }
        }

        public ProfileException()
        {

        }

        public ProfileException(string message, int rowIndex, int colIndex)
            : base(message)
        {
            this.rowIndex = rowIndex;
            this.colIndex = colIndex;
        }
    }

    
    [global::System.Serializable]
    public class MethodException : Exception
    {
        Method exMethod;

        public Method ExMethod
        {
            get { return exMethod; }
            set { exMethod = value; }
        }

        public MethodException()
        {

        }

        public MethodException(string message, Method exMethod)
            : base(message)
        {
            this.exMethod = exMethod;
        }
    }
}
