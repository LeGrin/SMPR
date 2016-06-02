﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySets;

namespace Modules.ModuleFuzzyLogic.Methods
{
    public class SimplifiedAlgo : Method
    {
        public override string Name
        {
            get { return "Спрощений алгоритм"; }
        }

        public void Defuzzificate(FuzzySet1D A1, FuzzySet1D A2, FuzzySet1D B1, FuzzySet1D B2,
            double c1, double c2, double x0, double y0)
        {

            double alfa1 = Math.Min(A1.getMu(x0), B1.getMu(y0));
            double alfa2 = Math.Min(A2.getMu(x0), B2.getMu(y0));
            
            if (alfa1 == 0 && alfa2 == 0)
            {
                System.Windows.Forms.MessageBox.Show("Обидва числа alfa1 і alfa2 рівні нулю. Будь ласка, введіть інші значення для x0 та y0");
                return;
            }

            double resultZ = (alfa1 * c1 + alfa2 * c2) / (alfa1 + alfa2);

            System.Windows.Forms.MessageBox.Show("Result Z is " + resultZ);
            
        }
    }
}