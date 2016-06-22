using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Modules.ConflictsAndCompromises
{
    public class Tester : Panel
    {
        double _score = 0, _maxScore;
        Dictionary<string, double> _testscore;
        int _index;
        List<TestItem> _items;
        bool _finished;


        public double Score { get { return _score; } }
        public TestItem CurrentItem { get { return _items[_index]; } }
        public bool Complete { get { return _finished; } }
        public Dictionary<string, double> TestScore { get { return _testscore; } }


        public bool Proceed(double correctPercent)
        {
            if (_finished) return false;

            _testscore[CurrentItem.Name] = Math.Max(_testscore[CurrentItem.Name], correctPercent);
            _score += _testscore[CurrentItem.Name] * _maxScore / _items.Count;
            //_score += correctPercent * _maxScore / _items.Count;

            (this.Controls[_index] as Label).Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            (this.Controls[_index] as Label).BackColor = Color.FromArgb(220, 220, 240);
            (this.Controls[_index] as Label).Text += " (" + (correctPercent * 100).ToString() + "%)";
            _index++;

            if (_index >= _items.Count) _finished = true;
            else
            {
                
                (this.Controls[_index] as Label).Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
                (this.Controls[_index] as Label).BackColor = Color.FromArgb(200, 200, 240);
            }

            return true;
        }

        public void Init(List<TestItem> items, double maxScore,Dictionary<string, double> testscore)
        {
            _items = items;
            _maxScore = maxScore;
            _index = 0;
            _finished = false;

            _testscore = testscore;
            if (_testscore == null) _testscore = new Dictionary<string, double>();
            this.Controls.Clear();
            foreach (TestItem i in _items)
            {
                if (!_testscore.ContainsKey(i.Name)) _testscore[i.Name] = 0;
                Label l = new Label();
                l.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
               // l.BackColor = Color.FromArgb(240, 240, 255);
                l.Width = 450;
                l.Height = 20;
                l.Top = this.Controls.Count * 22 + 2;
                l.Left = 2;
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Text = i.Name;
                this.Controls.Add(l);
            }

            (this.Controls[0] as Label).Font = new System.Drawing.Font("Tahoma", 10f, System.Drawing.FontStyle.Bold);
            (this.Controls[0] as Label).BackColor = Color.FromArgb(200, 200, 240);

        }

        public Tester()
        {

        }
    }
}
