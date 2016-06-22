using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class PO : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point> E = new List<Point>();
            int i, j;
            bool good;

            // ----------------- E
            for (i = 0; i < _game.X.Count; i++)
                for (j = 0; j < _game.Y.Count; j++)
                {
                    good = true;
                    for (int ii = 0; ii < _game.X.Count; ii++)
                        for (int jj = 0; jj < _game.Y.Count; jj++)
                            if (_game[ii, jj].Dominates(_game[i, j]))
                            {
                                good = false;
                                break;
                            }
                    if (good) E.Add(new Point(i, j));
                }
            // -----------------

            return E;
        }

        public override string Name
        {
            get { return Properties.Resources.POMethodName; }
        }

        public PO()
        {

        }
    }
}
