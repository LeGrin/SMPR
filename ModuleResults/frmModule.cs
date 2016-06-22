using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Common;
using Common.DataTypes;

namespace Modules.Results
{
    partial class frmModule : Form
    {
        public frmModule()
        {
            InitializeComponent();
        }

        public frmModule(List<Method> methods)
            : this()
        {
        }

        private void frmModule_Load(object sender, EventArgs e)
        {
            var lastResults = ResultsStorage.GetLastResults().ToArray();
            if (lastResults.Any())
            {
                double res = lastResults.Average(tr => tr.Result);
                this.Mark100.Text = Convert.ToInt32(res).ToString() + " " + Properties.Resources.Points;
                // TODO: move this logic to TestResult class
                if (res >= 95) this.Mark5.Text = Properties.Resources.Five;
                else if (res >= 86) this.Mark5.Text = Properties.Resources.FourFive;
                else if (res >= 74) this.Mark5.Text = Properties.Resources.Four;
                else if (res >= 67) this.Mark5.Text = Properties.Resources.ThreeFour;
                else if (res >= 53) this.Mark5.Text = Properties.Resources.Three;
                else this.Mark5.Text = Properties.Resources.Two;

                double minResult = lastResults.Min(tr => tr.Result);
                TestResult worstResult = lastResults.Where(tr => tr.Result == minResult).First();
                WorstResultAdvice.Text =
                    String.Format(Properties.Resources.Vasa, 
                    worstResult.ModuleName, Convert.ToInt32(worstResult.Result));
                WorstResultAdvice.Visible = true;
            }
            else
            {
                Mark100.Text = Properties.Resources.NoData;
                Mark5.Text = Properties.Resources.NoData;
                WorstResultAdvice.Visible = false;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResultsStorage.Clear();
            frmModule_Load(this, e);
        }
    }
}