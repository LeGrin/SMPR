using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using Common.DataTypes;
//using Modules.Tests;
using Modules.Tests;
using Modules.Tests.Methods;
using Modules.Tests.Properties;
using System.Threading;




namespace Modules.VotingMethods
{
    partial class frmModule : Form
    {
        BindingSource bsMethods;
        Candidates candidates;
        Profile profile;
        SequenceRenderer Renderer;

        frmAddCandidate m_frmAddCandidate;
        frmDeleteCandidate m_frmDeleteCandidate;
        frmChangeCandidate m_frmChangeCandidate;
        string[] candidateOrder;

        public frmModule()
        {
            InitializeComponent();

            candidates = new Candidates();
            bsMethods = new BindingSource();
        }

        public frmModule(List<Method> methods)
            : this()
        {
            this.nmCandidates.Value = 2;
            this.nmVoters.Value = 2;

            profile = new Profile(Convert.ToInt32(nmVoters.Value), Convert.ToInt32(nmCandidates.Value), dataVotes, candidates, cmbMethod.SelectedItem as Method);

            bsMethods.DataSource = methods;
            cmbMethod.DataSource = bsMethods;
        }

        public frmModule(Scalar<string> method, Scalar<Int32> numberCandidates, Scalar<Int32> numberVoters, Matrix<Int32> dataVotes, Vector<Int32> points, List<Method> methods)
            : this(methods)
        {
            this.nmCandidates.Value = numberCandidates;
            this.nmVoters.Value = numberVoters;
        }

        public void RefreshCandidatesChanges()
        {
            profile.RefreshCandidatesChange();

            if ((int)nmCandidates.Value != candidates.Count)
                nmCandidates.Value = candidates.Count;
        }

        private void RedrawResults(SequenceRenderer renderer)
        {
            renderer.Render();
            resGraph.Tag = renderer.Bmp;
            resGraph.Invalidate();
        }

        private void nmVoters_ValueChanged(object sender, EventArgs e)
        {
            if (nmVoters.Value > 60) nmVoters.Value = 60; 
            
            profile.NVoters = (int)nmVoters.Value;

            if (nmVoters.Value + 2 > profile.ColCount)
            {
                profile.SetProfile(profile.GetProfile());
            }
            else
                profile.RemoveMultyColumns((int)Math.Abs(nmVoters.Value - profile.ColCount + 1));
        }

        private void nmCandidates_ValueChanged(object sender, EventArgs e)
        {
            if (nmCandidates.Value > 60) nmCandidates.Value = 60;
            if (nmCandidates.Value + 2 > profile.RowCount)
            {
                profile.AddMultyRows(Convert.ToInt32(nmCandidates.Value - profile.RowCount + 1), true);
            }
            else
            {
                profile.RemoveMultyRows((int)Math.Abs(nmCandidates.Value - profile.RowCount + 1), true);
            }

            profile.NCandidates = Convert.ToInt32(nmCandidates.Value);
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            profile.CurrentMethod = cmbMethod.SelectedItem as Method;
            permatationToolStripMenuItem.Enabled = profile.CurrentMethod.PointsAsOrder;            
            profile.RefreshPointsVisible();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            resText.Items.Clear();
            Renderer = new SequenceRenderer(resGraph.Width, resGraph.Height, new Element[] { }, Color.White, Color.White);
            Renderer.RenderCleanGraphic();
            this.Invalidate();

            try
            {
                profile.CheckCorrect();
            }
            catch (ProfileException ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.frmModuleCaption);
                profile.Select(ex.RowIndex, ex.ColIndex);
                return;
            }

            int[] result;

            try
            {
                result = (cmbMethod.SelectedItem as Method).ProcessMethod(profile.NCandidates, profile.NVoters, profile.GetVoters(), profile.GetVotes(), profile.GetPoints());
            }
            catch (MethodException ex)
            {
                MessageBox.Show(string.Format(Properties.Resources.methodException, ex.ExMethod.Name, ex.Message), Properties.Resources.frmModuleCaption);
                return;
            }

            Element[] candidateSequence = new Element[candidates.Count];
            candidateOrder = new string[candidates.Count];

            for (int i=0; i< candidates.Count; i++)
                candidateSequence[i] = new Element(result[(int)candidates[i].Tag - 1], candidates[i].Text);

            Renderer = new SequenceRenderer(resGraph.Width, resGraph.Height, candidateSequence, Color.LightGreen, Color.Yellow);
            RedrawResults(Renderer);

            Element tmp;
            for (int i = 1; i < Convert.ToInt32(nmCandidates.Value); i++)
                for (int j = Convert.ToInt32(nmCandidates.Value) - 1; j >= i; j--)
                    if (Convert.ToInt32(candidateSequence[j].Tag) < Convert.ToInt32(candidateSequence[j - 1].Tag))
                    {
                        tmp = candidateSequence[j];
                        candidateSequence[j] = candidateSequence[j - 1];
                        candidateSequence[j - 1] = tmp;
                    }

            for (int i = 0; i < Convert.ToInt32(nmCandidates.Value); i++)
            {
                resText.Items.Add(candidateSequence[i].Tag.ToString() + ". " + candidateSequence[i].ToString());
                candidateOrder[i] = candidateSequence[i].ToString();
            }
        }

