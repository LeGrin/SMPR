using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.ModuleFuzzyLogic
{
    public partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
            this.Show();
        }

        private void buttonImageSets_Click(object sender, EventArgs e)
        {
            FuzzySetsImage form = new FuzzySetsImage();
            form.Show();

        }

        private void frmModule_Load(object sender, EventArgs e)
        {

        }
    }
}
