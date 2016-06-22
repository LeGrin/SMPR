using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Collections;

namespace Modules.ExpertProcessingMethods
{
    public abstract class Method : Common.MethodAbstract
    {
        public abstract void Execute(int expertCount, double[] expertTrust, ArrayList expertOpinions, out double efficiency, out Object results);
    }
}
