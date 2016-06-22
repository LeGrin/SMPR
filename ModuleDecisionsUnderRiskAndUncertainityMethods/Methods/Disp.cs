using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Disp:Method
    {
        public Disp()
        {
            this.crit = 273;
        }
        public override int RunMethod()
        {
            double[] msp = new double[matr.GetLength(0)];
            double[] mar = new double[matr.GetLength(0)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                msp[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    msp[i] += matr[i, j] * prob[j];                
            }
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    mar[i] += (matr[i, j] - msp[i]) * (matr[i, j] - msp[i]) * prob[j];
                if (mar[res] > mar[i]) res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Μ³ν³μ³ηΰφ³Ώ Δθροεπρ³Ώ"; }
            get { return Properties.Resources.MethodVarianceMinimization; }
        }
    }
}
