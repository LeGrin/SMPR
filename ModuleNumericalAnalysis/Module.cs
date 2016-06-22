using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Modules.ModuleNumericalAnalysis
{
    [Common.ModuleInfo(new string[] { "uk-UA::Чисельні методи", "en-US::Numerical analysis", "ru-RU::Вычислительные методы", "zh::數值分析" })]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;
        public Module()
        {
            form = new frmModule();
            form.Show();
        }

        public Module(Method meth)
        {
            if(meth.Name == "Операції над нечіткими відношеннями")
            {
                form = new frmModule();
            }
            form = new frmModule();
        }

        public override void Show(Form MdiParent)
        {
            
        }

        public override CloseEventArgs ShowDialog()
        {
            form.Show();
            return null;
        }

        protected override void OnClose(CloseEventArgs args)
        {
         
        }

    }
}
