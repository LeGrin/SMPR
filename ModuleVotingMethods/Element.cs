using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.VotingMethods
{
    class Element
    {
        private object tag;

        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public Element()
        {
            this.tag = null;
            this.text = "";
        }

        public Element(object tag, string text)
        {
            this.tag = tag;
            this.text = text;
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}
