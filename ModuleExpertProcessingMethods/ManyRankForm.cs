using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Modules.ExpertProcessingMethods;

namespace Modules.ExpertProcessingMethods
{
    public partial class ManyRankForm : Form
    {

        private RankView[] views;

        public ManyRankForm()
        {
            InitializeComponent();
        }

        Ranking[] MatrixToRankings(int[,] matrix)
        {
            int expertCount = matrix.GetLength(0);
            int objectCount = matrix.GetLength(1);
            Ranking[] result = new Ranking[expertCount];
            for (int i = 0; i < expertCount; i++)
            {
                double[] current = new double[objectCount];
                for (int j = 0; j < objectCount; j++)
                    current[j] = (double)matrix[i, j];
                result[i] = new Ranking(current);                
            }
            return result;
        }

        int[,] RankingsToMatrix(Ranking[] rankings)
        {
            int expertCount = rankings.Length;
            int objectCount = rankings[0].Size;
            int[,] result = new int[expertCount, objectCount];
            for (int i = 0; i < expertCount; i++)
            {
                double[] current = rankings[i].Marks;
                for (int j = 0; j < objectCount; j++)
                    result[i, j] = (int)current[j];
            }
            return result;
        }


        private void AddRanking(int i, Ranking ranking, bool strict)
        {
            int width =150;
            int x = i * width;
            Panel panel = new Panel();
            panel.AutoScroll = true;
            panel.Parent = area;
            panel.Left = x;
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.Show();
            panel.Width = width;
            panel.Height = area.ClientRectangle.Height-4;
            panel.Anchor = AnchorStyles.Left |AnchorStyles.Top | AnchorStyles.Bottom;


            Label label = new Label();
            label.Text = string.Format("Експерт {0}", (i + 1));
            label.Parent = panel;

            RankView rv = new RankView();
            ranking.Strict = strict;
            rv.TheRanking = ranking;
            rv.Top = label.Height;
            rv.Parent = panel;
            views[i] = rv;
            rv.Show();
        }

        protected Ranking[] GetRankings()
        {
            Ranking[] rs = new Ranking[views.Length];
            for (int i = 0; i < views.Length; i++)
            {
                rs[i] = views[i].TheRanking;
            }
            return rs;
        }

        protected bool _Dialog(ref int[,] expertsMarks, bool strict)
        {
            int expertCount = expertsMarks.GetLength(0);
            int objectCount = expertsMarks.GetLength(1);

            Ranking[] rankings = MatrixToRankings(expertsMarks);
            views = new RankView[expertCount];

            for (int i = 0; i < expertCount; i++)
            {
                AddRanking(i, rankings[i], strict);                                
            }

            this.Width = (400+150*expertCount)/2;
            if (this.Width > Screen.PrimaryScreen.Bounds.Width)
                this.Width = Screen.PrimaryScreen.Bounds.Width;

            //MessageBox.Show(Convert.ToString(expertCount));
            DialogResult dr = this.ShowDialog();
            if (dr == DialogResult.OK)
            {
                expertsMarks = RankingsToMatrix(GetRankings());
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Dialog(ref int[,] expertsMarks, bool strict)
        {
            ManyRankForm f = new ManyRankForm();
            return f._Dialog(ref expertsMarks, strict);
        }

        public static int[,] SimpleRankingMatrix(int expertCount, int objectCount)
        {
            int[,] result= new int[expertCount, objectCount];
            for (int i=0;i<expertCount;i++)
                for (int j=0;j<objectCount;j++)
                    result[i,j] = j;
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}