using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Modules.ConflictsAndCompromises
{
    public class GameGrid : DataGridView
    {
        public enum GridMode
        {
            Normal,
            Test,
            TestComplete
        }

        private enum CellType
        {
            Normal = 0,
            Selected = 1,
            Correct = 2,
            SelectedCorrect = 3,
            Header = 4,
            HeaderSelected = 5,
            HeaderCorrect = 6,
            HeaderSelectedCorrect = 7,
            Incorrect = 8,
            HeaderIncorrect = 12
        }

        static Color[] Colors = new Color[13]
        {
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(210, 210, 255),
            Color.FromArgb(210, 255, 210),
            Color.FromArgb(210, 250, 250),
            Color.FromArgb(230, 230, 240),
            Color.FromArgb(170, 170, 255),
            Color.FromArgb(170, 255, 170),
            Color.FromArgb(170, 220, 220),
            Color.FromArgb(255, 210, 210),
            Color.FromArgb(255, 255, 255),//fake
            Color.FromArgb(255, 255, 255),//fake
            Color.FromArgb(255, 255, 255),//fake
            Color.FromArgb(255, 170, 170)
        };

        public delegate void SelectionEventHandler(object sender, SelectionEventArgs e);
        public class SelectionEventArgs : EventArgs
        {
            protected List<Point> _l;
            public List<Point> SelectedCells { get { return _l; } }

            public SelectionEventArgs(List<Point> list)
            {
                _l = list;
            }
        }

        public delegate void MarkedListChangedEventHandler(object sender, SelectionEventArgs e);

        CCGame _game;
        bool _init = false;
        object _displayedObj = new object();
        List<Point> _selected = new List<Point>(), _result = new List<Point>();
        GridMode _mode = GridMode.Normal;
        TextBox _output = null;

        public CCGame Game
        {
            get { return _game; }
            set
            {
                if (value != null)
                {
                    this._game = value;
                    this._game.StructureChanged += delegate { this.Init(); this.Bind(); this.Draw(); };
                    this._game.ValueChanged += delegate { this.Bind(); };
                    Init();
                    Bind();
                    Draw();
                }
            }
        }

        public GridMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;

                if (_mode == GridMode.Normal)
                {
                    this.Enabled = true;
                    this.ReadOnly = false;
                }
                if (_mode == GridMode.Test)
                {
                    this.Enabled = true;
                    this.ReadOnly = true;
                }
                if (_mode == GridMode.TestComplete)
                {
                    this.Enabled = false;
                    this.ReadOnly = true;
                }

                if (_game != null)
                {
                    if (_mode != GridMode.TestComplete)
                    {
                        _selected.Clear();
                        if (_output != null) _output.Text = SetToString(_selected);
                    }
                    Draw();
                }
            }
        }

        public TextBox Output
        {
            get { return _output; }
            set 
            {
                if (value != null)
                {
                    _output = value;
                    _output.TextChanged += delegate
                    {
                        _selected = SetParse(_output.Text);
                        Draw();
                    };
                }
            }
        }


        protected override void OnCellValueChanged(System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            base.OnCellValueChanged(e);

            if (!_init)
            {
                if ((e.RowIndex == 0) && (e.ColumnIndex == 0))
                {
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    return;
                }

                string s = this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (e.RowIndex == 0)
                {
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _game.Y[e.ColumnIndex - 1].Name;
                    return;
                }
                if (e.ColumnIndex == 0)
                {
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _game.X[e.RowIndex - 1].Name;
                    return;
                }

                string[] cmp = s.Split(new char[4] { ' ', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                int x = 0, y = 0;
                if (cmp.Length > 0) int.TryParse(cmp[0], out x);
                if (cmp.Length > 1) int.TryParse(cmp[1], out y);
                x = (x < _game.MinValue) ? _game.MinValue : ((x > _game.MaxValue) ? _game.MaxValue : x);
                y = (y < _game.MinValue) ? _game.MinValue : ((y > _game.MaxValue) ? _game.MaxValue : y);
                x = (_game.F1 == Modules.ConflictsAndCompromises.CCGame.Function.Min) ? -x : x;
                y = (_game.F2 == Modules.ConflictsAndCompromises.CCGame.Function.Min) ? -y : y;

                _game[e.RowIndex - 1, e.ColumnIndex - 1] = new Situation(x, y);
            }
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            base.OnSelectionChanged(e);
            if (this.SelectedCells.Count == 0) return;
            if ((this.SelectedCells[0].RowIndex == 0) && (this.SelectedCells[0].ColumnIndex == 0)) return;

            Point cell = new Point(this.SelectedCells[0].RowIndex, this.SelectedCells[0].ColumnIndex);

            if (_selected.Contains(cell))
            {
                if (_mode != GridMode.TestComplete) _selected.Remove(cell);
            }
            else
            {
                if (_mode == GridMode.Normal) _selected.Clear();
                if (_mode != GridMode.TestComplete) _selected.Add(cell);
            }

            this.Draw();

            if (_output != null) _output.Text = SetToString(_selected);

            OnSelectionChanged(new SelectionEventArgs(_selected));
        }

        public string SetToString(List<Point> set)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int i = 0; i < set.Count; i++)
            {
                if (i > 0) sb.Append(", ");

                if (set[i].X == 0)
                {
                    sb.Append("(");
                    sb.Append(_game.Y[set[i].Y - 1].Name);
                    sb.Append(")");
                }
                else
                    if (set[i].Y == 0)
                    {
                        sb.Append("(");
                        sb.Append(_game.X[set[i].X - 1].Name);
                        sb.Append(")");
                    }
                    else
                        {
                            sb.Append("(");
                            sb.Append(_game.X[set[i].X - 1].Name);
                            sb.Append(", ");
                            sb.Append(_game.Y[set[i].Y - 1].Name);
                            sb.Append(")");
                        }
            }
            sb.Append("}");

            return sb.ToString();
        }

        public List<Point> SetParse(string s) 
        {
            List<Point> res = new List<Point>();

            s = s.Replace(" ", "");
            string[] points = s.Split(new string[3] { "{(", ")}", "),(" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string p in points)
            {
                string[] sp = p.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (sp.Length == 2)
                {
                    if (_game.X.Contains(sp[0]) && _game.Y.Contains(sp[1]))
                    {
                        res.Add(new Point(_game.X.IndexOf(sp[0]) + 1, _game.Y.IndexOf(sp[1]) + 1));
                    }
                }
                if (sp.Length == 1)
                {
                    if (_game.X.Contains(sp[0]))
                    {
                        res.Add(new Point(_game.X.IndexOf(sp[0]) + 1, 0));
                    }
                    if (_game.Y.Contains(sp[0]))
                    {
                        res.Add(new Point(0, _game.Y.IndexOf(sp[0]) + 1));
                    }
                }
            }

            return res;
        }

        protected void Bind()
        {
            if (!_game.IsInitialized) return;

            _init = true;

            int i, j;

            for (i = 0; i < _game.X.Count; i++)
            {
                for (j = 0; j < _game.Y.Count; j++)
                {
                    this.Rows[i + 1].Cells[j + 1].Value = "(" +
                        Math.Abs(_game[i, j][0]).ToString() + ", " +
                        Math.Abs(_game[i, j][1]).ToString() + ")";
                }
            }
            for (i = 0; i < _game.X.Count; i++) this.Rows[i + 1].Cells[0].Value = _game.X[i].Name;
            for (j = 0; j < _game.Y.Count; j++) this.Rows[0].Cells[j + 1].Value = _game.Y[j].Name;

            _init = false;
        }

        protected void Init()
        {
            if (!_game.IsInitialized) return;

            _init = true;

            int i, j;

            this.Rows.Clear();
            this.Columns.Clear();

            for (j = 0; j <= _game.Y.Count; j++)
            {
                this.Columns.Add("", "");
                this.Columns[j].Width = 65;
            }
            this.Rows.Add(_game.X.Count + 1);

            this.Rows[0].Height = 40;

            for (i = 1; i <= _game.X.Count; i++)
            {
                this.Rows[i].Cells[0].Style.Font = new Font("Tahoma", 14, FontStyle.Bold);
                this.Rows[i].Height = 40;
            }

            for (j = 1; j <= _game.Y.Count; j++)
            {
                this.Rows[0].Cells[j].Style.Font = new Font("Tahoma", 14, FontStyle.Bold);
            }

            _init = false;
        }


        #region Graphic section

        protected void Draw()
        {
            if (!_game.IsInitialized) return;

            for (int i = 0; i <= _game.X.Count; i++)
                for (int j = 0; j <= _game.Y.Count; j++)
                    if ((i > 0) || (j > 0))
                    {
                        CellType ct = CellType.Normal;

                        if (_mode == GridMode.Normal)
                        {
                            bool r = _result.Contains(new Point(i, j));
                            bool s = _selected.Contains(new Point(i, j));
                            bool h = ((i == 0) || (j == 0));

                            
                            if (r) ct = CellType.Correct | ct;
                            if (s) ct = CellType.Selected | ct;
                            if (h) ct = CellType.Header | ct;
                        }
                        if (_mode == GridMode.Test)
                        {
                            bool s = _selected.Contains(new Point(i, j));
                            bool h = ((i == 0) || (j == 0));

                            if (s) ct = CellType.Selected | ct;
                            if (h) ct = CellType.Header | ct;
                        }
                        if (_mode == GridMode.TestComplete)
                        {
                            bool r = _selected.Contains(new Point(i, j)) & _result.Contains(new Point(i, j));
                            bool b = _selected.Contains(new Point(i, j)) | _result.Contains(new Point(i, j));
                            bool h = ((i == 0) || (j == 0));

                            
                            if (b && !r) 
                                ct = CellType.Incorrect | ct;
                            else
                                if (r) ct = CellType.Correct | ct;
                            if (h) ct = CellType.Header | ct;
                        }

                        this.Rows[i].Cells[j].Style.BackColor = Colors[(int)ct];
                        this.Rows[i].Cells[j].Style.SelectionBackColor = Colors[(int)ct];
                    }
        }

        #endregion

        

        public new event SelectionEventHandler SelectionChanged;

        protected void OnSelectionChanged(SelectionEventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        public void SetResultSet(List<Point> set)
        {
            _result = set;
            Draw();
        }

        public double GetCorrectPercent()
        {
            double c = 0, b = 0, r;
            foreach (Point p in _selected)
                if (_result.Contains(p))
                {
                    c++;
                }
                else
                {
                    b++;
                }
            if (_result.Count == 0)
            {
                r = (b > 0) ? 0 : 1;
            }
            else
            {
                r = (c - b / 2) / _result.Count;
            }
            return Math.Max(r, 0);
        }


        public GameGrid()
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ColumnHeadersVisible = false;
            this.RowHeadersVisible = false;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToResizeRows = false;
            this.MultiSelect = false;


            this.GridColor = Color.FromArgb(20, 20, 200);
        }
    }
}
