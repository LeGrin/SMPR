using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.ModuleCooperativeProblemSolving
{
    public abstract class Method : Common.MethodAbstract
    {
        protected int CountBits(int x)
        {
            int r = 0;
            while (x > 0)
            {
                x &= x - 1;
                r++;
            }
            return r;
        }

        protected string IndexArrayToKey(int[] index)
        {
            StringBuilder key = new StringBuilder();
            for (int j = 0; j < strategies.PlayerCount; j++)
            {
                if (j > 0)
                    key.Append(", ");
                key.Append(strategies.GetStrategies(j)[index[j]]);
            }
            return key.ToString();
        }


        protected string PlayerSet(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                    sb.Append(", ");
                sb.Append((i + 1).ToString());
            }
            return sb.ToString();
        }

        protected Strategies strategies;

        public void Init(Strategies strategies)
        {
            this.strategies = strategies;
        }

        public abstract string[] Execute();
        public abstract string ResultSetName { get; }
        public abstract string ResultComment { get; }
    }
}