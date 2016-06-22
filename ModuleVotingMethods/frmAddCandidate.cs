using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.VotingMethods
{
    public partial class frmAddCandidate : Form
    {
        Candidates candidates;
        frmModule fmain;

        internal frmAddCandidate(frmModule fmain, Candidates candidates)
        {
            InitializeComponent();

            this.fmain = fmain;
            this.candidates = candidates;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.ForeColor = candidates.Contains(txtName.Text.Trim()) ? Color.Red : Color.Green;
        }

        private void btnAddCandidate_Click(object sender, EventArgs e)
        {
            if (candidates.Contains(txtName.Text.Trim()) == false)
            {
                candidates.AddCandidate(txtName.Text.Trim());
                fmain.RefreshCandidatesChanges();
            }
            else MessageBox.Show(Properties.Resources.frmAddCandidateException, Properties.Resources.frmAddCandidateCaption);
        }

        private void frmAddCandidate_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.RefreshCandidatesChanges();
        }
    }
}