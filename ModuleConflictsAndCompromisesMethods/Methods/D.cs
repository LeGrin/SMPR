using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class D : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point> D = new List<Point>();
            List<int>[] Di;

            // ----------------- Di
            Di Dimethod = new Di();
            Dimethod.Init(_game);
            Di = (Dimethod.Execute() as List<int>[]);
            // -----------------

            // ----------------- D
            foreach (int x in Di[0])
                foreach (int y in Di[1])
                {
                    D.Add(new Point(x, y));
                }
            // -----------------

            return D;
        }

        public override string Name
        {
            get { return Properties.Resources.DMethodName; }
        }

        public D()
        {

        }
    }
}
