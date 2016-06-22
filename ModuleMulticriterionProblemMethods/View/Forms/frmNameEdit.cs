using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.Workflow.Messaging;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    /// <summary>
    /// ����� ��� ����������� ��"� ������������ �� �������.
    /// </summary>
    internal partial class frmNameEdit : frmBase
    {
        public new event EventHandler<EventArgs<IValidationResult>> Validating;

        private string AlternativeName = Properties.Resources.AlternativeName; //"��'� ������������";
        private string CriteriumName = Properties.Resources.CriteriumName; //"��'� �������";

        private EntityKind m_nameKind;

        /// <summary>
        /// ����� ��� ����������� ��"� ������������ �� �������.
        /// </summary>
        public frmNameEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������� ��"�, ������� ������������
        /// </summary>
        public string Value
        {
            get { return textBox1.Text; }
        }

        /// <summary>
        /// ���� ���� �� ������.
        /// �������� ��� ������, �� �������� �� ������.
        /// </summary>
        private void _oK()
        {
            bool isSucces = true;
            if (Validating != null)
            {
                EventArgs<IValidationResult> ev = new EventArgs<IValidationResult>();
                Validating(this, ev);
                if (!ev.Value.IsSucces) Messenger.Current.ShowMessage(MessageKind.Warning_Ok, ev.Value.ErrorMessage);
                isSucces = ev.Value.IsSucces;
            }
            if (isSucces)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="nameKind">������� �� ������������</param>
        public void Init(EntityKind nameKind)
        {
            m_nameKind = nameKind;
            switch (nameKind)
            {
                case EntityKind.Alternative:
                    Text = AlternativeName;
                    break;

                case EntityKind.Criterium:
                    Text = CriteriumName;
                    break;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnOk.FlatStyle = FlatStyle.Popup;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _oK();
        }
    }
}