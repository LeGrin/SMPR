using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Common
{
    public partial class frmNewBufferElement : Form
    {
        public frmNewBufferElement()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {            
            if (DataBuffer.Instance.KeyExists(tbxName.Text))
            {
                MessageBox.Show("Об'єкт з таким ім'ям вже існує");
            }
            else
            {
                BufferData bd = BufferDataFactory.GetBufferData(cmbxNewElement.SelectedIndex, cmbxGenericType.SelectedIndex);
                DataBuffer.Instance.AddData(tbxName.Text, bd);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public static DialogResult ShowNewElementForm()
        {
            frmNewBufferElement bd = new frmNewBufferElement();
            return bd.ShowDialog();           
        }

        private void frmNewBufferElement_Load(object sender, EventArgs e)
        {            
            cmbxGenericType.SelectedIndex = 0;
            cmbxNewElement.SelectedIndex = 0;
        }
    }
}