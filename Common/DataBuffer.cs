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
    /// Singleton-�����, �� ������ ����� ����� ������ �� ��������
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
        /// ������ �����
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
        /// �������� ����� ���� �� ������
        /// </summary>
        /// <param name="name">��� �����</param>
        /// <param name="obj">����</param>
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
        /// ������� ����� ��� ���������� ������ �����
        /// </summary>
        /// <param name="obj">����, �� ���������� �� ������</param>
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
        /// �������� ��� ������ �� ��, �� ����� �� �����������.
        /// ������ ��������������� ��� ������������ ������ � ������, �� ������
        /// ����������� ����� ���������� (���������, ���� �������� ����� ���������)
        /// </summary>
        /// <param name="obj">����� �����</param>
        /// <returns>���, ���� �� ����� �����</returns>
        public delegate bool ValidationCallback(BufferData obj);

        /// <summary>
        /// �������� ���-��� ��������
        /// </summary>
        /// <param name="validator">�������</param>
        /// <returns>���-���</returns>
        private int getValidationDelegateHashCode(ValidationCallback validator)
        {
            return validator.Method.MetadataToken;
        }

        /// <summary>
        /// ������� ����� ������ ����� � ������ � ��������� ���� ��������
        /// </summary>
        /// <param name="validator">�������� �����</param>
        /// <returns>���, ���� ��� ������� ������� ����</returns>        
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
        /// ������� ����� ������ ����� � ������
        /// </summary>
        /// <returns></returns>
        public BufferData LoadDialog()
        {
            return LoadDialog(null);
        }

        /// <summary>
        /// ������ ���� � ������
        /// </summary>
        /// <param name="name">��� �����</param>
        /// <returns>���� �� ������� ����, ���� ����� ���� ��������</returns>
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
        /// �������� ����� ��� ������ � ������� ������ � ������
        /// </summary>
        /// <param name="load_form">����� ��� ����������</param>
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
        /// ���� ���� �� ����� ���� � �����
        /// </summary>
        /// <param name="name">��� �����</param>
        /// <returns>���, ���� ���� ����</returns>
        internal bool KeyExists(string name)
        {
            return value.ContainsKey(name);
        }

        /// <summary>
        /// �������������� ����� � ������
        /// </summary>
        /// <param name="oldName">����� ���</param>
        /// <param name="newName">���� ���</param>
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
