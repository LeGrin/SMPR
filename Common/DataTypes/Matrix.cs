using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    namespace DataTypes
    {
        /// <summary>
        /// Базовий тип - матриця
        /// </summary>
        /// <typeparam name="T"></typeparam>
        [Serializable]
        public class Matrix<T> : BufferData
        {
            private T[,] value;

            /// <summary>
            /// Value of data-type
            /// </summary>
            public T[,] Value
            {
                get { return value; }
                set { this.value = value; }
            }

            public Matrix(T[,] field)
            {
                value = field;
            }
            public Matrix()
            {
                value = new T[1, 1];
                value[0, 0] = default(T);
            }
            public T this[int x, int y]
            {
                get { return value[x, y]; }
                set { this.value[x, y] = value; }
            }

            public int RowCount
            {
                get { return value.GetLength(0); }
            }

            public int ColumnCount
            {
                get { return value.GetLength(1); }
            }

            public override System.Windows.Forms.UserControl GenerateControl()
            {
                MatrixUserControl control = new MatrixUserControl();

                control.ChangeDataEvent += control_ChangeDataEvent;
                control.SetData<T>(default(T).ToString(),value);
                return control;
            }

            void control_ChangeDataEvent(object sender, MatrixUserControl.ChangeDataEventArgs e)
            {
                value = new T[e.Data.GetLength(0), e.Data.GetLength(1)];
                for (int i = 0; i<e.Data.GetLength(0); i++)
                {
                    for (int j = 0; j < e.Data.GetLength(1); j++)
                    {
                        
                        object[] args = new object[1];
                        args[0] = e.Data[i, j].ToString();
                        value[i, j] = (T)typeof(T).InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, e.Data[i, j], args);
                        
                    }
                }
                OnChangeOccured();
            }

            public override System.Drawing.Image Icon
            {
                get { return Resources.DataTypeMatrix; }
            }


            public static implicit operator T[,](Matrix<T> s)
            {
                return s.value;
            }
            /// <summary>
            /// Повертає заданий стовпчик матриці
            /// </summary>
            /// <param name="ind">індекс стовпчика</param>
            /// <returns>Вектор-стовпчик</returns>
            public Vector<T> Column(int ind)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    list.Add(value[i, ind]);
                }
                return new Vector<T>(list.ToArray());
            }
            /// <summary>
            /// Повертає заданий рядок матриці
            /// </summary>
            /// <param name="ind">rіндекс рядка</param>
            /// <returns>Вектор-рядок</returns>
            public Vector<T> Row(int ind)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < value.GetLength(1); i++)
                {
                    list.Add(value[ind, i]);
                }
                return new Vector<T>(list.ToArray());
            }
            /// <summary>
            /// Повертає заданий елемент матриці
            /// </summary>
            /// <param name="column">стовпчик</param>
            /// <param name="row">рядок</param>
            /// <returns>Елемент матриці</returns>
            public Scalar<T> ColumnRow(int column, int row)
            {
                return new Scalar<T>(value[column, row]);
            }
            public override string ToString()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append('[');
                for (int i = 0; i < value.GetLength(0); i++)
                {
                    builder.Append('(');
                    builder.Append(value[i, 0].ToString());
                    for (int j = 1; j < value.GetLength(1); j++)
                    {
                        builder.Append(',');
                        builder.Append(value[i, j].ToString());
                    }
                    builder.Append(')');
                }

                builder.Append(']');
                return builder.ToString();
            }
        }
    }
}


