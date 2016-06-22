using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.ConflictsAndCompromises
{
    public partial class frmModule : Form
    {
        Module module;

        public frmModule()
        {
            InitializeComponent();
        }

        public frmModule(Module module)
            : this()
        {
            this.module = module;
            foreach (Method method in module.Methods)
            {
                methodList.Items.Add(method.Name);
            }

            gameGrid1.Game = module.Game;
            gameGrid1.Output = answer;
            module.Game.ValueChanged += delegate { RefreshResult(); };

            if (!module.Game.IsInitialized)
            {
                gameOptions.Enabled = false;
                module.Game.Initialized += delegate
                {
                    gameOptions.Enabled = true;
                };
            }
            else
            {
                rowCounter.Value = module.Game.X.Count;
                columnCounter.Value = module.Game.Y.Count;
            }

            module.Game.StructureChanged += delegate
            {
                rowCounter.Value = module.Game.X.Count;
                columnCounter.Value = module.Game.Y.Count;
            };

            player1Func.SelectedIndex = (int)module.Game.F1;
            player2Func.SelectedIndex = (int)module.Game.F2;
            // autoFillFlag.Checked = module.Game.AutoFillingEnabled;

            if (module.WorkingMethod != null)
                foreach (Method m in module.Methods)
                {
                    if (module.WorkingMethod.GetType() == m.GetType())
                        methodList.SelectedIndex = module.Methods.IndexOf(m);
                }
        }

        private void playerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResult();
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshResult();
        }


        private void rowCounter_ValueChanged(object sender, EventArgs e)
        {
            int newVal = (int)rowCounter.Value, oldVal = module.Game.X.Count;

            if (newVal > oldVal)
            {
                for (int i = 0; i < newVal - oldVal; i++) module.Game.X.Add("X" + (module.Game.X.Count + 1));
            }
            else
            {
                for (int i = 0; i < oldVal - newVal; i++) module.Game.X.RemoveAt(module.Game.X.Count - 1);
            }

            RefreshResult();
        }

        private void columnCounter_ValueChanged(object sender, EventArgs e)
        {
            int newVal = (int)columnCounter.Value, oldVal = module.Game.Y.Count;

            if (newVal > oldVal)
            {
                for (int i = 0; i < newVal - oldVal; i++) module.Game.Y.Add("Y" + (module.Game.Y.Count + 1));
            }
            else
            {
                for (int i = 0; i < oldVal - newVal; i++) module.Game.Y.RemoveAt(module.Game.Y.Count - 1);
            }

            RefreshResult();
        }

        protected void AutofillValues_Validation(object sender, EventArgs e)
        {
            int x = (int)autoFillMin.Value;
            int y = (int)autoFillMax.Value;

            if (x > y)
            {
                autoFillMax.Value = x;
                y = x;
            }

            module.Game.AutoFilling.Min = x;
            module.Game.AutoFilling.Max = y;
        }

        private void autoFillBtn_Click(object sender, EventArgs e)
        {
            module.Game.FillRandom();
            RefreshResult();
        }

        private void LoadFromBuffer_Click(object sender, EventArgs e)
        {
            Matrix<ParsablePointD> m = (Matrix<ParsablePointD>)Common.DataBuffer.Instance.LoadDialog(
                ValidData);
            if (m != null)
            {
                module.Game.Init(m);
            }
            player2Func.SelectedIndex = 0;
            playerList.SelectedIndex = 0;
            RefreshResult();
        }

        private void SaveToBuffer_Click(object sender, EventArgs e)
        {

            ParsablePointD[,] points = new ParsablePointD[module.Game.Y.Count, module.Game.X.Count];
            for (int i = 0; i < module.Game.X.Count; i++)
                for (int j = 0; j < module.Game.Y.Count; j++)
                {
                    Situation s = module.Game[i, j];
                    points[j, i] = new ParsablePointD(s[0], s[1]);
                }
            Matrix<ParsablePointD> m = new Matrix<ParsablePointD>(points);
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void player1Func_SelectedIndexChanged(object sender, EventArgs e)
        {
            module.Game.F1 = (CCGame.Function)player1Func.SelectedIndex;
            RefreshResult();
        }

        private void player2Func_SelectedIndexChanged(object sender, EventArgs e)
        {
            module.Game.F2 = (CCGame.Function)player2Func.SelectedIndex;
            RefreshResult();
        }

        private void autoFillFlag_CheckedChanged(object sender, EventArgs e)
        {
            module.Game.AutoFilling.Enabled = autoFillFlag.Checked;
        }


        private bool ValidData(BufferData obj)
        {
            return (obj is Matrix<ParsablePointD>);
        }

        protected void RefreshResult()
        {
            if (methodList.SelectedIndex < 0) gameGrid1.SetResultSet(new List<Point>());
            else
            {
                object res = module.GetResult(module.Methods[methodList.SelectedIndex]);
                gameGrid1.SetResultSet(module.ToSet(res, playerList.SelectedIndex));
                resultList.Clear();
                foreach (Point p in module.ToSet(res, playerList.SelectedIndex))
                {
                    if (p.X == 0)
                    {
                        resultList.Items.Add("Y" + p.Y);
                    }
                    if (p.Y == 0)
                    {
                        resultList.Items.Add("X" + p.X);
                    }
                    if ((p.X != 0) && (p.Y != 0))
                    {
                        resultList.Items.Add("(X" + p.X + ",Y" + p.Y + ") = (" + module.Game.U1["X" + p.X]["Y" + p.Y] + "," + module.Game.U2["Y" + p.Y]["X" + p.X] + ")");
                    }

                }
            }
        }

        private void nineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tenToolStripMenuItem.Checked = false;
            gameGrid1.Mode = GameGrid.GridMode.Normal;
            RefreshResult();

            testBox.Hide();
            gameOptions.Show();
        }

        private void òåñòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<TestItem> all = module.GetListOfSets(), selected = new List<TestItem>();
            TaskSelector ts = new TaskSelector();

            foreach (TestItem i in all) ts.TheList.Items.Add(i.Name);

            DialogResult dr = ts.ShowDialog();

            if (dr == DialogResult.OK)
            {
                nineToolStripMenuItem.Checked = false;

                testBox.Show();
                gameOptions.Hide();

                for (int j = 0; j < all.Count; j++)
                    if (ts.TheList.SelectedIndices.Contains(j)) selected.Add(all[j]);

                tester.Init(selected, 10,module.LastResults);
                 
                gameGrid1.Mode = GameGrid.GridMode.Test;
                gameGrid1.SetResultSet(tester.CurrentItem.Result);

                answerBox.Enabled = true;
                skipModuleBtn.Enabled = true;
                finishTestBtn.Enabled = false;
                testBox.Enabled = true;
            }
        }

        private void submitAnswerBtn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure this is correct result?\n Maybe you should recheck it first", "Confirmation", MessageBoxButtons.OKCancel);


            if (r == DialogResult.OK)
            {
                gameGrid1.Mode = GameGrid.GridMode.TestComplete;

                answerBox.Enabled = false;
                skipModuleBtn.Enabled = false;
                finishTestBtn.Enabled = true;
            }
        }

        private void skipModuleBtn_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Do you really want to skip this step?\n You will gain 0 points for this step", "Confirmation", MessageBoxButtons.OKCancel);

            if (r == DialogResult.OK)
            {
                /////////
                gameGrid1.Mode = GameGrid.GridMode.TestComplete;

                answerBox.Enabled = false;
                skipModuleBtn.Enabled = false;
                finishTestBtn.Enabled = true;
            }
        }

        private void clearAnswerBtn_Click(object sender, EventArgs e)
        {
            answer.Text = "{}";
        }

        private void finishTestBtn_Click(object sender, EventArgs e)
        {
            tester.Proceed(gameGrid1.GetCorrectPercent());

            if (tester.Complete)
            {
                module.LastResults = tester.TestScore;
                module.TestCount++;
                MessageBox.Show(tester.Score.ToString() + " points (" + (100 * tester.Score / 10).ToString() + "%)\n"+
                    module.TestCount.ToString()+((module.TestCount==1)?" try":" tries")+" expended"
                , "Your result is:");
                string resultString = "Total results:\n";
                double finalResult=0;
                foreach(KeyValuePair<string,double> entry in module.LastResults)
                {
                    finalResult+=entry.Value;
                    resultString+=string.Format("{0} : {1}%\n",entry.Key,100*entry.Value);
                }
                resultString+="Total: "+100*finalResult/module.LastResults.Count;
                MessageBox.Show(resultString, "Your total is:");
                testBox.Enabled = false;
            }
            else
            {
                gameGrid1.SetResultSet(tester.CurrentItem.Result);
                gameGrid1.Mode = GameGrid.GridMode.Test;
                answerBox.Enabled = true;
                skipModuleBtn.Enabled = true;
                finishTestBtn.Enabled = false;
            }
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}