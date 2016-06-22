using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;
using System.Drawing;

namespace Modules.ConflictsAndCompromises
{
    public class CCGame
    {
        public enum Function
        {
            Min = 0,
            Max = 1
        }

        public class AutoFillingParameters
        {
            public bool Enabled;
            public int Min;
            public int Max;
        }

        StrategyArray _x, _y;
        Dictionary<string, Dictionary<string, int>> _u1, _u2;
        Function _f1 = Function.Max, _f2 = Function.Max;
        bool _isInitialized = false;
        int _minValue = 0;
        int _maxValue = 99;
        AutoFillingParameters _autoFilling = new AutoFillingParameters();
        Random _rnd = new Random();


        public AutoFillingParameters AutoFilling { get { return _autoFilling; } set { _autoFilling = value; } }
        public bool IsInitialized { get { return _isInitialized; } }
        public StrategyArray X { get { return _x; } }
        public StrategyArray Y { get { return _y; } }
        public Dictionary<string, Dictionary<string, int>> U1 { get { return _u1; } }
        public Dictionary<string, Dictionary<string, int>> U2 { get { return _u2; } }
        public Situation this[int i, int j]
        {
            get
            {
                string x = _x[i].Name;
                string y = _y[j].Name;
                int u1 = _u1[x][y];
                int u2 = _u2[y][x];

                return new Situation(u1, u2);
            }
            set
            {
                string x = _x[i].Name;
                string y = _y[j].Name;
                _u1[x][y] = value[0];
                _u2[y][x] = value[1];

                OnValueChanged(new EventArgs());
            }
        }
        public Situation this[Point p]
        {
            get
            {
                string x = _x[p.X].Name;
                string y = _y[p.Y].Name;
                int u1 = _u1[x][y];
                int u2 = _u2[y][x];

                return new Situation(u1, u2);
            }
            set
            {
                string x = _x[p.X].Name;
                string y = _y[p.Y].Name;
                _u1[x][y] = value[0];
                _u2[y][x] = value[1];

                OnValueChanged(new EventArgs());
            }
        }
        public int MaxValue { get { return _maxValue; } }
        public int MinValue { get { return _minValue; } }
        public Function F1 
        { 
            get { return _f1; } 
            set
            {
                _f1 = value;

                if (_isInitialized)
                {
                    int k = (_f1 == Function.Max) ? 1 : -1;

                    foreach (Strategy x in _x)
                        foreach (Strategy y in _y)
                        {
                            _u1[x.Name][y.Name] = k * Math.Abs(_u1[x.Name][y.Name]);
                        }
                }

                OnPlayerFunctionChanged(new EventArgs());
            } 
        }
        public Function F2 
        {
            get { return _f2; }
            set 
            { 
                _f2 = value;

                if (_isInitialized)
                {
                    int k = (_f2 == Function.Max) ? 1 : -1;

                    foreach (Strategy x in _x)
                        foreach (Strategy y in _y)
                        {
                            _u2[y.Name][x.Name] = k * Math.Abs(_u2[y.Name][x.Name]);
                        }
                }

                OnPlayerFunctionChanged(new EventArgs());
            } 
        }

        public void RefreshStructure()
        {
            //foreach (KeyValuePair<string, Dictionary<string, int>> p in _u1) if (!_x.Contains(p.Key)) _u1.Remove(p.Key);
            //foreach (KeyValuePair<string, Dictionary<string, int>> p in _u2) if (!_y.Contains(p.Key)) _u2.Remove(p.Key);

            foreach (Strategy x in _x) if (!_u1.ContainsKey(x.Name)) _u1.Add(x.Name, new Dictionary<string, int>());
            foreach (Strategy y in _y) if (!_u2.ContainsKey(y.Name)) _u2.Add(y.Name, new Dictionary<string, int>());


          /*  foreach (string x in _x)
                foreach (KeyValuePair<string, int> p in _u1[x])
                {
                    if (!_x.Contains(p.Key)) _u1[x].Remove(p.Key);
                }
            foreach (string y in _y)
                foreach (KeyValuePair<string, int> p in _u2[y])
                {
                    if (!_y.Contains(p.Key)) _u2[y].Remove(p.Key);
                }*/

            foreach (Strategy x in _x)
                foreach (Strategy y in _y)
                {
                    Situation s = RandomSituation();

                    if (!_u1[x.Name].ContainsKey(y.Name)) _u1[x.Name].Add(y.Name, _autoFilling.Enabled ? s[0] : 0);
                    if (!_u2[y.Name].ContainsKey(x.Name)) _u2[y.Name].Add(x.Name, _autoFilling.Enabled ? s[1] : 0);
                }

            OnStructureChanged(new EventArgs());
        }


