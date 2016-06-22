using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class NDi : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<int>[] NDi = new List<int>[2];
            int i, j;
            bool good;

            // ----------------- NDi
            NDi[0] = new List<int>();
            for (i = 0; i < _game.X.Count; i++)
            {
                good = true;
                for (int ii = 0; ii < _game.X.Count; ii++)
                    if (_game.X[ii].Dominates(_game.X[i]))
                    {
                        good = false;
                        break;
                    }
                if (good) NDi[0].Add(i);
            }

            NDi[1] = new List<int>();
            for (j = 0; j < _game.Y.Count; j++)
            {
                good = true;
                for (int jj = 0; jj < _game.Y.Count; jj++)
                    if (_game.Y[jj].Dominates(_game.Y[j]))
                    {
                        good = false;
                        break;
                    }
                if (good) NDi[1].Add(j);
            }
            // -----------------

            return NDi;
        }

        public override string Name
        {
            get { return Properties.Resources.NDiMethodName; }
        }

        public NDi()
        {

        }
    }
}
