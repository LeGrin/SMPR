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
    /// Форма для редагування ім"я альтернативи чи критерію.
    /// </summary>
    internal partial class frmNameEdit : frmBase
    {
        public new event EventHandler<EventArgs<IValidationResult>> Validating;

        private string AlternativeName = Properties.Resources.AlternativeName; //"Ім'я альтернативи";
        private string CriteriumName = Properties.Resources.CriteriumName; //"Ім'я критерію";

        private EntityKind m_nameKind;

        /// <summary>
        /// Форма для редагування ім"я альтернативи чи критерію.
        /// </summary>
        public frmNameEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Значення ім"я, введене користувачем
        /// </summary>
        public string Value
        {
            get { return textBox1.Text; }
        }

        /// <summary>
        /// Юзер клікс Ок баттон.
        /// Валідатінг енд сейвінг, іф валідатіон із саццес.
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
        /// Ініціалізація
        /// </summary>
        /// <param name="nameKind">Критерій чи альтернатива</param>
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