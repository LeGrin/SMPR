using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;

namespace SMPR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
#if DEBUG
            bool isLicensed = true;
#else
            bool isLicensed = false;
            try
            {
                isLicensed = LicenseHelper.IsLicensed();
            }
            catch
            {
                isLicensed = false;
                MessageBox.Show(Properties.Resources.ActivationFail,
                    Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
#endif                        
            if (isLicensed || new LicenseForm().ShowDialog() == DialogResult.OK)
            {
                Application.Run(new pbTests());
            }
            else 
            {
                Application.Exit();
            }
        }
    }
}