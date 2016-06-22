using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class Adytyvn:Method
    { 
        public  Adytyvn()
        {
            this.crit = 322;
        }
        public override int RunMethod()
        {
            double[] mar = new double[matr.GetLength(0)];
            int res = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                mar[i] = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    mar[i] += matr[i, j];
                if (mar[i] > mar[res])
                    res = i;
            }
            return res;
        }
        public override string Name
        {
            //get {return "Адитивний"; }
            get { return Properties.Resources.MethodAdytyvn; }
        }
    }
}
