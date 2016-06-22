using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    namespace DataTypes
    {
        /// <summary>
        /// Базовий клас-скаляр
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Serializable]
        public class Scalar<T> : BufferData
        {
            private T value;

            /// <summary>
            /// Дане скаляра
            /// </summary>
            public T Value
            {
                get { return value; }
                set { this.value = value; }
            }

            public Scalar(T field)
            {
                value = field;
            }
            public Scalar()
            {
                value = default(T);
            }

            public override System.Windows.Forms.UserControl GenerateControl()
            {
                ScalarUserControl control = new ScalarUserControl();
                control.ChangeDataEvent += control_ChangeDataEvent;
                control.SetData(value);
                return control;
            }

            void control_ChangeDataEvent(object sender, ScalarUserControl.ChangeDataEventArgs e)
            {
                value = (T)e.Data;
                OnChangeOccured();
            }

            public override System.Drawing.Image Icon
            {
                get { return Resources.DataTypeScalar; }
            }

            public static implicit operator T(Scalar<T> s)
            {
                return s.value;
            }
            public override string ToString()
            {
                return value.ToString();
            }
           

        }
    }
}