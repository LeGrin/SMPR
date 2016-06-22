using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.View.Controls;

namespace Modules.MulticriterionProblemMethods.View.Forms
{
    partial class frmResultPresenter
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager ( typeof ( frmResultPresenter ) );
            this.ctrlMultiCriteriaMatrix1 = new ctrlMatrix ( );
            this.btnClose = new System.Windows.Forms.Button ( );
            this.SuspendLayout ( );
            // 
            // ctrlMultiCriteriaMatrix1
            // 
            this.ctrlMultiCriteriaMatrix1.AccessibleDescription = null;
            this.ctrlMultiCriteriaMatrix1.AccessibleName = null;
            resources.ApplyResources ( this.ctrlMultiCriteriaMatrix1, "ctrlMultiCriteriaMatrix1" );
            this.ctrlMultiCriteriaMatrix1.BackgroundImage = null;
            this.ctrlMultiCriteriaMatrix1.Font = null;
            this.ctrlMultiCriteriaMatrix1.Matrix = ( ( Modules.MulticriterionProblemMethods.DataTypes.Matrix ) ( resources.GetObject ( "ctrlMultiCriteriaMatrix1.Matrix" ) ) );
            this.ctrlMultiCriteriaMatrix1.Name = "ctrlMultiCriteriaMatrix1";
            this.ctrlMultiCriteriaMatrix1.ReadOnly = false;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleDescription = null;
            this.btnClose.AccessibleName = null;
            resources.ApplyResources ( this.btnClose, "btnClose" );
            this.btnClose.BackgroundImage = null;
            this.btnClose.Font = null;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler ( this.btnClose_Click );
            // 
            // frmResultPresenter
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources ( this, "$this" );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add ( this.btnClose );
            this.Controls.Add ( this.ctrlMultiCriteriaMatrix1 );
            this.Font = null;
            this.Icon = null;
            this.Name = "frmResultPresenter";
            this.ResumeLayout ( false );

        }

        #endregion

        private ctrlMatrix ctrlMultiCriteriaMatrix1;
        private System.Windows.Forms.Button btnClose;
    }
}