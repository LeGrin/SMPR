using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;

namespace Modules.ModuleFuzzyLogic.Methods
{
    public class SugenoAndTakagiAlgo : Method
    {
        public override string Name { get { return Properties.Resources.SugenoAndTakagiAlgo; } }


       public void GetAnswer(FuzzySet1D A1, FuzzySet1D A2, FuzzySet1D B1, FuzzySet1D B2,
            FuzzySet1D C1, FuzzySet1D C2, double x0, double y0, double a1, double a2, double b1, double b2)
        {   
            double alfa1 = Math.Min(A1.getMu(x0), B1.getMu(y0));
            double alfa2 = Math.Min(A2.getMu(x0), B2.getMu(y0));
            if (alfa1 == 0 && alfa2 == 0)
            {
                System.Windows.Forms.MessageBox.Show(Resourses.LocalStrings.alfa1_alfa2_zero);
                return;

            }
            double z1 = a1 * x0 + b1 * y0;
            double z2 = a2 * x0 + b1 * y0;

            double z0 = (alfa1*z1 + alfa2*z2)/(alfa1 + alfa2);
            System.Windows.Forms.MessageBox.Show(String.Format("{0} z0 = {1}", Resourses.LocalStrings.Result, z0));
      }
    }
}
