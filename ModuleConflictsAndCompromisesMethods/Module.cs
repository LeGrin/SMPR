using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Drawing;

namespace Modules.ConflictsAndCompromises
{
    [Common.ModuleInfo(new string[] { "uk-UA::Конфлікти і компроміси", "en-US::Conflicts and Compromisses", "ru-RU::Конфликты и компромиссы", "zh::冲突与妥协" })]
    [Common.About("Михайлов Павло Сергійович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "PashaMykhajlov")]
    [Common.About("Якубовський Павло Владаенович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "PashaJakubovskyj")]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        string s1 = " для гравця №1";
        string s2 = " для гравця №2";
        Dictionary<string, double> _lastresults;
        int _testcount = 0;
        frmModule form;
        Method workingMethod;
        protected CCGame _game;
        protected Dictionary<string, object> _cache;

        public Dictionary<string, double> LastResults
        {
            get { return _lastresults; }
            set { _lastresults = value; }
        }
        public CCGame Game
        {
            get { return _game; }
            set { _game = value; }
        }
        public int TestCount
        {
            get { return _testcount; }
            set { _testcount = value; }
        }

        public object GetResult(Method method)
        {
            if (!_cache.ContainsKey(method.Name))
            {
                method.Init(_game);
                _cache.Add(method.Name, method.Execute());
            }
            return _cache[method.Name];
        }

        public Method WorkingMethod
        {
            get { return workingMethod; }
            set { workingMethod = value; }
        }

        public class ConflictsAndCompromisesCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
            _cache = new Dictionary<string, object>();
            _game = new CCGame();
            _game.AutoFilling.Enabled = true;
            _game.AutoFilling.Min = 0;
            _game.AutoFilling.Max = 10;
            _game.StructureChanged += delegate { _cache.Clear(); };
            _game.ValueChanged += delegate { _cache.Clear(); };
            _game.PlayerFunctionChanged += delegate { _cache.Clear(); };

            _game.Init();
            _game.X.Add("X1");
            _game.X.Add("X2");
            _game.Y.Add("Y1");
            _game.Y.Add("Y2");
        }

        public Module(Method method)
            : this()
        {
            workingMethod = method;
        }

        public override void Show(Form MdiParent)
        {
            form = new frmModule(this);
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
                form.MdiParent = MdiParent;
            form.Show();
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new ConflictsAndCompromisesCloseEventArgs();
            OnClose(LastResult);
        }

        public override CloseEventArgs ShowDialog()
        {
            form = new frmModule(this);
            form.ShowDialog();
            return LastResult;
        }

        protected override void OnClose(CloseEventArgs args)
        {
            //              Buffer.Instance.Save("Останні результати модуля " + this.GetType().Name, args.result);                        
            base.OnClose(args);
        }

        public List<TestItem> GetListOfSets()
        {
            List<TestItem> res = new List<TestItem>();

            foreach (Method method in Methods)
            {
                object r = GetResult(method);

                if (r is Array)
                {
                    res.Add(new TestItem(method.Name + s1, ToSet(r, 0)));
                    res.Add(new TestItem(method.Name + s2, ToSet(r, 1)));
                }
                else
                {
                    res.Add(new TestItem(method.Name, ToSet(r, 0)));
                }
            }
            return res;
        }

        public List<Point> ToSet(object res, int pl)
        {
            List<Point> l = new List<Point>();

            if (res is List<Point>)
            {
                foreach (Point p in res as List<Point>)
                {
                    l.Add(new Point(p.X + 1, p.Y + 1));
                }
            }
            if (res is List<int>[])
            {
                if (pl == 0)
                    foreach (int i in (res as List<int>[])[0])
                    {
                        l.Add(new Point(i + 1, 0));
                    }
                if (pl == 1)
                    foreach (int j in (res as List<int>[])[1])
                    {
                        l.Add(new Point(0, j + 1));
                    }
            }
            if (res is List<Point>[])
            {
                if (pl == 0)
                    foreach (Point p in (res as List<Point>[])[0])
                    {
                        l.Add(new Point(p.X + 1, p.Y + 1));
                    }
                if (pl == 1)
                    foreach (Point p in (res as List<Point>[])[1])
                    {
                        l.Add(new Point(p.X + 1, p.Y + 1));
                    }
            }
            return l;
        }

    }
}
