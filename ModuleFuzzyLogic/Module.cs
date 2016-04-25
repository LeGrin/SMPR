using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Modules.ModuleFuzzyLogic
{
    [Common.ModuleInfo(new string[] { "uk-UA::Нечітка логіка", "en-US::Fuzzy logic", "ru-RU::Нечеткая логика", "zh::模糊逻辑" })]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;
        public Module()
        {
            form = new frmModule();
        }

        public Module(Method meth)
        {
            if(meth.Name == "Операції над нечіткими відношеннями")
            {
                frmOperOnRelation fOOR = new frmOperOnRelation();
                fOOR.Show();
            }
        }

        public override void Show(Form MdiParent)
        {
            
        }

        public override CloseEventArgs ShowDialog()
        {
            return null;
        }

        protected override void OnClose(CloseEventArgs args)
        {
         
        }

    }
}
