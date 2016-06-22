using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    /// <summary>
    /// Базовий контрол, для всіх контролів, що будуть поміщатися на форму, яка буде показуватись для діалогу з юзером під час виконання методу.
    /// </summary>
    public partial class ctrlMethodCallbackBase : UserControl
    {
        public event EventHandler<EventArgs<bool>> ButtonOkEnabledChangingRequest;
        /// <summary>
        /// Базовий контрол, для всіх контролів, що будуть поміщатися на форму, яка буде показуватись для діалогу з юзером під час виконання методу.
        /// </summary>
        public ctrlMethodCallbackBase ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// Введене користувачем значення.
        /// </summary>
        [DesignerSerializationVisibility ( DesignerSerializationVisibility.Hidden )]
        [Browsable(false)]
        public virtual object Value
        {
            get
            {
                throw new NotImplementedException ( "  You must override this method in your control!" );
            }
        }
        /// <summary>
        /// Повертає тру, якщо всі дані, що введені на контрол є валідними.
        /// (Зроблено, щоб контрол завжди повертав правильно введені дані(наприклад в щоб текст боксі було число, а не якийсь лєвий тест))
        /// </summary>
        public virtual bool IsValid ( )
        {
            return true;
        }
        /// <summary>
        /// Робить кнопку Ок, що знаходиться на формі frmМетодCallback.
        /// </summary>
        /// <param name="enabled">Значення, що буде присвоєно проперті Enabled кнопки Ок.</param>
        protected void SetButtonOkEnabled ( bool enabled )
        {
            if ( ButtonOkEnabledChangingRequest != null )
            {
                ButtonOkEnabledChangingRequest ( this, new EventArgs<bool> ( enabled ) );
            }
        }
    }
}