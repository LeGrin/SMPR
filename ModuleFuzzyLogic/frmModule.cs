using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using ModuleFuzzyLogic;

namespace Modules.ModuleFuzzyLogic
{
    public partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fuzzyPreferenceRelations form = new fuzzyPreferenceRelations();
            form.Show();
        }
    }
}
