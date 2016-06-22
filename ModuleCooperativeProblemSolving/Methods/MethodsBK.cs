using System;
using System.Collections.Generic;
using System.Text;
using Modules.ModuleCooperativeProblemSolving;

namespace Modules.ModuleCooperativeProblemSolving.Methods
{
    public class MethodBK : Method
    {
        public MethodBK() { }

        public override string ResultSetName
        {
            get
            {
                return "Beta-Kernel";
            }
        }

        public override string[] Execute()
        {
            resultComment.Remove(0, resultComment.Length);
            List<string> resultSet = new List<string>();

            foreach (Strategies.Wins w in strategies.WinsList)
            {
                // Check if w is in beta-kernel
                bool inBetaKernel = true;
                for (int t = 1; t < (1 << strategies.PlayerCount) - 1; t++)
                {
                    // t is a coalition.
                    int[] coalition = new int[CountBits(t)];
                    int[] complementary = new int[strategies.PlayerCount - CountBits(t)];
                    int[] index = new int[strategies.PlayerCount];

                    List<string> tmp = new List<string>(w.Key.Replace(',', ' ').Split(' '));
                    tmp.RemoveAll(string.IsNullOrEmpty);
                    string[] st = tmp.ToArray();

                    for (int j = 0; j < index.Length; j++)
                        index[j] = strategies.GetStrategies(j).IndexOf(st[j]);

                    int p = 0, q = 0;
                    int coalitionVariants = 1;
                    for (int j = 0; j < strategies.PlayerCount; j++)
                        if ((t & (1 << j)) != 0)
                        {
                            coalition[p++] = j;
                            coalitionVariants *= strategies.GetStrategies(j).Count;
                        }
                        else
                            complementary[q++] = j;

                    int[] newIndex = new int[strategies.PlayerCount];
                    for (int newT = 0; newT < strategies.WinsList.Count / coalitionVariants; newT++)
                    {
                        int k;
                        k = newT;
                        for (int i = 0; i < complementary.Length; i++)
                        {
                            int v = strategies.GetStrategies(complementary[i]).Count;
                            newIndex[complementary[i]] = k % v;
                            k /= v;
                        }

                        bool isGoodThreateningStrategy = true;
                        for (int forw = 0; forw < coalitionVariants; forw++)
                        {
                            k = forw;
                            for (int i = 0; i < coalition.Length; i++)
                            {
                                int v = strategies.GetStrategies(coalition[i]).Count;
                                newIndex[coalition[i]] = k % v;
                                k /= v;
                            }

                            Strategies.Wins w1 = strategies.GetWins(IndexArrayToKey(newIndex));
                            bool allEqual = true;
                            for (int i = 0; i < coalition.Length; i++)
                            {
                                int c = coalition[i];
                                allEqual &= w1[c] == w[c];
                                if (w1[c] < w[c])
                                {
                                    isGoodThreateningStrategy = false;
                                    break;
                                }
                            }
                            if (isGoodThreateningStrategy && allEqual)
                                isGoodThreateningStrategy = false;
                            if (!isGoodThreateningStrategy)
                                break; // Already found good threat.
                        }

                        if (!isGoodThreateningStrategy)
                        {
                            inBetaKernel = false;
//                            resultComment.AppendFormat("{0} не належить β-ядру гри", w.Key);
                            break;
                        }
                    }
                    if (!inBetaKernel)
                        break;
                }

                if (inBetaKernel)
                {
  //                  resultComment.Append(w.Key + " належить β-ядру гри\r\n");
                    resultSet.Add(w.Key);
                }
            }

            if (resultSet.Count > 0)
            {
                resultComment.Append("β-ядро гри: {");
                for (int i = 0; i < resultSet.Count; i++)
                {
                    if (i > 0)
                        resultComment.Append(", ");
                    resultComment.Append(resultSet[i]);
                }
                resultComment.Append("}");
            }
            else
            {
                resultComment.Append("β-ядро гри порожнє");
            }

            return resultSet.ToArray();
        }

        public override string Name
        {
            get
            {
                return Properties.Resources.BKMethodName;
            }
        }

        StringBuilder resultComment = new StringBuilder();

        public override string ResultComment
        {
            get
            {
                return resultComment.ToString();
            }
        }
    }
}
