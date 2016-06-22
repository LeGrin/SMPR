using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class JR : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            int[] alpha = new int[2];
            List<Point> JR = new List<Point>();
            int i, j, min, max;

            // ----------------- alpha
            max = -10000;
            for (i = 0; i < _game.X.Count; i++)
            {
                min = _game[i, 0][0];

                for (j = 1; j < _game.Y.Count; j++)
                {
                    if (_game[i, j][0] < min) min = _game[i, j][0];
                }

                if (min > max)
                {
                    max = min;
                }
            }
            alpha[0] = max;

            max = -10000;
            for (j = 0; j < _game.Y.Count; j++)
            {
                min = _game[0, j][1];

                for (i = 1; i < _game.X.Count; i++)
                {
                    if (_game[i, j][1] < min) min = _game[i, j][1];
                }

                if (min > max)
                {
                    max = min;
                }
            }
            alpha[1] = max;
            // -----------------


            // ----------------- JR
            for (i = 0; i < _game.X.Count; i++)
                for (j = 0; j < _game.Y.Count; j++)
                {
                    if ((_game[i, j][0] >= alpha[0]) && (_game[i, j][1] >= alpha[1]))
                        JR.Add(new Point(i, j));
                }
            // -----------------
            
            return JR;
        }

        public override string Name
        {
            get { return Properties.Resources.JRMethodName; }
        }

        public JR()
        {

        }
    }
}
