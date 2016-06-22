using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.ConflictsAndCompromises
{
    public class Strategy
    {
        string _name;
        StrategyArray _alterContainer;
        Dictionary<string, Dictionary<string, int>> _u;

        public string Name { get { return _name; } set { _name = value; } }

        public bool Dominates(Strategy s)
        {
            bool res = false;

            foreach (Strategy t in _alterContainer)
            {
                if (_u[this.Name][t.Name] > _u[s.Name][t.Name]) res = true;
                if (_u[this.Name][t.Name] < _u[s.Name][t.Name]) return false;
            }

            return res;
        }

        public bool EqualTo(Strategy s)
        {
            foreach (Strategy t in _alterContainer)
            {
                if (_u[this.Name][t.Name] != _u[s.Name][t.Name]) return false;
            }

            return true;
        }

        public Strategy(string name, StrategyArray alterContainer, Dictionary<string, Dictionary<string, int>> u)
        {
            _name = name;
            _alterContainer = alterContainer;
            _u = u;
        }
    }
}
