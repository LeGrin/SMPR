using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modules.ModuleFuzzyLogic.Methods
{
    static class BinRelationsProp
    {
        public static double[,] ToDouble(this DataGridView gridView)
        {
            int matrixSize = gridView.RowCount;
            double[,] result = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    result[i, j] = double.Parse(gridView[i, j].Value.ToString());
                }
            }
            return result;
        }

        public static bool IsReflexive(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                if(values[i, i] != 1)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsAntiReflexive(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                if (values[i, i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSymmetric(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (values[i, j] != values[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsAsymmetric(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (Math.Min(values[i, j], values[j, i]) != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsAntiSymmetric(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    if (Math.Min(values[i, j], values[j, i]) != 0 && i != j)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool IsTransitive(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    double maxValue = 0;
                    for (int k = 0; k < values.GetLength(0); k++)
                    {
                        maxValue = Math.Max(maxValue, Math.Min(values[i, k], values[k, j]));
                    }

                    if (maxValue > values[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsRearTransitive(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    double minValue = 0;
                    for (int k = 0; k < values.GetLength(0); k++)
                    {
                        minValue = Math.Min(minValue, Math.Max(values[i, k], values[k, j]));
                    }

                    if (minValue < values[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static NameValueCollection Analyze(this DataGridView gridView)
        {
            NameValueCollection result = new NameValueCollection();
            result["Рефлексивність"] = gridView.IsReflexive() ? "+" : "-";
            result["Антирефлексивність"] = gridView.IsAntiReflexive() ? "+" : "-";
            result["Симетричність"] = gridView.IsSymmetric() ? "+" : "-";
            result["Асиметричність"] = gridView.IsAsymmetric() ? "+" : "-";
            result["Антисиметричність"] = gridView.IsAntiSymmetric() ? "+" : "-";
            result["Транзитивність"] = gridView.IsTransitive() ? "+" : "-";
            result["Контртранзитивність"] = gridView.IsRearTransitive() ? "+" : "-";
            return result;
        }

        public static void TransitiveClosure(this DataGridView gridView)
        {
            double[,] values = gridView.ToDouble();
            double[,] valuesPow = values;
            double[,] valuesPowNext = composition(values, values);
            double[,] result = values;
            int count = 0;
            while(!equals(valuesPow, valuesPowNext) || count > 10)
            {
                count++;
                result = union(result, valuesPowNext);
                valuesPow = valuesPowNext;
                valuesPowNext = composition(valuesPowNext, values);
            }
            int matrixSize = values.GetLength(0);
            for (int i = 0; i<matrixSize; i++)
            {
                for (int j = 0; j<matrixSize; j++)
                {
                    gridView[i, j].Value = result[i, j];
                }
            }
            return;
        }

        private static double[,] pow(double[,] values, int k)
        {
            double[,] result = values;
            for(int i = 1; i<k; i++)
            {
                result = composition(result, values);
            }
            return result;
        }

        private static double[,] union(double[,] a, double[,] b)
        {
            int matrixSize = a.GetLength(0);
            double[,] result = new double[matrixSize, matrixSize];
            for (int i = 0; i<matrixSize; i++)
            {
                for(int j = 0; j<matrixSize; j++)
                {
                    result[i, j] = Math.Max(a[i, j], b[i, j]);
                }
            }
            return result;
        }

        private static bool equals(double[,] a, double[,] b)
        {
            int matrixSize = a.GetLength(0);
            if (matrixSize != b.GetLength(0))
            {
                return false;
            }
            for (int i = 0; i<matrixSize; i++)
            {
                for (int j = 0; j<matrixSize; j++)
                {
                    if (a[i, j] != b[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static double[,] composition(double[,] a, double[,] b)
        {
            int matrixSize = a.GetLength(0);
            double[,] result = new double[matrixSize, matrixSize];
            for (int i = 0; i<matrixSize; i++)
            {
                for(int j = 0; j<matrixSize; j++)
                {
                    double value = 0;
                    for (int k = 0; k<matrixSize; k++)
                    {
                        value = Math.Max(value, Math.Min(a[i, k], b[k, j]));
                    }
                    result[i, j] = value;
                }
            }
            return result;
        }

    }
}
