using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    /// <summary>
    /// Представляє собою альтернативу
    /// </summary>    
    internal class Alternative
    {
        #region Object overrides, operator overloads(using base implementation yet)

        /// <summary>
        /// Повертає хеш даного об"екту
        /// </summary>        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Перевірка на еквівалентність.
        /// (Викликає реалізацію object.Equals, тобто перевірка йде по ссилці)
        /// </summary>
        /// <param name="obj">Інший об"єкт</param>        
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Перевырка на рівність.
        /// (Перевіряється по ссилці)
        /// </summary>                
        public static bool operator ==(Alternative a1, Alternative a2)
        {
            return a1 != null ? a1.Equals(a2) : a2 == null;
        }
        /// <summary>
        /// Перевірка на нерівність.
        /// (Перевіряється по ссилці)
        /// </summary>                
        public static bool operator !=(Alternative a1, Alternative a2)
        {
            return a1 != null ? !a1.Equals(a2) : a2 != null;
        }

        /// <summary>
        /// Повертає стрінгове представлення об"екту
        /// </summary>        
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder(1024);
            strBuilder.AppendFormat("Альтернатива '{0}'. Критерії: ");

            foreach (KeyValuePair<Criterium, int> pair in _criteriums)
                strBuilder.AppendFormat("{0}={1}, ", pair.Key, pair.Value);

            strBuilder.Append(".");

            return strBuilder.ToString();
        }

        #endregion

        private readonly Dictionary<Criterium, int> _criteriums = new Dictionary<Criterium, int>();

        /// <summary>
        /// Ім"я
        /// </summary>
        private string _name = string.Empty;
        /// <summary>
        /// Ім"я альтернативи
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Критерії, що містить альтернатива
        /// </summary>
        public IEnumerable<Criterium> Criteriums
        {
            get { return _criteriums.Keys; }
        }
        /// <summary>
        /// Повртає кількість критеріїв, що містить дана альтернатива
        /// </summary>
        public int CriteriumsCount
        {
            get { return _criteriums.Keys.Count; }
        }

        /// <summary>
        /// Повертає цінність альтернативи за деяким критерієм
        /// </summary>
        /// <param name="c">Критерій</param>
        /// <returns>цінність альтернативи за деяким критерієм</returns>
        public int this[Criterium c]
        {
            get { return _criteriums[c]; }
            set { _criteriums[c] = value; }
        }
        /// <summary>
        /// Повертає цінність альтернативи за деяким критерієм
        /// </summary>
        /// <param name="c">Критерій</param>
        /// <returns>цінність альтернативи за деяким критерієм</returns>
        public int this[string criterium]
        {
            get { return _criteriums[new Criterium(criterium)]; }
            set { _criteriums[new Criterium(criterium)] = value; }
        }

        private Alternative()
        { }
        /// <summary>
        /// Створюэ альтернативу
        /// </summary>
        /// <param name="name">Ім"я</param>
        public Alternative(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            _name = name;
        }
        /// <summary>
        /// Створюэ альтернативу
        /// </summary>
        /// <param name="name">Ім"я</param>
        /// <param name="criteriums">Список критеріїв</param>
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
                throw new ArgumentException("Критерії повинні бути унікальними", "criteriums", a_exc);
            }
        }

        /// <summary>
        /// Повертає тру, якщо альтернатива містить заданий критерій        
        /// </summary>
        /// <param name="criterium">Критерій</param>        
        public bool HasCriterium(Criterium criterium)
        {
            return _criteriums.ContainsKey(criterium);
        }
        /// <summary>
        /// Повертає тру, якщо альтернатива містить заданий критерій        
        /// </summary>
        /// <param name="criterium">Критерій</param>        
        public bool HasCriterium(string criterium)
        {
            return _criteriums.ContainsKey(new Criterium(criterium));
        }

        /// <summary>
        /// Додає до альтернативи критерій
        /// </summary>
        /// <param name="c">Критерій</param>
        /// <param name="value">Значення</param>
        public void AddCriterium(Criterium c, int value)
        {
            _criteriums.Add(c, value);
        }
        /// <summary>
        /// Додає до альтернативи критерій з нульовим значенням
        /// </summary>
        /// <param name="c">Критерій</param>
        public void AddCriterium(Criterium c)
        {
            _criteriums.Add(c, 0);
        }
        /// <summary>
        /// Додає до альтернативи критерій
        /// </summary>
        /// <param name="c">Критерій</param>
        /// <param name="value">Значення</param>
        public void AddCriterium(string c, int value)
        {
            _criteriums.Add(new Criterium(c), value);
        }
        /// <summary>
        /// Додає до альтернативи критерій з нульовим значенням
        /// </summary>
        /// <param name="c">Критерій</param>
        public void AddCriterium(string c)
        {
            _criteriums.Add(new Criterium(c), 0);
        }

        /// <summary>
        /// Видаляє з альтернативи критерій(якщо такий існує)
        /// </summary>
        /// <param name="c">Критерій</param>
        public void RemoveCriterium(Criterium c)
        {
            _criteriums.Remove(c);
        }
        /// <summary>
        /// Видаляє з альтернативи критерій(якщо такий існує)
        /// </summary>
        /// <param name="c">Критерій</param>
        public void RemoveCriterium(string c)
        {
            _criteriums.Remove(new Criterium(c));
        }

        /// <summary>
        /// Очищує список існуючих в альтернативі критеріїв, та присвоює новий список, але з нульовими значеннями
        /// </summary>
        /// <param name="criteriums">Список критеріїв</param>
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
                throw new ArgumentException("Критерії повинні бути унікальними", "criteriums", a_exc);
            }
        }
        /// <summary>
        /// Очищує список існуючих в альтернативі критеріїв, та присвоює новий список, але з нульовими значеннями
        /// </summary>
        /// <param name="criteriums">Список критеріїв</param>
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
                throw new ArgumentException("Критерії повинні бути унікальними", "criteriums", a_exc);
            }
        }

        /// <summary>
        /// Видаляє всі критерії
        /// </summary>
        public void Clear()
        {
            _criteriums.Clear();
        }
    }
}