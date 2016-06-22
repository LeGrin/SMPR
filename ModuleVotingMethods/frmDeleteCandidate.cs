using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.VotingMethods
{
    public partial class frmDeleteCandidate : Form
    {
        frmModule fmain;
        Candidates candidates;
        DataSet dsCandidates;
        DataTable dtCandidates;
        BindingSource bsCandidates;

        List<Element> actions;

        internal frmDeleteCandidate(frmModule fmain, Candidates candidates)
        {
            InitializeComponent();

            actions = new List<Element>(new Element[2] { new Element(0, ""), new Element(1, Properties.Resources.frmDeleteCandidateStatusDelete) });

            this.fmain = fmain;
            this.candidates = candidates;

            dtCandidates = new DataTable("Candidates");
            dtCandidates.Columns.Add(new DataColumn("Candidate", typeof(Element)));

            dsCandidates = new DataSet();
            dsCandidates.Tables.Add(dtCandidates);

            bsCandidates = new BindingSource();

            RefreshCandidates();
        }

        private void RefreshCandidates()
        {          
            DataRow dr;
            dtCandidates.Clear();

            for (int i = 0; i < candidates.Count; i++)
            {
                dr = dtCandidates.NewRow();
                dr["candidate"] = candidates[i];
                dtCandidates.Rows.Add(dr);
            }

            bsCandidates.DataSource = dsCandidates;
            bsCandidates.DataMember = "Candidates";

            dataCandidates.DataSource = bsCandidates;
        }

        private void dataCandidates_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                DataGridViewCheckBoxCell cell = dataCandidates[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;

                if (cell != null)
                    dataCandidates["Status", e.RowIndex].Value = (Boolean)cell.EditedFormattedValue ? actions[1].ToString() : actions[0].ToString();
            }
            catch (Exception)
            { }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dataCandidates.SelectAll();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            DataGridViewRow currRow;
            for (int i = 0; i < dataCandidates.SelectedRows.Count; i++)
            {
                currRow = dataCandidates.SelectedRows[i];
                currRow.Cells["Check"].Value = true;
            }
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataCandidates.Rows.Count; i++)
            {
                dataCandidates["check", i].Value = false;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.frmDeleteCandidateQuestion, Properties.Resources.frmDeleteCandidateCaption, MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            List<Element> removeList = new List<Element>();
   
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates.Count <= 2)
                    return;

                if ((dataCandidates["check", i].Value != null) && (Boolean)dataCandidates["check", i].Value == true)
                    removeList.Add(candidates[i]);
            }

            for (int i = 0; i < removeList.Count; i++)
            {
                if (candidates.Count <= 2)
                    break;

                candidates.Remove(removeList[i]);
            }

            RefreshCandidates();
            fmain.RefreshCandidatesChanges();
        }

        private void frmDeleteCandidate_FormClosing(object sender, FormClosingEventArgs e)
        {
            fmain.RefreshCandidatesChanges();
        }
    }
}