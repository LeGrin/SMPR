namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    partial class ctrlMethodLimiting
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlMethodLimiting));
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.lstAltern = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlMatrix1 = new Modules.MulticriterionProblemMethods.View.Controls.ctrlMatrix();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLimit
            // 
            this.txtLimit.AccessibleDescription = null;
            this.txtLimit.AccessibleName = null;
            resources.ApplyResources(this.txtLimit, "txtLimit");
            this.txtLimit.BackgroundImage = null;
            this.txtLimit.Font = null;
            this.txtLimit.Name = "txtLimit";
            // 
            // lstAltern
            // 
            this.lstAltern.AccessibleDescription = null;
            this.lstAltern.AccessibleName = null;
            resources.ApplyResources(this.lstAltern, "lstAltern");
            this.lstAltern.BackgroundImage = null;
            this.lstAltern.Font = null;
            this.lstAltern.FormattingEnabled = true;
            this.lstAltern.Name = "lstAltern";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleDescription = null;
            this.groupBox1.AccessibleName = null;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackgroundImage = null;
            this.groupBox1.Controls.Add(this.ctrlMatrix1);
            this.groupBox1.Font = null;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ctrlMatrix1
            // 
            this.ctrlMatrix1.AccessibleDescription = null;
            this.ctrlMatrix1.AccessibleName = null;
            resources.ApplyResources(this.ctrlMatrix1, "ctrlMatrix1");
            this.ctrlMatrix1.BackgroundImage = null;
            this.ctrlMatrix1.Font = null;
            this.ctrlMatrix1.Name = "ctrlMatrix1";
            this.ctrlMatrix1.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.AccessibleDescription = null;
            this.groupBox2.AccessibleName = null;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackgroundImage = null;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtLimit);
            this.groupBox2.Controls.Add(this.lstAltern);
            this.groupBox2.Font = null;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ctrlMethodLimiting
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = null;
            this.Name = "ctrlMethodLimiting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.ListBox lstAltern;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ctrlMatrix ctrlMatrix1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
