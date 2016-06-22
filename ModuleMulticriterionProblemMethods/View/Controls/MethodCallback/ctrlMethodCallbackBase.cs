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
    /// ������� �������, ��� ��� ��������, �� ������ ��������� �� �����, ��� ���� ������������ ��� ������ � ������ �� ��� ��������� ������.
    /// </summary>
    public partial class ctrlMethodCallbackBase : UserControl
    {
        public event EventHandler<EventArgs<bool>> ButtonOkEnabledChangingRequest;
        /// <summary>
        /// ������� �������, ��� ��� ��������, �� ������ ��������� �� �����, ��� ���� ������������ ��� ������ � ������ �� ��� ��������� ������.
        /// </summary>
        public ctrlMethodCallbackBase ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// ������� ������������ ��������.
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
        /// ������� ���, ���� �� ���, �� ������ �� ������� � ��������.
        /// (��������, ��� ������� ������ �������� ��������� ������ ���(��������� � ��� ����� ���� ���� �����, � �� ������ ���� ����))
        /// </summary>
        public virtual bool IsValid ( )
        {
            return true;
        }
        /// <summary>
        /// ������ ������ ��, �� ����������� �� ���� frm�����Callback.
        /// </summary>
        /// <param name="enabled">��������, �� ���� �������� ������� Enabled ������ ��.</param>
        protected void SetButtonOkEnabled ( bool enabled )
        {
            if ( ButtonOkEnabledChangingRequest != null )
            {
                ButtonOkEnabledChangingRequest ( this, new EventArgs<bool> ( enabled ) );
            }
        }
    }
}