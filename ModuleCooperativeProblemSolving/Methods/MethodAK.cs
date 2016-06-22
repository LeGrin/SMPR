using System;
using System.Collections.Generic;
using System.Text;
using Modules.ModuleCooperativeProblemSolving;
using System.Windows.Forms;

namespace Modules.ModuleCooperativeProblemSolving.Methods
{
    public class MethodAK : Method
    {
        public MethodAK() { }

        public override string ResultSetName
        {
            get
            {
                return "Alpha-Kernel";
            }
        }

        public override string[] Execute()
        {
            resultComment.Remove(0, resultComment.Length);
            List<string> resultSet = new List<string>();

            foreach (Strategies.Wins w in strategies.WinsList)
            {
                // Check if w is in alpha-kernel
                bool inAlphaKernel = true;
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
                    for (int newT = 0; newT < coalitionVariants; newT++)
                    {
                        int k;
                        k = newT;
                        for (int i = 0; i < coalition.Length; i++)
                        {
                            int v = strategies.GetStrategies(coalition[i]).Count;
                            newIndex[coalition[i]] = k % v;
                            k /= v;
                        }

                        bool isBetter = true;
                        for (int threat = 0; threat < strategies.WinsList.Count / coalitionVariants; threat++)
                        {
                            k = threat;
                            for (int i = 0; i < complementary.Length; i++)
                            {
                                int v = strategies.GetStrategies(complementary[i]).Count;
                                newIndex[complementary[i]] = k % v;
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
                                    isBetter = false;
                                    break;
                                }
                            }
                            if (isBetter && allEqual)
                                isBetter = false;
                            if (!isBetter)
                                break; // Already found good threat.
                        }

                        if (isBetter)
                        {
                            inAlphaKernel = false;
                            resultComment.AppendFormat("{0} не належить α-ядру гри, так як гравці {{1}} можуть утворити коаліцію", w.Key, PlayerSet(coalition));
                            break;
                        }
                    }
                    if (!inAlphaKernel)
                        break;
                }

                if (inAlphaKernel)
                {
                    resultComment.Append(w.Key + " належить α-ядру гри\r\n");
                    resultSet.Add(w.Key);
                }
            }
            return resultSet.ToArray();
        }

        public override string Name
        {
            get
            {
                return Properties.Resources.AKMethodName;
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
