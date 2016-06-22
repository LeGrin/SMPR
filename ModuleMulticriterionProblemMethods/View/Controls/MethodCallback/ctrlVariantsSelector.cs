using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.Inerfaces;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    public partial class ctrlVariantsSelector : ctrlMethodCallbackBase
    {
        private const int DefaultXocation = 2;
        private const int DefaultInterval = 4;
        private const int StartYLocation = 12;

        public ctrlVariantsSelector ( )
        {
            InitializeComponent ( );
        }

        public void Init ( Dictionary<string, object> parameters )
        {
            gbControls.Controls.Clear ( );

            int yLocation = StartYLocation + DefaultInterval;
            foreach ( KeyValuePair<string, object> pair in parameters )
            {
                RadioButton b = new RadioButton ( );
                b.Location = new Point ( DefaultXocation, yLocation );
                b.Text = pair.Key;
                b.Tag = pair.Value;

                gbControls.Controls.Add ( b );
                yLocation += DefaultInterval + b.Height;
            }
            if ( gbControls.Controls.Count == 0 )
                throw new ArgumentException ( "variants cannot be empty", "variants" );
            ( gbControls.Controls[ 0 ] as RadioButton ).Checked = true;
        }

        public override object Value
        {
            get
            {
                foreach ( Control c in gbControls.Controls )
                    if ( ( c as RadioButton ).Checked ) return c.Tag;

                throw new Exception ( "Значення не вибрано!!!" );
            }
        }
    }
}