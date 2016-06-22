using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class Di : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<int>[] Di = new List<int>[2];
            int i, j;
            bool good;

            // ----------------- Di
            Di[0] = new List<int>();
            for (i = 0; i < _game.X.Count; i++)
            {
                good = true;
                for (int ii = 0; ii < _game.X.Count; ii++)
                    if (!_game.X[i].Dominates(_game.X[ii]) && !_game.X[i].EqualTo(_game.X[ii]))
                    {
                        good = false;
                        break;
                    }
                if (good) Di[0].Add(i);
            }

            Di[1] = new List<int>();
            for (j = 0; j < _game.Y.Count; j++)
            {
                good = true;
                for (int jj = 0; jj < _game.Y.Count; jj++)
                    if (!_game.Y[j].Dominates(_game.Y[jj]) && !_game.Y[j].EqualTo(_game.Y[jj]))
                    {
                        good = false;
                        break;
                    }
                if (good) Di[1].Add(j);
            }
            // -----------------

            return Di;
        }

        public override string Name
        {
            get { return Properties.Resources.DiMethodName; }
        }

        public Di()
        {

        }
    }
}
