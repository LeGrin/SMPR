using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    /// <summary>
    /// Base form for all forms in module.
    /// </summary>
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Makes buttons and group boxes flat.        
        /// </summary>
        private void _setFlatStyleAndHandCursor(Control c)
        {
            Panel p = c as Panel;
            if (p != null)
            {
                p.BorderStyle = BorderStyle.FixedSingle;
            }
            GroupBox g = c as GroupBox;
            if (g != null)
            {
                g.FlatStyle = FlatStyle.Flat;
            }
            Button b = c as Button;
            if (b != null)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.Cursor = Cursors.Hand;
            }
            foreach (Control child in c.Controls)
                _setFlatStyleAndHandCursor(child);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _setFlatStyleAndHandCursor(this);
        }

        private void frmBase_Load(object sender, EventArgs e)
        {

        }
    }
}