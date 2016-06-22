using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ExpertProcessingMethods.Methods
{
    class AlgebraicResult
    {
        public int[,] KemeniSnell;
        public int[,] Middle;
        public int[,] Compromise;

        public int[] KukSaiford;
    }

    class AlgebraicMethod : Method
    {
        public override string Name { get { return Properties.Resources.AlgebraicMethodName; } }

        private int[,] makeRangeTable(int objCount, int[] opinion)
        {
            int[,] A = new int[objCount, objCount];

            for (int i = 0; i < objCount; i++)
                for (int j = 0; j < objCount; j++)
                    if (opinion[i] > opinion[j])
                        A[i, j] = 1;
                    else if (opinion[i] < opinion[j])
                        A[i, j] = -1;
                    else
                        A[i, j] = 0;

            return A;
        }

        private int findD(int objCount, int[,] A, int[, ,] B, int ind)
        {
            int res = 0;
            for (int i = 0; i < objCount; i++)
                for (int j = 0; j < objCount; j++)
                    res += Math.Abs(A[i, j] - B[ind, i, j]);
            res /= 2;
            return res;
        }

        private int findRangeD(int objCount, int[] A, int[,] B, int ind)
        {
            int res = 0;
            for (int i = 0; i < objCount; i++)
                res += Math.Abs(A[i] - B[ind, i]);

            return res;
        }

        private int[] findNextRange(int objCount, int[] range)
        {
            int curMax = objCount;
            for (int i = 0; i < objCount; i++)
                if (range[i] > curMax)
                    curMax = range[i];

            if (curMax > objCount || curMax < 1) return null;

            bool finish = true;
            for (int i = 0; i < objCount; i++)
                if (range[i] < Math.Min(objCount - i, curMax))
                {
                    finish = false;
                    break;
                }

            if (finish && curMax >= objCount)
                return null;
            else if (finish)
            {
                curMax++;
                for (int i = 0; i < objCount; i++)
                    range[i] = 1;
                for (int i = 1; i <= curMax; i++)
                    range[objCount - i] = curMax + 1 - i;

                return range;
            }
            else
            {
                int k = objCount - 1;
                while (range[k] == curMax)
                    k--;
                range[k]++;
                for (int i = k + 1; i < objCount; i++)
                    range[i] = 1;

                return range;
            }
        }

        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            efficiency = 0; results = null;
            if (expertOpinions.Count != expertCount || !(expertOpinions[0] is int[])) return;

            int objCount = (expertOpinions[0] as int[]).Length;
            int[,] opinions = new int[expertCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    opinions[i, j] = (expertOpinions[0] as int[])[j];

            int[, ,] Al = new int[expertCount, objCount, objCount];
            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    for (int k = 0; k < objCount; k++)
                        if (opinions[i, j] > opinions[i, k])
                            Al[i, j, k] = 1;
                        else if (opinions[i, j] < opinions[i, k])
                            Al[i, j, k] = -1;
                        else
                            Al[i, j, k] = 0;

            int[] range = new int[objCount];

            for (int r = 0; r < objCount; r++)
                range[r] = 1;

            double sumExpertTrust = 0;
            for (int i = 0; i < expertCount; i++)
                sumExpertTrust += expertTrust[i];

            AlgebraicResult res = new AlgebraicResult();
            double minKemeniSnell = Double.MaxValue;
            double minMiddle = Double.MaxValue;
            double minCompromise = Double.MaxValue;
            double minKukSaiford = Double.MaxValue;

            while (range != null)
            {
                int[,] AStar = makeRangeTable(objCount, range);

                double KemeniSnellValue = 0;
                double MiddleValue = 0;
                double CompromiseValue = 0;
                double KukSaifordValue = 0;

                if (range[0] == 4 && range[1] == 3 && range[2] == 2 && range[3] == 1)
                {
                    range[0] = 4;
                }

                for (int i = 0; i < expertCount; i++)
                {
                    double curD = findD(objCount, AStar, Al, i);
                    double curRangeD = findRangeD(objCount, range, opinions, i);
                    KemeniSnellValue += expertTrust[i] * curD;
                    MiddleValue += expertTrust[i] * curD * curD;
                    CompromiseValue = Math.Max(CompromiseValue, expertTrust[i] * curD);
                    KukSaifordValue += expertTrust[i] * curRangeD;
                }

                KemeniSnellValue /= sumExpertTrust;
                MiddleValue /= sumExpertTrust;
                CompromiseValue /= sumExpertTrust;
                KukSaifordValue /= sumExpertTrust;


                if (KemeniSnellValue < minKemeniSnell)
                {
                    res.KemeniSnell = AStar.Clone() as int[,]; minKemeniSnell = KemeniSnellValue;
                }
                if (MiddleValue < minMiddle)
                {
                    res.Middle = AStar.Clone() as int[,]; minMiddle = MiddleValue;
                }
                if (CompromiseValue < minCompromise)
                {
                    res.Compromise = AStar.Clone() as int[,]; minCompromise = CompromiseValue;
                }
                if (KukSaifordValue < minKukSaiford)
                {
                    res.KukSaiford = range.Clone() as int[]; minKukSaiford = KukSaifordValue;
                }

                range = findNextRange(objCount, range);
            }

            results = res;
        }

    }

}
