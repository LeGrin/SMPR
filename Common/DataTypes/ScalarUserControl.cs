using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace Common
{
    namespace DataTypes
    {
        internal partial class ScalarUserControl : UserControl
        {
            private object _value;
            private Type _genericType;
            public ScalarUserControl()
            {
                InitializeComponent();
            }

            public void SetData<T>(T a)
            {
                _value = a;
                _genericType = a.GetType();
                textBox1.Text = a.ToString();
            }

            #region OnChange event
            public class ChangeDataEventArgs
            {
                private object arr;
                public object Data
                { get { return arr; } set { arr = value; } }
                public ChangeDataEventArgs(object arrr)
                {
                    arr = arrr;
                }
            }

            public delegate void ChangeDataDelegate(object sender, ChangeDataEventArgs e);
            public event ChangeDataDelegate ChangeDataEvent;
            private void OnChangeData()
            {
                if (ChangeDataEvent != null)
                {
                    ChangeDataEvent(this, new ChangeDataEventArgs(_value));
                }
            }
            #endregion

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                object[] args = new object[1];
                args[0] = textBox1.Text;
                object returnValue;
                //| System.Reflection.BindingFlags.Static
                try
                {
                    returnValue = _genericType.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod,
                        null, _value, args);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле. {0}", ex.Message));
                    return;
                }
                _value = returnValue;
            }

            private void button1_Click(object sender, EventArgs e)
            {
                OnChangeData();
            }
        }
    }
}