using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.View.Controls
{
    public partial class ctrlThereIsNoData : UserControl
    {
        private const double FontSizeKoef = 22.5d;
        private Control _coverderControl;

        public ctrlThereIsNoData ( )
        {
            InitializeComponent ( );
        }

        public void Init ( string text )
        {
            label1.Text = text;
        }

        public void Init ( string text, Control ctrlToCover )
        {
            Init ( text );
            Cover ( ctrlToCover );
        }

        public void Cover ( Control ctrlToCover )
        {
            if ( ctrlToCover == null ) throw new ArgumentNullException ( "ctrlToCover" );
            _coverderControl = ctrlToCover;

            ctrlToCover.Visible = false;
            Visible = true;

            Anchor = ctrlToCover.Anchor;
            Size = ctrlToCover.Size;
            Location = ctrlToCover.Location;

            if ( ctrlToCover.Parent != null )
            {
                Parent = ctrlToCover.Parent;
                Parent.Controls.Add ( this );
                Parent.Controls.Remove ( ctrlToCover );
            }
        }

        public void DeInit ( )
        {
            if ( Parent != null )
            {
                Parent.Controls.Add ( _coverderControl );
                Parent.Controls.Remove ( this );
                Parent = null;
            }
        }

        private void ctrlThereIsNoData_SizeChanged ( object sender, EventArgs e )
        {
            label1.Left = Width / 2 - label1.Width / 2;
            label1.Top = Height / 2 - label1.Height / 2;
        }
    }
}