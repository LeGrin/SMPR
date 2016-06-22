using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Gurvitz:Method
    {
        public Gurvitz()
        {
            //this.crit = 198;
            this.crit = 1222;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            double[] min = new double[matr.GetLength(0)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                min[i] = int.MaxValue;
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (matr[i, j] > mar[i]) mar[i] = matr[i, j];
                    if (matr[i, j] < min[i]) min[i] = matr[i, j];
                }
                mar[i] = alfa * mar[i] + (1 - alfa) * min[i];
                if (mar[i] > mar[res])
                    res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "√урв≥ца"; }
            get { return Properties.Resources.MethodGurvits; }
        }
    }
}
