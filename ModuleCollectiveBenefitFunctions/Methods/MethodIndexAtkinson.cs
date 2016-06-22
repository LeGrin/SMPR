using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions.Methods
{
    class MethodIndexAtkinson : Method
    {
        Scalar<double>[] m_IND = new Scalar<double>[2];

        internal override Scalar<double>[] DoCalculate()
        {
            Scalar<double> m_FKK = new Scalar<double>(0);     //Wo(u)
            foreach (int i in Vector1.Value)
            {
                m_FKK.Value += i;
            }

            double u_ = m_FKK.Value / Vector1.Value.Length;
            m_IND[0] = new Scalar<double>(0);     //Jq(u)                     
            m_IND[1] = new Scalar<double>(1);     //Jo(u) індекс Аткінсона    

            for (int i = 0, j = Vector1.Value.Length - 1; i < Vector1.Value.Length; ++i, --j)
            {
                m_IND[0].Value += Math.Pow(Convert.ToDouble(Vector1.Value[i]) / u_, Q);
                m_IND[1].Value *= Convert.ToDouble(Vector1.Value[i]) / u_;
            }

            m_IND[0].Value = 1 - Math.Pow((1 / (Vector1.Value.Length - 1)) * m_IND[0].Value, 0.5);
            m_IND[1].Value = 1 - Math.Pow(m_IND[1].Value, 1 / (Vector1.Value.Length - 1));

            return m_IND;
        }

        public override string Name
        {
            get { return Properties.Resources.AtkinsonMethodName; }
        }
    }
}