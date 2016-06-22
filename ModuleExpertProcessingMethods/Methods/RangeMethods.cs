using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ExpertProcessingMethods.Methods
{
    class SimpleRange : Method
    {
        public override string Name { get { return Properties.Resources.RangeMethodName; } }

        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            efficiency = 0; results = null;
            if (expertOpinions.Count != expertCount || !(expertOpinions[0] is int[])) return;

            int objCount = (expertOpinions[0] as int[]).Length;
            int[,] opinions = new int[expertCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    opinions[i, j] = (expertOpinions[0] as int[])[j];

            int[] sumRange = new int[objCount];
            int[] res = new int[objCount];

            efficiency = 0;
            double quadroSum = 0;

            for (int j=0; j<objCount; j++)
            {
                res[j] = j + 1;
                for (int i = 0; i < expertCount; i++)
                    sumRange[j] += opinions[i, j];

                quadroSum += (sumRange[j] - 0.5 * expertCount * (objCount + 1)) * (sumRange[j] - 0.5 * expertCount * (objCount + 1));
            }

            efficiency = 12*quadroSum/(expertCount*expertCount*(objCount*objCount*objCount - objCount));

            for (int i=0; i<objCount; i++)
                for (int j=i+1; j<objCount; j++)
                    if (sumRange[i] > sumRange[j])
                    {
                        int hlp = sumRange[i]; sumRange[i] = sumRange[j]; sumRange[j] = hlp;
                        hlp = res[i]; res[i] = res[j]; res[j] = hlp;
                    }

            results = res;
            return;
        }
    }

    class NonDirectRange : Method
    {
        public override string Name { get { return Properties.Resources.NonDirectRangeMethodName; } }

        public override void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results)
        {
            efficiency = 0; results = null;
            if (expertOpinions.Count != expertCount || !(expertOpinions[0] is int[])) return;

            int objCount = (expertOpinions[0] as int[]).Length;
            int[,] opinions = new int[expertCount, objCount];

            for (int i = 0; i < expertCount; i++)
                for (int j = 0; j < objCount; j++)
                    opinions[i, j] = (expertOpinions[0] as int[])[j];


            efficiency = 0;
            double quadroSum = 0;

            double rangeGroups = 0;
            for (int i = 0; i < expertCount; i++)
            {
                double[] opinion = new double[objCount];
                for (int j = 0; j < objCount; j++)
                    opinion[j] = opinions[i, j];
                Array.Sort(opinion);

                int curCount = 0; double curOpinion = 0;
                for (int j = 0; j < objCount; j++)
                    if (curOpinion == opinion[j])
                        curCount++;
                    else
                    {
                        rangeGroups += curCount * curCount * curCount - curCount;
                        curCount = 1; curOpinion = opinion[j];
                    }
            }

            int[] sumRange = new int[objCount];
            int[] res = new int[objCount];

            for (int j = 0; j < objCount; j++)
            {
                res[j] = j + 1;
                for (int i = 0; i < expertCount; i++)
                    sumRange[j] += opinions[i, j];

                quadroSum += (sumRange[j] - 0.5 * expertCount * (objCount + 1)) * (sumRange[j] - 0.5 * expertCount * (objCount + 1));
            }

            efficiency = 12 * quadroSum / (expertCount * expertCount * (objCount * objCount * objCount - objCount) - expertCount * rangeGroups);

            for (int i = 0; i < objCount; i++)
                for (int j = i + 1; j < objCount; j++)
                    if (sumRange[i] > sumRange[j])
                    {
                        int hlp = sumRange[i]; sumRange[i] = sumRange[j]; sumRange[j] = hlp;
                        hlp = res[i]; res[i] = res[j]; res[j] = hlp;
                    }

            results = res;
            return;
        }
    }
}
