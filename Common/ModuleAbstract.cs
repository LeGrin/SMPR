using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;

namespace Common
{
    /// <summary>
    /// ����������� ����, �� ����������� ����� ������� ������
    /// </summary>
    [Common.About("���������� ���� �������������", Group = "��-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Ertong")]
    [Common.About("������ ���� �������", Group = "��-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Gridchyn")]
    [Common.About("���� ��� �������������", Group = "��-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "Jura")]
    public abstract class ModuleAbstract
    {
        /// <summary>
        /// ��������� ��䳿 - �������� ������
        /// </summary>
        public class CloseEventArgs : EventArgs
        {
        }

        /// <summary>
        /// ��������� ��䳿 - ��������
        /// </summary>
        public CloseEventArgs LastResult = null;

        /// <summary>
        /// ��� ��������� ��䳿 �������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public delegate void CloseEventHandler(object sender, CloseEventArgs args);

        /// <summary>
        /// ���� �������� ������
        /// </summary>
        public event CloseEventHandler Close;

        /// <summary>
        /// ����� MDI-�����
        /// </summary>
        /// <param name="MdiParent">���������� �����</param>
        public abstract void Show(Form MdiParent);

        /// <summary>
        /// ĳ�������� ����� �����
        /// </summary>
        /// <returns>��������� ��䳿-�������� �����</returns>
        public abstract CloseEventArgs ShowDialog();

        /// <summary>
        /// ������� ����� ������
        /// </summary>
        public string Name
        {
            get
            {
                var moduleInfoAttr = ReflectionHelper.GetAttribute<ModuleInfoAttribute>(this.GetType());
                if (moduleInfoAttr == null)
                {
                    throw new NotImplementedException("������ " + this.GetType().Name + " ������� ������ �������� ModuleInfoAttribute");
                }
                return moduleInfoAttr.ModuleName;
            }
        }

        /// <summary>
        /// ������ � ����� ������ ���������� ������ ������
        /// </summary>
        /// <param name="ParamName">����� ���������(� �������� �����)</param>
        /// <param name="data">���</param>
        public void SaveLastResult(string ParamName, Common.DataTypes.BufferData data)
        {
            DataBuffer.Instance.Save("������ ���������� ������ " + Name + " - " + ParamName, data);
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
        /// �������� �������� ������
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnClose(CloseEventArgs args)
        {
            // TODO: write real code in each module for getting result (this is just a test)
            //var result = new Random().NextDouble() * 100;
            //SaveResult(result);
            //MessageBox.Show(String.Format("�� �������� {0} ������ �� ������ {1}", Convert.ToInt32(result), this.Name), "������ (���������)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Close != null) Close(this, args);
        }
    }

    /// <summary>
    /// ����������� ����-��������� ������ ������� ������
    /// </summary>
    /// <typeparam name="Method">��� ������ ������ ������</typeparam>
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
        /// ������ ������
        /// </summary>
        public List<Method> Methods
        {
            get { return methods; }
        }
    }
}