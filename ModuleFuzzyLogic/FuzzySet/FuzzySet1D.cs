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
            double[,] matr = (obj as Common.DataTypes.Matrix<double>).Value;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                if (xs.Contains(matr[i, 0])) return false;
                xs.Add(matr[i, 0]);
                if (matr[i, 1] > 1.0 || matr[i, 1] < 0.0) return false;
            }
            return true;
        }
        Dictionary<double, double> dots;
        public void clearDots()
        {
            dots.Clear();
        }
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
                foreach (KeyValuePair<double, double> pair in dots)
                {
                    res[i, 0] = pair.Key;
                    res[i, 1] = pair.Value;
                    i++;
                }
                return res;
            }

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

                        res.Add(currX, (rghX == lftX) ? 0.0 : currY);
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
                    gr.DrawString(acc.ToString(), font, Brushes.Green, new PointF((float)((acc - fromX) / (toX - fromX) * size.Width), size.Height * 0.95f));
                }
                for (double acc = 0; acc <= 1.0; acc += FuzzySet.yGridStep)
                {
                    gr.DrawLine(
                        pen,
                        new PointF(0, (float)((acc - 0.0) / (1.0 - 0.0) * size.Height * 0.8 + size.Height * 0.1)),
                        new PointF(size.Width, (float)((acc - 0.0) / (1.0 - 0.0) * size.Height * 0.8 + size.Height * 0.1)));
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
            dgw.ColumnCount = 2;
            dgw.Columns[0].Name = "x";
            dgw.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgw.Columns[0].HeaderText = "X";

            dgw.Columns[1].ValueType = typeof(double);
            dgw.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgw.Columns[1].Name = "p(x)";

            {
                List<double> xs = new List<double>(dots.Count);
                foreach (KeyValuePair<double, double> pair in dots)
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
                    row.Cells[0].Value = String.Format("{0:0.00}", xs[i]);
                    row.Cells[1].ValueType = typeof(double);
                    row.Cells[1].Value = String.Format("{0:0.00}", dots[xs[i]]);
                    dgw.Rows.Add(row);
                }
            }
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
            if (y >= 1.0) dots.Add(x, 1.0);
            else dots.Add(x, y);
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
            foreach (KeyValuePair<double, double> pair in dots)
                if (pair.Key == x) return pair.Value;
            return 0.0;
        }

        public static FuzzySet1D operator &(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
                res.AddDot(pair.Key, Math.Min(pair.Value, f2.Mu(pair.Key)));
            foreach (KeyValuePair<double, double> pair in f2.dots)
                res.AddDot(pair.Key, Math.Min(pair.Value, f1.Mu(pair.Key)));
            return res;
        }

        public static FuzzySet1D operator |(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
                res.AddDot(pair.Key, Math.Max(pair.Value, f2.Mu(pair.Key)));
            foreach (KeyValuePair<double, double> pair in f2.dots)
                res.AddDot(pair.Key, Math.Max(pair.Value, f1.Mu(pair.Key)));
            return res;

        }

        public static FuzzySet1D operator /(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
                res.AddDot(pair.Key, Math.Max(pair.Value - f2.Mu(pair.Key), 0));
            return res;
        }



        // дизьюнктивна сума
        public static FuzzySet1D dSum(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Max(Math.Min(f1.Mu(x), 1 - f2.Mu(x)), Math.Min(1 - f1.Mu(x), f2.Mu(x))));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Max(Math.Min(f1.Mu(x), 1 - f2.Mu(x)), Math.Min(1 - f1.Mu(x), f2.Mu(x))));
            }

            return res;
        }
        // граничний перетин
        public static FuzzySet1D gIntersect(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Max(f1.Mu(x) + f2.Mu(x) - 1, 0));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Max(f1.Mu(x) + f2.Mu(x) - 1, 0));
            }
            return res;
        }
        // граничний обєднання
        public static FuzzySet1D gUnion(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Min(f1.Mu(x) + f2.Mu(x), 1));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Min(f1.Mu(x) + f2.Mu(x), 1));
            }
            return res;
        }

        // альфа сума
        public static FuzzySet1D alphaSum(FuzzySet1D f1, FuzzySet1D f2, double alpha)
        {
            FuzzySet1D res = new FuzzySet1D();
            if (alpha > 1) alpha = 1;
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, alpha * f1.Mu(x) + (1 - alpha) * f2.Mu(x));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, alpha * f1.Mu(x) + (1 - alpha) * f2.Mu(x));
            }
            return res;
        }



        // алгебраїчний перетин
        public static FuzzySet1D operator *(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();

            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, f1.Mu(x) * f2.Mu(x));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, f1.Mu(x) * f2.Mu(x));
            }

            return res;
        }

        //алгебраїчне обєднання
        public static FuzzySet1D operator +(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, f1.Mu(x) + f2.Mu(x) - f1.Mu(x) * f2.Mu(x));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, f1.Mu(x) + f2.Mu(x) - f1.Mu(x) * f2.Mu(x));
            }
            return res;
        }

        // симетрична різниця
        public static FuzzySet1D operator -(FuzzySet1D f1, FuzzySet1D f2)
        {
            FuzzySet1D res = new FuzzySet1D();
            foreach (KeyValuePair<double, double> pair in f1.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Abs(f1.Mu(x) - f2.Mu(x)));
            }
            foreach (KeyValuePair<double, double> pair in f2.dots)
            {
                double x = pair.Key;
                res.AddDot(pair.Key, Math.Abs(f1.Mu(x) - f2.Mu(x)));
            }
            return res;
        }

        // CONSTRUCTORS
        public FuzzySet1D()
        {
            dots = new Dictionary<double, double>();
            discrete = true;
        }
        public FuzzySet1D(double[,] mas, bool discrete = true) : this()
        {
            this.discrete = discrete;
            if (mas.GetLength(1) != 2) return;
            for (int i = 0; i < mas.GetLength(0); i++)
                AddDot(mas[i, 0], mas[i, 1]);
        }
        public FuzzySet1D(FuzzySet1D set) : this()
        {
            this.Name = set.Name;
            foreach (KeyValuePair<double, double> pair in set.Dots)
                this.dots.Add(pair.Key, pair.Value);
            this.discrete = set.discrete;
        }
        
        public double getMu(double x)
        {
            SortedList<double, double> v = new SortedList<double, double>(dots);
            int len = v.Count;

            for (int i = 0; i + 1 < len; i++)
            {
                if (x >= v.Keys[i] && x <= v.Keys[i + 1])
                {
                    double x1 = v.Keys[i], x2 = v.Keys[i + 1];
                    double y1 = v.Values[i], y2 = v.Values[i + 1];
                    return (x2 * y1 - x1 * y2 + (y2 - y1) * x) / (x2 - x1);
                }
            }
            return 0.0;
        }
        public FuzzySet1D sliceSet(double alpha)
        {
            FuzzySet1D res = new FuzzySet1D();
            SortedList<double, double> v = new SortedList<double, double>(dots);
            int len = v.Count;
            bool isOpen = false;

            for (int i = 0; i < len; i++)
            {
                if (isOpen)
                {
                    if (v.Values[i] < alpha)
                    {
                        double x1 = v.Keys[i - 1], x2 = v.Keys[i];
                        double y1 = v.Values[i - 1], y2 = v.Values[i];
                        double x = alpha * ((x2 - x1) / (y2 - y1)) - (x2 * y1 - x1 * y2) / (y2 - y1);
                        res.AddDot(x, alpha);
                        res.AddDot(v.Keys[i], v.Values[i]);
                        isOpen = false;
                    } else
                    if (i + 1 == len)
                    {
                        res.AddDot(v.Keys[i], alpha);
                    }
                }
                else
                {
                    if (v.Values[i] <= alpha)
                    {
                        res.AddDot(v.Keys[i], v.Values[i]);
                    }
                    else
                    {
                        if (i > 0)
                        {
                            double x1 = v.Keys[i - 1], x2 = v.Keys[i];
                            double y1 = v.Values[i - 1], y2 = v.Values[i];
                            double x = alpha * ((x2 - x1) / (y2 - y1)) - (x2 * y1 - x1 * y2) / (y2 - y1);
                            res.AddDot(x, alpha);
                            if (i + 1 == len)
                            {
                                res.AddDot(v.Keys[i], alpha);
                            }
                        }
                        else
                        {
                            res.AddDot(v.Keys[i], alpha);
                        }
                        isOpen = true;
                    }
                }
            }
            return res;
        }

        // помножити функцію належності на множник, множник в [0,1]
        public FuzzySet1D multiplyMuOn(double multiplier) {
            if (multiplier > 1 || multiplier < 0) return null;
            FuzzySet1D res = new FuzzySet1D();
            foreach (var dot in dots) {
                res.AddDot(dot.Key, dot.Value * multiplier);
            }
            return res;
        }

        public FuzzySet1D unite(FuzzySet1D that)
        {
            if(this.Dots.Count == 0)return that;
            if(that.Dots.Count == 0)return this;

            FuzzySet1D res = new FuzzySet1D();
            int firstPos = 0, secondPos = 0;
            double last = 0.0;
            double eps = 1e-9;

            SortedList<double, double>[] set = new SortedList<double,double>[2];
            set[0] = new SortedList<double,double>(this.Dots);
            set[1] = new SortedList<double,double>(that.Dots);

            if(set[0].Keys[0] + eps < set[1].Keys[0]){
                last = set[0].Keys[0];
                firstPos++;
                res.AddDot(set[0].Keys[0], set[0].Values[0]);
            } else
            if(set[0].Keys[0] > set[1].Keys[0] + eps){
                last = set[1].Keys[0];
                secondPos++;
                res.AddDot(set[1].Keys[0], set[1].Values[0]);
            } else
            {
                last = set[0].Keys[0];

                if(set[0].Values[0] > set[1].Values[0] + eps){
                    firstPos++;
                    res.AddDot(set[0].Keys[0], set[0].Values[0]);
                }
                else {
                    secondPos++;
                    res.AddDot(set[1].Keys[0], set[1].Values[0]);
                }
            }

            while(firstPos < set[0].Count || secondPos < set[1].Count){
                if(firstPos == set[0].Count){
                    res.AddDot(set[1].Keys[secondPos], set[1].Values[secondPos]);
                    secondPos++;
                } else
                if(secondPos == set[1].Count){
                    res.AddDot(set[0].Keys[firstPos], set[0].Values[firstPos]);
                    firstPos++;
                }
                else {

                    double x1 = last;
                    double x2 = Math.Min(set[0].Keys[firstPos], 
                                         set[1].Keys[secondPos]);
                    double m1 = this.getMu(x2);
                    double m2 = that.getMu(x2);
                    double lastM1 = this.getMu(last);
                    double lastM2 = that.getMu(last);

                    if ((m1 > m2 + eps || Math.Abs(m1 - m2) < eps) &&
                       (lastM1 > lastM2 + eps || Math.Abs(lastM1 - lastM2) < eps))
                    {
                        res.AddDot(x2, m1);
                    } else
                    if((m2 > m1 + eps || Math.Abs(m1 - m2) < eps) && 
                       (lastM2 > lastM1 + eps || Math.Abs(lastM1 - lastM2) < eps)){
                        res.AddDot(x2, m2);
                    } else 
                    if ((lastM1 > lastM2 + eps && m1 + eps < m2) ||
                        (lastM1 + eps < lastM2 && m1 > m2 + eps))
                    {
                        double x = (x1 * (m1 - m2) + x2 * (lastM2 - lastM1)) /
                                   (m1 - lastM1 - m2 + lastM2);
                        double y = this.getMu(x);

                        res.AddDot(x, y);
                        res.AddDot(x2, Math.Max(m1, m2));
                    }

                    last = x2;
                    if (Math.Abs(x2 - set[0].Keys[firstPos]) < eps) firstPos++;
                    if (Math.Abs(x2 - set[1].Keys[secondPos]) < eps) secondPos++;

                }

            }
            return res;
        }

        public double integral(bool flag)
        {
            double res = 0.0;
            SortedList<double, double> z = new SortedList<double, double>(this.Dots);
            int N = z.Count;
            for (int i = 0; i + 1 < N; i++)
            {
                double a = z.Keys[i], b = z.Keys[i + 1];
                double middle = (a + b) / 2.0;
                double len = b - a;
                if (flag)
                {
                    //Simpson's rule
                    //I = (b - a) * (f(a) + b(b) + 4 * f((a + b) / 2)) / 6

                    double cur = this.getMu(a) + this.getMu(b) +
                                 4.0 * middle * this.getMu(middle);

                    res += cur * len / 6.0;
                }
                else
                {
                    //Rectangle method
                    //I = (b - a) * f((a + b) / 2)

                    double cur = len * middle;
                    res += cur;
                }
            }
            return res;
        }
    }
}
