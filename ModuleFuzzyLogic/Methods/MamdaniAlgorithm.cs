using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;

namespace Modules.ModuleFuzzyLogic.Methods
{
    class MamdaniAlgorithm : Method
    {
        public override string Name { get { return Properties.Resources.MamdaniAlgorithm; } }

        public double calcAnswer(List<Tuple<FuzzySet1D, FuzzySet1D>> conditions, List<FuzzySet1D> conclusions, double x0, double y0)
        {
            double z0 = 0.0;
            FuzzySet1D z = new FuzzySet1D();
            List<FuzzySet1D> sets = new List<FuzzySet1D>();
            int len = conclusions.Count;

            for (int i = 0; i < len; i++)
            {
                double alpha1 = conditions.ElementAt(i).Item1.getMu(x0);
                double alpha2 = conditions.ElementAt(i).Item2.getMu(y0);
                double alpha = Math.Min(alpha1, alpha2);

                sets.Add(conclusions.ElementAt(i).sliceSet(alpha));
            }

            for (int i = 0; i < len; i++)
            {
                z = z.unite(sets.ElementAt(i));
            }
            
            z0 = z.integral(true) / z.integral(false);

            return z0;
        }
    }
}
