namespace KeyGenerator
{
    partial class MainForm
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
            this.lbUserId = new System.Windows.Forms.Label();
            this.lbKey = new System.Windows.Forms.Label();
            this.lbHdd = new System.Windows.Forms.Label();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbHdd = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(24, 23);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(81, 13);
            this.lbUserId.TabIndex = 0;
            this.lbUserId.Text = "Ідентифікатор:";
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(69, 90);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(36, 13);
            this.lbKey.TabIndex = 1;
            this.lbKey.Text = "Ключ:";
            // 
            // lbHdd
            // 
            this.lbHdd.AutoSize = true;
            this.lbHdd.Location = new System.Drawing.Point(16, 56);
            this.lbHdd.Name = "lbHdd";
            this.lbHdd.Size = new System.Drawing.Size(89, 13);
            this.lbHdd.TabIndex = 2;
            this.lbHdd.Text = "Жорсткий диск:";
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(111, 20);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(448, 20);
            this.tbUserId.TabIndex = 3;
            // 
            // tbHdd
            // 
            this.tbHdd.Location = new System.Drawing.Point(112, 53);
            this.tbHdd.Name = "tbHdd";
            this.tbHdd.ReadOnly = true;
            this.tbHdd.Size = new System.Drawing.Size(448, 20);
            this.tbHdd.TabIndex = 4;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(112, 87);
            this.tbKey.Name = "tbKey";
            this.tbKey.ReadOnly = true;
            this.tbKey.Size = new System.Drawing.Size(448, 20);
            this.tbKey.TabIndex = 5;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(443, 119);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(117, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Згенерувати ключ";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 150);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.tbHdd);
            this.Controls.Add(this.tbUserId);
            this.Controls.Add(this.lbHdd);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.lbUserId);
            this.Name = "MainForm";
            this.Text = "Генератор ключів";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.Label lbHdd;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.TextBox tbHdd;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnGenerate;
    }
}

