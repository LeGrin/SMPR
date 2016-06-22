using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Germeier:Method
    {
        public Germeier()
        {
            this.crit = 157;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = int.MaxValue;
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (prob[j]*matr[i, j] < mar[i]) mar[i] = matr[i, j]*prob[j];
                if (mar[i] > mar[res])
                    res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Гермейєра"; }
            get { return Properties.Resources.MethodGermeier; }
        }
    }
}
