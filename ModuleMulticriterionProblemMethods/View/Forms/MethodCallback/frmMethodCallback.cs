using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Forms.MethodCallback
{
    /// <summary>
    /// Форма, що показується як діалогова при виконанні якогось методу.
    /// Використовується для ділогу з користувачем.
    /// </summary>
    internal partial class frmMethodCallback : frmBase
    {
        private bool _canClose = false;
        private readonly bool _isResizeAble = false;
        private readonly ctrlMethodCallbackBase _innerControl;
        /// <summary>
        /// Форма, що показується як діалогова при виконанні якогось методу.
        /// </summary>
        private frmMethodCallback ( )
        {
            InitializeComponent ( );

            ShowCloseButton = false;
        }
        public frmMethodCallback ( ctrlMethodCallbackBase innerControl, bool isResizeable, bool showCloseButton )
            : this ( )
        {
            // initializing form
            ShowCloseButton = showCloseButton;
            _isResizeAble = isResizeable;
            // initializing inner control
            _innerControl = innerControl;
            _innerControl.ButtonOkEnabledChangingRequest +=  _innerControl_SetButtonOkEnabled;            
            _innerControl.Dock = DockStyle.Fill;            
            pnlClientArea.Controls.Clear ( );
            pnlClientArea.Controls.Add ( _innerControl );
        }
        /// <summary>
        /// Значення, введене користувачем.
        /// </summary>
        public object Value
        {
            get { return _innerControl.Value; }
        }
        /// <summary>
        /// Визначає, чи показувати кнопочку закрити, і чи може користувач взагалі просто 
        /// взяти і закрити форму.
        /// (Взагалі не рекомендується ставити в true.
        /// Можливо пізніше дана властивість може буде видалена.
        /// Подивимось в принципі.)
        /// </summary>
        public bool ShowCloseButton
        {
            get
            {
                return btnClose.Visible;
            }
            set
            {
                btnClose.Visible = value;
            }
        }
        /// <summary>
        /// На даному етапі(як тільки форма показується) 
        /// підганяються розміри форми та панелі під контрол, що міститсья всередині.
        /// </summary>        
        protected override void OnShown ( EventArgs e )
        {
            base.OnShown ( e );

            pnlClientArea.MinimumSize = pnlClientArea.Size;
            MinimumSize = Size;
            pnlClientArea.AutoSize = AutoSize = false;
        }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad ( e );

            FormBorderStyle = _isResizeAble ? FormBorderStyle.SizableToolWindow : FormBorderStyle.FixedToolWindow;
        }
        /// <summary>
        /// На даному етапі(при спробі закриття)
        /// йде валідація.
        /// </summary>
        protected override void OnClosing ( CancelEventArgs e )
        {
            if ( !_canClose )
            {
                e.Cancel = true;
                return;
            }
            base.OnClosing ( e );
            e.Cancel &= DialogResult != DialogResult.OK || !_innerControl.IsValid ( );
        }
        /// <summary>
        /// Додано для того, щоб заборонити юзеру закривати форму тільки на Ок Close
        /// </summary>
        private void btn_Click ( object sender, EventArgs e )
        {
            _canClose = sender == btnOk || ShowCloseButton;
            Close ( );
            _canClose = false;
        }
        /// <summary>
        /// Зроблено для того, щоб внутрішній контрол міг керувати доступністю кнопки "Ок".
        /// (наприклад, щоб форму можна було закривати лише після закінчення виконання методу.)
        /// </summary>
        private void _innerControl_SetButtonOkEnabled ( object sender, EventArgs<bool> e )
        {
            btnOk.Enabled = e.Value;
        }
    }
}