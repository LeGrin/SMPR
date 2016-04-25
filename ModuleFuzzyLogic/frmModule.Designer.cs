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
            this.binRelationsPropButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonOperOnRelation = new System.Windows.Forms.Button();
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // binRelationsPropButton
            // 
            this.binRelationsPropButton.Location = new System.Drawing.Point(137, 12);
            this.binRelationsPropButton.Name = "binRelationsPropButton";
            this.binRelationsPropButton.Size = new System.Drawing.Size(119, 51);
            this.binRelationsPropButton.TabIndex = 0;
            this.binRelationsPropButton.Text = "Властивості бін. відн.";
            this.binRelationsPropButton.UseVisualStyleBackColor = true;
            this.binRelationsPropButton.Click += new System.EventHandler(this.binRelationsPropButton_Click);
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
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonOperOnRelation
            // 
            this.buttonOperOnRelation.Location = new System.Drawing.Point(9, 68);
            this.buttonOperOnRelation.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOperOnRelation.Name = "buttonOperOnRelation";
            this.buttonOperOnRelation.Size = new System.Drawing.Size(124, 41);
            this.buttonOperOnRelation.TabIndex = 0;
            this.buttonOperOnRelation.Text = "Операції над нечіткими відношенннями";
            this.buttonOperOnRelation.UseVisualStyleBackColor = true;
            this.buttonOperOnRelation.Click += new System.EventHandler(this.buttonOperOnRelation_Click);

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
            this.Controls.Add(this.buttonOperOnRelation);
            this.Controls.Add(this.buttonImageSets);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.binRelationsPropButton);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmModule";
            this.Text = "frmModule";
            this.Load += new System.EventHandler(this.frmModule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button binRelationsPropButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonOperOnRelation;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonImageSets;
        private System.Windows.Forms.Button button7;
    }
}