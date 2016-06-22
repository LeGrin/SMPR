namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    partial class ctrlYesNoDialog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.rbYes = new System.Windows.Forms.RadioButton ( );
            this.rbNo = new System.Windows.Forms.RadioButton ( );
            this.panel1 = new System.Windows.Forms.Panel ( );
            this.panel1.SuspendLayout ( );
            this.SuspendLayout ( );
            // 
            // rbYes
            // 
            this.rbYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point ( 13, 5 );
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size ( 44, 17 );
            this.rbYes.TabIndex = 0;
            this.rbYes.Text = "връ";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // rbNo
            // 
            this.rbNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbNo.AutoSize = true;
            this.rbNo.Checked = true;
            this.rbNo.Location = new System.Drawing.Point ( 13, 28 );
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size ( 35, 17 );
            this.rbNo.TabIndex = 1;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "ЭГ";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add ( this.rbYes );
            this.panel1.Controls.Add ( this.rbNo );
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point ( 0, 0 );
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size ( 69, 53 );
            this.panel1.TabIndex = 2;
            // 
            // ctrlYesNoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add ( this.panel1 );
            this.MinimumSize = new System.Drawing.Size ( 69, 53 );
            this.Name = "ctrlYesNoDialog";
            this.Size = new System.Drawing.Size ( 69, 53 );
            this.panel1.ResumeLayout ( false );
            this.panel1.PerformLayout ( );
            this.ResumeLayout ( false );

        }

        #endregion

        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.Panel panel1;
    }
}
