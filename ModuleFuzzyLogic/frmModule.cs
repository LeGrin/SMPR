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
       
        private void button3_Click(object sender, EventArgs e)
        {
            new frmBinOperations().Show();  
        }

        private void binRelationsPropButton_Click(object sender, EventArgs e)
        {
            BinRelationsPropForm binRealtionsPropForm = new BinRelationsPropForm();
            binRealtionsPropForm.Show();
        }
        private void buttonOperOnRelation_Click(object sender, EventArgs e)
        {
            frmOperOnRelation opOnRel = new frmOperOnRelation();
            opOnRel.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fuzzyPreferenceRelations form = new fuzzyPreferenceRelations();
            form.Show();
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
