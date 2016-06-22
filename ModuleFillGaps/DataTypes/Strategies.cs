using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Text;
using System.Drawing;

namespace Modules.ModuleCooperativeProblemSolving
{
    public class Strategies
    {
        private frmModule module;
        private List<List<string>> strategyList = new List<List<string>>();
        private List<Label> labels = new List<Label>();
        private List<TextBox> textboxes = new List<TextBox>();

        public class Wins
        {
            private string key;
            private int[] wins = new int[6];
            public string Key
            {
                get { return key; }
                set { key = value; }
            }
            public int win1
            {
                get { return wins[0]; }
                set { wins[0] = value; }
            }
            public int win2
            {
                get { return wins[1]; }
                set { wins[1] = value; }
            }
            public int win3
            {
                get { return wins[2]; }
                set { wins[2] = value; }
            }
            public int win4
            {
                get { return wins[3]; }
                set { wins[3] = value; }
            }
            public int win5
            {
                get { return wins[4]; }
                set { wins[4] = value; }
            }
            public int win6
            {
                get { return wins[5]; }
                set { wins[5] = value; }
            }
            public int this[int v]
            {
                get { return wins[v]; }
                set { wins[v] = value; }
            }
        }

        private IDictionary<string, Wins> winsDict = new Dictionary<string, Wins>();
        public IList<Wins> WinsList;

        public Strategies(frmModule module)
        {
            this.module = module;
        }

        private void UpdateWins()
        {
            int v = 1;
            foreach (List<string> stgList in strategyList)
                v *= stgList.Count;

            WinsList = new List<Wins>(v);
            int[] index = new int[strategyList.Count];
            for (int i = 0; i < v; i++)
            {
                int k = i;
                for (int j = 0; j < index.Length; j++)
                {
                    index[j] = k % strategyList[j].Count;
                    k /= strategyList[j].Count;
                }

                StringBuilder _key = new StringBuilder();
                for (int j = 0; j < strategyList.Count; j++)
                {
                    if (j > 0)
                        _key.Append(", ");
                    _key.Append(strategyList[j][index[j]]);
                }
                string key = _key.ToString();

                if (!winsDict.ContainsKey(key))
                {
                    Wins w = new Wins();
                    w.Key = key;
                    for (int j = 0; j < strategyList.Count; j++)
                        w[j] = 0;
                    winsDict.Add(key, w);
                }
                WinsList.Add(winsDict[key]);
            }

            module.wins.DataSource = WinsList;
            module.wins.Columns[0].HeaderText = Properties.Resources.AlgorithmResampling;
            for (int i = 0; i < strategyList.Count; i++)
            {
                module.wins.Columns[i + 1].HeaderText = Properties.Resources._1 + " " + (i + 1);
                module.wins.Columns[i + 1].Visible = true;
            }
            for (int i = strategyList.Count + 1; i < module.wins.Columns.Count; i++)
                module.wins.Columns[i].Visible = false;
        }

        private void UpdateView()
        {
            int N = strategyList.Count;
            while (labels.Count > N)
            {
                module.strategiesGroupBox.Controls.Remove(labels[N]);
                module.strategiesGroupBox.Controls.Remove(textboxes[N]);
                labels.RemoveAt(N);
                textboxes.RemoveAt(N);
            }

            while (labels.Count < N)
            {
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Text = Properties.Resources.AlgorithmZET + " " + (labels.Count + 1);
                lbl.Location = new Point(10, 26 * (textboxes.Count + 1));

                labels.Add(lbl);
                module.strategiesGroupBox.Controls.Add(lbl);

                TextBox tb = new TextBox();
                tb.Tag = textboxes.Count;
                tb.TextChanged += tb_TextChanged;
                tb.Text = "a" + (textboxes.Count + 1);
                tb.Location = new Point(lbl.Location.X + lbl.Size.Width + 5, 26 * (textboxes.Count + 1) - tb.Height + lbl.Height);
                tb.Width = 120;
                textboxes.Add(tb);
                module.strategiesGroupBox.Controls.Add(tb);
            }

            module.strategiesGroupBox.Height = textboxes[textboxes.Count - 1].Location.Y + 30;
            module.strategiesGroupBox.Width = textboxes[0].Location.X + textboxes[0].Width + 10;

            UpdateWins();
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            TextBox me = (TextBox)sender;
            List<string> stg = new List<string>(me.Text.Replace(',', ' ').Split(' '));
            stg.RemoveAll(string.IsNullOrEmpty);
            strategyList[(int)me.Tag] = stg;

            UpdateWins();
        }

        public int PlayerCount
        {
            get
            {
                return strategyList.Count;
            }
            set
            {
                while (strategyList.Count < value)
                {
                    int player = strategyList.Count + 1;
                    strategyList.Add(new List<string>(new string[] { "a" + player }));
                }
                while (strategyList.Count > value)
                    strategyList.RemoveAt(value);

                UpdateView();
            }
        }

        public int Count(int p)
        {
            return strategyList[p].Count;
        }

        public List<string> GetStrategies(int p)
        {
            return strategyList[p];
        }

        internal Wins GetWins(string p)
        {
            return winsDict[p];
        }
    }
}