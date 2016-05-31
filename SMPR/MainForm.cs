using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Linq;

namespace SMPR
{
    public partial class pbTests : Form
    {
        public pbTests()
        {
            // get system localization and set it here.
            changeCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        //public string LocalizedHelp()
        //{
        //    frmHelp frm = new frmHelp();
        //    string fname = profile.CurrentMethod.Name.ToString() + "." + Thread.CurrentThread.CurrentUICulture.Name.ToString();
        //    //    MessageBox.Show(fname);
        //    //     MessageBox.Show(fname+".rtf","info must be in file:" );
        //    fname = fname.Replace(".", "_");
        //    fname = fname.Replace(" ", "_");
        //    fname = fname.Replace("-", "_");


        //    frmHelp.ShowHelp(Properties.Resources.ResourceManager.GetString(fname));  
        //}

        private void BuildHelpMenu()
        {
            ToolStripMenuItem mi_modules = new ToolStripMenuItem();
            mi_modules.Text = Properties.Resources.Modules; //Properties.Resources.Modules;
            mi_modules.Image = Properties.Resources.help;

            foreach (ModuleInfo i in ModuleInfo.Modules)
            {
                ToolStripMenuItem 
                                  mi_module = new ToolStripMenuItem(),
                                  mi_module_help = new ToolStripMenuItem(),
                                  mi_ui_help = new ToolStripMenuItem(),
                                  mi_method = new ToolStripMenuItem();
                

                mi_module.Text = i.Name;
                mi_module.Image = i.MenuIcon;

                ModuleInfo ii = i;

                mi_module_help.Text = Properties.Resources.ModuleTheory;
                //MessageBox.Show(ii.HelpFileString);
                mi_module_help.Click += delegate { frmHelp.ShowHelp(ii.HelpFileString); };

                mi_ui_help.Text = Properties.Resources.Usage;
                mi_ui_help.Click += delegate { frmHelp.ShowHelp(ii.HelpUIFileString); };

                if (ii.HelpFileString != null)
                {
                    mi_module_help.Image = Properties.Resources.th_help;
                    mi_module.DropDownItems.Add(mi_module_help);
                }
                if (ii.HelpUIFileString != null)
                {
                    mi_ui_help.Image = Properties.Resources.ui_help;
                    mi_module.DropDownItems.Add(mi_ui_help);
                }
                
                if (i.methods.Count > 0)
                {
                    if (mi_module.DropDownItems.Count>0)
                        mi_module.DropDownItems.Add(new ToolStripSeparator());

                    foreach (MethodAbstract m in i.methods)
                    {
                        if (m.HelpFileString != null)
                        {
                            string help = m.HelpFileString;
                            mi_method = new ToolStripMenuItem(m.Name);
                            mi_method.Click += delegate(object sender, EventArgs e) { frmHelp.ShowHelp(help); };

                            mi_module.DropDownItems.Add(mi_method);
                        }
                    }
                }

                if (mi_module.DropDownItems.Count>0)
                    mi_modules.DropDownItems.Add(mi_module);                
            }

            tsmHelp.DropDownItems.Add(mi_modules);
        }

        private void BuildModulesMenu()
        {
            foreach (ModuleInfo i in ModuleInfo.Modules)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem(),
                                  mi_mdi = new ToolStripMenuItem(),
                                  mi_dialog = new ToolStripMenuItem(),
                                  mi_method;
                mi.Text = i.Name;

                mi.Image = i.MenuIcon;

                ModuleInfo ii = i;

#if DEBUG
                mi_mdi.Text = "Mdi";
                
                mi_mdi.Click += delegate(object sender, EventArgs e) { ii.NewInstance().Show(this); };

                mi_dialog.Text = "Dialog";
                mi_dialog.Click += delegate(object sender, EventArgs e) { ii.NewInstance().ShowDialog(); };

                mi.DropDownItems.Add(mi_mdi);
                mi.DropDownItems.Add(mi_dialog);

#else
                mi_mdi.Text = Properties.Resources.OpenModule;
                mi_mdi.Click += delegate(object sender, EventArgs e) { ii.NewInstance().Show(this); };

                loadToolStripMenuItem.Visible = false;
                saveToolStripMenuItem.Visible = false;

                mi.DropDownItems.Add(mi_mdi);
#endif
                if (i.methods.Count > 0)
                {
                    mi.DropDownItems.Add(new ToolStripSeparator());

                    foreach (MethodAbstract m in i.methods)
                    {
                        MethodAbstract mm = m;
                        mi_method = new ToolStripMenuItem(m.Name);
                        mi_method.Click += delegate(object sender, EventArgs e) { /*ii.NewInstance().ShowDialog();*/ ii.NewInstance(mm).Show(this); };
                        mi.DropDownItems.Add(mi_method);
                    }
                }

                tsmModules.DropDownItems.Add(mi);
            }
        }

