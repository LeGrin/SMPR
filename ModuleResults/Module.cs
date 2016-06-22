using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Common.DataTypes;

namespace Modules.Results
{
    /// Example:
    /// [Common.ModuleInfo(new string[] { "uk-UA::Модуль", "ru-RU::Модуль", "en-US::Module" })]
    /// [Common.About("ФИО", Group = "группа (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName="")]
    [Common.ModuleInfo(new string[] { "uk-UA::Оцінка результатів навчання", "ru-RU::Оценка результатов обучения", "en-US::Study results", "zh::评估学习成果" })]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;

        public Module()
        {
        }

        public Module(Method method)
            : this()
        {
            //do something to initialize module by method
        }

        public override void Show(Form MdiParent)
        {
            form = new frmModule(this.Methods);
            form.Text = Name;
            if (MdiParent != null && MdiParent.IsMdiContainer)
                form.MdiParent = MdiParent;
            form.Show();
        }

        public override CloseEventArgs ShowDialog()
        {
            form = new frmModule();
            form.ShowDialog();
            return LastResult;
        }

        protected override void OnClose(CloseEventArgs args)
        {
            // Buffer.Instance.Save("Останні результати модуля " + this.GetType().Name, args.result);
            base.OnClose(args);
        }

    }
}