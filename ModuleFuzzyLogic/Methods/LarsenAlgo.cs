using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;

namespace Modules.ModuleFuzzyLogic.Methods
{
    class LarsenAlgo : Method
    {
        public override string Name
        {
            get { return "Алгоритм Ларсена"; }
        }

        public void defuzzificate(FuzzySet1D A1, FuzzySet1D A2, FuzzySet1D B1, FuzzySet1D B2, 
            FuzzySet1D C1, FuzzySet1D C2, double x0, double y0)
        {
            double alfa1 = Math.Min(A1.Mu(x0), B1.Mu(y0));
            FuzzySet1D multC1 = FuzzySet1D.multiplyProbOn(C1, alfa1);
            double alfa2 = Math.Min(A2.Mu(x0), B2.Mu(y0));
            FuzzySet1D multC2 = FuzzySet1D.multiplyProbOn(C2, alfa2);
            FuzzySet1D res = multC1 & multC2;
            // now defuzzificate dis madafacka
        }
    }
}
