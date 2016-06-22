using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions
{
    public abstract class Method : Common.MethodAbstract
    {
        int m_iMemberCount;
        private Vector<int> m_Vector1;
        private Vector<int> m_Vector2;
        private Scalar<double> m_ScalarQ;
        private Scalar<double> m_ScalarP;
  
        /// <summary>
        /// Вектор з данними
        /// </summary>
        internal Vector<int> Vector1
        {
            get { return m_Vector1; }
        }

        internal Vector<int> Vector2
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
            get { return m_iMemberCount; }
        }
        /// <summary>
        /// Ініціалізація методу.
        /// </summary>
        /// <param name="matrix">Вектор з данними</param>
        internal virtual void Init(Data data)
        {
            m_Vector1 = data.Vector1;
            m_Vector2 = data.Vector2;
            m_ScalarQ = data.Q;
            m_ScalarP = data.P;
            m_iMemberCount = data.Members;
        }
        /// <summary>
        /// Виконати метод.
        /// </summary>
        /// <returns>Метод обчислення результатів</returns>
        internal virtual Scalar<double>[] DoCalculate() { return null; }
        
    }
}
