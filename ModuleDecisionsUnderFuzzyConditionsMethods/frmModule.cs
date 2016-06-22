using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormulaParser;
using FuzzySetFParser;
using FuzzySets;
using Common.DataTypes;

namespace Modules.DecisionsUnderFuzzyConditionsMethods
{
    public partial class frmModule : Form
    {
        List<FuzzySet> sets;
        public frmModule()
        {
            InitializeComponent();
            #region Dgw & List
            sets = new List<FuzzySet>();
            dgwSets.DataSource = null;
            dgwSets.Columns.Clear();
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.ValueType = typeof(string);
                col.Name = "Name";
                col.HeaderText = Properties.Resources.Name;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.ReadOnly = false;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgwSets.Columns.Add(col);
            }
            {
                DataGridViewColumn col = new DataGridViewTextBoxColumn();
                col.ValueType = typeof(string);
                col.Name = "Dimension";
                col.HeaderText = Properties.Resources.Dimension;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.ReadOnly = true;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgwSets.Columns.Add(col);
            }
            #endregion
#if DEBUG
            {
                FuzzySet1D fs = new FuzzySet1D();
                fs.Name = "A";
                fs.AddDot(1.0, 1.0);
                fs.AddDot(2.0, 0.3);
                fs.AddDot(2.5, 0.4);
                fs.AddDot(3.0, 0.7);
                sets.Add(fs);
            }
            {
                FuzzySet1D fs = new FuzzySet1D();
                fs.Name = "B";
                fs.AddDot(1.0, 0.2);
                fs.AddDot(3.0, 0.1);
                fs.AddDot(4.0, 0.3);
                fs.AddDot(5.0, 0.4);
                sets.Add(fs);
            }
            {
                FuzzySet1D fs = new FuzzySet1D();
                fs.Name = "C";
                fs.AddDot(1.0, 0.1);
                fs.AddDot(3.0, 0.1);
                fs.AddDot(4.0, 0.1);
                fs.AddDot(5.0, 0.1);
                sets.Add(fs);
            }
            {
                FuzzySet1D fs = new FuzzySet1D();
                fs.Name = "D";
                fs.AddDot(1.0, 0.5);
                fs.AddDot(3.0, 0.5);
                fs.AddDot(4.0, 0.5);
                fs.AddDot(5.0, 0.5);
                sets.Add(fs);
            }
            {
                FuzzySet2D fs = new FuzzySet2D();
                fs.Name = "E";
                fs.AddDot(1.0,1.0, 0.5);
                fs.AddDot(3.0,3.0, 0.5);
                fs.AddDot(4.0,4.0, 0.5);
                fs.AddDot(5.0,5.0, 0.5);
                sets.Add(fs);
            }
            {
                FuzzySet2D fs = new FuzzySet2D();
                fs.Name = "F";
                fs.AddDot(1.0, 0.3, 0.3);
                fs.AddDot(3.0, 1.7, 0.1);
                fs.AddDot(4.0, 3.6, 0.3);
                fs.AddDot(5.0, 8.0, 0.7);
                sets.Add(fs);
            }
#endif
            UpdateListToDgw();
        }
        void UpdateListToDgw()
        {
            
            dgwSets.Rows.Clear();
            foreach (FuzzySet fs in sets)
            {
                DataGridViewRow row = new DataGridViewRow();
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.ValueType = typeof(string);
                    row.Cells.Add(cell);
                    cell.ReadOnly = false;
                }
                {
                    DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                    cell.ValueType = typeof(string);
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    row.Cells.Add(cell);
                    cell.ReadOnly = true;
                }
                if (fs.Name == "" || fs.Name == null) fs.Name = "unnamed";
                row.Cells[0].Value = fs.Name;
                row.Cells[1].Value = (fs is FuzzySet1D) ? "1D" : "2D";
                row.Cells[1].Style.BackColor = (fs.Discrete) ? Color.Red : Color.Blue;
                row.Tag = fs;
                dgwSets.Rows.Add(row);
            }
        }

        private void dgwSets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgwSets.Rows[e.RowIndex].Tag == null) return;
            FuzzySet set = (dgwSets.Rows[e.RowIndex].Tag as FuzzySet);
            tcDisplay.SelectedIndex = 0;
            tcDisplay.Tag = set;
            dgwItems.Tag = set;
            //if (set.Discrete)
            tsGridEdit.Visible = set.Discrete;
            set.ToMatrix(dgwItems);
            pGraph.Tag = set.Render(pGraph.Size);
            pGraph.Invalidate();
            if (set is FuzzySet1D)
            {
                pFormula.Visible = false;
                tbMuX.Visible = true;
                tbDotX3.Visible = false;
                lblComa2.Visible = false;
            }
            else
            {
                pFormula.Visible = true;
                tbMuX.Visible = false;
                tbDotX3.Visible = true;
                lblComa2.Visible = true;
            }
        }

        private void tcDisplay_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void pGraph_Paint(object sender, PaintEventArgs e)
        {
            if (pGraph.Tag != null && pGraph.Tag is Bitmap)
            {
                Graphics gr = pGraph.CreateGraphics();
                gr.DrawImage(pGraph.Tag as Bitmap, new Point(0, 0));
            }
        }

        private void Ó·∫‰‡ÌÌˇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count == 0) return;
            if (dgwSets.SelectedRows.Count == 1)
                sets.Add(new FuzzySet1D(dgwSets.SelectedRows[0].Tag as FuzzySet1D));

            else
            {
                for (int i = 1; i < dgwSets.SelectedRows.Count; i++)
                    if ((dgwSets.SelectedRows[i].Tag as FuzzySet).Discrete != (dgwSets.SelectedRows[0].Tag as FuzzySet).Discrete)
                        return;
                for (int i = 1; i < dgwSets.SelectedRows.Count; i++)
                    if (((dgwSets.SelectedRows[i].Tag is FuzzySet1D)&&(dgwSets.SelectedRows[0].Tag is FuzzySet2D))
                        ||((dgwSets.SelectedRows[i].Tag is FuzzySet2D)&&(dgwSets.SelectedRows[0].Tag is FuzzySet1D)))
                        return;
                if (dgwSets.SelectedRows[0].Tag is FuzzySet1D)
                {
                    FuzzySet1D set = (dgwSets.SelectedRows[0].Tag as FuzzySet1D) | (dgwSets.SelectedRows[1].Tag as FuzzySet1D);
                    for (int i = 2; i < dgwSets.SelectedRows.Count; i++)
                        set = set | (dgwSets.SelectedRows[i].Tag as FuzzySet1D);
                    sets.Add(set);
                }
                if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
                {
                    FuzzySet2D set = (dgwSets.SelectedRows[0].Tag as FuzzySet2D) | (dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                    for (int i = 2; i < dgwSets.SelectedRows.Count; i++)
                        set = set | (dgwSets.SelectedRows[i].Tag as FuzzySet2D);
                    sets.Add(set);
                }
            }
            UpdateListToDgw();
        }

        private void ÔÂÂÚËÌToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count == 0) return;
            if (dgwSets.SelectedRows.Count == 1)
                sets.Add(new FuzzySet1D(dgwSets.SelectedRows[0].Tag as FuzzySet1D));

            else
            {
                for (int i = 1; i < dgwSets.SelectedRows.Count; i++)
                    if ((dgwSets.SelectedRows[i].Tag as FuzzySet).Discrete != (dgwSets.SelectedRows[0].Tag as FuzzySet).Discrete)
                        return;
                for (int i = 1; i < dgwSets.SelectedRows.Count; i++)
                    if (((dgwSets.SelectedRows[i].Tag is FuzzySet1D) && (dgwSets.SelectedRows[0].Tag is FuzzySet2D))
                        || ((dgwSets.SelectedRows[i].Tag is FuzzySet2D) && (dgwSets.SelectedRows[0].Tag is FuzzySet1D)))
                        return;
                if (dgwSets.SelectedRows[0].Tag is FuzzySet1D)
                {
                    FuzzySet1D set = (dgwSets.SelectedRows[0].Tag as FuzzySet1D) & (dgwSets.SelectedRows[1].Tag as FuzzySet1D);
                    for (int i = 2; i < dgwSets.SelectedRows.Count; i++)
                        set = set & (dgwSets.SelectedRows[i].Tag as FuzzySet1D);
                    sets.Add(set);
                }
                if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
                {
                    FuzzySet2D set = (dgwSets.SelectedRows[0].Tag as FuzzySet2D) & (dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                    for (int i = 2; i < dgwSets.SelectedRows.Count; i++)
                        set = set & (dgwSets.SelectedRows[i].Tag as FuzzySet2D);
                    sets.Add(set);
                }
            }
            UpdateListToDgw();
        }

        private void fourthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 2) return;
            if ((dgwSets.SelectedRows[0].Tag as FuzzySet).Discrete != (dgwSets.SelectedRows[1].Tag as FuzzySet).Discrete) return;
            if (dgwSets.SelectedRows[0].Tag.GetType() != dgwSets.SelectedRows[1].Tag.GetType()) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet1D)
            {
                FuzzySet1D set = (dgwSets.SelectedRows[0].Tag as FuzzySet1D) / (dgwSets.SelectedRows[1].Tag as FuzzySet1D);
                sets.Add(set);
            }
            if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
            {
                FuzzySet2D set = (dgwSets.SelectedRows[0].Tag as FuzzySet2D) / (dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                sets.Add(set);
            }
            UpdateListToDgw();
        }

        private void ‚Ë‰‡ÎËÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count == 0) return;
            if (MessageBox.Show("¬Ë‰‡ÎËÚË Ó·‡Ì≥ ÏÌÓÊËÌË?", "¬Ë‰‡ÎÂÌÌˇ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                foreach (DataGridViewRow row in dgwSets.SelectedRows)
                    sets.Remove(row.Tag as FuzzySet);
            UpdateListToDgw();
        }

        private void ‰Ó‰ÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ‰ËÒÍÂÚÌ‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuzzySet1D fs = new FuzzySet1D();
            fs.Discrete = true;
            sets.Add(fs);
            UpdateListToDgw();
        }

        private void ÌÂÔÂÂ‚Ì‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuzzySet1D fs = new FuzzySet1D();
            fs.Discrete = false;
            sets.Add(fs);
            UpdateListToDgw();
        }

        private void ‰ËÒÍÂÚÌ‡ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuzzySet2D fs = new FuzzySet2D();
            fs.Discrete = true;
            sets.Add(fs);
            UpdateListToDgw();
        }

        private void ÌÂÔÂÂ‚Ì‡ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FuzzySet2D fs = new FuzzySet2D();
            fs.Discrete = false;
            sets.Add(fs);
            UpdateListToDgw();
        }

        private void dgwSets_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgwSets.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    dgwSets.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "unnamed";
                (dgwSets.Rows[e.RowIndex].Tag as FuzzySet).Name = dgwSets.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void tsmiCont_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgwSets.SelectedRows)
                if ((row.Tag as FuzzySet).Discrete) (row.Tag as FuzzySet).Discrete = false;
            UpdateListToDgw();
        }

        private void btnAddDot_Click(object sender, EventArgs e)
        {
            if (!(dgwItems.Tag as FuzzySet).Discrete) return;
            if (dgwItems.Tag is FuzzySet1D)
            {
                FuzzySet1D set = dgwItems.Tag as FuzzySet1D;
                try
                {
                    double x = double.Parse(tbDotX1.Text);
                    double y = double.Parse(tbDotX2.Text);
                    set.AddDot(x, y);
                }
                catch { return; }
                set.ToMatrix(dgwItems);
                pGraph.Tag = set.Render(pGraph.Size);
                pGraph.Invalidate();
            }
            if (dgwItems.Tag is FuzzySet2D)
            {
                FuzzySet2D set = dgwItems.Tag as FuzzySet2D;
                try
                {
                    double x = double.Parse(tbDotX1.Text);
                    double y = double.Parse(tbDotX2.Text);
                    double z = double.Parse(tbDotX3.Text);
                    set.RemoveDot(x, y);
                    set.AddDot(x, y, z);
                }
                catch { return; }
                set.ToMatrix(dgwItems);
                pGraph.Tag = set.Render(pGraph.Size);
                pGraph.Invalidate();
            }
        }

        private void tbDotDel_Click(object sender, EventArgs e)
        {
            if (!(dgwItems.Tag as FuzzySet).Discrete) return;
            if (dgwItems.Tag is FuzzySet1D)
            {
                FuzzySet1D set = dgwItems.Tag as FuzzySet1D;
                foreach (DataGridViewRow row in dgwItems.SelectedRows)
                    set.RemoveDot(double.Parse(row.Cells[0].Value.ToString()));
                set.ToMatrix(dgwItems);
                pGraph.Tag = set.Render(pGraph.Size);
                pGraph.Invalidate();
            }
            if (dgwItems.Tag is FuzzySet2D)
            {
                FuzzySet2D set = dgwItems.Tag as FuzzySet2D;
                foreach (DataGridViewCell cell in dgwItems.SelectedCells)
                    if (dgwItems.Columns[cell.ColumnIndex].Tag != null && dgwItems.Rows[cell.RowIndex].Tag != null)
                        set.RemoveDot((double)dgwItems.Columns[cell.ColumnIndex].Tag, (double)dgwItems.Rows[cell.RowIndex].Tag);
                set.ToMatrix(dgwItems);
                pGraph.Tag = set.Render(pGraph.Size);
                pGraph.Invalidate();
            }
        }

        private void btnDFormula_Click(object sender, EventArgs e)
        {
            if (dgwItems.Tag == null) return;
            if (dgwItems.Tag is FuzzySet1D)
            {
                FuzzySet1D set = dgwItems.Tag as FuzzySet1D;
                double x = 0.0;
                try
                {
                    x = double.Parse(tbMuX.Text);
                }
                catch
                {
                    tbMuX.Text = "";
                    return;
                }
                tbMuRes.Text = set.Mu(x).ToString();
            }
            else
            {
                FuzzySet2D set = dgwItems.Tag as FuzzySet2D;
                double x = 0.0;
                double y = 0.0;
                try
                {
                    x = double.Parse(tbMuX1.Text);
                    y = double.Parse(tbMuX2.Text);
                }
                catch
                {
                    tbMuX1.Text = "";
                    tbMuX2.Text = "";
                    return;
                }
                tbMuRes.Text = set.Mu(x,y).ToString();
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            {
                FuzzySet1D fs = new FuzzySet1D();
                fs.Discrete = false;

                FParser parser = new FParser();
                for (int i = 0; i < FuzzySet.maxDotCount; i++)
                {
                    double x = 1.0 * i * (FuzzySet.toX - FuzzySet.fromX) / FuzzySet.maxDotCount+FuzzySet.fromX;
                    parser.Eval(tbFormula.Text, x);
                    if (!parser.SyntaxCorrect){
                        MessageBox.Show(parser.ErrText, "—ËÌÚ‡ÍÒË˜Ì‡ ÔÓÏËÎÍ‡", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    fs.AddDot(x, parser.Result());
                }
                for (int i = 0; i < tbFormula.Text.Length; i++)
                    if (Char.IsLetterOrDigit(tbFormula.Text[i]))
                        fs.Name += tbFormula.Text[i];
                sets.Add(fs);
            }
            UpdateListToDgw();
        }

        private void twentysevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm frm = new OptionsForm();
            OptionsForm.FromX = FuzzySet.fromX;
            OptionsForm.ToX = FuzzySet.toX;
            OptionsForm.XStep = FuzzySet.xGridStep;
            OptionsForm.YStep = FuzzySet.yGridStep;
            OptionsForm.Approx = FuzzySet.maxDotCount;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                FuzzySet.fromX=OptionsForm.FromX;
                FuzzySet.toX=OptionsForm.ToX;
                FuzzySet.xGridStep=OptionsForm.XStep;
                FuzzySet.yGridStep=OptionsForm.YStep;
                FuzzySet.maxDotCount=OptionsForm.Approx;
                sets.Clear();
                UpdateListToDgw();
            }
        }

        private void pGraph_Resize(object sender, EventArgs e)
        {
            if (!(dgwItems.Tag is FuzzySet)) return;
            pGraph.Tag = (dgwItems.Tag as FuzzySet).Render(pGraph.Size);
            pGraph.Invalidate();
        }

        private void sixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 2) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet1D || dgwSets.SelectedRows[1].Tag is FuzzySet1D) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
            {
                FuzzySet2D set =FuzzySet2D.MaxMinCompose(dgwSets.SelectedRows[0].Tag as FuzzySet2D,dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                sets.Add(set);
            }
            UpdateListToDgw();
        }

        private void sevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 2) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet1D || dgwSets.SelectedRows[1].Tag is FuzzySet1D) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
            {
                FuzzySet2D set = FuzzySet2D.MinMaxCompose(dgwSets.SelectedRows[0].Tag as FuzzySet2D, dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                sets.Add(set);
            }
            UpdateListToDgw();
        }

        private void Ï‡ÍÒËÏÛÎ¸ÚËÔÎËÍ‡ÚË‚Ì‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 2) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet1D || dgwSets.SelectedRows[1].Tag is FuzzySet1D) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet2D)
            {
                FuzzySet2D set = FuzzySet2D.MaxMultCompose(dgwSets.SelectedRows[0].Tag as FuzzySet2D, dgwSets.SelectedRows[1].Tag as FuzzySet2D);
                sets.Add(set);
            }
            UpdateListToDgw();
        }

        private void twentyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgwSets.SelectedRows)
                if (row.Tag is FuzzySet1D) sets.Add(new FuzzySet1D(row.Tag as FuzzySet1D));
            else if (row.Tag is FuzzySet2D) sets.Add(new FuzzySet2D(row.Tag as FuzzySet2D));
            UpdateListToDgw();
        }

        private void dgwItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwItems.Tag == null) return;
            if (dgwItems.Tag is FuzzySet1D)
            {
                tbDotX1.Text = dgwItems.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbDotX2.Text = dgwItems.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            if (dgwItems.Tag is FuzzySet2D)
            {
                tbDotX2.Text = dgwItems.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbDotX1.Text = dgwItems.Columns[e.ColumnIndex].Name;
                tbDotX3.Text = dgwItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void nineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 2) return;
            if (!(dgwSets.SelectedRows[0].Tag is FuzzySet1D) || !(dgwSets.SelectedRows[1].Tag is FuzzySet1D)) return;
            if (!(dgwSets.SelectedRows[0].Tag as FuzzySet1D).Discrete || !(dgwSets.SelectedRows[1].Tag as FuzzySet1D).Discrete) return;
            FuzzySet2D res=(dgwSets.SelectedRows[0].Tag as FuzzySet1D) *(dgwSets.SelectedRows[1].Tag as FuzzySet1D);
            sets.Add(res);
            UpdateListToDgw();
        }

        private void seventeenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuzzySet1D res=StandartSetForm.GetSet(StandartSet.NormalDistribution);
            if (res != null)
            {
             sets.Add(res);
             UpdateListToDgw();
            }
        }

        private void ÚËÍÛÚÌ‡ÃÌÓÊËÌ‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuzzySet1D res = StandartSetForm.GetSet(StandartSet.Triangle);
            if (res != null)
            {
                sets.Add(res);
                UpdateListToDgw();
            }
        }

        private void nineteenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuzzySet1D res = StandartSetForm.GetSet(StandartSet.Trapeze);
            if (res != null)
            {
                sets.Add(res);
                UpdateListToDgw();
            }
        }

        private void btnCalcSet_Click(object sender, EventArgs e)
        {
            FSetParser p = new FSetParser(tbSetFormula.Text, sets);
            p.Eval();
            if (!p.ResultOK) {
                MessageBox.Show(p.ErrText);
                return;
            }
            sets.Add(p.Result);
            UpdateListToDgw();
        }

        private void Á·ÂÂ„ÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwSets.SelectedRows.Count != 1) return;
            if (dgwSets.SelectedRows[0].Tag is FuzzySet1D)
            {
                FuzzySet1D set=dgwSets.SelectedRows[0].Tag as FuzzySet1D;
                Common.DataBuffer.Instance.SaveDialog(new Matrix<double>(set.toMassiv()));
            }
        }

        private void Á‡‚‡ÌÚ‡ÊËÚËToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrix<double> data = (Common.DataBuffer.Instance.LoadDialog(FuzzySet1D.ValidationCallback) as Matrix<double>);
            if (data == null) return;
            FuzzySet1D res;
            if (MessageBox.Show("«‡‚‡ÌÚ‡ÊËÚË ˇÍ ‰ËÒÍÂÚÌÛ ÏÌÓÊËÌÛ?", "«‡‚‡ÌÚ‡ÊÂÌÌˇ ‰‡ÌËı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                res = new FuzzySet1D(data.Value, true);
            else res = new FuzzySet1D(data.Value, false);
            sets.Add(res);
            UpdateListToDgw();
        }

        private void tbFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnCreateNew_Click(sender, e);
        }

        private void tbSetFormula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnCalcSet_Click(sender, e);
        }

        private void sampleFormulaClick(object sender, EventArgs e)
        {
            tbFormula.Text = (sender as ToolStripMenuItem).Text;//"sin(x)";
            btnCreateNew_Click(sender, e);
        }

        private void sampleSetFormulaClick(object sender, EventArgs e)
        {
            tbSetFormula.Text = (sender as ToolStripMenuItem).Text.Replace("&&", "&");
            btnCalcSet_Click(sender, e);
        }
    }
}