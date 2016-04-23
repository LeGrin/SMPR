using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FuzzySets
{
    public struct PairD: IComparer<PairD>
    {
        double x1;
        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        double x2;
        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }
        public PairD(double x1, double x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        #region IComparer<PairD> Members

        int IComparer<PairD>.Compare(PairD a, PairD b)
        {
            if (a.x1 != b.x1) return Math.Sign(a.x1 - b.x1);
            else return Math.Sign(a.x2 - b.x2);
        }

        #endregion
    }

    public class FuzzySet2D: FuzzySet
    {
        bool discrete;
        Dictionary<PairD, double> dots;

        public Dictionary<PairD, double> Dots
        {
            get { return dots; }
        }
        #region Private
        private Dictionary<PairD, double> selectByX1(double x1)
        {
            Dictionary<PairD, double> res = new Dictionary<PairD, double>();
            foreach (KeyValuePair<PairD, double> pair in dots)
                if (pair.Key.X1 == x1) res.Add(pair.Key, pair.Value);
            return res;
        }
        private Dictionary<PairD, double> selectByX2(double x2)
        {
            Dictionary<PairD, double> res = new Dictionary<PairD, double>();
            foreach (KeyValuePair<PairD, double> pair in dots)
                if (pair.Key.X2 == x2) res.Add(pair.Key, pair.Value);
            return res;
        }
        private List<double> getUniqueX1()
        {
            List<double> res = new List<double>();
            foreach (KeyValuePair<PairD, double> pair in dots)
                if (!res.Contains(pair.Key.X1)) res.Add(pair.Key.X1);
            return res;
        }
        private List<double> getUniqueX2()
        {
            List<double> res = new List<double>();
            foreach (KeyValuePair<PairD, double> pair in dots)
                if (!res.Contains(pair.Key.X2)) res.Add(pair.Key.X2);
            return res;
        }
        #endregion

        public override bool Discrete
        {
            get
            {
                return discrete;
            }
            set
            {
            }
           
        }

        public bool Contains(PairD xy)
        {
            return (dots.ContainsKey(xy));
        }
       

        public override System.Drawing.Bitmap Render(System.Drawing.Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.EndCap = LineCap.ArrowAnchor;
                gr.DrawLine(pen, new PointF(0, size.Height * 0.1f), new PointF(size.Width, size.Height * 0.1f));
            }
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.EndCap = LineCap.ArrowAnchor;
                gr.DrawLine(pen, new PointF(size.Width * 0.1f, 0), new PointF(size.Width * 0.1f, size.Height));
            }
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.DashStyle = DashStyle.Dash;
                gr.DrawLine(pen, new PointF(0, size.Height * 0.9f), new PointF(size.Width, size.Height * 0.9f));
            }
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.DashStyle = DashStyle.Dash;
                gr.DrawLine(pen, new PointF(size.Width * 0.9f, 0), new PointF(size.Width * 0.9f, size.Height));
            }
            {
                Pen pen = new Pen(Color.Black, 1.0f);
                pen.DashStyle = DashStyle.Dash;
                Font font = new Font("Courier New", 8);
                for (double acc = FuzzySet.fromX; acc <= toX; acc += FuzzySet.xGridStep)
                {
                    gr.DrawLine(
                        pen,
                        new PointF((float)((acc - fromX) / (toX - fromX) * size.Width * 0.8f + size.Width * 0.1f), 0),
                        new PointF((float)((acc - fromX) / (toX - fromX) * size.Width * 0.8f + size.Width * 0.1f), size.Height));
                    gr.DrawString(acc.ToString(), font, Brushes.Green, new PointF((float)((acc - fromX) / (toX - fromX) * size.Width * 0.8f + size.Width * 0.1f), size.Height * 0.00f));
                }
                for (double acc = FuzzySet.fromX; acc <= toX; acc += FuzzySet.xGridStep)
                {
                    gr.DrawLine(
                        pen,
                        new PointF(0, (float)((acc - fromX) / (toX - fromX) * size.Height * 0.8f + size.Height * 0.1f)),
                        new PointF(size.Width, (float)((acc - fromX) / (toX - fromX) * size.Height * 0.8f + size.Height * 0.1f)));
                    gr.DrawString(acc.ToString(), font, Brushes.Green, new PointF(size.Width * 0.00f, (float)((acc - fromX) / (toX - fromX) * size.Height * 0.8f + size.Height * 0.1f)));
                }

            }
            if (this.discrete)
            {
                Pen pen = new Pen(Color.Red, 2.0f);
                pen.DashStyle = DashStyle.Dash;
                Font font = new Font("Courier New", 8);
                int diam = 20;
                const int addDiam = 1;
                foreach (KeyValuePair<PairD, double> pair in dots)
                {
                    float x1 = (float)((pair.Key.X1 - fromX) / (toX - fromX) * size.Width * 0.8f + size.Width * 0.1f);
                    float x2 = (float)((pair.Key.X2 - fromX) / (toX - fromX) * size.Height * 0.8f + size.Height * 0.1f);
                    
                    float y = (float)(pair.Value * diam);
                    gr.FillEllipse(Brushes.Red, x1 - y / 2, x2 - y / 2, (Math.Round(y) == 0) ? 1 : y+addDiam, (Math.Round(y) == 0) ? 1 : y+addDiam);
                    gr.DrawLine(pen, new PointF(x1, x2), new PointF(x1, size.Height * 0.1f));
                    gr.DrawLine(pen, new PointF(x1, x2), new PointF(size.Width * 0.1f,x2));
                    gr.DrawString(pair.Value.ToString(), font, Brushes.Blue, new PointF(x1 +y/2, x2+y/2));
                    gr.DrawString(pair.Key.X1.ToString(), font, Brushes.Blue, new PointF(x1, size.Height * 0.1f));
                    gr.DrawString(pair.Key.X1.ToString(), font, Brushes.Blue, new PointF(size.Width * 0.1f,x2));
                }
            }
            else
            {
            }
            return bmp;
        }


        public override void ToMatrix(System.Windows.Forms.DataGridView dgw)
        {
            dgw.DataSource = null;
            dgw.Rows.Clear();
            dgw.Columns.Clear();
            dgw.Tag = this;
            dgw.ColumnHeadersVisible = true;
            dgw.RowHeadersVisible = false;
            dgw.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (!this.discrete) return;
            List<double> ux1 = getUniqueX1();
            ux1.Sort();
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.ValueType = typeof(double);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.Name = "y\\x";
                col.ReadOnly = true;
                col.Frozen = true;
                col.DefaultCellStyle.BackColor = Color.DarkGray;
                dgw.Columns.Add(col);
            }
            for (int i = 0; i < ux1.Count; i++)
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.ValueType = typeof(double);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.Name = ux1[i].ToString();
                col.Tag = ux1[i];
                dgw.Columns.Add(col);
            }
            List<double> ux2 = getUniqueX2();
            ux2.Sort();
            for (int i = 0; i < ux2.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.ValueType = typeof(double);
                    cell.Value = ux2[i];
                    row.Tag = ux2[i]; 
                    row.Cells.Add(cell);
                }
                for (int k = 0; k < ux1.Count; k++)
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.ValueType = typeof(double);
                    cell.Value = this.Mu(ux1[k], ux2[i]);
                    row.Cells.Add(cell);
                }
                dgw.Rows.Add(row);
            }
        }

        /// <summary>
        /// добавить новую точку
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="z">Z</param>
        /// <returns>можно ли ее добавить</returns>
        public bool AddDot(double x, double y, double z)
        {
            if (dots.ContainsKey(new PairD(x,y))) return false;
            if (z <= 0||z>1.0) return false;
            dots.Add(new PairD(x, y),z);
            return true;
        }
        /// <summary>
        /// удалить точку
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns>можно ли ее удалить</returns>
        public bool RemoveDot(double x, double y)
        {
            if (!dots.ContainsKey(new PairD(x, y))) return false;
            dots.Remove(new PairD(x, y));
            return true;
        }
        public FuzzySet2D()
        {
            this.dots = new Dictionary<PairD, double>();
            this.discrete = true;
        }
        public FuzzySet2D(FuzzySet2D fs): this()
        {
            foreach (KeyValuePair<PairD, double> pair in fs.dots)
                this.AddDot(pair.Key.X1, pair.Key.X2, pair.Value);
        }
        /// <summary>
        /// функция мю
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double Mu(double x, double y)
        {
            if (discrete)
            {
                foreach (KeyValuePair<PairD, double> pair in dots)
                    if (pair.Key.X1 == x && pair.Key.X2 == y)
                        return pair.Value;
                return 0.0;
            }
            else
            {
                return 0.0;
            }
        }

        public static FuzzySet2D operator &(FuzzySet2D f1, FuzzySet2D f2)
        {
            if (!f1.discrete || !f2.discrete) return null;
            FuzzySet2D res = new FuzzySet2D();
            foreach (KeyValuePair<PairD, double> pair in f1.dots)
                res.AddDot(pair.Key.X1, pair.Key.X2, Math.Min(f2.Mu(pair.Key.X1, pair.Key.X2), pair.Value));
            foreach (KeyValuePair<PairD, double> pair in f2.dots)
                res.AddDot(pair.Key.X1, pair.Key.X2, Math.Min(f1.Mu(pair.Key.X1, pair.Key.X2), pair.Value));
            return res;
        }
        public static FuzzySet2D operator |(FuzzySet2D f1, FuzzySet2D f2)
        {
            if (!f1.discrete || !f2.discrete) return null;
            FuzzySet2D res = new FuzzySet2D();
            foreach (KeyValuePair<PairD, double> pair in f1.dots)
                res.AddDot(pair.Key.X1, pair.Key.X2, Math.Max(f2.Mu(pair.Key.X1, pair.Key.X2), pair.Value));
            foreach (KeyValuePair<PairD, double> pair in f2.dots)
                res.AddDot(pair.Key.X1, pair.Key.X2, Math.Max(f1.Mu(pair.Key.X1, pair.Key.X2), pair.Value));
            return res;
        }
        public static FuzzySet2D operator /(FuzzySet2D f1, FuzzySet2D f2)
        {
            if (!f1.discrete || !f2.discrete) return null;
            FuzzySet2D res = new FuzzySet2D();
            foreach (KeyValuePair<PairD, double> pair in f1.dots)
                if (pair.Value - f2.Mu(pair.Key.X1, pair.Key.X2)>0)
                res.AddDot(pair.Key.X1, pair.Key.X2, pair.Value - f2.Mu(pair.Key.X1, pair.Key.X2));
            return res;
        }
        public static FuzzySet2D MaxMinCompose(FuzzySet2D R, FuzzySet2D S)
        {
            List<double> zList = new List<double>();
            zList.AddRange(R.getUniqueX2());
            zList.AddRange(S.getUniqueX1());
            List<double> xList = new List<double>();
            xList.AddRange(R.getUniqueX1());
            List<double> yList = new List<double>();
            yList.AddRange(S.getUniqueX2());
            FuzzySet2D res = new FuzzySet2D();
            foreach (double x in xList)
                foreach (double y in yList)
            {
                double sup = 0;
                foreach (double z in zList)
                {
                    double tmp = Math.Min(R.Mu(x,z),S.Mu(z,y));
                    if (tmp > sup) sup = tmp;
                }
                res.AddDot(x, y, sup);
            }
        return res;
        }
        public static FuzzySet2D MinMaxCompose(FuzzySet2D R, FuzzySet2D S)
        {
            List<double> zList = new List<double>();
            zList.AddRange(R.getUniqueX2());
            zList.AddRange(S.getUniqueX1());
            List<double> xList = new List<double>();
            xList.AddRange(R.getUniqueX1());
            List<double> yList = new List<double>();
            yList.AddRange(S.getUniqueX2());
            FuzzySet2D res = new FuzzySet2D();
            foreach (double x in xList)
                foreach (double y in yList)
                {
                    double inf = 1;
                    foreach (double z in zList)
                    {
                        double tmp = Math.Max(R.Mu(x, z), S.Mu(z, y));
                        if (tmp < inf) inf = tmp;
                    }
                    res.AddDot(x, y, inf);
                }
            return res;
        }
        public static FuzzySet2D MaxMultCompose(FuzzySet2D R, FuzzySet2D S)
        {
            List<double> zList = new List<double>();
            zList.AddRange(R.getUniqueX2());
            zList.AddRange(S.getUniqueX1());
            List<double> xList = new List<double>();
            xList.AddRange(R.getUniqueX1());
            List<double> yList = new List<double>();
            yList.AddRange(S.getUniqueX2());
            FuzzySet2D res = new FuzzySet2D();
            foreach (double x in xList)
                foreach (double y in yList)
                {
                    double sup = 0;
                    foreach (double z in zList)
                    {
                        double tmp = R.Mu(x,z)*S.Mu(z,y);
                        if (tmp > sup) sup = tmp;
                    }
                    res.AddDot(x, y, sup);
                }
            return res;
        }
    }
}
