using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Common;

namespace SMPR
{
    public partial class AboutBlock : UserControl
    {
        private AboutAttribute attribute;

        public AboutAttribute Attribute
        {
            get { return attribute; }
            set 
            { 
                attribute = value;
                lbName.Text = value.Name;
                lbOrganization.Text = value.Organization;
                lbGroup.Text = value.Group;
                pbPhoto.Image = value.Photo;
            }
        }

        public AboutBlock(AboutAttribute attribute)
        {
            InitializeComponent();
            Attribute = attribute;
        }
    }
}
