namespace SMPR
{
    partial class LicenseForm
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
            this.activateBtn = new System.Windows.Forms.Button();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.lbUserId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.helbLb = new System.Windows.Forms.Label();
            this.contactLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // activateBtn
            // 
            this.activateBtn.Location = new System.Drawing.Point(215, 114);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(100, 23);
            this.activateBtn.TabIndex = 0;
            this.activateBtn.Text = "Активувати";
            this.activateBtn.UseVisualStyleBackColor = true;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(99, 58);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.ReadOnly = true;
            this.tbUserId.Size = new System.Drawing.Size(216, 20);
            this.tbUserId.TabIndex = 1;
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(12, 61);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(81, 13);
            this.lbUserId.TabIndex = 2;
            this.lbUserId.Text = "Ідентифікатор:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ключ:";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(99, 88);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(216, 20);
            this.tbKey.TabIndex = 4;
            // 
            // helbLb
            // 
            this.helbLb.Location = new System.Drawing.Point(15, 9);
            this.helbLb.Name = "helbLb";
            this.helbLb.Size = new System.Drawing.Size(300, 31);
            this.helbLb.TabIndex = 5;
            this.helbLb.Text = "Щоб отримати ключ, зв\'яжіться з автором програми та вкажіть свій унікальний ідент" +
    "ифікатор.";
            // 
            // contactLink
            // 
            this.contactLink.AutoSize = true;
            this.contactLink.Location = new System.Drawing.Point(225, 40);
            this.contactLink.Name = "contactLink";
            this.contactLink.Size = new System.Drawing.Size(90, 13);
            this.contactLink.TabIndex = 6;
            this.contactLink.TabStop = true;
            this.contactLink.Text = "legrin@gmail.com";
            this.contactLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.contactLink_LinkClicked);
            // 
            // LicenseForm
            // 
            this.AcceptButton = this.activateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 149);
            this.Controls.Add(this.contactLink);
            this.Controls.Add(this.helbLb);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUserId);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.activateBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Активуйте програму";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label helbLb;
        private System.Windows.Forms.LinkLabel contactLink;
    }
}