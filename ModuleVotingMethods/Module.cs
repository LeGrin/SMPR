using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.VotingMethods
{
    [Common.ModuleInfo(new string[] { "uk-UA::Методи голосування", "ru-RU::Методы голосования", "en-US::Voting Methods", "zh::投票方法" })]
    [Common.About("Лозицький Дмитро Анатолійович", Group = "ТК-3 (2007-2008)", ResourceClassType = typeof(AboutPhotos), PhotoResName="mit")]
    public class Module : Common.ModuleAbstractEx<Method>
    {
        frmModule form;

        public class VotingMethodsCloseEventArgs : CloseEventArgs
        {
        }

        public Module()
        {
            form = new frmModule(this.Methods);
            form.Text = Name;
        }

        public Module(Method method)
        {
            form = new frmModule(this.Methods);
            form.Text = Name;
            form.cmbMethod.SelectedItem = method;
        }

        public Module(Scalar<string> method, Scalar<Int32> numberCandidates, Scalar<Int32> numberVoters, Matrix<Int32> dataVotes, Vector<Int32> points)
        {
            form = new frmModule(method, numberCandidates, numberVoters, dataVotes, points, this.Methods);
        }

        public override void Show(Form MdiParent)
        {
            form.Text = Name;
            if (MdiParent!=null && MdiParent.IsMdiContainer)
            form.MdiParent = MdiParent;
            form.Show();
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            LastResult = new VotingMethodsCloseEventArgs();
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