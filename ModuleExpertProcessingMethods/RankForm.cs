using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.ExpertProcessingMethods;

namespace Rankviewtest
{
    public partial class RankForm : Form
    {
        Ranking TheRanking 
        {
            get{return rankView1.TheRanking;}
            set{rankView1.TheRanking = value;}
        }

        public RankForm(Ranking ranking)
        {
            InitializeComponent();
            rankView1.TheRanking = ranking;
            Size s = rankView1.Size;
            s.Width = (int) ((s.Width+ranking.Size*Ranking.RankCellSize)/2);
            s.Height = (int)((s.Height + ranking.Size * Ranking.RankCellSize) / 2);
            s.Width += 40;
            s.Height += 130;
            
            int maxHeight = Screen.PrimaryScreen.Bounds.Height-80;
            int maxWidth = Screen.PrimaryScreen.Bounds.Width-80;
            s.Height = (s.Height > maxHeight) ? maxHeight : s.Height;
            s.Width = (s.Width > maxWidth) ? maxWidth : s.Width;
            if (s.Width < 200) s.Width = 200;
            this.Size = s;
        }

        public static bool Dialog(ref Ranking ranking)
        {
            Ranking copy = (Ranking)ranking.Clone();
            RankForm rankForm = new RankForm(ranking);
            DialogResult result = rankForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                ranking = rankForm.TheRanking;
                return true;
            }
            else
            {
                ranking = copy;
                return false;
            }
        }

    }
}