        public Situation[,] ToArray()
        {
            Situation[,] r = new Situation[_x.Count, _y.Count];

            for (int i = 0; i < _x.Count; i++)
                for (int j = 0; j < _y.Count; j++)
                {
                    r[i, j] = this[i, j];
                }

            return r;
        }

        protected Situation RandomSituation()
        {
            int u1 = _rnd.Next(_autoFilling.Max - _autoFilling.Min + 1) + _autoFilling.Min;
            int u2 = _rnd.Next(_autoFilling.Max - _autoFilling.Min + 1) + _autoFilling.Min;
            //u1 = (_f1 == Function.Max) ? u1 : -u1;
            //u2 = (_f2 == Function.Max) ? u2 : -u2;

            return new Situation(u1, u2);
        }


        public event EventHandler StructureChanged;

        public event EventHandler ValueChanged;

        public event EventHandler Initialized;

        public event EventHandler PlayerFunctionChanged;

        protected void OnStructureChanged(EventArgs e)
        {
            if (StructureChanged != null)
                StructureChanged(this, e);
        }

        protected void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(this, e);
        }

        protected void OnInitialized(EventArgs e)
        {
            if (Initialized != null)
                Initialized(this, e);
        }

        protected void OnPlayerFunctionChanged(EventArgs e)
        {
            if (PlayerFunctionChanged != null)
                PlayerFunctionChanged(this, e);
        }


        public void Init(Situation[,] data)
        {
            int i, j;

            _u1 = new Dictionary<string, Dictionary<string, int>>();
            _u2 = new Dictionary<string, Dictionary<string, int>>();
            _x = new StrategyArray(this, _u1);
            _y = new StrategyArray(this, _u2);
            _x.AlterContainer = _y;
            _y.AlterContainer = _x;

            for (i = 0; i < data.GetLength(0); i++) _x.AddWithoutRefresh("X" + (i + 1).ToString());
            for (j = 0; j < data.GetLength(1); j++) _y.AddWithoutRefresh("Y" + (j + 1).ToString());

            RefreshStructure();

            for (i = 0; i < _x.Count; i++)
                for (j = 0; j < _y.Count; j++)
                {
                    Situation s = new Situation(data[i, j][0], data[i, j][1]);

                    if (_f1 == Function.Min) s[0] = -s[0];
                    if (_f2 == Function.Min) s[1] = -s[1];

                    this[i, j] = s;
                }

            _isInitialized = true;

            OnInitialized(new EventArgs());
        }

        public void Init(Matrix<ParsablePointD> data)
        {
            Situation[,] situations = new Situation[data.RowCount, data.ColumnCount];
            for (int i = 0; i < data.RowCount; i++)
            {
                for (int j = 0; j < data.ColumnCount; j++)
                {
                    situations[j, i] = new Situation((int)data[i, j].X, (int)data[i, j].Y);
                }
            }
            Init(situations);
            OnInitialized(new EventArgs());
        }

        public void Init()
        {
            _u1 = new Dictionary<string, Dictionary<string, int>>();
            _u2 = new Dictionary<string, Dictionary<string, int>>();
            _x = new StrategyArray(this, _u1);
            _y = new StrategyArray(this, _u2);
            _x.AlterContainer = _y;
            _y.AlterContainer = _x;

            _isInitialized = true;

            OnInitialized(new EventArgs());
        }

        public void CCGame_Initialized(object sender, EventArgs e)
        {
        }

        public void FillRandom()
        {
            foreach (Strategy x in _x)
                foreach (Strategy y in _y)
                {
                    Situation s = RandomSituation();

                    _u1[x.Name][y.Name] = s[0];
                    _u2[y.Name][x.Name] = s[1];
                }

            OnValueChanged(new EventArgs());
        }

        public CCGame()
        {
            Initialized += CCGame_Initialized;
        }
    }
}
