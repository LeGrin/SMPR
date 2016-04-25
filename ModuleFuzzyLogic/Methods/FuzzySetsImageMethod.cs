using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Math;
using System.Threading.Tasks;

namespace Modules.ModuleFuzzyLogic.Methods
{
    public class FuzzySetsImageMethod : Method
    {
        public override string Name { get { return Properties.Resources.FuzzySetsImage; } }// Properties.Resources.OperationsOnRelationships; } }

        public double functionClearImage(double x, int func, double koef)
        {
            double result = 0;
            if(func == 0)
                result = koef * x ;
            if (func == 1)
                result = koef * x * x;
            if (func == 2)
                result = koef * x * x * x;
            if (func == 3)
                result = koef * x * x * x * x;
            if(func == 4)
                result = koef*(Math.Sin(x));
            if (func == 5)
                result = koef * Math.Cos(x);
            if (func == 6)
                result = koef * Math.Tan(x);
            if (func == 7)
                result = koef * Math.Log10(x);
            if (func == 8)
                result = koef * Math.Log(x);
            if (func == 9)
                result = koef * Math.Exp(x);
        

            return result;
        }
        public Dictionary<double, double> resultClearImage(Dictionary<double, double> set, int func, double koef)
        {
            Dictionary<double, double> ans = new Dictionary<double, double>();
            foreach (double x in set.Keys)
            {
                double y = functionClearImage(x, func, koef);
                ans.Add(y, set[x]);
            }
            return ans;
        }
        public Dictionary<double, double> resultFuzzyImage1(Dictionary<double, double>[] subSet, Dictionary<double, double> set, int n)
        {
            double mx = 0;
            Dictionary<double, double> ans = new Dictionary<double, double>();
            for (int i = 0; i < n; i++)
            {
                foreach (double x in subSet[i].Keys)
                {
                    if (ans.ContainsKey(x))
                    {
                        mx = Math.Max(ans[x], subSet[i][x]);
                        ans[x] = mx;
                    }
                    else
                    {
                        ans.Add(x, Math.Min(subSet[i][x], set.ElementAt(i).Value));
                    }
                }
            }
            return ans;
        }
        public Dictionary<double, double> resultFuzzyImage2(Dictionary<double, double> set, Dictionary<double, double> setC, int func, double koef)
        {
            Dictionary<double, double> ans = new Dictionary<double, double>();
            double mx = 0;
            foreach (double x in set.Keys)
            {
                foreach (double y in setC.Keys)
                {
                    double k = y*functionClearImage(x, func, koef); 
                    if (!ans.ContainsKey(k))
                    {
                        ans.Add(k, Math.Min(set[x], setC[y]));
                    }
                    else
                    {
                        mx = Math.Max(Math.Min(set[x], setC[y]), ans[k]);
                        ans.Remove(k);
                        ans.Add(k, mx);
                    }
                }
            }
            return ans;
        }
    }
}

