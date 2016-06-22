using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;

namespace SMPR
{
    public partial class About : Form
    {
        public void AddTab(List<AboutAttribute> About, string TabName)
        {
            TabPage tab = new TabPage(TabName);
            
            AboutBlock block;
            tabControl1.Controls.Add(tab);
            tab.AutoScroll = true;
            int Y = 10;
            foreach (AboutAttribute about in About)
            {
                block = new AboutBlock(about);
                block.Top = Y;
                block.Height = 100;
                block.Left = 5;
                block.Width = tab.ClientSize.Width-10;
                block.Anchor = block.Anchor | AnchorStyles.Right;
                tab.Controls.Add(block);

                Y += 110;
            }
        }

        public About()
        {
            InitializeComponent();
            {
                object[] attrs_obj = typeof(ModuleAbstract).GetCustomAttributes(typeof(AboutAttribute),false);
                List<AboutAttribute> attrs = new List<AboutAttribute>();
                foreach(object obj in attrs_obj)
                    if (obj is AboutAttribute)
                        attrs.Add(obj as AboutAttribute);
                AddTab(attrs, Properties.Resources.CoreDevelopers);
                tabControl1.TabPages[0].BorderStyle = BorderStyle.FixedSingle;
            }
            foreach (ModuleInfo info in ModuleInfo.Modules)
                if (info.About.Count > 0)
                    AddTab(info.About, info.Name );            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}