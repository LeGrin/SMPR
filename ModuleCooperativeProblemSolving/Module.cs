using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Drawing;

namespace Modules.ModuleCooperativeProblemSolving
{
    [Common.ModuleInfo(new string[] { "uk-UA::Кооперативне прийняття рішень", "en-US::Cooperative Problem Solving", "ru-RU::Кооперативное принятие решений", "zh::合作社的决策" })]
    [Common.About("Знов'як Юрій Володимирович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos))]
    public class Module : Common.ModuleAbstract
    {
        frmModule form;

        public Module()
        {
        }

        public Module(Method method)
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
            base.OnClose(null);
        }

        public override CloseEventArgs ShowDialog()
        {
            form = new frmModule();
            form.ShowDialog();
            return null;
        }
    }
}