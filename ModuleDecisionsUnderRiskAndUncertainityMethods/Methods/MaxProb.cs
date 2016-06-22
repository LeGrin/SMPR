using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods.Methods
{
    class MaxProb:Method
    {
        public MaxProb()
        {
            this.crit = 273;
        }
        public override int RunMethod()
        {
            int maxp;
            int res = 0;
            maxp = 0;
            for (int j = 0; j < matr.GetLength(1); j++)
                if (prob[j] > prob[maxp]) maxp = j;
            for (int i = 0; i < matr.GetLength(0); i++)
                if (matr[i, maxp] > matr[res, maxp]) res = i;
            return res;
        }
        public override string Name
        {
            //get {return "Максимізації Ймоіврності"; }
            get { return Properties.Resources.MethodProbabilityMaximization; }
        }
    }
}
