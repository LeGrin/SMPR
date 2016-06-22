using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.Workflow.Validation;
using Modules.MulticriterionProblemMethods.Workflow.Messaging;
using Modules.MulticriterionProblemMethods.Exceptions;
using Modules.MulticriterionProblemMethods.View.Forms;
using Common.DataTypes;




namespace Modules.MulticriterionProblemMethods.View.Forms
{
    /// <summary>
    /// Сама-сама головна форма.
    /// </summary>
    partial class frmModule : frmBase, IMulticriterionProblemMethodsModuleForm, IMatrixEditor
    {

        public Module module;
        public void setModule(Module m)
        {
            module = m;
        }
        public event EventHandler DataEditing;
        public event EventHandler ShowResult;
        public event EventHandler SavingToBuffer;
        public event EventHandler LoadingFromBuffer;

        private const int DefaultButtonXLocation = 6;
        private const int DefaultStartButtonYLocation = 19;
        private const int DefaultButtonWidth = 318;
        private const int DefaultButtonHeight = 23;
        private const int DefaultInterval = 6;

        private bool _mustValidate = true;

        private bool _isReadOnly;
        /// <summary>
        ///  Поведінка тільки для читання
        /// </summary>
        public bool ReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                _isReadOnly = value;
                ctrlMatrix.ReadOnly = value;
            }
        }

        /// <summary>
        /// Конструктор самої-самої головної форми
        /// </summary>
        public frmModule()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ініціалізація, розміщує на формі контроли(кнопки), які будуть запускати методи
        /// </summary>
        /// <param name="controlsToRunMethod">Масив контролів, що будуть запускати методи</param>
        public void Init(Control[] controlsToRunMethod)
        {
            gbMethods.Controls.Clear();
            gbMethods.Controls.AddRange(controlsToRunMethod);

            int yLocation = DefaultStartButtonYLocation;
            foreach (Control ctrl in controlsToRunMethod)
            {
                ctrl.Size = new Size(DefaultButtonWidth, DefaultButtonHeight);
                ctrl.Location = new Point(DefaultButtonXLocation, yLocation);

                yLocation += DefaultInterval + DefaultButtonHeight;
            }
        }

        #region Methods

        /// <summary>
        /// Показує ділогове вікно для введеня ім"я критерію чи альтернативи
        /// </summary>
        /// <param name="nameKind">Критерій/Альтернатива</param>
        /// <returns>Введене ім"я альтернативи чи критерію</returns>
        private string _showNameEditor(EntityKind nameKind)
        {
            frmNameEdit frmNameEditor = new frmNameEdit();
            frmNameEditor.Init(nameKind);

            frmNameEditor.Validating += delegate(object sender, EventArgs<IValidationResult> e)
            {
                List<string> validationInfo = new List<string>();
                IEnumerable items;
                items = nameKind == EntityKind.Alternative ? ctrlMatrix.Alternatives
                    : ctrlMatrix.Criteriums;

                foreach (object item in items)
                    validationInfo.Add(item.ToString());

                UniqueValidator<string> uniqueValidator = new UniqueValidator<string>(validationInfo.ToArray(), frmNameEditor.Value);
                e.Value = uniqueValidator.Validate();
            };

            return frmNameEditor.ShowDialog() == DialogResult.OK ? frmNameEditor.Value : string.Empty;
        }
        /// <summary>
        /// Додати до матриці критерій/альтернативу
        /// </summary>
        /// <param name="entityName">Ім"я критерію/альтернативи</param>
        /// <param name="nameKind">Критерій/Альтернативу</param>
        private void _addEntity(string entityName, EntityKind nameKind)
        {
            if (!string.IsNullOrEmpty(entityName))
            {
                switch (nameKind)
                {
                    case EntityKind.Alternative:
                        ctrlMatrix.AddAlternative(entityName);
                        break;
                    case EntityKind.Criterium:
                        ctrlMatrix.AddCriterium(entityName);
                        break;
                }
            }
        }
        /// <summary>
        /// Додає критерій до матриці
        /// </summary>
        private void _addCriterium()
        {
            string criteriumName = _showNameEditor(EntityKind.Criterium);
            if (!string.IsNullOrEmpty(criteriumName))
                _addEntity(criteriumName, EntityKind.Criterium);
        }
        /// <summary>
        /// Додає альтернативу до матриці
        /// </summary>
        private void _addAlternative()
        {
            string alternativeName = _showNameEditor(EntityKind.Alternative);
            if (!string.IsNullOrEmpty(alternativeName))
                _addEntity(alternativeName, EntityKind.Alternative);
        }
        /// <summary>
        /// Перевірка на валідність введених даних.
        /// </summary>        
        private bool isValid()
        {
            Matrix matrix = ctrlMatrix.Matrix;
            List<Alternative> alternatives = new List<Alternative>(matrix.Alternatives);
            List<Criterium> equalCriteriums = new List<Criterium>();
            if (alternatives.Count > 1)
            {
                foreach (Criterium c in matrix.Criteriums)
                {
                    bool equal = true;
                    for (int i = 1; i < alternatives.Count; i++)
                    {

                        if (matrix[alternatives[i], c] != matrix[alternatives[0], c])
                        {
                            equal = false;
                            break;
                        }
                    }
                    if (equal) equalCriteriums.Add(c);
                }
                if (equalCriteriums.Count > 0)
                {
                    int criteriumIndex = 1;
                    StringBuilder output = new StringBuilder();
                    output.AppendLine("Всі альтернативи мають однакові значення по таких критеріях:");
                    foreach (Criterium c in equalCriteriums)
                    {
                        output.AppendLine(string.Format("{1}) {0};", c.Name, criteriumIndex));
                        criteriumIndex++;
                    }
                    output.Append("Видалити дані критерії як надлишкові?");

                    if (Messenger.Current.ShowMessage(MessageKind.Question_Yes_No, output.ToString()) == DialogResult.Yes)
                    {
                        foreach (Criterium c in equalCriteriums)
                            ctrlMatrix.RemoveCriterium(c);
                    }
                    return false;
                }
            }
            else if (matrix.AlternativesCount == 0)
            {
                Messenger.Current.ShowMessage(MessageKind.Warning_Ok, "Введіть хоча б одну альтернативу.");
                return false;
            }
            if (matrix.CriteriumsCount == 0)
            {
                Messenger.Current.ShowMessage(MessageKind.Warning_Ok, "Введіть хоча б один критерій.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Повертає введену матрию
        /// </summary>
        public Matrix Matrix
        {
            get { return ctrlMatrix.Matrix; }
        }
        /// <summary>
        /// Ініціалізація форми
        /// </summary>
        /// <param name="editMode">Режим: введеня даних чи редагування існуючих</param>
        /// <param name="matrix">Матриця з данними</param>
        /// <param name="nameEditor">Діалог, через який вводиться ім"я критерію/альтернативи</param>
        public void Init(Matrix matrix)
        {
            ctrlMatrix.Matrix = matrix;
        }
        /// <summary>
        /// Очищає матрицю
        /// </summary>
        public void ClearMatrix()
        {
            ctrlMatrix.ClearMatrix();
        }

        public void HighlightAlternatives(Alternative[] alts)
        {
            ctrlMatrix.HighlightAlternatives(alts);
        }

        #endregion

        #region Events
        /// <summary>
        /// Введення вхідних даних.
        /// </summary>        
        private void btnDataEdit_Click(object sender, EventArgs e)
        {
            if (DataEditing != null) DataEditing(this, EventArgs.Empty);
            else throw new ModuleException("Нема прив'язки event'a головної форми DataEditing.");
        }
        /// <summary>
        /// Показ останнього результату.
        /// </summary>        
        private void btnShowResult_Click(object sender, EventArgs e)
        {
            if (ShowResult != null) ShowResult(this, EventArgs.Empty);
            else throw new ModuleException("Нема прив'язки event'a головної форми ShowResult.");
        }
        /// <summary>
        /// Збереження даних в буфер.
        /// </summary>        
        private void btnSaveToBuffer_Click(object sender, EventArgs e)
        {
            if (SavingToBuffer != null) SavingToBuffer(this, EventArgs.Empty);
            else throw new ModuleException("Нема прив'язки event'a головної форми SavingToBuffer.");
        }
        /// <summary>
        /// Завантаження даних з буфера.
        /// </summary>        
        private void btnLoadFromBuffer_Click(object sender, EventArgs e)
        {
            if (LoadingFromBuffer != null) LoadingFromBuffer(this, EventArgs.Empty);
            else throw new ModuleException("Нема прив'язки event'a головної форми SavingToBuffer.");
        }


        private void _addCriterium(object sender, EventArgs e)
        {
            _addCriterium();
        }
        private void _addAlternative(object sender, EventArgs e)
        {
            _addAlternative();
        }
        private void _removeCriterium(object sender, EventArgs e)
        {
            ctrlMatrix.RemoveCriterium();
        }
        private void _removeAlternative(object sender, EventArgs e)
        {
            ctrlMatrix.RemoveAlternative();
        }
        private void _clearMatrix(object sender, EventArgs e)
        {
            ctrlMatrix.ClearMatrix();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            _mustValidate = false;
            Close();
            _mustValidate = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            //e.Cancel |= _mustValidate && !isValid();
        }

        private void bRandomFill_Click(object sender, EventArgs e)
        {
            ctrlMatrix.RandomFill();
        }

        private void bAddAlternative_Click(object sender, EventArgs e)
        {
            _addAlternative();
        }

        #endregion

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Testing testing = new Testing(this);
            testing.ShowDialog();
        }
    }
}