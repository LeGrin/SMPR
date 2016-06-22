using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods
{
    [ModuleInfoAttribute(new string[] { "uk-UA::Прийняття рішень в умовах невизначеності та ризику", "ru-RU::Принятие решений в условиях неопределенности и риска", "en-US::Making Decisions Under Risk and Uncertainity", "zh::决定在不确定性和风险决策" })]
    [Common.About("Криволап Андрій Володимирович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhoto), PhotoResName = "photo1")]
    [Common.About("Костюк Галина Любомирівна", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhoto), PhotoResName="gala2")]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;

        public class DecisionsUnderRiskAndUncertainityMethodsCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
            form = new frmModule(Methods, null);
        }

        public Module(Method method)
        {
            form = new frmModule(Methods, method);
        }
        public override void Show(Form MdiParent)
        {
            //form = new frmModule();
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
            form.MdiParent = MdiParent;
            form.Show();
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new DecisionsUnderRiskAndUncertainityMethodsCloseEventArgs();
            OnClose(LastResult);
        }

        public override CloseEventArgs ShowDialog()
        {
            //form = new frmModule();
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
