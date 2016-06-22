using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
    //[Serializable]
    partial class frmSelectBufferData : Form
    {
        /// <summary>
        /// Імя обраного в таблиці обєкту
        /// </summary>
        public string SelectedName
        {
            get 
            {
                if (dataGridViewBufferData.SelectedRows.Count > 0)
                    return dataGridViewBufferData.SelectedRows[0].Cells[0].Value.ToString();
                else
                    return null;
            }
        }

        /// <summary>
        /// Імя збережуваного обєкту
        /// </summary>
        public string SaveName
        {
            get { return textBoxSaveName.Text; }
        }

        public bool save;

        /// <summary>
        /// Валідатор обєктів
        /// </summary>
        public DataBuffer.ValidationCallback Validator;

        /// <summary>
        /// Конструктор форми роботи з буфером
        /// </summary>
        /// <param name="val">валідатор</param>
        public frmSelectBufferData(DataBuffer.ValidationCallback val)
            : this(false, val)
        { 
        }

        /// <summary>
        /// Конструктор форми роботи з буфером
        /// </summary>
        /// <param name="save">тру, якщо форма викликається для збереження обєктів</param>
        /// <param name="val">валідатор</param>
        public frmSelectBufferData(bool save, DataBuffer.ValidationCallback val)
        {
            InitializeComponent();

            this.save = save;

            Validator = val;

            DataBuffer.Instance.FillData(this);

            if (save)
            {
                textBoxSaveName.Visible = true;
                this.Text = "Збереження даних";
                buttonAccept.Text = "Зберегти";

                dataGridViewBufferData.ClearSelection();

                int i = 0;
                while (DataBuffer.Instance.KeyExists("Noname#" + i.ToString())) ++i;
                textBoxSaveName.Text = "Noname#" + i.ToString();
            }
            chbShowNonValid.Visible = !save;

            //test
            //dataGridViewBufferData.Rows.Add("test", SMPR.Properties.Resources._active__Copy, "test");
            //dataGridViewBufferData.Rows.Add("test1", SMPR.Properties.Resources._active__Cut, "test1");
            if (dataGridViewBufferData.SelectedRows.Count>0)
                buttonAccept.Enabled =
                    (dataGridViewBufferData.SelectedRows[0].DefaultCellStyle.BackColor != Color.DarkSalmon);
        }

        /// <summary>
        /// Додаэ обєкти до таблиці
        /// </summary>
        /// <param name="pars">Обєкти для додавання</param>
        public void AddData(params object[] pars)
        {
            dataGridViewBufferData.Rows.Add(pars);
        }

        /// <summary>
        /// Додаэ обєкти до таблиці
        /// </summary>
        /// <param name="pars">Обєкти для додавання</param>
        public void AddData(bool valRes, params object[] pars)
        {
            AddData(pars);
            if (!valRes )
            {
                if (chbShowNonValid.Checked)
                {
                    dataGridViewBufferData.Rows[dataGridViewBufferData.Rows.Count - 1].DefaultCellStyle.BackColor = Color.DarkSalmon;
                }
                else
                {
                    dataGridViewBufferData.Rows[dataGridViewBufferData.Rows.Count - 1].Visible = false;
                }
            }            
        }

        private string selName;

        private BufferData editedBd;

        private void UpdateBufferData(object sender, EventArgs e)
        {
            
            //int pos = dataGridViewBufferData.SelectedRows[0].Index;
            DataBuffer.Instance.RemoveData(selName);
            DataBuffer.Instance.AddData(selName, editedBd);

            dataGridViewBufferData.Rows.Clear();
            DataBuffer.Instance.FillData(this);
        }

        private void dataGridViewBufferData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            buttonAccept.Enabled = 
                    (dataGridViewBufferData.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.DarkSalmon);

            string dataName = dataGridViewBufferData.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBoxSaveName.Text = dataName;
            selName = dataName;

            //Loading user control
            BufferData bd = DataBuffer.Instance.Load(dataName);

            editedBd = bd;

            UserControl uc = bd.GenerateControl();
            foreach (Control c in panelUC.Controls)
            {
                c.Dispose();
            }
            panelUC.Controls.Clear();
            panelUC.Controls.Add(uc);

            bd.ChangeOccured -= UpdateBufferData;
            bd.ChangeOccured += UpdateBufferData;
        }

        private void dataGridViewBufferData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
                DataBuffer.Instance.ChangeName(selName, dataGridViewBufferData.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
        }

        private void dataGridViewBufferData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string name = e.FormattedValue.ToString();
                if (name != selName && DataBuffer.Instance.KeyExists(name) || name.Trim().Length == 0)
                    e.Cancel = true;

                
            }
        }

        private void panelUC_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewBufferData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelUC_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Height - panelUC.Height - 20;
        }

        private void frmSelectBufferData_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Height - panelUC.Height - 20;
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (sfdBuf.ShowDialog() == DialogResult.OK)         
            {
                DataBuffer.Instance.SerializeData(sfdBuf.FileName);
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            if (ofdBuf.ShowDialog() == DialogResult.OK)
            {
                DataBuffer.Instance.DeserializeData(ofdBuf.FileName);
                dataGridViewBufferData.Rows.Clear();
                DataBuffer.Instance.FillData(this);
            }        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (frmNewBufferElement.ShowNewElementForm() == DialogResult.OK)
            {
                dataGridViewBufferData.Rows.Clear();
                DataBuffer.Instance.FillData(this);
            }
        }

        private void dataGridViewBufferData_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataBuffer.Instance.RemoveData(e.Row.Cells[0].Value.ToString());
        }

        private void chbShowNonValid_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridViewBufferData.Rows.Clear();
            //Buffer.Instance.FillData(this);

            if (!chbShowNonValid.Checked)
            {
                foreach(DataGridViewRow row in dataGridViewBufferData.Rows)
                {
                    if(row.DefaultCellStyle.BackColor == Color.DarkSalmon)
                    {
                        row.Visible = false;
                    }
                }
                
            }
            else
            {
                foreach (DataGridViewRow row in dataGridViewBufferData.Rows)
                {
                    if (!row.Visible)
                    {
                        row.DefaultCellStyle.BackColor = Color.DarkSalmon;
                        row.Visible = true;
                    }
                }
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (!save && (dataGridViewBufferData.SelectedRows.Count != 1 || dataGridViewBufferData.SelectedRows[0].DefaultCellStyle.BackColor == Color.DarkSalmon))
                return;
            
            DialogResult = DialogResult.OK;
        }

    }
}