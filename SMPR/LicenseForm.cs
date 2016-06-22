using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using System.Diagnostics;

namespace SMPR
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.keys;
            this.contactLink.Links.Add(new LinkLabel.Link() { LinkData = "mailto:legrin@gmail.com" });
            this.tbUserId.Text = LicenseHelper.GetUserId();
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LicenseHelper.SaveLicenseKey(this.tbKey.Text);
                MessageBox.Show(Properties.Resources.ActivationSuccess, Properties.Resources.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                MessageBox.Show(Properties.Resources.ActivationFail,
                    Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }        

        private void contactLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as String);
        }
    }
}
