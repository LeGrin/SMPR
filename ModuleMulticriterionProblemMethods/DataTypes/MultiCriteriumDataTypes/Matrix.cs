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
        /// Альтернативи
        /// </summary>
        public IEnumerable<Alternative> Alternatives
        {
            get { return m_alternatives.Values; }
        }
        /// <summary>
        /// Критерії
        /// </summary>
        public IEnumerable<Criterium> Criteriums
        {
            get { return m_criteriums.Values; }
        }

        /// <summary>
        /// Повертає цінність заданої альтернативи за заданим критерієм
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <param name="criterium">Критерій</param>        
        public int this[string alternativeName, Criterium criterium]
        {
            get { return m_alternatives[alternativeName][criterium]; }
            set { m_alternatives[alternativeName][criterium] = value; }
        }
        /// <summary>
        /// Повертає цінність заданої альтернативи за заданим критерієм
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <param name="criterium">Критерій</param>        
        public int this[Alternative alternative, Criterium criterium]
        {
            get { return m_alternatives[alternative.Name][criterium]; }
            set { m_alternatives[alternative.Name][criterium] = value; }
        }
        /// <summary>
        /// Повертає цінність заданої альтернативи за заданим критерієм
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <param name="criteriumName">Ім"я критерію</param>        
        public int this[string alternativeName, string criteriumName]
        {
            get { return m_alternatives[alternativeName][new Criterium(criteriumName)]; }
            set { m_alternatives[alternativeName][new Criterium(criteriumName)] = value; }
        }
        /// <summary>
        /// Повертає цінність заданої альтернативи за заданим критерієм
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <param name="criteriumName">Ім"я критерію</param>        
        public int this[Alternative alternative, string criteriumName]
        {
            get { return m_alternatives[alternative.Name][new Criterium(criteriumName)]; }
            set { m_alternatives[alternative.Name][new Criterium(criteriumName)] = value; }
        }
        /// <summary>
        /// Повертає критерій за деяким індексом
        /// </summary>
        /// <param name="index">Індекс не може бути від"ємним 
        /// або більшим за кількість критеріїв -1.
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
        /// Повертає альтернативу за деяким індексом
        /// </summary>
        /// <param name="index">Індекс не може бути від"ємним 
        /// або більшим за кількість альтернатив -1.
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
        /// Повертає null-able критерій за ім"ям.
        /// Якщо критерію не знайдено, то повертає null.
        /// </summary>
        /// <param name="name">Ім"я критерію</param>        
        public Criterium? GetCriteriumByName(string name)
        {
            foreach (Criterium c in m_criteriums.Values)
                if (c.Name == name) return c;
            return null;
        }
        /// <summary>
        /// Повертає альтернативу за ім"ям.
        /// Якщо не знайдено, то повертає null.
        /// </summary>
        /// <param name="name">Ім"я альтернативи</param>        
        public Alternative GetAlternativeByName(string name)
        {
            foreach (Alternative a in m_alternatives.Values)
                if (a.Name == name) return a;

            return null;
        }

        /// <summary>
        /// Кількість альтернатив
        /// </summary>
        public int AlternativesCount
        {
            get { return m_alternatives.Count; }
        }
        /// <summary>
        /// Кількість критеріїв
        /// </summary>
        public int CriteriumsCount
        {
            get { return m_criteriums.Count; }
        }

        /// <summary>
        /// Генерує матрицю зі значеннями
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
        /// Перевірка альтернативи на коректність
        /// </summary>
        /// <param name="alternative">Альтернатива</param>
        private void _checkAlternativeForConstraints(Alternative alternative)
        {
            string exceptionMessage = "Альтернатива містить недопустимі критерії !";
            if (alternative.CriteriumsCount != m_criteriums.Values.Count)
                throw new AlternativeConstraintException(exceptionMessage);

            foreach (Criterium c in m_criteriums.Values)
                if (!alternative.HasCriterium(c))
                    throw new AlternativeConstraintException(exceptionMessage);

            if (m_alternatives.ContainsKey(alternative.Name))
                throw new AlternativeConstraintException("Дана альтернатива вже міститься в матриці !");
        }

        /// <summary>
        /// Видаляє всі з матриці всі критерії, та додає до неї задані.
        /// </summary>
        /// <param name="criteriums">Критерії, що додається</param>
        public void SetCriteriums(IEnumerable<Criterium> criteriums)
        {
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.SetCriteriums(criteriums);

            m_criteriums.Clear();
            foreach (Criterium criterium in criteriums)
                m_criteriums.Add(criterium.Name, criterium);
        }
        /// <summary>
        /// Видаляє всі з матриці всі критерії, та додає до неї задані.
        /// </summary>
        /// <param name="criteriums">Критерії, що додається</param>
        public void SetCriteriums(IEnumerable<string> criteriums)
        {
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.SetCriteriums(criteriums);

            m_criteriums.Clear();
            foreach (string criterium in criteriums)
                m_criteriums.Add(criterium, new Criterium(criterium));
        }
        /// <summary>
        /// Повна очистка матриці.
        /// Видаляє всі альтернативи та критерії.
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
        /// Перевіряє, чи містить матриця деякий критерій
        /// </summary>
        /// <param name="criterium">Критерій</param>        
        public bool HasCriterium(Criterium criterium)
        {
            return m_criteriums.ContainsKey(criterium.Name);
        }
        /// <summary>
        /// Перевіряє, чи містить матриця деякий критерій
        /// </summary>
        /// <param name="criteriumName">Ім"я критерію</param>   
        public bool HasCriterium(string criteriumName)
        {
            return m_criteriums.ContainsKey(criteriumName);
        }
        /// <summary>
        /// Додає до матриці деякий критерій
        /// </summary>
        /// <param name="criterium">Критерій</param>
        public void AddCriterium(Criterium criterium)
        {
            if (m_criteriums.ContainsKey(criterium.Name)) throw new ArgumentException("Даний критерій вже міститься в матриці !");

            m_criteriums.Add(criterium.Name, criterium);
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.AddCriterium(criterium);

            _generateMatrix();
        }
        /// <summary>
        /// Додає до матриці критерій з деяким ім"ям
        /// </summary>
        /// <param name="criteriumName">Ім"я критерію</param>
        public void AddCriterium(string criteriumName)
        {
            AddCriterium(new Criterium(criteriumName));
        }
        /// <summary>
        /// Видаляє з матриці деякий критерій
        /// </summary>
        /// <param name="criterum">Критерій</param>
        public void RemoveCriterium(Criterium criterum)
        {
            m_criteriums.Remove(criterum.Name);
            foreach (Alternative alternative in m_alternatives.Values)
                alternative.RemoveCriterium(criterum);

            _generateMatrix();
        }
        /// <summary>
        /// Видаляє з матриці деякий критерій
        /// </summary>
        /// <param name="criteriumName">Ім"я  критерію</param>
        public void RemoveCriterium(string criteriumName)
        {
            RemoveCriterium(new Criterium(criteriumName));
        }

        /// <summary>
        /// Перевіряє, чи є в матриці задана альтернатива
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <returns>тру, якщо є</returns>
        public bool HasAlternative(string alternativeName)
        {
            return m_alternatives.ContainsKey(alternativeName);
        }
        /// <summary>
        /// Додає альтернативу до матриці.        
        /// </summary>
        /// <param name="alternative">Альтернатива</param>
        public void AddAlternative(Alternative alternative)
        {
            _checkAlternativeForConstraints(alternative);

            m_alternatives.Add(alternative.Name, alternative);

            _generateMatrix();
        }
        /// <summary>
        /// Створює нову альтернативу з заданим ім"ям та додає її до матриці
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        public void AddAlternative(string alternativeName)
        {
            AddAlternative(NewAlternative(alternativeName));
        }
        /// <summary>
        /// Видаляю альтернативу з заданим ім"ям
        /// </summary>
        /// <param name="alternative">Ім"я альтернативи</param>
        public void RemoveAlternative(string alternative)
        {
            if (m_alternatives.ContainsKey(alternative))
            {
                m_alternatives.Remove(alternative);
                _generateMatrix();
            }
        }
        /// <summary>
        /// Видаляє задану альтернативу
        /// </summary>
        /// <param name="alternative">Альтернатива</param>
        public void RemoveAlternative(Alternative alternative)
        {
            if (m_alternatives.ContainsKey(alternative.Name))
            {
                m_alternatives.Remove(alternative.Name);
                _generateMatrix();
            }
        }
        /// <summary>
        /// Створює нову альтернативу з заданим ім"ям
        /// </summary>
        /// <param name="alternativeName">Ім"я альтернативи</param>
        /// <returns>Альтернатива</returns>
        public Alternative NewAlternative(string alternativeName)
        {
            return new Alternative(alternativeName, m_criteriums.Values);
        }

        /// <summary>
        /// Генеруэ контрол, що выдображає дані чього типу.
        /// </summary>        
        public override System.Windows.Forms.UserControl GenerateControl()
        {
            ctrlMatrix result = new ctrlMatrix();
            result.Matrix = this;
            return result;
        }

        #region ICloneable Members

        /// <summary>
        /// Повертаэ копыю матриці
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
        /// Повертаэ копыю матриці
        /// </summary>        
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
    }
}