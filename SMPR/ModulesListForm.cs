using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace SMPR
{
    public partial class ModulesListForm : Form
    {
        private Form parentForm;
        public ModulesListForm Instanse;
        public ModulesListForm(Form parent)
        {
            InitializeComponent();
            InitModules();
            parentForm = parent;
            
            listView1.MultiSelect = false;
        }

        private void InitModules()
        {
            listView1.SmallImageList = new ImageList();
            foreach(var module in ModuleInfo.Modules)
            {
                if (module.MenuIcon!=null)
                listView1.SmallImageList.Images.Add(module.MenuIcon);
                var item = new ListViewItem();
                item.ImageIndex = listView1.SmallImageList.Images.Count - 1;
                item.Name = module.Name;
                item.Text = module.Name;
                item.Tag = module;
                listView1.Items.Add(item);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && listView1.SelectedItems[0].Tag is ModuleInfo)
                (listView1.SelectedItems[0].Tag as ModuleInfo).NewInstance().Show(parentForm);
                //(listView1.SelectedItems[0].Tag as ModuleInfo).NewInstance().ShowDialog();
        }

        internal void StartPosition()
        {
            throw new NotImplementedException();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
