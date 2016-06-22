using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.VotingMethods
{
    class Profile
    {
        int nVoters, nCandidates;
        Method currentMethod;
        Candidates candidates;
        DataGridView profile;

        public int NCandidates
        {
            get { return nCandidates; }
            set { nCandidates = value; }
        }

        public int NVoters
        {
            get { return nVoters; }
            set { nVoters = value; }
        }
        

        public Method CurrentMethod
        {
            get { return currentMethod; }
            set { currentMethod = value; }
        }
        
        internal Candidates Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }

        public Profile()
        {
            profile = new DataGridView();
        }

        public Profile(int nVoters, int nCandidates, DataGridView profile, Candidates candidates, Method currentMethod)
            : this()
        {
            this.nVoters = nVoters;
            this.nCandidates = nCandidates;

            this.profile = profile;

            this.candidates = candidates;
            this.currentMethod = currentMethod;

            CreateVotesProfile();
        }

        public void CreateVotesProfile()
        {
            profile.Rows.Clear();
            profile.Columns.Clear();
            candidates.Clear();

            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();

            dc.Name = "points";
            dc.HeaderText = Properties.Resources.pointsCaption;
            dc.Width = 50;
            dc.ValueType = typeof (double);

            profile.Columns.Add(dc);
            profile.Rows.Add();

            profile.Rows[0].Cells["points"].ReadOnly = true;
            profile.Rows[0].Cells["points"].Style.BackColor = Color.FromKnownColor(KnownColor.InactiveBorder);
            profile.Rows[0].Cells["points"].Style.SelectionBackColor = Color.FromKnownColor(KnownColor.InactiveBorder);

            AddMultyColumns(nVoters);

            AddMultyRows(nCandidates, true);

            RefreshPointsVisible();

        }

        public int ObjToInt(object value)
        {
            if ((value == null) || (Convert.IsDBNull(value) == true))
                return 0;
            else return Convert.ToInt32(value);
        }

        public int RowCount
        {
            get { return profile.Rows.Count; }
        }

        public int ColCount
        {
            get { return profile.Columns.Count; }
        }

        public void Select(int rowIndex, int colIndex)
        {
            profile.Focus();
            profile[colIndex, rowIndex].Selected = true;
        }

        public void AddMultyColumns(int count)
        {
            if (count <= 0)
                return;

            DataGridViewColumn dc;

            for (int i = 0; i < count; i++)
            {
                dc = new DataGridViewComboBoxColumn();

                dc.Name = "col" + profile.Columns.Count.ToString();
                dc.HeaderText = Properties.Resources.profileVotersGroupCaption + profile.Columns.Count.ToString();

                profile.Columns.Insert(profile.Columns.Count - 1, dc);
                profile[profile.Columns.Count - 2, 0] = new DataGridViewTextBoxCell();
                profile[profile.Columns.Count - 2, 0].ValueType = typeof (double);
            }

            RefreshColumnsSource();

            nVoters = ColCount - 1;
        }

        public void RemoveMultyColumns(int count)
        {
            if (count <= 0)
                return;

            for (int i = 0; i < count; i++)
                profile.Columns.RemoveAt(ColCount - 2);

            nVoters = ColCount - 1;
        }

        public void AddMultyRows(int count, bool ChangeCandidates)
        {
            if (count <= 0)
                return;

            if (ChangeCandidates)
                for (int i = 0; i < count; i++)
                    candidates.AddCandidate();

            profile.Rows.Add(count);

            nCandidates = candidates.Count;
        }

        public void RemoveMultyRows(int count, bool ChangeCandidates)
        {
            if (count <= 0)
                return;

            for (int t = 0; t < count; t++)
            {
                if (ChangeCandidates)
                    candidates.RemoveAt(candidates.Count - 1);

                for (int i = 1; i < profile.Rows.Count; i++)
                {
                    for (int j = 0; j < profile.Columns.Count - 1; j++)
                    {
                        if ((ObjToInt(profile[j, i].Value) > 0) && (candidates.Contains((int)profile[j, i].Value) == false))
                            profile[j, i].Value = null;
                    }
                }

                profile.Rows.RemoveAt(RowCount - 1);
            }

            nCandidates = candidates.Count;
        }

        public void RefreshCandidatesChange()
        {
            if (candidates.Count > profile.RowCount - 1)
                AddMultyRows(candidates.Count - RowCount + 1, false);
            else RemoveMultyRows(RowCount - 1 - candidates.Count, false);

            RefreshColumnsSource();
            profile.Refresh();
        }

        public void RefreshColumnsSource()
        {
            DataGridViewComboBoxColumn dc;
            for (int i = 0; i < profile.Columns.Count - 1; i++)
            {
                if (profile.Columns[i] is DataGridViewComboBoxColumn)
                {
                    dc = (profile.Columns[i] as DataGridViewComboBoxColumn);

                    if (dc.DataSource != null)
                        continue;

                    dc.DataSource = candidates.DataSource;
                    dc.DisplayMember = "Text";
                    dc.ValueMember = "Tag";
                }
            }
        }

        public bool ExistsColValue(int row, int col, int cand)
        {
            for (int i = 1; i < RowCount; i++)
            {
                if (i == row)
                    continue;

                if ((profile[col, i].Value != null) && ((int)profile[col, i].Value == cand + 1))
                    return true;
            }

            return false;
        }

        public void RefreshPointsVisible()
        {
            if (currentMethod == null)
                return;

            if (currentMethod.ShowPoints == 1)
                profile.Columns["points"].Visible = true;
            else
                profile.Columns["points"].Visible = false;
        }

        public void Clear()
        {
            int[,] matrix = new int[RowCount, ColCount - 1];
            SetProfile(new Matrix<int>(matrix));
        }

        public void RandomGenerate()
        {
            int[,] matrix = new int[RowCount, ColCount - 1];
            List<int> indexes = new List<int>();

            Random r;
            int numb = 0;
            r = new Random();

            for (int j = 0; j < ColCount - 1; j++)
            {
                indexes.Clear();
                for (int k = 0; k < candidates.Count; k++)
                    indexes.Add(k);

                for (int i = 0; i < RowCount; i++)
                {
                    if (i == 0)
                        matrix[i, j] = r.Next(1, 101);
                    else
                    {
                        numb = r.Next(0, candidates.Count - i + 1);
                        matrix[i, j] = Convert.ToInt32(candidates[indexes[numb]].Tag);
                        indexes.RemoveAt(numb);
                    }
                }
            }

            SetProfile(new Matrix<int>(matrix));

            if (currentMethod.ShowPoints == 1)
            {
                int[] vector = new int[candidates.Count];
                vector[0] = r.Next(candidates.Count, 2*candidates.Count);

                for (int i = 1; i < candidates.Count; i++)
                    vector[i] = r.Next(candidates.Count - i - 1, vector[i - 1] - 1);

                SetPoints(new Vector<int>(vector));
            }
            
        }

        public void SetProfile(Matrix<int> data)
        {
            if ((RowCount != nCandidates + 1) || (ColCount != nVoters + 1))
                CreateVotesProfile();

            profile.Enabled = false;
            for (int i = 0; i < data.Value.GetLength(0); i++)
                for (int j = 0; j < data.Value.GetLength(1); j++)
                    if (data[i, j] != 0)//TODO WHY???
                            profile[j, i].Value = data[i, j];
            profile.Enabled = true;

        }

        public Matrix<int> GetProfile()
        {
            int[,] matrix = new int[RowCount, ColCount - 1];

            for (int i = 0; i < ColCount - 1; i++)
                for (int j = 0; j < RowCount; j++)
                    matrix[j, i] = ObjToInt(profile[i, j].Value);

            return new Matrix<int>(matrix);
        }

        public Matrix<int> GetVotes()
        {
            int[,] matrix = new int[RowCount - 1, ColCount - 1];

            for (int i = 0; i < ColCount - 1; i++)
                for (int j = 1; j < RowCount; j++)
                    matrix[j - 1, i] = ObjToInt(profile[i, j].Value);

            return new Matrix<int>(matrix);
        }

        public void SetPoints(Vector<int> data)
        {
            for (int i = 1; i < RowCount; i++)
                profile["points", i].Value = data[i - 1];
        }

        public Vector<int> GetPoints()
        {
            int[] points = new int[RowCount - 1];

            for (int i = 1; i < RowCount; i++)
                points[i - 1] = ObjToInt(profile["points", i].Value);

            return new Vector<int>(points);
        }

        public Vector<int> GetVoters()
        {
            int[] voters = new int[ColCount - 1];

            for (int i = 0; i < ColCount - 1; i++)
                voters[i] = ObjToInt(profile[i, 0].Value);

            return new Vector<int>(voters);
        }

        public void Check_VotersFull()
        {
            for (int i = 0; i < ColCount - 1; i++)
                if (ObjToInt(profile[i, 0].Value) == 0)
                    throw new ProfileException(Properties.Resources.profileVotersFullException, 0, i);
        }

        public void Check_VotersCorrect()
        {
            for (int i = 0; i < ColCount - 1; i++)
                if (!(int.Parse(profile[i, 0].Value.ToString()) > 0))
                    throw new ProfileException(Properties.Resources.profileVotersCorrectException, 0, i);
        }

        public void Check_ProfileFull()
        {
            for (int i = 0; i < ColCount - 1; i++)
                for (int j = 1; j < RowCount; j++)
                    if (ObjToInt(profile[i, j].Value) == 0)
                        throw new ProfileException(Properties.Resources.profileProfileFullException, j, i);
        }

        public void Check_ProfileUnique()
        {
            for (int i = 0; i < ColCount - 1; i++)
                for (int j = 1; j < RowCount; j++)
                    for (int k = j + 1; k < RowCount; k++)
                        if (profile[i, k].Value.ToString() == profile[i, j].Value.ToString())
                            throw new ProfileException(Properties.Resources.profileProfileUniqueException, k, i);
        }

        public void Check_Points()
        {
            int prev = Int32.MaxValue;
            for (int i = 1; i < RowCount; i++)
            {
                if ((ObjToInt(profile[ColCount - 1, i].Value) < 0)||(ObjToInt(profile[ColCount - 1, i].Value) >= prev))
                    throw new ProfileException(Properties.Resources.profilePointsException, i, ColCount - 1);

                prev = ObjToInt(profile[ColCount - 1, i].Value);
            }
        }

        public void Check_Order()
        {
            List<int> exists = new List<int>();
            int val;
            for (int i = 1; i < RowCount; i++)
            {
                val = ObjToInt(profile[ColCount - 1, i].Value);
                if ((val <= 0) || (val > candidates.Count))
                    throw new ProfileException(Properties.Resources.profileOrder1Exception, i, ColCount - 1);

                if (exists.Contains(val) == true)
                    throw new ProfileException(Properties.Resources.profileOrder2Exception, i, ColCount - 1);

                exists.Add(val);
            }
        }

        public void generatePermatation()
        {
            if (currentMethod.PointsAsOrder == true)
            {
                int[] vector = new int[candidates.Count];
                int[] temp = new int[candidates.Count];
                for (int i = 0; i < candidates.Count; i++) temp[i] = i + 1;

                Random r = new Random();
                for (int i = 0; i < candidates.Count - 1; i++)
                {
                    int kil = candidates.Count - i;
                    int ind = r.Next(kil);
                    vector[i] = temp[ind];
                    temp[ind] = temp[kil - 1];
                }

                vector[candidates.Count - 1] = temp[0];



                    SetPoints(new Vector<int>(vector));
            }
        }


        public void CheckCorrect()
        {
            try
            {
                Check_VotersFull();
                Check_VotersCorrect();
                Check_ProfileFull();
                Check_ProfileUnique();

                if (currentMethod.ShowPoints == 1)
                {
                    if (currentMethod.PointsAsOrder == true)
                        Check_Order();
                    else
                        Check_Points();
                }
            }
            catch (ProfileException ex)
            {
                throw ex;
            }
        }
    }
}