        private void BuildModulesList() 
        {
            ModulesListForm mlf = new ModulesListForm(this);
            //mlf.MdiParent = this;
            //mlf.WindowState = FormWindowState.Maximized;
            mlf.Owner = this;
            //mlf.StartPosition = FormStartPosition.Manual;
            mlf.Location = new Point(0, 56);
            mlf.Show();
        }

        private void changeCulture(string culture)
        {
            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
            Controls.Clear();
            foreach (Form f in OwnedForms)
                f.Close();
            InitializeComponent();
            BuildModulesMenu();

            BuildModulesList();
            ModuleInfo.InvalidateHelp();
            BuildHelpMenu();

            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "ru-RU":
                    tsmRussian.Checked = true;
                    break;
                case "en-US":
                    tsmEnglish.Checked = true;
                    break;
                case "uk-UA":
                    tsmUkrainian.Checked = true;
                    break;
                case "zh":
                    tsmZh.Checked = true;
                    break;
                default :
                    tsmEnglish.Checked = true;
                    break;
            }




        }
        private void tsmLangRussian_Click(object sender, EventArgs e)
        {
            changeCulture("ru-RU");
        }

        private void tsmLangEnglish_Click(object sender, EventArgs e)
        {
            changeCulture("en-US");
        }

        private void tsmLangUkrainian_Click(object sender, EventArgs e)
        {
            changeCulture("uk-UA");
        }

        private void tsmLangZh_Click(object sender, EventArgs e)
        {
            changeCulture("zh");
        }

        private void tsmAbout_Click(object sender, EventArgs e)
        {
            using (About form = new About())
                form.ShowDialog();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferData bb = Common.DataBuffer.Instance.LoadDialog();
            if (bb != null) MessageBox.Show(bb.ToString());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.DataBuffer.Instance.SaveDialog(new Common.DataTypes.Scalar<int>(5));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        struct ModulePicture
        {
            public string name;
            public PictureBox picture;
            public ModulePicture(string name,PictureBox picture)
            {
                this.name=name;
                this.picture=picture;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            ModulePicture[] names=new ModulePicture[]
            {
            new ModulePicture("Конфликты и компромиссы",pbConflictsAndCompromisses),
            new ModulePicture("Кооперативное принятие решений",pbCooperativeDecision),
            new ModulePicture("Методы голосования",pbVotingMethods),
            new ModulePicture("Методы экспертной оценки",pbPeerReviewMethods),
            new ModulePicture("Многокритериальные задачи",pbManyCriterionTasks),
            new ModulePicture("Принятие решений в условиях неопределенности и риска",pbUncertainty),
            new ModulePicture("Принятия решений в нечетких условиях",pbFuzzy),
            new ModulePicture("Тесты",pbTestss),
            new ModulePicture("Функции колективной полезности",pbCollectiveUsabilityFunctions)
            };
            //foreach(ModulePicture mp in names)
            //{
            //    var moduleobj = ModuleInfo.Modules.FirstOrDefault(x => x.Name == mp.name);
            //    mp.picture.Click+=(o,ee)=>
            //        {
            //           moduleobj.NewInstance().Show(this);
            //        };
            //}







        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            int EtalonHeight = (this.ClientRectangle.Height - 20) / 3-10;
            int EtalonWidth = (this.Width-20) / 3-10;
            int EtalonDelta = 5;
            PictureBox[] x = new PictureBox[10];
            x[0] = pbCollectiveUsabilityFunctions;
            x[1] = pbConflictsAndCompromisses;
            x[2] = pbCooperativeDecision;
            x[3] = pbPeerReviewMethods;
            x[4] = pbManyCriterionTasks;
            x[5] = pbUncertainty;
            x[6] = pbFuzzy;
            x[7] = pbVotingMethods;
            x[8] = pbTestss;
            int i;
            x[0].Height = EtalonHeight;
            x[0].Width = EtalonWidth;
            x[0].Left = 10;
            x[0].Top = 30;
            for (i = 1; i < 9; i++)
                if (x[i] != null)
            {
                if (i % 3 > 0)
                {
                    x[i].Left = x[i - 1].Left + x[i - 1].Width + EtalonDelta;
                    x[i].Top = x[i - 1].Top;
                }
                else
                {
                    x[i].Left = x[i - 3].Left;
                    x[i].Top = x[i - 3].Top + x[i - 3].Height + EtalonDelta;
                }
                x[i].Width = EtalonWidth;
                x[i].Height = EtalonHeight;
            }
        }

        private void pbConflictsAndCompromisses_Click(object sender, EventArgs e)
        {

        }

        private void removeLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseHelper.RemoveLicenseKey();
            MessageBox.Show(this, Properties.Resources.ActivationReset, Properties.Resources.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}