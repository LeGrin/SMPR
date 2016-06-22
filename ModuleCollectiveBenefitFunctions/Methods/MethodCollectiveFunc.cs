using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions.Methods
{
    class MethodCollectiveFunc : Method
    {
        Scalar<double>[] m_FKK = new Scalar<double>[4];

        //internal override void Init(Data data)
        //{
        //    //throw new Exception ( "The method or operation is not implemented." );
        //}

        internal override Scalar<double>[] DoCalculate()
        {
            m_FKK[0] = new Scalar<double>(0);     //Wp(u)             
            m_FKK[1] = new Scalar<double>(0);     //W^q(u)            
            m_FKK[2] = new Scalar<double>(0);     //Wo(u)             
            m_FKK[3] = new Scalar<double>(0);     //W^o(u)            

            foreach( int i in Vector1.Value)
            {
                m_FKK[0].Value += Math.Exp(P * i);
                m_FKK[1].Value += Math.Pow(Convert.ToDouble(i), Q);
                m_FKK[2].Value += i;
                m_FKK[3].Value += Math.Log(Convert.ToDouble(i));
            }

            m_FKK[0].Value *= P > 0 ? P : -P;
            m_FKK[1].Value *= Q > 0 ? Q : -Q;

            return m_FKK;
        }

        public override string Name
        {
            get { return Properties.Resources.CollectiveMethodName; }
        }
    }
}
