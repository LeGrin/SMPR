namespace Common
{
    partial class frmSelectBufferData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectBufferData));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chbShowNonValid = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.textBoxSaveName = new System.Windows.Forms.TextBox();
            this.dataGridViewBufferData = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewImageColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panelUC = new System.Windows.Forms.Panel();
            this.sfdBuf = new System.Windows.Forms.SaveFileDialog();
            this.ofdBuf = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBufferData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chbShowNonValid);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadFromFile);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSaveName);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewBufferData);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAccept);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelUC);
            // 
            // chbShowNonValid
            // 
            resources.ApplyResources(this.chbShowNonValid, "chbShowNonValid");
            this.chbShowNonValid.Checked = true;
            this.chbShowNonValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbShowNonValid.Name = "chbShowNonValid";
            this.chbShowNonValid.UseVisualStyleBackColor = true;
            this.chbShowNonValid.CheckedChanged += new System.EventHandler(this.chbShowNonValid_CheckedChanged);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLoadFromFile
            // 
            resources.ApplyResources(this.btnLoadFromFile, "btnLoadFromFile");
            this.btnLoadFromFile.BackColor = System.Drawing.Color.Silver;
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.UseVisualStyleBackColor = false;
            this.btnLoadFromFile.Click += new System.EventHandler(this.btnLoadFromFile_Click);
            // 
            // textBoxSaveName
            // 
            resources.ApplyResources(this.textBoxSaveName, "textBoxSaveName");
            this.textBoxSaveName.Name = "textBoxSaveName";
            // 
            // dataGridViewBufferData
            // 
            this.dataGridViewBufferData.AllowUserToAddRows = false;
            resources.ApplyResources(this.dataGridViewBufferData, "dataGridViewBufferData");
            this.dataGridViewBufferData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBufferData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.Content});
            this.dataGridViewBufferData.Name = "dataGridViewBufferData";
            this.dataGridViewBufferData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBufferData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBufferData_CellValidated);
            this.dataGridViewBufferData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewBufferData_CellValidating);
            this.dataGridViewBufferData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBufferData_RowEnter);
            this.dataGridViewBufferData.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewBufferData_UserDeletedRow);
            // 
            // ColumnName
            // 
            this.ColumnName.FillWeight = 134.7716F;
            resources.ApplyResources(this.ColumnName, "ColumnName");
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnType
            // 
            this.ColumnType.FillWeight = 30.45685F;
            resources.ApplyResources(this.ColumnType, "ColumnType");
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // Content
            // 
            this.Content.FillWeight = 134.7716F;
            resources.ApplyResources(this.Content, "Content");
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            // 
            // buttonAccept
            // 
            resources.ApplyResources(this.buttonAccept, "buttonAccept");
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // panelUC
            // 
            resources.ApplyResources(this.panelUC, "panelUC");
            this.panelUC.Name = "panelUC";
            this.panelUC.Resize += new System.EventHandler(this.panelUC_Resize);
            // 
            // sfdBuf
            // 
            resources.ApplyResources(this.sfdBuf, "sfdBuf");
            // 
            // ofdBuf
            // 
            this.ofdBuf.FileName = "*.bbin";
            resources.ApplyResources(this.ofdBuf, "ofdBuf");
            // 
            // frmSelectBufferData
            // 
            this.AcceptButton = this.buttonAccept;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectBufferData";
            this.Resize += new System.EventHandler(this.frmSelectBufferData_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBufferData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxSaveName;
        private System.Windows.Forms.DataGridView dataGridViewBufferData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Panel panelUC;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog sfdBuf;
        private System.Windows.Forms.OpenFileDialog ofdBuf;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chbShowNonValid;

    }
}