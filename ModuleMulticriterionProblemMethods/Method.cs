using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Common.DataTypes;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.View.Forms.MethodCallback;

namespace Modules.MulticriterionProblemMethods
{
    /// <summary>
    /// Базовий клас для методів багатокритеріального аналізу
    /// </summary>
    public abstract class Method : Common.MethodAbstract
    {
        private Matrix _matrix;
        /// <summary>
        /// Матриця з данними
        /// </summary>
        internal Matrix Matrix
        {
            get { return _matrix; }
        }
        /// <summary>
        /// Ініціалізація методу.
        /// </summary>
        /// <param name="matrix">Матриця з данними</param>
        internal virtual void Init(Matrix matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Виконати метод.
        /// </summary>
        /// <returns>Нaйкращі альтернитиви</returns>
        internal abstract Alternative[] Do();

        /// <summary>
        /// Показуэ форму для введення даних користувачем.
        /// </summary>
        /// <param name="parameters">Параметри для ініціалізації форми</param>        
        /// <returns>Введене користувачем значення</returns>
        protected object DoCallback(ctrlMethodCallbackBase ctrlCallback)
        {
            return DoCallback(ctrlCallback, false, false, Properties.Resources.Choose);
        }
        /// <summary>
        /// Показуэ форму для введення даних користувачем.
        /// </summary>
        /// <param name="parameters">Параметри для ініціалізації форми</param>        
        /// <returns>Введене користувачем значення</returns>
        protected object DoCallback(ctrlMethodCallbackBase ctrlCallback, bool showCloseButton, bool resizeAble, string text)
        {
            //frmMethodCallback frm = new frmMethodCallback ( );
            // Позже должно быть удалено, т.к. являеться ошыбкой с точки зрения дизайна(или архитектури).
            // все, что находить от сих...
            //if (ctrlCallback.GetType().Name == "ctrlMethod3")
            //{
            //    frm.Width = 822+15;
            //    frm.Height = 340 + 20;
            //}
            //if (ctrlCallback.GetType().Name == "ctrlMethod4")
            //{
            //    frm.Width = 415;
            //    frm.Height = 349 + 20;
            //}
            // .. до сих. Слишком уж хрупкое все получаеться.
            frmMethodCallback frm = new frmMethodCallback(ctrlCallback, resizeAble, showCloseButton);
            frm.Text = text;
            return frm.ShowDialog() == DialogResult.OK ? frm.Value : null;
        }
    }
}