using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Opt:Method
    { 
        public  Opt()
        {
            this.crit = 146;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (matr[i, j] > mar[i]) mar[i] = matr[i, j];
                if (mar[i] > mar[res])
                    res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Оптимістичний"; }
            get { return Properties.Resources.MethodOptimistic; }
        }
    }
}
