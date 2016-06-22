using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FuzzySets
{
    public partial class FuzzySet1D : FuzzySet
    {
        static public bool ValidationCallback(Common.DataTypes.BufferData obj)
        {
            if (!(obj is Common.DataTypes.Matrix<double>))
            {
                //MessageBox.Show("[Помилка] Данні повинні бути матрицею","Помилка при завантаженні", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if ((obj as Common.DataTypes.Matrix<double>).Value.GetLength(1) != 2) return false;
            List<double> xs = new List<double>();
            double[,] matr=(obj as Common.DataTypes.Matrix<double>).Value;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                if (xs.Contains(matr[i,0])) return false;
                xs.Add(matr[i, 0]);
                if (matr[i, 1] > 1.0 || matr[i, 1] < 0.0) return false;
            }
            return true;
        }
        Dictionary<double, double> dots;
        /// <summary>
        /// точки множества
        /// </summary>
        public Dictionary<double, double> Dots
        {
            get { return dots; }
        }
        bool discrete;
        public double[,] toMassiv()
        {
            if (!discrete)
            {
                double[,] res = new double[maxDotCount, 2];
                for (int i = 0; i < maxDotCount; i++)
                {
                    res[i, 0] = 1.0 * i / maxDotCount * (toX - fromX) + fromX;
                    res[i, 1] = this.Mu(res[i, 0]);
                }
                return res;
            }
            else
            {
                double[,] res = new double[dots.Count, 2];
                int i = 0;
                foreach (KeyValuePair<double,double> pair in dots)
                {
                    res[i, 0] = pair.Key;
                    res[i, 1] = pair.Value;
                    i++;
                }
                return res;
            }

        }
        public FuzzySet1D(double[,] mas, bool discrete): this()
        {
            this.discrete = discrete;
            if (mas.GetLength(1) != 2) return;
            for (int i = 0; i < mas.GetLength(0); i++)
                AddDot(mas[i, 0], mas[i, 1]);
        }

        /// <summary>
        /// является ли это множество дискретным
        /// </summary>
        public override bool Discrete
        {
            get { return discrete; }
            set
            {
                if (!discrete)
                {
                    MessageBox.Show("Не дискретну множину не можна перетворити на дискретну");
                    return;
                }
                discrete = value;
                if (!discrete)
                {
                    #region Преобразование дискретного множества в недискретное
                    //IEnumerator<double> en = dots.Keys.GetEnumerator();
                    IEnumerator<double> en = this.SortedXEnumarator();
                    en.MoveNext();
                    double lftX = fromX;
                    double rghX = en.Current;
                    double lftY = 0;
                    double rghY = (dots.Count > 0) ? dots[rghX] : 0.0;
                    Dictionary<double, double> res = new Dictionary<double, double>(maxDotCount);
                    for (int i = 0; i < maxDotCount; i++)
                    {
                        double currX = (toX - fromX) * i / maxDotCount + fromX;
                        if (currX <= rghX) { }
                        else
                        {
                            bool ok = en.MoveNext();
                            if (ok)
                            {
                                lftX = rghX;
                                lftY = rghY;
                                rghX = en.Current;
                                rghY = dots[rghX];
                            }
                            else if (rghX != toX)
                            {
                                lftX = rghX;
                                lftY = rghY;
                                rghX = toX;
                                rghY = 0.0;
                            }
                        }
                        double currY = (currX - lftX) / (rghX - lftX) * (rghY - lftY) + lftY;

                        res.Add(currX, (rghX==lftX)?0.0:currY);
                    }
                    this.dots = res;
                    #endregion
                }
            }
        }
        /// <summary>
        /// Рисует графическое представление матрицы
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public override Bitmap Render(System.Drawing.Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.EndCap = LineCap.SquareAnchor;
                gr.DrawLine(pen, new PointF(0, size.Height * 0.9f), new PointF(size.Width, size.Height * 0.9f));
            }
            {
                Pen pen = new Pen(Color.Black, 2.0f);
                pen.DashStyle = DashStyle.Dash;
                gr.DrawLine(pen, new PointF(0, size.Height * 0.1f), new PointF(size.Width, size.Height * 0.1f));
            }
            {
                Pen pen = new Pen(Color.Black, 1.0f);
                pen.DashStyle = DashStyle.Dash;
                Font font = new Font("Courier New", 8);
                for (double acc = FuzzySet.fromX; acc <= toX; acc += FuzzySet.xGridStep)
                {
                    gr.DrawLine(
                        pen,
                        new PointF((float)((acc - fromX) / (toX - fromX) * size.Width), 0),
                        new PointF((float)((acc - fromX) / (toX - fromX) * size.Width), size.Height));
                    gr.DrawString(acc.ToString(), font, Brushes.Green, new PointF((float)((acc - fromX) / (toX - fromX) * size.Width), size.Height*0.95f));
                }
                for (double acc = 0; acc <= 1.0; acc += FuzzySet.yGridStep)
                {
                    gr.DrawLine(
                        pen,
                        new PointF(0,(float)((acc - 0.0) / (1.0 - 0.0) * size.Height*0.8+size.Height*0.1)),
                        new PointF(size.Width,(float)((acc - 0.0) / (1.0 - 0.0) * size.Height*0.8+size.Height*0.1)));
                }

            }

            if (discrete)
            {
                Pen pen = new Pen(Color.Red, 2.0f);
                Font font = new Font("Courier New", 8);
                foreach (KeyValuePair<double, double> pair in dots)
                {
                    float x = (float)((pair.Key - fromX) / (toX - fromX) * size.Width);
                    float y = (float)(size.Height * 0.9f - pair.Value * size.Height * 0.8f);
                    int rad = 4;
                    gr.DrawEllipse(pen, x - rad, y - rad, 2 * rad, 2 * rad);
                    gr.DrawLine(pen, new PointF(x, y + rad), new PointF(x, size.Height * 0.9f));
                    gr.DrawString(pair.Value.ToString(), font, Brushes.Blue, new PointF(x + rad, y + rad));
                    gr.DrawString(pair.Key.ToString(), font, Brushes.Blue, new PointF(x + rad, size.Height * 0.9f));
                }
            }
            else
            {
                Pen pen = new Pen(Color.Red, 2.0f);
                float lst = size.Height * 0.9f;
                for (int i = 0; i < size.Width; i++)
                {
                    float dx = (float)((toX - fromX) * i / size.Width + fromX);
                    float y = (float)(size.Height * 0.9f - this.Mu(dx) * size.Height * 0.8f);
                    gr.DrawLine(pen, new PointF(i - 1, lst), new PointF(i, y));
                    lst = y;
                }
            }
            return bmp;
        }
        /// <summary>
        /// Заполняет контрол. матрицей точек
        /// </summary>
        /// <param name="dgw">котрол</param>
        public override void ToMatrix(DataGridView dgw)
        {
         
            dgw.DataSource = null;
            dgw.Rows.Clear();
            dgw.Columns.Clear();
            dgw.Tag = this;
            if (!this.discrete) return;
            dgw.ColumnHeadersVisible = true;
            dgw.RowHeadersVisible = false;
            dgw.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.ValueType = typeof(double);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.Name = "x";
                dgw.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewColumn();
                col.ValueType = typeof(double);
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.Name = "мю(x)";
                dgw.Columns.Add(col);
            }
            {
                List<double> xs = new List<double>(dots.Count);
                foreach (KeyValuePair<double,double> pair in dots)
                    xs.Add(pair.Key);
                xs.Sort();
                for (int i = 0; i < dots.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    {
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        cell.ValueType = typeof(double);
                        cell.Style.Font = new Font("Courier New", 10.0f);
                        row.Cells.Add(cell);
                    }
                    {
                        DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                        cell.ValueType = typeof(double);
                        cell.Style.Font = new Font("Courier New", 10.0f);
                        row.Cells.Add(cell);
                    }
                    row.Cells[0].ValueType = typeof(double);
                    row.Cells[0].Value = xs[i];
                    row.Cells[1].ValueType = typeof(double);
                    row.Cells[1].Value = dots[xs[i]];
                    dgw.Rows.Add(row);
                }
            }
        }
        public FuzzySet1D()
        {
            dots = new Dictionary<double, double>();
            discrete = true;
        }
        /// <summary>
        /// добавить новую точку
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <returns>можно ли ее добавить</returns>
        public bool AddDot(double x, double y)
        {
            if (y < 0.0) return false;
            if (x < fromX || x > toX) return false;
            if (dots.ContainsKey(x))
                this.RemoveDot(x);
            if (y == 0) return false;
            if (y >= 1.0) dots.Add(x, 1.0);
            else  dots.Add(x, y);
            return true;
        }
        /// <summary>
        /// удалить точку
        /// </summary>
        /// <param name="x">X</param>
        /// <returns>можно ли ее удалить</returns>
        public bool RemoveDot(double x)
        {
            if (!dots.ContainsKey(x)) return false;
            dots.Remove(x);
            return true;
        }

        /// <summary>
        /// возвращает Enumarator на остортированное множество
        /// </summary>
        /// <returns></returns>
        private IEnumerator<double> SortedXEnumarator()
        {
            List<double> xs = new List<double>(dots.Count);
            foreach (KeyValuePair<double, double> pair in dots)
                xs.Add(pair.Key);
            xs.Sort();
            return xs.GetEnumerator();
        }
        /// <summary>
        /// функция мю
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Mu(double x)
        {
            if (discrete)
            {
                foreach (KeyValuePair<double, double> pair in dots)
                    if (pair.Key == x) return pair.Value;
                return 0.0;
            }
            else
            {
                
                if (this.dots.ContainsKey(x)) 
                    return this.dots[x];
                //IEnumerator<double> en = dots.Keys.GetEnumerator();
                IEnumerator<double> en = this.SortedXEnumarator();
                en.MoveNext();
                if (x <= en.Current && x >= fromX) return 0.0;
                double lst=en.Current;
                double curr = en.Current;
                while (x >= en.Current)
                    if (en.MoveNext())
                    {
                        lst = curr;
                        curr = en.Current;
                    }
                    else
                        return 0.0;
                if (Math.Abs(lst - curr) > (toX - fromX) / (maxDotCount-1)) 
                    return 0.0;
                return (dots[lst] + dots[curr]) / 2;
            }
        }

        public static FuzzySet1D operator &(FuzzySet1D f1, FuzzySet1D f2)
        {
            if ((!f1.discrete && f2.discrete) || (f1.discrete && !f2.discrete))
            {
                MessageBox.Show("Операцію перетину можна робити тільки над множинами одного типу");
                return null;
            }
            if (f1.discrete && f2.discrete)
            {
                FuzzySet1D res = new FuzzySet1D();
                foreach (KeyValuePair<double, double> pair in f1.dots)
                    res.AddDot(pair.Key, Math.Min(pair.Value, f2.Mu(pair.Key)));
                foreach (KeyValuePair<double, double> pair in f2.dots)
                    res.AddDot(pair.Key, Math.Min(pair.Value, f1.Mu(pair.Key)));
                return res;
            }
            else
            {
                FuzzySet1D res = new FuzzySet1D();
                res.Discrete = false;
                foreach (KeyValuePair<double, double> pair in f1.dots)
                    res.AddDot(pair.Key, Math.Min(pair.Value, f2.Mu(pair.Key)));
                return res;
            }
        }

        public static FuzzySet1D operator |(FuzzySet1D f1, FuzzySet1D f2)
        {
            if ((!f1.discrete && f2.discrete) || (f1.discrete && !f2.discrete))
            {
                MessageBox.Show("Операцію об'єднання можна робити тільки над множинами одного типу");
                return null;
            }
            if (f1.discrete && f2.discrete)
            {
                FuzzySet1D res = new FuzzySet1D();
                foreach (KeyValuePair<double, double> pair in f1.dots)
                    res.AddDot(pair.Key, Math.Max(pair.Value, f2.Mu(pair.Key)));
                foreach (KeyValuePair<double, double> pair in f2.dots)
                    res.AddDot(pair.Key, Math.Max(pair.Value, f1.Mu(pair.Key)));
                return res;
            }
            else
            {
                FuzzySet1D res = new FuzzySet1D();
                res.Discrete = false;
                foreach (KeyValuePair<double, double> pair in f1.dots)
                {
                    double x = pair.Key;
                    double y = Math.Max(pair.Value, f2.Mu(pair.Key));
                    res.AddDot(pair.Key, Math.Max(pair.Value, f2.Mu(pair.Key)));
                }
                foreach (KeyValuePair<double, double> pair in f2.dots)
                {
                    double x = pair.Key;
                    double y = Math.Max(pair.Value, f1.Mu(pair.Key));
                    res.AddDot(pair.Key, Math.Max(Math.Max(pair.Value, f1.Mu(pair.Key)),res.Mu(pair.Key)));
                }
                return res;
            }
        }

        public static FuzzySet1D operator /(FuzzySet1D f1, FuzzySet1D f2)
        {
            if ((!f1.discrete && f2.discrete) || (f1.discrete && !f2.discrete))
            {
                MessageBox.Show("Операцію різниці можна робити тільки над множинами одного типу");
                return null;
            }
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
                if (pair.Value - f2.Mu(pair.Key) > 0)
                    res.AddDot(pair.Key, pair.Value - f2.Mu(pair.Key));
            res.discrete = f1.discrete;
            return res;
        }

        public FuzzySet1D(FuzzySet1D set):this()
        {
            this.Name = set.Name;
            foreach (KeyValuePair<double,double> pair in set.Dots)
                this.dots.Add(pair.Key, pair.Value);
            this.discrete = set.discrete;
        }
        public static FuzzySet2D operator *(FuzzySet1D f1, FuzzySet1D f2)
        {
            if (!f1.discrete || !f2.discrete) return null;
            FuzzySet2D res = new FuzzySet2D();
            foreach (KeyValuePair<double, double> p1 in f1.dots)
                foreach (KeyValuePair<double, double> p2 in f2.dots)
                    res.AddDot(p1.Key, p2.Key, Math.Min(p1.Value, p2.Value));
            return res;
        }
    }
}
