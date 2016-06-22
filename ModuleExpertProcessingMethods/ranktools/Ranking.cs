using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
//using System.Windows.Forms.;

namespace Modules.ExpertProcessingMethods
{
    public class Ranking
    {
        public const int RankCellSize = 20;

        double[] marks;
        private ArrayList order;
        bool strict;

        public bool Strict
        {
            get
            {
                return strict;
            }
            set
            {
                strict = value;
                Change(order);
                if (!this.IsStrict)
                    throw new Exception("not strict");
            }
        }


        public double[] Marks
        {
            get { return (double[])marks.Clone(); }
            set { Change(marks); }
        }

        public ArrayList Order
        {
            get { return (ArrayList)order.Clone(); }
            set { Change(order); }
        }

        bool IsStrict
        {
            get { return (marks.Length ==order.Count);}
        }

        int[,] Matrix
        {
            get
            {
                int[,] A = new int[marks.Length, marks.Length];

                for (int i = 0; i < marks.Length; i++)
                    for (int j = 0; j < marks.Length; j++)
                        if (marks[i] > marks[j])
                            A[i, j] = 1;
                        else if (marks[i] < marks[j])
                            A[i, j] = -1;
                        else
                            A[i, j] = 0;

                return A;
            }
        }

        public object Clone()
        {
            Ranking temp = new Ranking(order);
            if (strict) temp.Strict = true;
            return temp;
        }


        public Ranking()
        {
            marks = new double[0];
            order = new ArrayList();
        }

        public Ranking(double[] marks)
        {
            Change(marks);
        }

        public Ranking(ArrayList order)
        {
            Change(order);
        }

        public void Change(double[] marks)
        {
            ArrayList diffValues = new ArrayList();
            this.marks = (double[])marks.Clone();
            this.order = new ArrayList();

            diffValues.Clear();
            order.Clear();

            //form list of values
            foreach (double value in marks)
            {
                if (!diffValues.Contains(value))
                    diffValues.Add(value);
            }

            diffValues.Sort();

            foreach (double uniqValue in diffValues)
            {
                ArrayList curElements = new ArrayList();
                for (int i = 0; i < marks.Length; i++)
                {
                    double mark = marks[i];
                    if (mark == uniqValue)
                        curElements.Add(i);
                }
                order.Add(curElements);
            }

            if (strict && !this.IsStrict)
                throw new Exception("not strict");
        }


        public void Change(ArrayList order)
        {
            this.order = (ArrayList)order.Clone();

            int elCount = 0;

            foreach (ArrayList curElements in order)
            {
                int elsHere = curElements.Count;
                elCount += elsHere;
            }

            marks = new double[elCount];

            //new array search, now determining the marks;
            elCount = 0;
            double thisValue;
            int deepCounter = 0;

            foreach (ArrayList curElements in order)
            {
/*                int elsHere = curElements.Count;
                thisValue = elCount + ((double)elsHere) / 2;
                elCount += elsHere;
 */
                deepCounter++; thisValue = deepCounter;
                foreach (int elId in curElements)
                {
                    marks[elId] = thisValue;
                }
            }
            Change(marks);
        }

        public int CellUnderMouse(Point mouse, Point start)
        {
            int cellx = (mouse.X-start.X) / RankCellSize;
            int celly = (mouse.Y-start.Y) / RankCellSize;
            if (celly >= 0 && celly < order.Count)
            {
                ArrayList curElements = (ArrayList)order[celly];
                if (cellx >= 0 && cellx < curElements.Count)
                {
                    return (int)curElements[cellx];
                }
            }
            //none found
            return -1;
        }


   
        public void MoveCell(int no, int mousey, Point start)
        {
            mousey -= start.Y;
            if (no < 0 || no > marks.Length)
                throw new Exception("invalid cell");
            bool done = false;
            foreach (ArrayList curElements in order)
            {
                foreach (int id in curElements)
                {
                    if (id == no)
                    {
                        curElements.Remove(no);
                        if (curElements.Count == 0)
                        {
                            order.Remove(curElements);
                        }
                        done = true;
                        break;
                    }
                }
                if (done) break;
            }
            if (!done) throw new Exception("cell should be found, but not");

            if (mousey < 0) mousey = 0;
            if (mousey > order.Count * RankCellSize + RankCellSize / 2-2)
                mousey = order.Count * RankCellSize + RankCellSize / 2-2;
            int regionno = mousey / RankCellSize;
            

            if (mousey % RankCellSize < RankCellSize / 2 || strict)
            {
                ArrayList temp = new ArrayList();
                temp.Add(no);
                order.Insert(regionno, temp);
            }
            else
            {
                ((ArrayList)order[regionno]).Add(no);
            }
            Change(order);
        }

        public int Size { get { return marks.Length; } }

        public Size VisibleDimensions()
        {
           int maxx = 0; 
           int maxy = 0;
           foreach (ArrayList curElements in order)
           {
               maxy += RankCellSize;
               int newx = curElements.Count*RankCellSize;
               if (newx > maxx) maxx = newx;
           }
           return new Size(maxx+1, maxy+1);
        }



        public void DrawTo(Graphics g, int highlighted, Point start)
        {
            int x = start.X, y = start.Y;
            StringFormat sfmt = new StringFormat();
            sfmt.Alignment = StringAlignment.Center;
            sfmt.LineAlignment = StringAlignment.Center;
            Brush brush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 10);
            Font smfont = new Font("Arial", 8);
            int i = 0;
            foreach (ArrayList curElements in order)
            {
                i++;
                x = start.X;
                foreach (int id in curElements)
                {
                    g.DrawRectangle(new Pen(Color.Black), new Rectangle(x, y, RankCellSize, RankCellSize));
                    if (id == highlighted)
                        g.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(x+1, y+1, RankCellSize-1, RankCellSize-1));
                    g.DrawString(Convert.ToString(1+id), font , brush, new RectangleF(x, y, RankCellSize, RankCellSize),
                        sfmt);
                    x += RankCellSize;
                }
                if (start.X >= Ranking.RankCellSize)
                {
                    g.DrawString(Convert.ToString(i)+")", smfont, brush, new RectangleF(0, y, RankCellSize, RankCellSize),
                        sfmt);
                }
                y += RankCellSize;
            }
        }

    };
}
