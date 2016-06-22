using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ExpertProcessingMethods.Methods
{
    class KondorseMethod : Method
    {
        public override string Name { get { return Properties.Resources.KondorseMethodName; } }

        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            efficiency = 0; results = null;
            if (expertOpinions.Count != expertCount || !(expertOpinions[0] is int[])) return;

            int objCount = (expertOpinions[0] as int[]).Length;
            int[,] opinions = new int[expertCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    opinions[i, j] = (expertOpinions[i] as int[])[j];

            int[,] n1 = new int[objCount, objCount];
            int[,] n2 = new int[objCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    for (int k = 0; k < objCount; k++)
                    {
                        n1[j, k] += Convert.ToInt32(opinions[i, j] > opinions[i, k]);
                        n2[j, k] += Convert.ToInt32(opinions[i, j] < opinions[i, k]);
                    }

            int[] res = new int[objCount];
            for (int i = 0; i < objCount; i++)
                res[i] = i + 1;

            for (int i = 0; i < objCount; i++)
            {
                int curplace = 0;
                for (int j = i; j < objCount; j++)
                {
                    bool current = true;
                    for (int k = i; k<objCount; k++)
                        if (n1[j, k] < n2[j, k])
                        {
                            current = false;
                            break;
                        }

                    if (current)
                    {
                        curplace = j;
                        break;
                    }
                }

                int hlp = res[i]; res[i] = res[curplace]; res[curplace] = hlp;
            }

            efficiency = 0;
            results = res;
        }
    }

    class PairCompareMethod : Method
    {
        public override string Name { get { return Properties.Resources.PairCompareMethod; } }

        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            efficiency = 0; results = null;
            if (expertOpinions.Count != expertCount || !(expertOpinions[0] is int[])) return;

            int objCount = (expertOpinions[0] as int[]).Length;
            int[,] opinions = new int[expertCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    opinions[i, j] = (expertOpinions[0] as int[])[j];

            int [,,] Al = new int[expertCount, objCount, objCount];
            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    for (int k = 0; k < objCount; k++)
                        Al[i, j, k] = Convert.ToInt32(opinions[i, j] > opinions[i, k]);

            int [,] A = new int[objCount,objCount];
            for (int i = 0; i < objCount; i++)
                for (int j = 0; j < objCount; j++)
                    for (int k = 0; k < expertCount; k++)
                        A[i, j] += Al[k, i, j];

            int[] a = new int[objCount];
            for (int i = 0; i < objCount; i++)
                for (int j = 0; j < objCount; j++)
                    a[j] += A[i, j];

            double d = 0;
            for (int i = 0; i < objCount; i++)
                for (int j = i + 1; j < objCount; j++)
                    for (int k = j + 1; k < objCount; k++)
                        d += Math.Min(A[i, j], Math.Min(A[j, k], A[k, i]));

            int[] res = new int[objCount];
            for (int i = 0; i < objCount; i++)
                res[i] = i + 1;

            for (int i = 0; i < objCount; i++)
                for (int j = i + 1; j < objCount; j++)
                    if (a[i] > a[j])
                    {
                        int hlp = a[i]; a[i] = a[j]; a[j] = hlp;
                        hlp = res[i]; res[i] = res[j]; res[j] = hlp;
                    }

            results = res;

            if (objCount % 2 == 1)
                efficiency = 1 - 24 * d * 1.0 / (objCount * objCount * objCount - objCount);
            else
                efficiency = 1 - 24 * d * 1.0 / (objCount * objCount * objCount - 4 * objCount);

            return;
        }
    }
}
