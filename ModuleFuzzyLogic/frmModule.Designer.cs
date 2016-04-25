namespace Modules.ModuleFuzzyLogic
{
    partial class frmModule
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonImageSets = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Andrii";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 10);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 41);
            this.button2.TabIndex = 0;
            this.button2.Text = "Rita";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(196, 10);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 41);
            this.button3.TabIndex = 0;
            this.button3.Text = "Dmytro";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(9, 68);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 41);
            this.button5.TabIndex = 0;
            this.button5.Text = "Kate";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonImageSets
            // 
            this.buttonImageSets.Location = new System.Drawing.Point(152, 68);
            this.buttonImageSets.Margin = new System.Windows.Forms.Padding(2);
            this.buttonImageSets.Name = "buttonImageSets";
            this.buttonImageSets.Size = new System.Drawing.Size(134, 41);
            this.buttonImageSets.TabIndex = 0;
            this.buttonImageSets.Text = "Відображення нечітких множин";
            this.buttonImageSets.UseVisualStyleBackColor = true;
            this.buttonImageSets.Click += new System.EventHandler(this.buttonImageSets_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(-184, 128);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 41);
            this.button7.TabIndex = 0;
            this.button7.Text = "button1";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // frmModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 129);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.buttonImageSets);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmModule";
            this.Text = "frmModule";
            this.Load += new System.EventHandler(this.frmModule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonImageSets;
        private System.Windows.Forms.Button button7;
    }
}