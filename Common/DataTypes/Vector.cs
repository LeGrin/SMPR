using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace Common
{
    namespace DataTypes
    {
        /// <summary>
        /// Базовий клас-вектор
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Serializable]
        public class Vector<T> : BufferData
        {
            private T[] value;

            /// <summary>
            /// Value of data-type
            /// </summary>
            public T[] Value
            {
                get { return value; }
                set { this.value = value; }
            }

            /// <summary>
            /// Конструктор вектора
            /// </summary>
            /// <param name="field">елементи вектора</param>
            public Vector(params T[] field)
            {
                value = field;
            }
            public Vector()
                : this(default(T))
            {

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index">індекс елемента вектора</param>
            /// <returns>заданий елмент вектора</returns>
            public T this[int index]
            {
                get { return value[index]; }
                set { this.value[index] = value; }
            }
            public override System.Windows.Forms.UserControl GenerateControl()
            {
                VectorUserControl control = new VectorUserControl();
                control.ChangeDataEvent += control_ChangeDataEvent;
                control.SetData<T>(value);
                return control;
            }

            void control_ChangeDataEvent(object sender, VectorUserControl.ChangeDataEventArgs e)
            {
                List<T> list = new List<T>();
                foreach (object o in e.Data)
                {
                    list.Add((T)o);
                }
                value = list.ToArray();
                OnChangeOccured();
            }

            public override System.Drawing.Image Icon
            {
                get { return Resources.DataTypeVector; }
            }


            public static implicit operator T[](Vector<T> s)
            {
                return s.value;
            }
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append('(');
                foreach (T a in value)
                {
                    if (builder.Length != 1) builder.Append(',');
                    builder.Append(a.ToString());
                }

                builder.Append(')');
                return builder.ToString();
            }

        }
    }
}