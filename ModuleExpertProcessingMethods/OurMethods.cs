using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ExpertProcessingMethods
{
    //public abstract class Method : Common.MethodAbstract
    //{
    //    public abstract void Execute(int expertCount, int[] expertTrust, ArrayList expertOpinions, out double efficiency, out ArrayList results);
    //}
    public class IncorrectMethodUse: Exception
    {
    };

    public  class SampleMethod : Method
    {
        public override String Name { get {return "sample";} }
        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            MessageBox.Show("yo");
            efficiency = 1;
            results = new ArrayList();
        }
    };

    public class SimpleSumming : Method
    {
        public override String Name { get { return "Expertise1"; } }
        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            double sum=0;
            double trustSum=0;
            double distortionSum = 0;
            for (int i = 0; i < expertCount; i++)
            {
                if (!(expertOpinions[i] is double)) throw new IncorrectMethodUse();

                sum += expertTrust[i] * (double)expertOpinions[i];
                trustSum += expertTrust[i];
            }
            double result = sum / trustSum;
            for (int i = 0; i < expertCount; i++)
            {
               double dist = (result-(double)expertOpinions[i]);
               distortionSum += dist * dist*expertTrust[i];
            }
            efficiency = distortionSum/trustSum;
            results = result;
        }

    };

    public class TestedSumming : Method
    {
        public override String Name { get { return "Expertise1"; } }

        protected double Gamma1;
        protected double Gamma2;
        protected double Gamma3;
        protected double Gamma4;

        public void Init(double _gamma1,double _gamma2,double _gamma3,double _gamma4)
        {
            Gamma1 = _gamma1;
            Gamma2 = _gamma2;
            Gamma3 = _gamma3;
            Gamma4 = _gamma4;
        }


        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            double sum=0;
            double trustSum=0;
            double distortionSum = 0;

            double[] a = new double[expertCount];
            double[] si = new double[expertCount];


            for (int i = 0; i < expertCount; i++)
            {
                Object opinion = expertOpinions[i];
                if (!(opinion is double[])) throw new IncorrectMethodUse();
                double[] marks = (double[]) opinion;

                si[i] = (marks[2] - marks[0]) * (marks[2] - marks[0]) / Gamma4;
                a[i] = (marks[0] * Gamma1 + marks[1] * Gamma2 + marks[2] * Gamma3)/(Gamma1+Gamma2+Gamma3);

                sum += expertTrust[i] * (a[i]);
                trustSum += expertTrust[i];
            }
            double result = sum / trustSum;

            for (int i = 0; i < expertCount; i++)
            {
                distortionSum += (si[i] * expertTrust[i]) + (result - a[i]) * (result - a[i]) * expertTrust[i];
            }

            efficiency = distortionSum / trustSum;
            results = result;
            return;
        }
    };


}
