namespace Modules.MulticriterionProblemMethods.View.Forms.MethodCallback
{
    partial class frmMethodCallback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( frmMethodCallback ) );
            this.btnOk = new System.Windows.Forms.Button ( );
            this.pnlClientArea = new System.Windows.Forms.Panel ( );
            this.label2 = new System.Windows.Forms.Label ( );
            this.label1 = new System.Windows.Forms.Label ( );
            this.btnClose = new System.Windows.Forms.Button ( );
            this.pnlClientArea.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // btnOk
            // 
            this.btnOk.AccessibleDescription = null;
            this.btnOk.AccessibleName = null;
            resources.ApplyResources ( this.btnOk, "btnOk" );
            this.btnOk.BackgroundImage = null;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler ( this.btn_Click );
            // 
            // pnlClientArea
            // 
            this.pnlClientArea.AccessibleDescription = null;
            this.pnlClientArea.AccessibleName = null;
            resources.ApplyResources ( this.pnlClientArea, "pnlClientArea" );
            this.pnlClientArea.BackgroundImage = null;
            this.pnlClientArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlClientArea.Controls.Add ( this.label2 );
            this.pnlClientArea.Controls.Add ( this.label1 );
            this.pnlClientArea.Font = null;
            this.pnlClientArea.Name = "pnlClientArea";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = null;
            this.label2.AccessibleName = null;
            resources.ApplyResources ( this.label2, "label2" );
            this.label2.Font = null;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources ( this.label1, "label1" );
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources ( this.btnClose, "btnClose" );
            this.btnClose.BackgroundImage = null;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler ( this.btn_Click );
            // 
            // frmMethodCallback
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources ( this, "$this" );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btnClose;
            this.ControlBox = false;
            this.Controls.Add ( this.btnClose );
            this.Controls.Add ( this.pnlClientArea );
            this.Controls.Add ( this.btnOk );
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = null;
            this.Name = "frmMethodCallback";
            this.pnlClientArea.ResumeLayout ( false );
            this.pnlClientArea.PerformLayout ( );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel pnlClientArea;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}