        private void dataVotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ComboBox cb = dataVotes.EditingControl as ComboBox;
            if (cb != null)
            {
                cb.DroppedDown = true;
            }
        }

        bool profileValidator(BufferData obj)
        {
            if (!((obj is Matrix<int>) && ((obj as Matrix<int>).Value.GetLength(0) >= 3) && ((obj as Matrix<int>).Value.GetLength(1) >= 2)))
                return false;

            return true;
        }

        bool pointsValidator(BufferData obj)
        {
            if (!((obj is Vector<int>) && ((obj as Vector<int>).Value.GetLength(0) == Convert.ToInt32(nmCandidates.Value))))
                return false;
            return true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            BufferData obj = Common.DataBuffer.Instance.LoadDialog(profileValidator);
            if (obj == null) return;

            Matrix<int> data = obj as Matrix<int>;
            if (data != null)
            {
                nmCandidates.Value = data.Value.GetLength(0) - 1;
                nmVoters.Value = data.Value.GetLength(1);

                profile.SetProfile(data);
            }
            else
                MessageBox.Show(Properties.Resources.bufferLoadProfileException, Properties.Resources.frmModuleCaption);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            dataVotes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            Common.DataBuffer.Instance.SaveDialog(new Matrix<int>(profile.GetProfile()));
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Common.DataBuffer.Instance.SaveDialog(new Vector<int>(profile.GetPoints()));
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BufferData obj = Common.DataBuffer.Instance.LoadDialog(pointsValidator);
            if (obj == null) return;

            Vector<int> data = obj as Vector<int>;

            if (data != null)
                profile.SetPoints(data);
            else
                MessageBox.Show(Properties.Resources.bufferLoadPointsException, Properties.Resources.frmModuleCaption);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            //profile.Clear();
            profile = new Profile(Convert.ToInt32(nmVoters.Value), Convert.ToInt32(nmCandidates.Value), dataVotes, candidates, cmbMethod.SelectedItem as Method);
        }

        private void pGraph_Paint(object sender, PaintEventArgs e)
        {
            if (resGraph.Tag != null && resGraph.Tag is Bitmap)
            {
                e.Graphics.DrawImage(resGraph.Tag as Bitmap, new Point(0, 0));
            }
        }

        private void pGraph_Resize(object sender, EventArgs e)
        {
            if (resGraph.Tag != null && resGraph.Tag is Bitmap)
            {
                Renderer.Resize(resGraph.Width, resGraph.Height);
                Renderer.Render();
                resGraph.Tag = Renderer.Bmp;
            }
        }

        private void pGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (resGraph.Tag != null && resGraph.Tag is Bitmap)
            {
                Renderer.SelectRectangle(e.X, e.Y);
                resGraph.Tag = Renderer.Bmp;
                resGraph.Refresh();
            }
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            profile.RandomGenerate();
        }

        private void dataVotes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox cb = dataVotes.EditingControl as ComboBox;
            if (cb != null)
            {
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += cb_DrawItem;
            }
        }

        void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (dataVotes.SelectedCells == null)
                return;

            if (dataVotes.SelectedCells.Count == 0) return; 
                
            DataGridViewComboBoxCell currCell = dataVotes.SelectedCells[0] as DataGridViewComboBoxCell;

            if (currCell == null)
                return;

            bool red = profile.ExistsColValue(currCell.RowIndex, currCell.ColumnIndex, e.Index);
            bool selected = (e.State & DrawItemState.Selected) != 0;

            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.DrawString(candidates[e.Index].Text, Font,

                    selected ? (red ? Brushes.Red : Brushes.LightGreen)
                             : (red ? Brushes.Red : Brushes.Green),

                    e.Bounds);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            dataVotes.CommitEdit(DataGridViewDataErrorContexts.Commit);

            m_frmDeleteCandidate = new frmDeleteCandidate(this, candidates);
            m_frmDeleteCandidate.ShowDialog();

            
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            dataVotes.CommitEdit(DataGridViewDataErrorContexts.Commit);

            m_frmChangeCandidate = new frmChangeCandidate(this, candidates);
            m_frmChangeCandidate.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            dataVotes.CommitEdit(DataGridViewDataErrorContexts.Commit);

            m_frmAddCandidate = new frmAddCandidate(this, candidates);
            m_frmAddCandidate.ShowDialog();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            Common.DataBuffer.Instance.SaveDialog(new Vector<string>(candidateOrder));
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp frm = new frmHelp();

           

            string fname = profile.CurrentMethod.Name.ToString() + "." + Thread.CurrentThread.CurrentUICulture.Name.ToString();
        //    MessageBox.Show(fname);
       //     MessageBox.Show(fname+".rtf","info must be in file:" );
            fname = fname.Replace(".", "_");
            fname=fname.Replace(" ", "_");
            fname = fname.Replace("-", "_");
            

            frmHelp.ShowHelp(Properties.Resources.ResourceManager.GetString(fname));          
            
        }

        private void testingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest( new Modules.Tests.Methods.MethodVouting() );
            frm.ShowDialog();

          
                

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
                       
            frmInfo frm = new frmInfo( helpToolStripMenuItem.Text );
            frm.ShowDialog();
            
        }

        private void permatationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            profile.generatePermatation();
        }

        private void dataVotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataVotes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(Properties.Resources.typeDataGridCellError);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

       
    }
}