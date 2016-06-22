namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    partial class ctrlMultipleRangeSelector
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
            this.ctrlRangeSelector = new Modules.MulticriterionProblemMethods.View.Controls.MethodCallback.ctrlRangeSelector ( );
            this.SuspendLayout ( );
            // 
            // ctrlRangeSelector
            // 
            this.ctrlRangeSelector.AutoSize = true;
            this.ctrlRangeSelector.Location = new System.Drawing.Point ( 3, 3 );
            this.ctrlRangeSelector.Name = "ctrlRangeSelector";
            this.ctrlRangeSelector.NumbersAfterDot = 2;
            this.ctrlRangeSelector.Size = new System.Drawing.Size ( 382, 64 );
            this.ctrlRangeSelector.TabIndex = 0;
            // 
            // ctrlMultipleRangeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF ( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add ( this.ctrlRangeSelector );
            this.Name = "ctrlMultipleRangeSelector";
            this.Size = new System.Drawing.Size ( 388, 70 );
            this.ResumeLayout ( false );
            this.PerformLayout ( );

        }

        #endregion

        private ctrlRangeSelector ctrlRangeSelector;
    }
}
