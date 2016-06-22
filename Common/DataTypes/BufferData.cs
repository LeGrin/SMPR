using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Common
{
    namespace DataTypes
    {
        /// <summary>
        /// Абстрактний клас базових типів даних
        /// </summary>
        [Serializable]
        public abstract class BufferData
        {
            /// <summary>
            /// Генерує контрол, що відображує дані цього типу
            /// </summary>
            /// <returns></returns>
            public abstract UserControl GenerateControl();

            public event EventHandler ChangeOccured;
            protected void OnChangeOccured()
            {
                ChangeOccured(this, new EventArgs());
            }

            public void ClearEvent()
            {
                try
                {
                    ChangeOccured -= (EventHandler)ChangeOccured.GetInvocationList()[0];
                }
                catch
                {
#if DEBUG
                    MessageBox.Show("BUG!");
#endif
                }
            }

            /// <summary>
            /// Іконка типу даних
            /// </summary>
            public abstract Image Icon { get; }

            /// <summary>
            /// Список кодов методов-валидаторов, которые проверили данный объект
            /// </summary>            
            [NonSerialized]
            protected Dictionary<int, bool> validatorsResults = new Dictionary<int, bool>();

            public Dictionary<int, bool> ValidatorsResults
            {
                get
                {
                    return validatorsResults;
                }
                set
                {
                    validatorsResults = value;
                }
            }

            public override string ToString()
            {
                return this.GetType().Name;
            }
        }
    }
}