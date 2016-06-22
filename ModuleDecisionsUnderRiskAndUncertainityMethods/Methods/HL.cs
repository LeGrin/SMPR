using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class HL:Method
    {
        public HL()
        {
            this.crit = 290;
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
                    mar[i]+=matr[i,j]*prob[j];
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
            //get {return "Ходжа-Лемана"; }
            get { return Properties.Resources.MethodHodgesLehmann; }
        }
    }
}
