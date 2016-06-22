using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    class Method_XNT1 : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            CCGame current;
            NDi NDi = new NDi();
            int finish = 0;
            int player = 0;

            current = new CCGame();
            current.Init(_game.ToArray());

            while (finish < 3)
            {
                finish++;

                NDi.Init(current);
                List<int>[] r = NDi.Execute() as List<int>[];

                if (((player == 0) && (r[player].Count < current.X.Count)) ||
                    ((player == 1) && (r[player].Count < current.Y.Count)))
                {
                    current = MiniGame(current, r[player], player);
                    finish = 0;
                }

                player = 1 - player;
            }

            List<Point> XNT = new List<Point>();
            
            foreach (Strategy x in current.X)
                foreach (Strategy y in current.Y)
                {
                    XNT.Add(new Point(_game.X.IndexOf(x.Name), _game.Y.IndexOf(y.Name)));
                }

            return XNT;
        }

        protected CCGame MiniGame(CCGame game, List<int> goodStrategies, int player)
        {
            int i, j;
            CCGame g = new CCGame();

            g.Init();

            if (player == 0)
            {
                for (i = 0; i < goodStrategies.Count; i++) g.X.Add(game.X[goodStrategies[i]].Name);
                for (j = 0; j < game.Y.Count; j++) g.Y.Add(game.Y[j].Name);
            }
            if (player == 1)
            {
                for (i = 0; i < game.X.Count; i++) g.X.Add(game.X[i].Name);
                for (j = 0; j < goodStrategies.Count; j++) g.Y.Add(game.Y[goodStrategies[j]].Name);
            }

            for (i = 0; i < g.X.Count; i++)
                for (j = 0; j < g.Y.Count; j++)
                {
                    g.U1[g.X[i].Name][g.Y[j].Name] = game.U1[g.X[i].Name][g.Y[j].Name];
                    g.U2[g.Y[j].Name][g.X[i].Name] = game.U2[g.Y[j].Name][g.X[i].Name];
                }

            return g;
        }

        public override string Name
        {
            get { return Properties.Resources.XNT1MethodName; }
        }

        public Method_XNT1()
        {

        }

    }
}
