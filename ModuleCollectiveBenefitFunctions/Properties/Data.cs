using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions
{
    internal class Data
    {
        private Vector<int> m_Vector1;
        private Vector<int> m_Vector2;
        private Scalar<double> m_ScalarQ;
        private Scalar<double> m_ScalarP;
        private int m_Members;

        public void SetData(Vector<int> vec1, Vector<int> vec2, Scalar<double> Q, Scalar<double> P, int Members)
        {
            m_Vector1 = vec1;
            m_Vector2 = vec2;
            m_ScalarQ = Q;
            m_ScalarP = P;
            m_Members = Members;
        }

        public Vector<int> Vector1
        {
            get { return m_Vector1; }
        }

        public Vector<int> Vector2
        {
            get { return m_Vector2; }
        }

        public Scalar<double> Q
        {
            get { return m_ScalarQ; }
        }

        public Scalar<double> P
        {
            get { return m_ScalarP; }
        }

        public int Members
        {
            get { return m_Members; }
        }
    }
}
