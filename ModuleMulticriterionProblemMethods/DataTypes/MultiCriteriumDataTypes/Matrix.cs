using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.Exceptions;
using Modules.MulticriterionProblemMethods.Exceptions.Alternative;
using Modules.MulticriterionProblemMethods.View.Controls;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    [Serializable]
    internal class Matrix : Common.DataTypes.Matrix<int>, ICloneable
    {
        private readonly Dictionary<string, Criterium> m_criteriums = new Dictionary<string, Criterium>();
        private readonly Dictionary<string, Alternative> m_alternatives = new Dictionary<string, Alternative>();

        /// <summary>
        /// ������������
        /// </summary>
        public IEnumerable<Alternative> Alternatives
        {
            get { return m_alternatives.Values; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public IEnumerable<Criterium> Criteriums
        {
            get { return m_criteriums.Values; }
        }

        /// <summary>
        /// ������� ������� ������ ������������ �� ������� �������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <param name="criterium">�������</param>        
        public int this[string alternativeName, Criterium criterium]
        {
            get { return m_alternatives[alternativeName][criterium]; }
            set { m_alternatives[alternativeName][criterium] = value; }
        }
        /// <summary>
        /// ������� ������� ������ ������������ �� ������� �������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <param name="criterium">�������</param>        
        public int this[Alternative alternative, Criterium criterium]
        {
            get { return m_alternatives[alternative.Name][criterium]; }
            set { m_alternatives[alternative.Name][criterium] = value; }
        }
        /// <summary>
        /// ������� ������� ������ ������������ �� ������� �������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <param name="criteriumName">��"� �������</param>        
        public int this[string alternativeName, string criteriumName]
        {
            get { return m_alternatives[alternativeName][new Criterium(criteriumName)]; }
            set { m_alternatives[alternativeName][new Criterium(criteriumName)] = value; }
        }
        /// <summary>
        /// ������� ������� ������ ������������ �� ������� �������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <param name="criteriumName">��"� �������</param>        
        public int this[Alternative alternative, string criteriumName]
        {
            get { return m_alternatives[alternative.Name][new Criterium(criteriumName)]; }
            set { m_alternatives[alternative.Name][new Criterium(criteriumName)] = value; }
        }
        /// <summary>
        /// ������� ������� �� ������ ��������
        /// </summary>
        /// <param name="index">������ �� ���� ���� ��"����� 
        /// ��� ������ �� ������� ������� -1.
        /// </param>        
        public Criterium GetCriteriumByIndex(int index)
        {
            if (index < 0) throw new IndexOutOfRangeException("index must be greater than -1");

            int i = 0;
            foreach (Criterium c in m_criteriums.Values)
                if (index == i++) return c;

            throw new IndexOutOfRangeException("index must be less than criteriums count-1");
        }
        /// <summary>
        /// ������� ������������ �� ������ ��������
        /// </summary>
        /// <param name="index">������ �� ���� ���� ��"����� 
        /// ��� ������ �� ������� ����������� -1.
        /// </param>  
        public Alternative GetAlternativeByIndex(int index)
        {
            if (index < 0) throw new IndexOutOfRangeException("index must be greater than -1");

            int i = 0;
            foreach (Alternative a in m_alternatives.Values)
                if (index == i++) return a;

            throw new IndexOutOfRangeException("index must be less than criteriums count-1");
        }
        /// <summary>
        /// ������� null-able ������� �� ��"��.
        /// ���� ������� �� ��������, �� ������� null.
        /// </summary>
        /// <param name="name">��"� �������</param>        
        public Criterium? GetCriteriumByName(string name)
        {
            foreach (Criterium c in m_criteriums.Values)
                if (c.Name == name) return c;
            return null;
        }
        /// <summary>
        /// ������� ������������ �� ��"��.
        /// ���� �� ��������, �� ������� null.
        /// </summary>
        /// <param name="name">��"� ������������</param>        
        public Alternative GetAlternativeByName(string name)
        {
            foreach (Alternative a in m_alternatives.Values)
                if (a.Name == name) return a;

            return null;
        }

        /// <summary>
        /// ʳ������ �����������
        /// </summary>
        public int AlternativesCount
        {
            get { return m_alternatives.Count; }
        }
        /// <summary>
        /// ʳ������ �������
        /// </summary>
        public int CriteriumsCount
        {
            get { return m_criteriums.Count; }
        }

        /// <summary>
        /// ������ ������� � ����������
        /// </summary>
        private void _generateMatrix()
        {
            int[,] matrix = new int[m_alternatives.Keys.Count, m_criteriums.Count];

            int i = 0;
            foreach (Alternative a in m_alternatives.Values)
            {
                int j = 0;
                foreach (Criterium c in m_criteriums.Values)
                {
                    matrix[i, j] = a[c];
                    j++;
                }
                i++;
            }
            Value = new Common.DataTypes.Matrix<int>(matrix);
        }
        /// <summary>
        /// �������� ������������ �� ����������
        /// </summary>
        /// <param name="alternative">������������</param>
        private void _checkAlternativeForConstraints(Alternative alternative)
        {
            string exceptionMessage = "������������ ������ ���������� ������ !";
            if (alternative.CriteriumsCount != m_criteriums.Values.Count)
                throw new AlternativeConstraintException(exceptionMessage);

            foreach (Criterium c in m_criteriums.Values)
                if (!alternative.HasCriterium(c))
                    throw new AlternativeConstraintException(exceptionMessage);

            if (m_alternatives.ContainsKey(alternative.Name))
                throw new AlternativeConstraintException("���� ������������ ��� �������� � ������� !");
        }

        /// <summary>
        /// ������� �� � ������� �� ������, �� ���� �� �� �����.
        /// </summary>
        /// <param name="criteriums">������, �� ��������</param>
        public void SetCriteriums(IEnumerable<Criterium> criteriums)
        {
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.SetCriteriums(criteriums);

            m_criteriums.Clear();
            foreach (Criterium criterium in criteriums)
                m_criteriums.Add(criterium.Name, criterium);
        }
        /// <summary>
        /// ������� �� � ������� �� ������, �� ���� �� �� �����.
        /// </summary>
        /// <param name="criteriums">������, �� ��������</param>
        public void SetCriteriums(IEnumerable<string> criteriums)
        {
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.SetCriteriums(criteriums);

            m_criteriums.Clear();
            foreach (string criterium in criteriums)
                m_criteriums.Add(criterium, new Criterium(criterium));
        }
        /// <summary>
        /// ����� ������� �������.
        /// ������� �� ������������ �� ������.
        /// </summary>
        public void Clear()
        {
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.Clear();

            m_criteriums.Clear();

            Value = new int[0, 0];
            Value.Initialize();
        }

        /// <summary>
        /// ��������, �� ������ ������� ������ �������
        /// </summary>
        /// <param name="criterium">�������</param>        
        public bool HasCriterium(Criterium criterium)
        {
            return m_criteriums.ContainsKey(criterium.Name);
        }
        /// <summary>
        /// ��������, �� ������ ������� ������ �������
        /// </summary>
        /// <param name="criteriumName">��"� �������</param>   
        public bool HasCriterium(string criteriumName)
        {
            return m_criteriums.ContainsKey(criteriumName);
        }
        /// <summary>
        /// ���� �� ������� ������ �������
        /// </summary>
        /// <param name="criterium">�������</param>
        public void AddCriterium(Criterium criterium)
        {
            if (m_criteriums.ContainsKey(criterium.Name)) throw new ArgumentException("����� ������� ��� �������� � ������� !");

            m_criteriums.Add(criterium.Name, criterium);
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.AddCriterium(criterium);

            _generateMatrix();
        }
        /// <summary>
        /// ���� �� ������� ������� � ������ ��"��
        /// </summary>
        /// <param name="criteriumName">��"� �������</param>
        public void AddCriterium(string criteriumName)
        {
            AddCriterium(new Criterium(criteriumName));
        }
        /// <summary>
        /// ������� � ������� ������ �������
        /// </summary>
        /// <param name="criterum">�������</param>
        public void RemoveCriterium(Criterium criterum)
        {
            m_criteriums.Remove(criterum.Name);
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.RemoveCriterium(criterum);

            _generateMatrix();
        }
        /// <summary>
        /// ������� � ������� ������ �������
        /// </summary>
        /// <param name="criteriumName">��"�  �������</param>
        public void RemoveCriterium(string criteriumName)
        {
            RemoveCriterium(new Criterium(criteriumName));
        }

        /// <summary>
        /// ��������, �� � � ������� ������ ������������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <returns>���, ���� �</returns>
        public bool HasAlternative(string alternativeName)
        {
            return m_alternatives.ContainsKey(alternativeName);
        }
        /// <summary>
        /// ���� ������������ �� �������.        
        /// </summary>
        /// <param name="alternative">������������</param>
        public void AddAlternative(Alternative alternative)
        {
            _checkAlternativeForConstraints(alternative);

            m_alternatives.Add(alternative.Name, alternative);

            _generateMatrix();
        }
        /// <summary>
        /// ������� ���� ������������ � ������� ��"�� �� ���� �� �� �������
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        public void AddAlternative(string alternativeName)
        {
            AddAlternative(NewAlternative(alternativeName));
        }
        /// <summary>
        /// ������� ������������ � ������� ��"��
        /// </summary>
        /// <param name="alternative">��"� ������������</param>
        public void RemoveAlternative(string alternative)
        {
            if (m_alternatives.ContainsKey(alternative))
            {
                m_alternatives.Remove(alternative);
                _generateMatrix();
            }
        }
        /// <summary>
        /// ������� ������ ������������
        /// </summary>
        /// <param name="alternative">������������</param>
        public void RemoveAlternative(Alternative alternative)
        {
            if (m_alternatives.ContainsKey(alternative.Name))
            {
                m_alternatives.Remove(alternative.Name);
                _generateMatrix();
            }
        }
        /// <summary>
        /// ������� ���� ������������ � ������� ��"��
        /// </summary>
        /// <param name="alternativeName">��"� ������������</param>
        /// <returns>������������</returns>
        public Alternative NewAlternative(string alternativeName)
        {
            return new Alternative(alternativeName, m_criteriums.Values);
        }

        /// <summary>
        /// ������� �������, �� ��������� ��� ����� ����.
        /// </summary>        
        public override System.Windows.Forms.UserControl GenerateControl()
        {
            ctrlMatrix result = new ctrlMatrix();
            result.Matrix = this;
            return result;
        }

        #region ICloneable Members

        /// <summary>
        /// �������� ����� �������
        /// </summary>        
        public Matrix Clone()
        {
            Matrix clone = new Matrix();
            foreach (KeyValuePair<string, Criterium> pair in m_criteriums)
                clone.m_criteriums.Add(pair.Key, pair.Value);
            foreach (KeyValuePair<string, Alternative> pair in m_alternatives)
                clone.m_alternatives.Add(pair.Key, pair.Value);

            return clone;
        }
        /// <summary>
        /// �������� ����� �������
        /// </summary>        
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
    }
}