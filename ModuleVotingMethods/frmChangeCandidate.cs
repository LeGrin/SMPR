using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.VotingMethods
{
    public partial class frmChangeCandidate : Form
    {
        Candidates candidates;
        List<Element> lstCandidates;
        BindingSource bsCandidates;

        frmModule fmain;

        internal frmChangeCandidate(frmModule fmain, Candidates candidates)
        {
            InitializeComponent();

            lstCandidates = new List<Element>();
            bsCandidates = new BindingSource();

            this.fmain = fmain;
            this.candidates = candidates;

            RefreshCandidates();
        }

        private void RefreshCandidates()
        {
            lstCandidates.Clear();

            lstCandidates.AddRange(candidates.DataSource);

            bsCandidates.DataSource = lstCandidates;

            CandidatesList.DataSource = null;
            CandidatesList.Items.Clear();

            CandidatesList.DataSource = bsCandidates;
            fmain.RefreshCandidatesChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (candidates.Contains(bsCandidates.Position, txtNew.Text) == false)
            {
                candidates[bsCandidates.Position].Text = txtNew.Text;

                RefreshCandidates();
            }
            else
                MessageBox.Show(Properties.Resources.frmAddCandidateException, Properties.Resources.frmChangeCandidateCaption);
        }

        private void CandidatesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOld.Text = bsCandidates.Current.ToString();
            txtNew.Text = txtOld.Text;
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            txtNew.ForeColor = candidates.Contains(bsCandidates.Position, txtNew.Text.Trim()) ? Color.Red : Color.Green;
        }
    }
}