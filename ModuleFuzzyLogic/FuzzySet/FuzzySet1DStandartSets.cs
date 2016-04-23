using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzySets
{
    public partial class FuzzySet1D: FuzzySet
    {
        private const double eps = 0.001;

        static double pNormalDiscr(double x, double m, double s)
        {
            return 1.0 / (s * Math.Sqrt(2.0 * Math.PI)) * Math.Exp(-(x-m)*(x-m)/(2*s*s));
        }
        static double pTriangle(double x, double d, double s, double h)
        {
            if (x<(d-s)||x>(d+s)) return 0;
            if (x > d) 
                return -h / s * x + h * (1.0 + d / s);
            return h / s * x + h * (1.0 - d / s); 
        }

        /// <summary>
        /// создает нечеткое множество, определяющее нормальную функцию распределения
        /// </summary>
        /// <param name="m">Мат ожидание</param>
        /// <param name="s">Корень из дисперсии</param>
        /// <returns></returns>
        public static FuzzySet1D CreateNormalDistribution(double m, double s)
        {
            FuzzySet1D fs = new FuzzySet1D();
            fs.Discrete = false;

            for (int i = 0; i < FuzzySet.maxDotCount; i++)
            {
                double x = 1.0 * i * (FuzzySet.toX - FuzzySet.fromX) / FuzzySet.maxDotCount+fromX;
                fs.AddDot(x, pNormalDiscr(x,m,s));
            }
            return fs;
        }
        public static FuzzySet1D CreateTriangle(double d, double s, double h)
        {
            FuzzySet1D fs = new FuzzySet1D();
            fs.Discrete = false;

            for (int i = 0; i < FuzzySet.maxDotCount; i++)
            {
                double x = 1.0 * i * (FuzzySet.toX - FuzzySet.fromX) / FuzzySet.maxDotCount + fromX;
                fs.AddDot(x, pTriangle(x, d, s, h));
            }
            return fs;
        }
        public static FuzzySet1D CreateTrapeze(double d, double s, double h, double H)
        {
            FuzzySet1D fs = new FuzzySet1D();
            fs.Discrete = false;

            for (int i = 0; i < FuzzySet.maxDotCount; i++)
            {
                double x = 1.0 * i * (FuzzySet.toX - FuzzySet.fromX) / FuzzySet.maxDotCount + fromX;
                double y = pTriangle(x, d, s, h);
                fs.AddDot(x, (y>H)?H:y);
            }
            return fs;
        }
    }
    public enum StandartSet
    {
        NormalDistribution,
        Triangle,
        Trapeze
    }
}
