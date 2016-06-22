using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using Modules.ExpertProcessingMethods.Methods;

namespace Modules.ExpertProcessingMethods
{
    [Common.ModuleInfo(new string[] { "uk-UA::Методи експертної оцінки", "ru-RU::Методы экспертной оценки", "en-US::Expert Processing Methods", "zh::同行评议的方法" })]
    [Common.About("Нечипоренко Єгор Андрійович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    [Common.About("Гончаренко Сергій Вікторович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;
        private int tabNum;

        public class ExpertProcessingMethodsCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
        }

        public Module(Method method)
        {
            if (method.Name == Properties.Resources.OurMethodName)
                tabNum = 1;
            else if (method.Name == Properties.Resources.TestedSummingMethodName)
                tabNum = 2;
            else if (method.Name == Properties.Resources.RangeMethodName)
                tabNum = 3;
            else if (method.Name == Properties.Resources.NonDirectRangeMethodName)
                tabNum = 4;
            else if (method.Name == Properties.Resources.KondorseMethodName)
                tabNum = 5;
            else if (method.Name == Properties.Resources.PairCompareMethod)
                tabNum = 6;
            else if (method.Name == Properties.Resources.AlgebraicMethodName)
                tabNum = 7;
        }

        public override void Show(Form MdiParent)
        {
            form = new frmModule();
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
            form.MdiParent = MdiParent;
            form.Show();
            form.showTab(tabNum);
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new ExpertProcessingMethodsCloseEventArgs();
            OnClose(LastResult);
        }

        public override CloseEventArgs ShowDialog()
        {
            form = new frmModule();
            form.ShowDialog();
            return LastResult;
        }

        protected override void OnClose(CloseEventArgs args)
        {
            //              Buffer.Instance.Save("Останні результати модуля " + this.GetType().Name, args.result);
            base.OnClose(args);
        }

    }
}