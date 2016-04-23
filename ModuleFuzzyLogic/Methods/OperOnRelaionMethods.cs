using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ModuleFuzzyLogic.Methods
{
    class OperOnRelaionMethods : Method
    {
        public override string Name { get { return Properties.Resources.OperationOnRelation; }  }// Properties.Resources.OperationsOnRelationships; } }

        public List<double> intersection(List<double> list1, List<double> list2)
        {
            List<double> res = new List<double>();
            if (list1.Count != list2.Count)
                return res;
            for(int i = 0; i<list1.Count; i++)
            {
                res.Add(Math.Min(list1[i], list2[i]));
            }
            return res;
        }

        public List<double> association(List<double> list1, List<double> list2)
        {
            List<double> res = new List<double>();
            if (list1.Count != list2.Count)
                return res;
            for (int i = 0; i < list1.Count; i++)
            {
                res.Add(Math.Max(list1[i], list2[i]));
            }
            return res;
        }

        public List<double> difference(List<double> list1, List<double> list2)
        {
            List<double> res = new List<double>();
            if (list1.Count != list2.Count)
                return res;
            for (int i = 0; i < list1.Count; i++)
            {
                res.Add(Math.Max(list1[i] - list2[i], 0));
            }
            return res;
        }

        public List<double> symmetricDifference(List<double> list1, List<double> list2)
        {
            List<double> res = new List<double>();
            if (list1.Count != list2.Count)
                return res;
            for (int i = 0; i < list1.Count; i++)
            {
                res.Add(Math.Abs(list1[i] - list2[i]));
            }
            return res;
        }

        public List<double> addition(List<double> list1)
        {
            List<double> res = new List<double>();
            for (int i = 0; i < list1.Count; i++)
            {
                res.Add(1 - list1[i]);
            }
            return res;
        }

        public List<double> composition(List<double> list1, int m11, int m12, List<double> list2, int m21, int m22)
        {
            double[,] ar1 = new double[m11, m12];
            double[,] ar2 = new double[m21, m22];
            for(int i=0;i<m11;i++)
            {
                for(int j=0;j<m12;j++)
                {
                    ar1[i, j] = list1[m12 * i + j];
                }
            }
            for (int i = 0; i < m21; i++)
            {
                for (int j = 0; j < m22; j++)
                {
                    ar2[i, j] = list2[m22 * i + j];
                }
            }
            List<double> res = new List<double>();
            for (int i = 0; i < m11; i++)
            {
                for (int j = 0; j < m22; j++)
                {
                    double mx = 0;
                    for (int k = 0; k < m12; k++)
                    {
                        double mn = Math.Min(ar1[i, k], ar2[k, j]);
                        if (mx < mn) mx = mn;
                    }
                    res.Add(mx);
                }
            }
            return res;
        }
    }
}
