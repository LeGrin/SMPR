using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common.DataTypes
{
    [Serializable]
    public struct ParsablePointD
    {
        private double _x;
        private double _y;
        /// <summary>
        /// X data
        /// </summary>
        public double X
        { get { return _x; } set { _x = value; } }

        /// <summary>
        /// Y data
        /// </summary>
        public double Y
        { get { return _y; } set { _y = value; } }

        #region ctor`s
       
        public ParsablePointD(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public ParsablePointD(Point p)
        {
            _x = p.X;
            _y = p.Y;
        }
        public ParsablePointD(PointF p)
        {
            _x = p.X;
            _y = p.Y;
        }
        public ParsablePointD(int x, int y)
        {
            _x = x;
            _y = y;
        }
        #endregion
        #region Casts
        public static explicit operator Point (ParsablePointD pointD)
        {
            Point p = new Point();

            p.X = (int)pointD.X;
            p.Y = (int)pointD.Y;
            return p;
        }
        public static explicit operator PointF(ParsablePointD pointD)
        {
            PointF p = new PointF();
            
            p.X = (float)pointD.X;
            p.Y = (float)pointD.Y;
            return p;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("({0};{1})", _x, _y);
        }
        public static ParsablePointD Parse(string s)
        {
            s = s.Trim().Replace(" ", "");
            if (s[0] == '(') s = s.Remove(0, 1);
            if (s[s.Length - 1] == ')') s = s.Remove(s.Length - 1);

            char[] commaChars = new char[] { ';', ':' };
            int commaIndex = s.IndexOfAny(commaChars);

            if (commaIndex == -1)
            {

                try
                {
                    double first = double.Parse(s);
                    ParsablePointD point = new ParsablePointD(first, 0);
                    return point;
                }
                catch (FormatException ex)
                {
                    throw new FormatException("Couldn`t parse this", ex);
                }   
            }

            try
            {
                double first = double.Parse(s.Substring(0, commaIndex));
                double second = double.Parse(s.Substring(commaIndex + 1));
                ParsablePointD point = new ParsablePointD(first, second);
                return point;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Couldn`t parse this", ex);
            }
            
            

        }
    }
}
