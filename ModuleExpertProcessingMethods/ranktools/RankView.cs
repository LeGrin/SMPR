using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Modules.ExpertProcessingMethods
{

    public delegate void SimpleEvent();


    public partial class RankView : UserControl
    {

        Point start = new Point(Ranking.RankCellSize, 0);

        public event SimpleEvent Changed;

        private void SetNewRanking(int[] ranking)
        {
        }

        private Ranking ranking, rankingBak;

        public bool Strict;

        private int dragged = -1;

        [Browsable(true)]
        [EditorBrowsable(0)]
        public Ranking TheRanking
        {
            get
            {
                return ranking;
            }
            set
            {
                ranking = value;
                Size temp= ranking.VisibleDimensions() +new Size(start);
                this.Height = temp.Height;
                this.Width = temp.Width;
                this.Refresh();
                Refresh();
            }
        }
        ////public int size{get{return 0;}  set{}}

        public RankView()
        {
            InitializeComponent();
            double[] temp = {1.0};
            ranking = new Ranking(temp);
            Strict = false;
        }


        private void grid_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void grid_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
        {

        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_MouseHover(object sender, EventArgs e)
        {
            //toolTip.Show("Використовуйте Ctrl+курсорні клавіші для зміни позиції об'экта в ранжуванні", grid);
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void RankView_Paint(object sender, PaintEventArgs e)
        {
        }


        private void PaintRanking(Graphics g)
        {
            //ArrayList diff
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);
            // Call methods of the System.Drawing.Graphics object.
            ranking.DrawTo(e.Graphics,dragged, start);
            //e.Graphics.DrawString("yo", this.Font, new SolidBrush(Color.Red), ClientRectangle);
        } 


        private void RankView_Load(object sender, EventArgs e)
        {
        }

        private void RankView_MouseDown(object sender, MouseEventArgs e)
        {
            dragged = ranking.CellUnderMouse(new Point(e.X, e.Y), start);
            rankingBak = (Ranking)ranking.Clone();
            Refresh();
        }

        private void RankView_MouseUp(object sender, MouseEventArgs e)
        {
            dragged = -1;
            Refresh();
            if (Changed != null)
                Changed();
        }

        private void RankView_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragged >= 0)
            {
                ranking.MoveCell(dragged, e.Y, start);
                ranking = (Ranking)ranking.Clone();
                Size temp = ranking.VisibleDimensions() + new Size(start);
                this.Height = temp.Height;
                this.Width = temp.Width;
                this.Refresh();
                Refresh();
            }
        }
    }
}
