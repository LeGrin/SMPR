using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.View.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using System.Windows.Forms;

namespace Modules.MulticriterionProblemMethods.Workflow
{
    /// <summary>
    /// ������ � ��� ������� ������������ ������� �� ������� ��������� ���������.
    /// </summary>
    internal class DataContainer
    {
        private Matrix m_matrix = null;
        /// <summary>
        /// �������
        /// </summary>
        public Matrix Matrix
        {
            get { return m_matrix; }
            set { m_matrix = value; }
        }

        private Alternative[] m_lastResult = null;
        /// <summary>
        /// ������� ���������
        /// </summary>
        public Alternative[] LastResult
        {
            get { return m_lastResult; }
            set { m_lastResult = value; }
        }
        /// <summary>
        /// ������� ���, ���� ���� ������ ���������        
        /// </summary>
        public bool HasResult
        {
            get { return m_lastResult != null && m_lastResult.Length > 0; }
        }

        /// <summary>
        /// �������� ���, ���� ��� �������
        /// </summary>
        public bool HasData
        {
            get
            {
                return m_matrix != null
                    && m_matrix.AlternativesCount > 0
                    && m_matrix.CriteriumsCount > 0;
            }
        }

    }
}