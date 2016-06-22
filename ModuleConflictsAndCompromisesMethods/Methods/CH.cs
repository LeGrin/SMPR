using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class CH : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point> E, CH = new List<Point>(), H;

            // ----------------- E
            PO Emethod = new PO();
            Emethod.Init(_game);
            E = (Emethod.Execute() as List<Point>);
            // -----------------


            // ----------------- H
            NE Hmethod = new NE();
            Hmethod.Init(_game);
            H = (Hmethod.Execute() as List<Point>);
            // -----------------


            // ----------------- CH
            foreach (Point pt in H)
            {
                if (E.Contains(pt))
                    CH.Add(pt);
            }
            // -----------------

            return CH;
        }

        public override string Name
        {
            get { return Properties.Resources.CHMethodName; }
        }

        public CH()
        {

        }
    }
}
