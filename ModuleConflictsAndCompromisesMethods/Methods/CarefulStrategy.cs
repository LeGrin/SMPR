using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class CarefulStrategy : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<int>[] Pi = new List<int>[2];
            int i, j, min, max;

            // ----------------- Pi
            Pi[0] = new List<int>();
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
                    Pi[0].Clear();
                    max = min;
                }
                if (min == max)
                    Pi[0].Add(i);
            }

            Pi[1] = new List<int>();
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
                    Pi[1].Clear();
                    max = min;
                }
                if (min == max)
                    Pi[1].Add(j);
            }
            // -----------------
            return Pi;
        }

        public override string Name
        {
            get { return Properties.Resources.CarefulStrategyMethodName; }
        }

        public CarefulStrategy()
        {

        }
    }
}
