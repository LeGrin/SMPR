using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace Modules.DecisionsUnderFuzzyConditionsMethods
{
    [Common.ModuleInfo(new string[] { "uk-UA::Прийняття рішень в нечітких умовах", "ru-RU::Принятия решений в нечетких условиях", "en-US::Making Desicions Under Fuzzy Conditions", "zh::在模糊环境决策" })]
    [Common.About("Завершинський Максим Володимирович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    [Common.About("Уманський Віталій Ігорович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    [Common.About("Конюшенко Олексій Володимирович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;

        public class DecisionsUnderFuzzyConditionsMethodsCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
        }

        public override void Show(Form MdiParent)
        {
            form = new frmModule();
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
            form.MdiParent = MdiParent;
            form.Show();
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new DecisionsUnderFuzzyConditionsMethodsCloseEventArgs();
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