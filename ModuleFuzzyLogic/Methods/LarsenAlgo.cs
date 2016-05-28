using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;

namespace Modules.ModuleFuzzyLogic.Methods
{
    public class LarsenAlgo : Method
    {
        public override string Name
        {
            get { return "Алгоритм Ларсена"; }
        }

        public void Defuzzificate(FuzzySet1D A1, FuzzySet1D A2, FuzzySet1D B1, FuzzySet1D B2, 
            FuzzySet1D C1, FuzzySet1D C2, double x0, double y0)
        {

            double alfa1 = Math.Min(A1.getMu(x0), B1.getMu(y0));
            FuzzySet1D multC1 = C1.multiplyMuOn(alfa1);
            double alfa2 = Math.Min(A2.getMu(x0), B2.getMu(y0));
            FuzzySet1D multC2 = C2.multiplyMuOn(alfa2);
            //FuzzySet1D res = multC1 & multC2;
            // now defuzzificate dis madafacka
        }
    }
}
