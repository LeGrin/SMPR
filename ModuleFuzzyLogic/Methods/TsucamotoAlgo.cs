using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;
using System.Windows.Forms;
namespace Modules.ModuleFuzzyLogic.Methods
{
    class TsucamotoAlgo : Method
    {
        public override string Name { get { return Properties.Resources.TsucamotoAlgo; } }

        public double CalcAlgo(FuzzySet1D A1, FuzzySet1D A2, FuzzySet1D B1, FuzzySet1D B2, 
            FuzzySet1D C1, FuzzySet1D C2, double x0, double y0)
        {
            double z0 = 0.0;
            double alfa1 = Math.Min(A1.getMu(x0), B1.getMu(y0));
            double alfa2 = Math.Min(A2.getMu(x0), B2.getMu(y0));

            double z1 = C1.Inv(alfa1);
            double z2 = C2.Inv(alfa2);

            if(alfa1!=0 || alfa2!=0)
             z0 = (alfa1 * z1 + alfa2 * z2) / (alfa1 + alfa2);
            return z0;
           
        }
    }
}
