using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions.Methods
{
    class MethodFKKNesha : Method
    {
        Scalar<double> m_Nesh;

        internal override Scalar<double>[] DoCalculate()
        {
            m_Nesh = new Scalar<double>(1);     //Wn(u) ФКК Неша
            foreach (int i in Vector1.Value)
            {
                m_Nesh.Value *= i;
            }
            Scalar<double>[] result = new Scalar<double>[1] { m_Nesh };
            return result;
        }

        public override string Name
        {
            get { return Properties.Resources.FKKMethodName; }
        }
    }
}