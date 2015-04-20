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
    /// ������� ���� ��� ������ ������������������� ������
    /// </summary>
    public abstract class Method : Common.MethodAbstract
    {
        private Matrix _matrix;
        /// <summary>
        /// ������� � �������
        /// </summary>
        internal Matrix Matrix
        {
            get { return _matrix; }
        }
        /// <summary>
        /// ����������� ������.
        /// </summary>
        /// <param name="matrix">������� � �������</param>
        internal virtual void Init(Matrix matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// �������� �����.
        /// </summary>
        /// <returns>�a������ ������������</returns>
        internal abstract Alternative[] Do();

        /// <summary>
        /// ������� ����� ��� �������� ����� ������������.
        /// </summary>
        /// <param name="parameters">��������� ��� ����������� �����</param>        
        /// <returns>������� ������������ ��������</returns>
        protected object DoCallback(ctrlMethodCallbackBase ctrlCallback)
        {
            return DoCallback(ctrlCallback, false, false, Properties.Resources.Choose);
        }
        /// <summary>
        /// ������� ����� ��� �������� ����� ������������.
        /// </summary>
        /// <param name="parameters">��������� ��� ����������� �����</param>        
        /// <returns>������� ������������ ��������</returns>
        protected object DoCallback(ctrlMethodCallbackBase ctrlCallback, bool showCloseButton, bool resizeAble, string text)
        {
            //frmMethodCallback frm = new frmMethodCallback ( );
            // ����� ������ ���� �������, �.�. ��������� ������� � ����� ������ �������(��� �����������).
            // ���, ��� �������� �� ���...
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
            // .. �� ���. ������� �� ������� ��� �����������.
            frmMethodCallback frm = new frmMethodCallback(ctrlCallback, resizeAble, showCloseButton);
            frm.Text = text;
            return frm.ShowDialog() == DialogResult.OK ? frm.Value : null;
        }
    }
}