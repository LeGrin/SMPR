using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Singleton-класс, що реалізує буфер обміну даними між модулями
    /// </summary>
    [Serializable]
    public class DataBuffer
    {
        protected DataBuffer()
        {
            value = new Dictionary<string, BufferData>();

            //test
            value.Add("Vector", new Vector<int>(1, 2, 3));
            value.Add("Scalar", new Scalar<char>('c'));
            value.Add("Matrix", new Matrix<int>(new int[,] { { 1, 2 }, { 3, 4 } }));
        }

        private Dictionary<string, BufferData> value;

        static DataBuffer instance;

        /// <summary>
        /// Власне буфер
        /// </summary>
        public static DataBuffer Instance
        {
            get
            {
                if (instance == null) instance = new DataBuffer();
                return instance;
            }
        }

        public void SerializeData(string path)
        {
            foreach(BufferData bd in value.Values)
            {
                bd.ClearEvent();
            }

            Stream fStream = new FileStream(path, FileMode.Create);
            IFormatter bfmtr = new BinaryFormatter();
            foreach (BufferData bd in DataBuffer.Instance.value.Values)
            {                
                bd.ClearEvent();              
            }
            bfmtr.Serialize(fStream, DataBuffer.Instance.value);
            fStream.Close();
        }

        public void DeserializeData(string path)
        {
            Stream fStream = new FileStream(path, FileMode.Open);
            IFormatter bfmtr = new BinaryFormatter();
            Dictionary<string, BufferData> loadedData = (Dictionary<string, BufferData>)bfmtr.Deserialize(fStream);
            foreach (string s in loadedData.Keys)
            {
                if (!value.ContainsKey(s))
                {
                    value.Add(s, loadedData[s]);
                }
            }
            fStream.Close();            
        }

        public bool AddData(string name, BufferData el)
        {
            if (value.ContainsKey(name))
            {
                return false;
            }
            else
            {
                value.Add(name, el);                
            }
            return true;
        }

        public void RemoveData(string name)
        {
            if (value.ContainsKey(name))
            {
                value.Remove(name);
            }
        }

        /// <summary>
        /// Заносить новий обєкт до буферу
        /// </summary>
        /// <param name="name">імя обєкту</param>
        /// <param name="obj">обєкт</param>
        public void Save(string name, BufferData obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            if (name == null)
                throw new ArgumentNullException("name");

            if (value.ContainsKey(name))
            {
                value.Remove(name);
            }
            value.Add(name, obj);
        }

        /// <summary>
        /// Викликає діалог для збереження нового обєкту
        /// </summary>
        /// <param name="obj">обєкт, що заноситься до буфера</param>
        public void SaveDialog(BufferData obj)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");

            frmSelectBufferData frm_load = new frmSelectBufferData(true, null);

            if (frm_load.ShowDialog() == DialogResult.OK)
            {
                Save(frm_load.SaveName, obj);
            }
        }

        /// <summary>
        /// Перевіряє дані буферу на те, чи можна їх використати.
        /// Зручно використовувати для завантаження данних з буферу, які повинні
        /// задовільняти якусь властивість (наприклад, бути матрицею певної розмірності)
        /// </summary>
        /// <param name="obj">масив обєктів</param>
        /// <returns>тру, якщо всі обєкти сумісні</returns>
        public delegate bool ValidationCallback(BufferData obj);

        /// <summary>
        /// Обчислює хеш-код делегата
        /// </summary>
        /// <param name="validator">делегат</param>
        /// <returns>хеш-код</returns>
        private int getValidationDelegateHashCode(ValidationCallback validator)
        {
            return validator.Method.MetadataToken;
        }

        /// <summary>
        /// Викликає діалог вибору обєкту з буфера з перевіркою його валідності
        /// </summary>
        /// <param name="validator">валідатор обєктів</param>
        /// <returns>тру, якщо був обраний валідний обєкт</returns>        
        public BufferData LoadDialog(ValidationCallback validator)
        {
            //validator = delegate(BufferData obj) { return obj.ToString().Length>7 ;};

            frmSelectBufferData frm_load = new frmSelectBufferData(validator);

            if (frm_load.ShowDialog() == DialogResult.OK)
            {
                BufferData selectedBd = Load(frm_load.SelectedName);
                if (validator == null)
                {
                    return selectedBd;
                }
                else
                {
                    int valKey = getValidationDelegateHashCode(validator);
                    if (selectedBd.ValidatorsResults.ContainsKey(valKey) &&
                        selectedBd.ValidatorsResults[valKey])
                    {
                        return selectedBd;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Викликає діалог вибору обєкту з буфера
        /// </summary>
        /// <returns></returns>
        public BufferData LoadDialog()
        {
            return LoadDialog(null);
        }

        /// <summary>
        /// Вибирає обєкт з буферу
        /// </summary>
        /// <param name="name">імя обєкту</param>
        /// <returns>обєкт із заданим імям, якщо такий було знайдено</returns>
        public BufferData Load(string name)
        {
            BufferData res;
            value.TryGetValue(name, out res);
            return res;
        }

        internal void FillData(frmSelectBufferData load_form, string elName)
        {
            BufferData bd;
            if (!value.TryGetValue(elName, out bd))
                return;
        }

        /// <summary>
        /// Заповнює форму для роботи з буфером даними з буфера
        /// </summary>
        /// <param name="load_form">форма для заповнення</param>
        internal void FillData(frmSelectBufferData load_form)
        {
            foreach (string k in value.Keys)
            {
                BufferData bd;
                value.TryGetValue(k, out bd);

                if (bd != null)
                {
                    if (load_form.Validator != null)
                    {
                        int valKey = getValidationDelegateHashCode(load_form.Validator);
                        bool valRes;

                        if (bd.ValidatorsResults.ContainsKey(valKey))
                        {
                            valRes = bd.ValidatorsResults[valKey];
                        }
                        else
                        {
                            //testing
                            //MessageBox.Show("Validating " + bd.ToString() + " with " + valKey);
                            valRes = load_form.Validator(bd);
                            bd.ValidatorsResults.Add(valKey, valRes);
                        }

                        load_form.AddData(valRes, k, bd.Icon, bd.ToString());
                    }
                    else
                    {
                        load_form.AddData(k, bd.Icon, bd.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Шукає обєкт із зідіним імям у буфері
        /// </summary>
        /// <param name="name">імя обєкту</param>
        /// <returns>тру, якщо обєкт існує</returns>
        internal bool KeyExists(string name)
        {
            return value.ContainsKey(name);
        }

        /// <summary>
        /// Перейменування обєкту з буфера
        /// </summary>
        /// <param name="oldName">старе імя</param>
        /// <param name="newName">нове імя</param>
        internal void ChangeName(string oldName, string newName)
        {
            BufferData tempBd;
            if (oldName != newName && value.TryGetValue(oldName, out tempBd))
            {
                value.Remove(oldName);
                value.Add(newName, tempBd);
            }
        }
    }
}
