using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    /// <summary>
    /// ����������� ����� ������������
    /// </summary>    
    internal class Alternative
    {
        #region Object overrides, operator overloads(using base implementation yet)

        /// <summary>
        /// ������� ��� ������ ��"����
        /// </summary>        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// �������� �� �������������.
        /// (������� ��������� object.Equals, ����� �������� ��� �� ������)
        /// </summary>
        /// <param name="obj">����� ��"���</param>        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// ��������� �� ������.
        /// (������������ �� ������)
        /// </summary>                
        public static bool operator ==(Alternative a1, Alternative a2)
        {
            return a1 != null ? a1.Equals(a2) : a2 == null;
        }
        /// <summary>
        /// �������� �� ��������.
        /// (������������ �� ������)
        /// </summary>                
        public static bool operator !=(Alternative a1, Alternative a2)
        {
            return a1 != null ? !a1.Equals(a2) : a2 != null;
        }

        /// <summary>
        /// ������� �������� ������������� ��"����
        /// </summary>        
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder(1024);
            strBuilder.AppendFormat("������������ '{0}'. ������: ");

            foreach (KeyValuePair<Criterium, int> pair in _criteriums)
                strBuilder.AppendFormat("{0}={1}, ", pair.Key, pair.Value);

            strBuilder.Append(".");

            return strBuilder.ToString();
        }

        #endregion

        private readonly Dictionary<Criterium, int> _criteriums = new Dictionary<Criterium, int>();

        /// <summary>
        /// ��"�
        /// </summary>
        private string _name = string.Empty;
        /// <summary>
        /// ��"� ������������
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// ������, �� ������ ������������
        /// </summary>
        public IEnumerable<Criterium> Criteriums
        {
            get { return _criteriums.Keys; }
        }
        /// <summary>
        /// ������ ������� �������, �� ������ ���� ������������
        /// </summary>
        public int CriteriumsCount
        {
            get { return _criteriums.Keys.Count; }
        }

        /// <summary>
        /// ������� ������� ������������ �� ������ �������
        /// </summary>
        /// <param name="c">�������</param>
        /// <returns>������� ������������ �� ������ �������</returns>
        public int this[Criterium c]
        {
            get { return _criteriums[c]; }
            set { _criteriums[c] = value; }
        }
        /// <summary>
        /// ������� ������� ������������ �� ������ �������
        /// </summary>
        /// <param name="c">�������</param>
        /// <returns>������� ������������ �� ������ �������</returns>
        public int this[string criterium]
        {
            get { return _criteriums[new Criterium(criterium)]; }
            set { _criteriums[new Criterium(criterium)] = value; }
        }

        private Alternative()
        { }
        /// <summary>
        /// ������� ������������
        /// </summary>
        /// <param name="name">��"�</param>
        public Alternative(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            _name = name;
        }
        /// <summary>
        /// ������� ������������
        /// </summary>
        /// <param name="name">��"�</param>
        /// <param name="criteriums">������ �������</param>
        public Alternative(string name, IEnumerable<Criterium> criteriums)
            : this(name)
        {
            if (criteriums == null) throw new ArgumentNullException("criteriums");

            try
            {
                foreach (Criterium c in criteriums)
                    _criteriums.Add(c, 0);
            }
            catch (ArgumentException a_exc)
            {
                throw new ArgumentException("������ ������ ���� ����������", "criteriums", a_exc);
            }
        }

        /// <summary>
        /// ������� ���, ���� ������������ ������ ������� �������        
        /// </summary>
        /// <param name="criterium">�������</param>        
        public bool HasCriterium(Criterium criterium)
        {
            return _criteriums.ContainsKey(criterium);
        }
        /// <summary>
        /// ������� ���, ���� ������������ ������ ������� �������        
        /// </summary>
        /// <param name="criterium">�������</param>        
        public bool HasCriterium(string criterium)
        {
            return _criteriums.ContainsKey(new Criterium(criterium));
        }

        /// <summary>
        /// ���� �� ������������ �������
        /// </summary>
        /// <param name="c">�������</param>
        /// <param name="value">��������</param>
        public void AddCriterium(Criterium c, int value)
        {
            _criteriums.Add(c, value);
        }
        /// <summary>
        /// ���� �� ������������ ������� � �������� ���������
        /// </summary>
        /// <param name="c">�������</param>
        public void AddCriterium(Criterium c)
        {
            _criteriums.Add(c, 0);
        }
        /// <summary>
        /// ���� �� ������������ �������
        /// </summary>
        /// <param name="c">�������</param>
        /// <param name="value">��������</param>
        public void AddCriterium(string c, int value)
        {
            _criteriums.Add(new Criterium(c), value);
        }
        /// <summary>
        /// ���� �� ������������ ������� � �������� ���������
        /// </summary>
        /// <param name="c">�������</param>
        public void AddCriterium(string c)
        {
            _criteriums.Add(new Criterium(c), 0);
        }

        /// <summary>
        /// ������� � ������������ �������(���� ����� ����)
        /// </summary>
        /// <param name="c">�������</param>
        public void RemoveCriterium(Criterium c)
        {
            _criteriums.Remove(c);
        }
        /// <summary>
        /// ������� � ������������ �������(���� ����� ����)
        /// </summary>
        /// <param name="c">�������</param>
        public void RemoveCriterium(string c)
        {
            _criteriums.Remove(new Criterium(c));
        }

        /// <summary>
        /// ����� ������ �������� � ����������� �������, �� �������� ����� ������, ��� � ��������� ����������
        /// </summary>
        /// <param name="criteriums">������ �������</param>
        public void SetCriteriums(IEnumerable<Criterium> criteriums)
        {
            _criteriums.Clear();
            try
            {
                foreach (Criterium c in criteriums)
                    _criteriums.Add(c, 0);
            }
            catch (ArgumentException a_exc)
            {
                throw new ArgumentException("������ ������ ���� ����������", "criteriums", a_exc);
            }
        }
        /// <summary>
        /// ����� ������ �������� � ����������� �������, �� �������� ����� ������, ��� � ��������� ����������
        /// </summary>
        /// <param name="criteriums">������ �������</param>
        public void SetCriteriums(IEnumerable<string> criteriums)
        {
            _criteriums.Clear();
            try
            {
                foreach (string c in criteriums)
                    _criteriums.Add(new Criterium(c), 0);
            }
            catch (ArgumentException a_exc)
            {
                throw new ArgumentException("������ ������ ���� ����������", "criteriums", a_exc);
            }
        }

        /// <summary>
        /// ������� �� ������
        /// </summary>
        public void Clear()
        {
            _criteriums.Clear();
        }
    }
}