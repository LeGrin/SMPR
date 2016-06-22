using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.ConflictsAndCompromises
{
    public class StrategyArray : List<Strategy>
    {
        CCGame _parent;
        Dictionary<string, Dictionary<string, int>> _u;
        public StrategyArray AlterContainer;

        public void Add(string item)
        {
            base.Add(new Strategy(item, AlterContainer, _u));
            _parent.RefreshStructure();
        }

        public void AddWithoutRefresh(string item)
        {
            base.Add(new Strategy(item, AlterContainer, _u));
        }

        public new void Add(Strategy item)
        {
            base.Add(item);
            _parent.RefreshStructure();
        }

        public new void AddWithoutRefresh(Strategy item)
        {
            base.Add(item);
        }

        public bool Contains(string item)
        {
            foreach (Strategy s in this)
            {
                if (s.Name == item) return true;
            }

            return false;
        }

        public int IndexOf(string item)
        {
            foreach (Strategy s in this)
            {
                if (s.Name == item) return this.IndexOf(s);
            }

            return -1;
        }

        public new void Clear()
        {
            base.Clear();
            _parent.RefreshStructure();
        }

        public new bool RemoveAt(int index)
        {
            base.RemoveAt(index);
            _parent.RefreshStructure();

            return true;
        }

        public StrategyArray(CCGame parent, Dictionary<string, Dictionary<string, int>> u)
        {
            _parent = parent;
            _u = u;
        }
    }
}
