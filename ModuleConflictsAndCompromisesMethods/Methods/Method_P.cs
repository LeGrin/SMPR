using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Modules.ConflictsAndCompromises.Methods
{
    public class Method_P : Method
    {
        CCGame _game;

        public override void Init(CCGame game)
        {
            this._game = game;
        }

        public override object Execute()
        {
            List<Point> JR, E, P = new List<Point>();

            // ----------------- E
            PO Emethod = new PO();
            Emethod.Init(_game);
            E = (Emethod.Execute() as List<Point>);
            // -----------------


            // ----------------- JR
            JR JRmethod = new JR();
            JRmethod.Init(_game);
            JR = (JRmethod.Execute() as List<Point>);
            // -----------------


            // ----------------- P
            foreach (Point pt in JR)
            {
                if (E.Contains(pt))
                    P.Add(pt);
            }
            // -----------------

            return P;
        }

        public override string Name
        {
            get { return Properties.Resources.PMethodName; }
        }

        public Method_P()
        {

        }
    }
}
