using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.Workflow;
using Modules.MulticriterionProblemMethods.Workflow.Messaging;
using Modules.MulticriterionProblemMethods.Exceptions.Algorithm;
using Modules.MulticriterionProblemMethods.DataTypes;
using Modules.MulticriterionProblemMethods.View.Forms;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.View.Forms.MethodCallback;
using Common;
using Buffer = Common.DataBuffer;
using Common.DataTypes;

namespace Modules.MulticriterionProblemMethods
{
    [Common.ModuleInfo(new string[] { "uk-UA::Багатокритеріальні задачі", "ru-RU::Многокритериальные задачи", "en-US::Multicriterion Problems", "zh::多任务" })]
    [Common.About("Березан Олексій Миколайович", Group = "МІ-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "lexx")]
    [Common.About("Березань Ірина Олександрівна", Group = "МІ-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "ira")]
    [Common.About("Лукаш Микола Володимирович", Group = "МІ-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "kolja")]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        #region Nested types

        public class MulticriterionProblemMethodsCloseEventArgs : CloseEventArgs
        {
        }

        #endregion

        #region Fields

        private readonly Control[] _controlsToRunMethods;
        internal readonly DataStorage _dataStorage = new DataStorage();
        internal frmModule _parrentForm;

        #endregion

        /// <summary>
        /// Багатокритеріальні задачі.
        /// </summary>
        public Module()
        {
            _controlsToRunMethods = _initButtons();
        }
        /// <summary>
        /// Багатокритеріальні задачі.
        /// </summary>
        /// <param name="m">Метод, який буде виконуватись.</param>
        public Module(Method m)
            : this()
        {
            _runMethodWithoutEnteredData(m);
        }

        #region Methods

        /// <summary>
        /// Запускає метод на виконання
        /// </summary>
        /// <param name="method">Метод</param>
        public void RunMethod(Method method)
        {
            _dataStorage.Matrix = _parrentForm.Matrix;
            if (_dataStorage.HasData)
            {
                method.Init(_dataStorage.Matrix);
                try
                {
                    _dataStorage.LastResult = method.Do();
                    showLastResult();
                }
                catch (AlgorithmException)
                {
                    throw;
                }
            }
            else
            {
                Messenger.Current.ShowMessage(MessageKind.Warning_Ok, Properties.Resources.NoData);
            }
        }
        /// <summary>
        /// Запускає на виконання метод m, показавши перед цим форму введення даних для цього метода.
        /// </summary>        
        public void _runMethodWithoutEnteredData(Method m)
        {
            if (showDataEditForm())
            {
                try
                {
                    m.Init(_dataStorage.Matrix);
                    _dataStorage.LastResult = m.Do();
                    showLastResult();
                }
                catch (AlgorithmException a_exc)
                {
                    throw a_exc;
                }
            }
        }

        /// <summary>
        /// Виводить в режимі діалога головну форму
        /// </summary>        
        public override CloseEventArgs ShowDialog()
        {
            using (Form frm = _initModuleForm(null))
            {
                frm.ShowDialog();
                return LastResult;
            }
        }
        /// <summary>
        /// Виводить головну форму
        /// </summary>        
        public override void Show(Form MdiParent)
        {
            Form frm = _initModuleForm(MdiParent);
            frm.Show();
            frm.FormClosed += for_FormClosed;
        }

        /// <summary>
        /// Показує форму для введення даних
        /// </summary>
        private bool showDataEditForm()
        {
            using (frmMatrixEdit frmDataEdit = new frmMatrixEdit())
            {
                frmDataEdit.Init(_dataStorage.Matrix);

                if (frmDataEdit.ShowDialog() == DialogResult.OK)
                {
                    _dataStorage.Matrix = frmDataEdit.Matrix;
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Показуэ форму з результатом
        /// </summary>
        private void showLastResult()
        {
            ///pmb 17/05/2010
            ///OLD. Boring
            //using (frmResultPresenter frmResult = new frmResultPresenter())
            //{
            //    frmResult.Init(_dataStorage.LastResult);
            //    frmResult.ShowDialog();
            //}

            ///NEW. Exciting!
            _parrentForm.HighlightAlternatives(_dataStorage.LastResult);
        }

        /// <summary>
        /// Ініціалізація та підготовка головної форми
        /// </summary>
        /// <param name="MdiParent">Батьківська форма.</param>
        /// <returns>Головну форму, проініціалізовану, готову до показу.</returns>
        private Form _initModuleForm(Form MdiParent)
        {
            _parrentForm = new frmModule();
            _parrentForm.setModule(this);
            // initializing properties
            _parrentForm.Text = Name;
            _parrentForm.Init(_controlsToRunMethods);
            if (MdiParent!=null && MdiParent.IsMdiContainer)
            _parrentForm.MdiParent = MdiParent;
            // events attachement
            _parrentForm.DataEditing += delegate { showDataEditForm(); };
            _parrentForm.ShowResult += delegate { showLastResult(); };
            _parrentForm.SavingToBuffer += delegate { _saveDataTouffer(); };
            _parrentForm.LoadingFromBuffer += delegate { _loadDataFromBuffer(); };

            // returning!
            return _parrentForm;
        }
        /// <summary>
        /// Ініціалізація кнопочег, що запускають методи
        /// </summary>
        /// <returns>Кнопочки!</returns>
        private Control[] _initButtons()
        {
            List<Button> result = new List<Button>();
            foreach (Method method in Methods)
            {
                Button b = new Button();
                b.Tag = method;
                b.Text = method.Name;
                b.Click += delegate { RunMethod((Method)b.Tag); };
                result.Add(b);
            }
            return result.ToArray();
        }

        #endregion

        #region Work with buffer
        /// <summary>
        /// Зберігає останній результат
        /// </summary>
        private void _saveLastResult()
        {
            Buffer.Instance.SaveDialog(MatrixConverter.Current.GetMatrix(_dataStorage.LastResult));
        }
        /// <summary>
        /// Зберігає матрицю
        /// </summary>
        private void _saveDataTouffer()
        {
            Buffer.Instance.SaveDialog(_parrentForm.Matrix);
        }
        /// <summary>
        /// Завантажує матрицю
        /// </summary>
        private void _loadDataFromBuffer()
        {
            _dataStorage.Matrix = (Matrix)Buffer.Instance.LoadDialog(_validateData);
        }
        /// <summary>
        /// Перевірка даних, що зберігаються/завантажуються.
        /// </summary>
        /// <param name="data">Дані</param>        
        private bool _validateData(BufferData data)
        {
            return data is Matrix;
        }
        #endregion

        #region Events

        /// <summary>
        /// Метод події закриття.
        /// </summary>  
        private void for_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new MulticriterionProblemMethodsCloseEventArgs();
            OnClose(LastResult);
        }
        /// <summary>
        /// Метод події закриття.
        /// </summary>        
        protected override void OnClose(CloseEventArgs args)
        {
            base.OnClose(args);
        }

        #endregion
    }
}
