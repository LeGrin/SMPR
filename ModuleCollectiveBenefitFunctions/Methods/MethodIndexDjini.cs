using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions.Methods
{
    class MethodIndexDjini : Method
    {
        Scalar<double> m_IND;

        internal override Scalar<double>[] DoCalculate()
        {
            Scalar<double> m_FKK = new Scalar<double>(0);     //Wo(u)
            foreach (int i in Vector1.Value)
            {
                m_FKK.Value += i;
            }

            double u_ = m_FKK.Value / Vector1.Value.Length;
            m_IND = new Scalar<double>(0);     //G(u)  індекс Джинні      

            for (int i = 0, j = Vector1.Value.Length - 1; i < Vector1.Value.Length; ++i, --j)
            {
                m_IND.Value += Math.Abs(Convert.ToDouble(Vector1.Value[i]) - Convert.ToDouble(Vector1.Value[j]));
            }

            m_IND.Value = (1 / (Math.Pow(Vector1.Value.Length - 1, 2) * u_)) * m_IND.Value;
            Scalar<double>[] result = new Scalar<double>[1] { m_IND };

            return result;
        }

        public override string Name
        {
            get { return Properties.Resources.DjiniMethodName; }
        }
    }
}