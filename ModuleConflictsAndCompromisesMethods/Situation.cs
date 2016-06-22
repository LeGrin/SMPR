using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.ConflictsAndCompromises
{
    public class Situation
    {
        int[] _value;

        public int this[int index]
        {
            get { return _value[index]; }
            set { _value[index] = value; }
        }

        public bool Dominates(Situation s)
        {
            bool dom = false;

            for (int i = 0; i < _value.Length; i++)
            {
                if (_value[i] > s[i]) dom = true;
                if (_value[i] < s[i]) return false;
            }

            return dom;
        }

        public Situation(params int[] value)
        {
            this._value = value;
        }
    }
}
