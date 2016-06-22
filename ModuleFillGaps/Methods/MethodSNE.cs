using System;
using System.Collections.Generic;
using System.Text;
using Modules.ModuleCooperativeProblemSolving;
using System.Windows.Forms;

namespace Modules.ModuleCooperativeProblemSolving.Methods
{
    public class MethodSNE : Method
    {
        public MethodSNE() { }

        public override string ResultSetName
        {
            get
            {
                return "SNE";
            }
        }

        public override string[] Execute()
        {
            resultComment.Remove(0, resultComment.Length);
            List<string> resultSet = new List<string>();
            foreach (Strategies.Wins w in strategies.WinsList)
            {
                // Check if w is Strong Nash Equibalance
                bool isStrongNash = true;
                for (int t = 0; t < (1 << strategies.PlayerCount) - 1; t++)
                {
                    int[] group = new int[CountBits(t)];
                    int[] index = new int[strategies.PlayerCount];

                    List<string> tmp = new List<string>(w.Key.Replace(',', ' ').Split(' '));
                    tmp.RemoveAll(string.IsNullOrEmpty);
                    string[] st = tmp.ToArray();

                    for (int j = 0; j < index.Length; j++)
                        index[j] = strategies.GetStrategies(j).IndexOf(st[j]);

                    int p = 0;
                    for (int j = 0; j < strategies.PlayerCount; j++)
                        if ((t & (1 << j)) != 0)
                            group[p++] = j;

                    int v = 1;
                    for (int j = 0; j < group.Length; j++)
                        v *= strategies.Count(group[j]);

                    for (int i = 0; i < v; i++)
                    {
                        int k = i;
                        for (int j = 0; j < group.Length; j++)
                        {
                            index[group[j]] = k % strategies.Count(group[j]);
                            k /= strategies.Count(group[j]);
                        }

                        string key = IndexArrayToKey(index);

                        Strategies.Wins w1 = strategies.GetWins(key);
                        bool allNotWorse = true, haveBetter = false;
                        for (int j = 0; j < group.Length; j++)
                            if (w1[j] < w[j])
                            {
                                allNotWorse = false;
                                break;
                            }
                            else
                                if (w1[j] > w[j])
                                    haveBetter = true;

                        if (allNotWorse && haveBetter)
                        {
                            isStrongNash = false;
                            resultComment.Append(w.Key);
                            resultComment.Append(" не є Сильною Рівновагою Неша, бо коаліція {");
                            for (int j = 0; j < group.Length; j++)
                            {
                                if (j > 0)
                                    resultComment.Append(", ");
                                resultComment.Append(group[j] + 1);
                            }
                            resultComment.Append("} змінює стратегію на ");
                            resultComment.Append(w1.Key);
                            resultComment.Append("\r\n");
                            break;
                        }
                    }
                    if (!isStrongNash)
                        break;
                }
                if (isStrongNash)
                {
                    resultComment.Append(w.Key + " є Сильною Рівновагою Неша\r\n");
                    resultSet.Add(w.Key);
                }
            }
            return resultSet.ToArray();
        }

        public override string Name
        {
            get
            {
                return Properties.Resources.SNEMethodName;
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
