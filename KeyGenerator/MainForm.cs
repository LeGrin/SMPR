using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KeyGenerator.Properties;
using System.Resources;
using Common;

namespace KeyGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {            
            InitializeComponent();
            this.ShowIcon = true;
            this.Icon = Resources.key_green;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            String userId = tbUserId.Text;

            try
            {
                String hdd = LicenseHelper.DecryptStringAES(userId, LicenseHelper.USER_ID_ENCRYPTION_STRING);
                tbHdd.Text = hdd;

                String message = "01'\"@'. *!@^@*&#%89~{]{~";
                String key = LicenseHelper.EncryptStringAES(message, userId);
                tbKey.Text = key;
            }
            catch
            {
                MessageBox.Show("Ідентифікатор неправильний.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
