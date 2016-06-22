using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions.Methods
{
    class MethodPiguDalton : Method
    {
        internal override Scalar<double>[] DoCalculate()
        {
            Scalar<double>[] Res = new Scalar<double>[1] { new Scalar<double>(0)};

            Random rand = new Random();
            int i = rand.Next(0, Members);
            int j = rand.Next(0, Members);

            if (Vector1[i] + Vector1[j] == Vector2[i] + Vector2[j])
                Res[0].Value = 1;
            else
                Res[0].Value = 0;

            return Res;
        }
        public override string Name
        {
            get { return Properties.Resources.PiguMethodName; }
        }
    }
}