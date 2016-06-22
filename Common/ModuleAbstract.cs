using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace Common
{
    /// <summary>
    /// Абстрактний клас, що представляє собою окремий модуль
    /// </summary>
    [Common.About("Литвиненко Ігор Олександрович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Ertong")]
    [Common.About("Грідчин Ігор Юрійович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Gridchyn")]
    [Common.About("Газін Юрій Олександрович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Jura")]
    public abstract class ModuleAbstract
    {
        /// <summary>
        /// Аргументи події - закриття модулю
        /// </summary>
        public class CloseEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Аргументи події - закриття
        /// </summary>
        public CloseEventArgs LastResult = null;

        /// <summary>
        /// Тип обробника події закриття модулю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void CloseEventHandler(object sender, CloseEventArgs args);

        /// <summary>
        /// Подія закриття модулю
        /// </summary>
        public event CloseEventHandler Close;

        /// <summary>
        /// Показ MDI-форми
        /// </summary>
        /// <param name="MdiParent">Батьківська форма</param>
        public abstract void Show(Form MdiParent);

        /// <summary>
        /// Діалоговий показ форми
        /// </summary>
        /// <returns>Аргументи події-закриття форми</returns>
        public abstract CloseEventArgs ShowDialog();

        /// <summary>
        /// Повертає назву модуля
        /// </summary>
        public string Name
        {
            get
            {
                var moduleInfoAttr = ReflectionHelper.GetAttribute<ModuleInfoAttribute>(this.GetType());
                if (moduleInfoAttr == null)
                {
                    throw new NotImplementedException("Модуль " + this.GetType().Name + " повинен містити аттрибут ModuleInfoAttribute");
                }
                return moduleInfoAttr.ModuleName;
            }
        }

        /// <summary>
        /// Зберігає в буфері останні результати роботи модуля
        /// </summary>
        /// <param name="ParamName">Назва параметра(з маленької букви)</param>
        /// <param name="data">Дані</param>
        public void SaveLastResult(string ParamName, Common.DataTypes.BufferData data)
        {
            DataBuffer.Instance.Save("Останні результати модуля " + Name + " - " + ParamName, data);
        }

        public void SaveResult(double result)
        {
            ResultsStorage.SaveResult(this, result);
        }

        public IEnumerable<TestResult> GetResults()
        {
            return ResultsStorage.GetAllResults().Where(tr => tr.ModuleName == this.Name);
        }

        public IEnumerable<TestResult> GetLastResults()
        {
            return ResultsStorage.GetLastResults().Where(tr => tr.ModuleName == this.Name);
        }

        /// <summary>
        /// Обробник закриття модулю
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnClose(CloseEventArgs args)
        {
            // TODO: write real code in each module for getting result (this is just a test)
            //var result = new Random().NextDouble() * 100;
            //SaveResult(result);
            //MessageBox.Show(String.Format("Вы получили {0} баллов за модуль {1}", Convert.ToInt32(result), this.Name), "Оценка (случайная)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Close != null) Close(this, args);
        }
    }

    /// <summary>
    /// Абстрактнйи клас-контейнер методів певного модуля
    /// </summary>
    /// <typeparam name="Method">тип методів даного модуля</typeparam>
    abstract public class ModuleAbstractEx<Method> : ModuleAbstract
        where Method : MethodAbstract
    {
        public ModuleAbstractEx()
        {
            foreach (MethodAbstract m in ModuleInfo.GetModuleInfo(this).methods)
                if (m is Method)
                    methods.Add(m as Method);
        }

        private List<Method> methods = new List<Method>();

        /// <summary>
        /// Список методів
        /// </summary>
        public List<Method> Methods
        {
            get { return methods; }
        }
    }
}