using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Modules.ConflictsAndCompromises
{
    public abstract class Method : Common.MethodAbstract
    {
        public abstract void Init(CCGame game);
        public abstract object Execute();
    }
}
