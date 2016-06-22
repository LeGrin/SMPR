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
        internal partial class VectorUserControl : UserControl
        {
            private List<object> _objects = new List<object>();
            private Type _genericType;
            public VectorUserControl()
            {
                InitializeComponent();
            }

            public void SetData<T>(T[] arr)
            {
                listBox1.Items.Clear();
                _genericType = typeof(T);
                foreach (T a in arr)
                {
                    _objects.Add(a);
                    listBox1.Items.Add(a.ToString());
                }
            }
            public class ChangeDataEventArgs
            {
                private object[] arr;
                public object[] Data
                { get { return arr; } set { arr = value; } }
                public ChangeDataEventArgs(object[] arrr)
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
                   ChangeDataEvent(this, new ChangeDataEventArgs(_objects.ToArray()));
               }
           }

           private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
           {
               if (listBox1.SelectedIndex == -1) return;
               textBox1.Text = _objects[listBox1.SelectedIndex].ToString();
           }

           private void UpdateButton_Click(object sender, EventArgs e)
           {
               if (listBox1.SelectedIndex == -1) return;               
               object[] args = new object[1];
               args[0] = textBox1.Text;
               object returnValue;
               //| System.Reflection.BindingFlags.Static
               try
               {
                   returnValue = _genericType.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod,
                       null, _objects[0], args);
               }
               catch (Exception ex)
               {
                   MessageBox.Show(string.Format("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле. {0}", ex.Message));
                   return;
               }

               if (!_genericType.IsInstanceOfType(returnValue))
               {
                   MessageBox.Show("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле");
               }
               else
               {
                   _objects[listBox1.SelectedIndex] = returnValue;
                   listBox1.Items[listBox1.SelectedIndex] = returnValue;
               }

           }

           private void AddButton_Click(object sender, EventArgs e)
           {
               //if (listBox1.SelectedIndex == -1) return; 
               object instance = Activator.CreateInstance(_genericType, false);
               if (listBox1.SelectedIndex != -1)
               {
                   _objects.Insert(listBox1.SelectedIndex, instance);
                   listBox1.Items.Insert(listBox1.SelectedIndex, instance);
               }
               else
               {
                   _objects.Add(instance);
                   listBox1.Items.Add(instance);
               }
           }

           private void DeleteButton_Click(object sender, EventArgs e)
           {
               if (listBox1.SelectedIndex == -1) return;
               _objects.RemoveAt(listBox1.SelectedIndex);
               
               int index = listBox1.SelectedIndex;
               
               listBox1.Items.RemoveAt(listBox1.SelectedIndex);
               
               if (index>=listBox1.Items.Count) index = listBox1.Items.Count-1;
               listBox1.SelectedIndex = index;
           }

           private void ClearButton_Click(object sender, EventArgs e)
           {
               _objects.Clear();
               listBox1.Items.Clear();
           }

           private void AcceptButton_Click(object sender, EventArgs e)
           {
               OnChangeData();
           }

            private void button2_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex <= 0) return;
                int index = listBox1.SelectedIndex;
                _objects.Reverse(index - 1, 2);
                object t = listBox1.Items[index - 1];
                listBox1.Items.RemoveAt(index - 1);
                listBox1.Items.Insert(index, t);
                listBox1.SelectedIndex = index - 1;
            }

            private void button1_Click(object sender, EventArgs e)
            {
                if ((listBox1.SelectedIndex == -1) || (listBox1.SelectedIndex == listBox1.Items.Count - 1)) return;
                int index = listBox1.SelectedIndex;
                _objects.Reverse(index, 2);
                object t = listBox1.Items[index];
                listBox1.Items.RemoveAt(index);
                listBox1.Items.Insert(index+1, t);
                listBox1.SelectedIndex = index + 1;
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex == -1) return;
                object[] args = new object[1];
                args[0] = textBox1.Text;
                object returnValue;
                //| System.Reflection.BindingFlags.Static
                try
                {
                    returnValue = _genericType.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod,
                        null, _objects[0], args);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле. {0}", ex.Message));
                    return;
                }

                if (!_genericType.IsInstanceOfType(returnValue))
                {
                    MessageBox.Show("Неможливо пропарсити данні. Можливо ви не правильно ввели данні в поле");
                }
                else
                {
                    _objects[listBox1.SelectedIndex] = returnValue;
                    listBox1.Items[listBox1.SelectedIndex] = returnValue;
                }
            }

            private void textBox1_Validating(object sender, CancelEventArgs e)
            {

            }

            private void button3_Click(object sender, EventArgs e)
            {
                ParsablePointD point = ParsablePointD.Parse(textBox1.Text);
                MessageBox.Show(point.ToString());
            }
        }
    }
}