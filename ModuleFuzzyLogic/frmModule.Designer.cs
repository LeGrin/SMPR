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
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Andrii";
            this.button1.UseVisualStyleBackColor = true;
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
            this.button3.Location = new System.Drawing.Point(262, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 51);
            this.button3.TabIndex = 0;
            this.button3.Text = "Dmytro";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 84);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 51);
            this.button5.TabIndex = 0;
            this.button5.Text = "Kate";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(203, 84);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(178, 51);
            this.button6.TabIndex = 0;
            this.button6.Text = "Sofiia";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(-245, 157);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(119, 51);
            this.button7.TabIndex = 0;
            this.button7.Text = "button1";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // frmModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 159);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.binRelationsPropButton);
            this.Controls.Add(this.button1);
            this.Name = "frmModule";
            this.Text = "frmModule";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button binRelationsPropButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}