using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods
{
    public abstract class Method : Common.MethodAbstract
    {
        //private string name;
        protected  double[,] matr;
        protected double[] prob;
        protected double alfa;
        protected double a;
        protected int crit;
        //protected int num;
        public void Init(double[,] m, double[] p, double alfa, double a)
        {
            matr = new double[m.GetLength(0), m.GetLength(1)];
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    matr[i, j] = m[i, j];
                }
            prob=new double[p.Length];
            p.CopyTo(prob, 0);
            this.alfa = alfa;
            this.a = a;
            //this.num = num;
        }
        virtual public int RunMethod()
        {
            return 0;
        }
        public bool Match(int pat)
        {
            return pat==(pat & crit);
        }
        public string GetName()
        {
            return Name;
        }
    }
}
