using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    public class EventArgs<T> : EventArgs
    {
        private T _value;

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public EventArgs ( )
        { }
        public EventArgs ( T value )
        {
            _value = value;
        }
    }
}
