using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Voloshin:Method
    {
        public Voloshin()
        {
            this.crit = 526;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            double[] PO = new double[matr.GetLength(0)];
            double[] maxr = new double[matr.GetLength(0)];
            int e, a, p;
            int res = 0;

            for (int i = 0; i < matr.GetLength(0); i++)
            {
                PO[i] = 1;
                p = 0;
                for (int j = 0; j < matr.GetLength(0); j++)
                {
                    e = 0;
                    a = 1;
                    for (int k = 0; k < matr.GetLength(1); k++)
                        if (matr[i, k] < matr[j, k]) e = 1;
                        else if (matr[i, k] > matr[j, k]) a = 0;
                    if ((e == 1) && (a == 1)) p = 1;
                }
                if (p == 1) PO[i] = 0;
            }

            for (int j = 0; j < matr.GetLength(0); j++)
            {
                maxr[j] = 0;
                for (int i = 0; i < matr.GetLength(1); i++)
                    if (maxr[j] < matr[j, i]) maxr[j] = matr[j, i];
            }
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (mar[i] < (maxr[i]-matr[i, j])) mar[i] = maxr[i]-matr[i,j];
                if ((mar[res] > mar[i])&&(PO[i]==1)) res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Волошина"; }
            get { return Properties.Resources.MethodVoloshin; }
        }
    }
}
