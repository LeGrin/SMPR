using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Modules.Tests
{
    [Common.ModuleInfo(new string[] { "uk-UA::Тести", "ru-RU::Тесты", "en-US::Tests", "zh::测试" })]
    [Common.About("Голобородько Гліб Ярославович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName="glib")]
    [Common.About("Любарський Дмитро Валентинович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName = "dmytro")]
    public class Module : ModuleAbstractEx<Method>
    {
        frmSelectTest form;

        Method CurrentMethod = null;

        public class TestsCloseEventArgs : CloseEventArgs
        {
            private double mark;

            public double Mark
            {
                get { return mark; }
            }
            public TestsCloseEventArgs(double mark)
            {
                this.mark = mark;
            }
        }

        public Module()
        {
        }

        public Module(Method method)
        {
            CurrentMethod = method;
        }
        public override void Show(Form MdiParent)
        {            
            // here was no parameters in constructor for Module.
            if (CurrentMethod == null)
            {
                form = new frmSelectTest(Methods);
if (MdiParent!=null && MdiParent.IsMdiContainer)
                form.MdiParent = MdiParent;
                form.Show();
                form.FormClosed += form_frmSelectTestClosed;
            }
            // There was a parametr in constructor for Module.
            else
                form_frmSelectTestClosed(null, null);
        }
        /// <summary>
        /// Can't understand: what the fuck?!?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void form_frmSelectTestClosed(object sender, FormClosedEventArgs e)
        {
            // Here was no parametr in constructor for Module.
            if (sender is frmSelectTest)
            {
                var form = sender as frmSelectTest;
                if (form.DialogResult != DialogResult.OK)
                    return;

                CurrentMethod = form.SelectedMethod;
            }

            if (CurrentMethod != null)
            {
                frmTest form = new frmTest(CurrentMethod);
                if (sender is frmSelectTest)
                    form.MdiParent = (sender as frmSelectTest).MdiParent;
                form.FormClosed += form_frmTestClosed;
                form.Show();
            }

        }

        void form_frmTestClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new TestsCloseEventArgs((double)CurrentMethod.finRes);
            OnClose(LastResult);
        }

        public override CloseEventArgs ShowDialog()
        {
            if (CurrentMethod == null)
            {
                form = new frmSelectTest(Methods);
            

                if (form.ShowDialog() == DialogResult.OK)
                    CurrentMethod = form.SelectedMethod;
                
                    

            }

            if (CurrentMethod != null)
            {
                frmTest form = new frmTest(CurrentMethod);
                form.LoadDataFromMethod();
                form.ShowDialog();
                LastResult = new TestsCloseEventArgs((double)CurrentMethod.finRes);
                OnClose(LastResult);
                return LastResult;
            }

            return null;
        }

        protected override void OnClose(CloseEventArgs args)
        {
            if (args is TestsCloseEventArgs)
            {
                //MessageBox.Show("Останні результати модуля " + this.GetType().Name + CurrentMethod.Name);
               if((CurrentMethod.finRes)!=0) MessageBox.Show("Коефіцієнт для поточного тесту:"+CurrentMethod.finRes.ToString());
                Common.DataBuffer.Instance.Save("Останні результати "
                    + this.Name + " - " + CurrentMethod.Name,
                    new Common.DataTypes.Scalar<double>((args as TestsCloseEventArgs).Mark)); // якщо ця хуйня запрацює, то буде просто заїбісь!!!
            }
            base.OnClose(args);
        }
    }
}