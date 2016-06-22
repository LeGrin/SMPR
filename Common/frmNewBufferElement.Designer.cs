namespace Common
{
    partial class frmNewBufferElement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewBufferElement));
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cmbxNewElement = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxGenericType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxName
            // 
            resources.ApplyResources(this.tbxName, "tbxName");
            this.tbxName.Name = "tbxName";
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // cmbxNewElement
            // 
            resources.ApplyResources(this.cmbxNewElement, "cmbxNewElement");
            this.cmbxNewElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxNewElement.FormattingEnabled = true;
            this.cmbxNewElement.Items.AddRange(new object[] {
            resources.GetString("cmbxNewElement.Items"),
            resources.GetString("cmbxNewElement.Items1"),
            resources.GetString("cmbxNewElement.Items2")});
            this.cmbxNewElement.Name = "cmbxNewElement";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmbxGenericType
            // 
            resources.ApplyResources(this.cmbxGenericType, "cmbxGenericType");
            this.cmbxGenericType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxGenericType.FormattingEnabled = true;
            this.cmbxGenericType.Items.AddRange(new object[] {
            resources.GetString("cmbxGenericType.Items"),
            resources.GetString("cmbxGenericType.Items1"),
            resources.GetString("cmbxGenericType.Items2"),
            resources.GetString("cmbxGenericType.Items3")});
            this.cmbxGenericType.Name = "cmbxGenericType";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmNewBufferElement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbxGenericType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbxNewElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewBufferElement";
            this.Load += new System.EventHandler(this.frmNewBufferElement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox cmbxNewElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxGenericType;
        private System.Windows.Forms.Button button1;
    }
}