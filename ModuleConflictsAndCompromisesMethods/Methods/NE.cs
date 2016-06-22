using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class NE : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point> H = new List<Point>();
            int i, j, max;

            // ----------------- H
            List<Point> p1 = new List<Point>(), p2 = new List<Point>(), tmp = new List<Point>();

            for (i = 0; i < _game.X.Count; i++)
            {
                max = -10000;
                for (j = 0; j < _game.Y.Count; j++)
                {
                    if (_game[i, j][1] > max)
                    {
                        tmp.Clear();
                        max = _game[i, j][1];
                    }
                    if (_game[i, j][1] == max)
                        tmp.Add(new Point(i, j));
                }
                p2.AddRange(tmp);
            }

            for (j = 0; j < _game.Y.Count; j++)
            {
                max = -10000;
                for (i = 0; i < _game.X.Count; i++)
                {
                    if (_game[i, j][0] > max)
                    {
                        tmp.Clear();
                        max = _game[i, j][0];
                    }
                    if (_game[i, j][0] == max)
                        tmp.Add(new Point(i, j));
                }
                p1.AddRange(tmp);
            }

            foreach (Point pt in p1)
            {
                if (p2.Contains(pt))
                    H.Add(pt);
            }
            // -----------------

            return H;
        }

        public override string Name
        {
            get { return Properties.Resources.NEMethodName; }
        }

        public NE()
        {

        }
    }
}
