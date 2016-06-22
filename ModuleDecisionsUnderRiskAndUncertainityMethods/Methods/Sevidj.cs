using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Sevidj:Method
    {
        public Sevidj()
        {
            this.crit = 526;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            double[] maxr = new double[matr.GetLength(1)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(1); i++)
            {
                maxr[i] = 0;
                for (int j = 0; j < matr.GetLength(0); j++)
                    if (maxr[i] < matr[j, i]) maxr[i] = matr[j, i];
            }
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (mar[i] < (maxr[j]-matr[i, j])) mar[i] = maxr[j]-matr[i,j];
                if (mar[res] > mar[i]) res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Севіджа"; }
            get { return Properties.Resources.MethodSavage; }
        }
    }
}
