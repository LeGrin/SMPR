using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.VotingMethods
{
    class Candidates
    {
        List<Element> candidates;

        public Candidates()
        {
            candidates = new List<Element>();
        }

        public List<Element> DataSource
        {
            get { return candidates; }
            set { candidates = value; }
        }

        public Element this[int index]
        {
            get
            {
                if ((index >= 0)&&(index<candidates.Count))
                    return candidates[index];
                else return null;
            }
            set { candidates[index] = value; }
        }

        public void ChangeCandidateName(int index, string newName)
        {
            candidates[index].Text = newName;
        }

        public void AddCandidate()
        {
            candidates.Add(new Element(candidates.Count + 1, Properties.Resources.candidateCaption + (candidates.Count + 1).ToString()));
        }

        public void AddCandidate(string name)
        {
            candidates.Add(new Element(candidates.Count + 1, name));
        }

        public void Clear()
        {
            candidates.Clear();
        }

        public void Remove(Element candidate)
        {
            candidates.Remove(candidate);

            for (int i = 0; i < candidates.Count; i++)
                candidates[i].Tag = i + 1;
        }

        public void RemoveAt(int index)
        {
            candidates.RemoveAt(index);

            for (int i = 0; i < candidates.Count; i++)
                candidates[i].Tag = i + 1;
        }

        public bool Contains(Element candidate)
        {
            return candidates.Contains(candidate);
        }

        public bool Contains(int Tag)
        {
            try
            {
                Element el = candidates[Tag - 1];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Contains(string name)
        {
            for (int i = 0; i < candidates.Count; i++)
                if (candidates[i].Text.ToLower() == name.ToLower())
                    return true;

            return false;
        }

        public bool Contains(int currIndex, string name)
        {
            for (int i = 0; i < candidates.Count; i++)
                if ((candidates[i].Text.ToLower() == name.ToLower())&&(i!= currIndex))
                    return true;

            return false;
        }

        public int Count
        {
            get { return candidates.Count; }
        }
	
    }
}
