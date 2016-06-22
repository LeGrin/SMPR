namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    partial class ctrlShowAlternativeAndYesNoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( ctrlShowAlternativeAndYesNoDialog ) );
            this.ctrlYesNoDialog = new Modules.MulticriterionProblemMethods.View.Controls.MethodCallback.ctrlYesNoDialog ( );
            this.ctrlMatrix = new Modules.MulticriterionProblemMethods.View.Controls.ctrlMatrix ( );
            this.SuspendLayout ( );
            // 
            // ctrlYesNoDialog
            // 
            this.ctrlYesNoDialog.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ctrlYesNoDialog.AutoSize = true;
            this.ctrlYesNoDialog.Location = new System.Drawing.Point ( 0, 497 );
            this.ctrlYesNoDialog.MinimumSize = new System.Drawing.Size ( 69, 53 );
            this.ctrlYesNoDialog.Name = "ctrlYesNoDialog";
            this.ctrlYesNoDialog.Size = new System.Drawing.Size ( 806, 53 );
            this.ctrlYesNoDialog.TabIndex = 0;
            // 
            // ctrlMatrix
            // 
            this.ctrlMatrix.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.ctrlMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlMatrix.Location = new System.Drawing.Point ( 3, 3 );
            this.ctrlMatrix.Matrix = ( ( Modules.MulticriterionProblemMethods.DataTypes.Matrix ) ( resources.GetObject ( "ctrlMatrix.Matrix" ) ) );
            this.ctrlMatrix.Name = "ctrlMatrix";
            this.ctrlMatrix.ReadOnly = false;
            this.ctrlMatrix.Size = new System.Drawing.Size ( 800, 491 );
            this.ctrlMatrix.TabIndex = 1;
            // 
            // ctrlShowAlternativeAndYesNoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add ( this.ctrlMatrix );
            this.Controls.Add ( this.ctrlYesNoDialog );
            this.MinimumSize = new System.Drawing.Size ( 71, 93 );
            this.Name = "ctrlShowAlternativeAndYesNoDialog";
            this.Size = new System.Drawing.Size ( 806, 553 );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

        }

        #endregion

        private ctrlYesNoDialog ctrlYesNoDialog;
        private ctrlMatrix ctrlMatrix;
    }
}
