using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class WEi : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point>[] Ri  = new List<Point>[2];
            List<Point>[] WEi = new List<Point>[2];
            List<Point> tmp = new List<Point>();

            int i, j, max;

            Ri[0] = new List<Point>();
            //шукаємо множину R1 - Ri[0]

            for (j = 0; j < _game.Y.Count; j++)
            {
                max = -10000;

                for (i = 0; i < _game.X.Count; i++)
                {
                    if (_game[i, j][0] > max)
                    {
                        max = _game[i, j][0];
                        tmp.Clear();
                    }

                    if (_game[i, j][0] == max)
                    {
                        tmp.Add(new Point(i, j));
                    }
                }
                Ri[0].AddRange(tmp);
            }

            Ri[1] = new List<Point>();
            //шукаємо множину R2 - Ri[1]

            for (i = 0; i < _game.X.Count; i++)
            {
                max = -10000;

                for (j = 0; j < _game.Y.Count; j++)
                {
                    if (_game[i, j][1] > max)
                    {
                        max = _game[i, j][1];
                        tmp.Clear();
                    }

                    if (_game[i, j][1] == max)
                    {
                        tmp.Add(new Point(i, j));
                    }
                }
                Ri[1].AddRange(tmp);
            }

            // Будуємо по множині R2 (Ri[1]) множину WE1 (WEi[0])

            WEi[0] = new List<Point>();

            max = -10000;
            for (i = 0; i < Ri[1].Count; i++)
            {
                if (_game[Ri[1][i]][0] > max)
                {
                    max = _game[Ri[1][i]][0];
                    WEi[0].Clear();
                }

                if (_game[Ri[1][i]][0] == max)
                {
                    WEi[0].Add(Ri[1][i]);
                }
            }

            // Будуємо по множині R1 (Ri[0]) множину WE2 (WEi[1])

            WEi[1] = new List<Point>();

            max = -10000;
            for (i = 0; i < Ri[0].Count; i++)
            {
                if (_game[Ri[0][i]][1] > max)
                {
                    max = _game[Ri[0][i]][1];
                    WEi[1].Clear();
                }

                if (_game[Ri[0][i]][1] == max)
                {
                    WEi[1].Add(Ri[0][i]);
                }
            }
            
            return WEi;
        }

        public override string Name
        {
            get { return Properties.Resources.WEiMethodName; }
        }

        public WEi()
        {

        }


    }
}
