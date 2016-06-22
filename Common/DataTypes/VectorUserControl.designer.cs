namespace Common
{
    namespace DataTypes
    {
        partial class VectorUserControl
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
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.UpdateButton = new System.Windows.Forms.Button();
                this.AddButton = new System.Windows.Forms.Button();
                this.DeleteButton = new System.Windows.Forms.Button();
                this.ClearButton = new System.Windows.Forms.Button();
                this.AcceptButton = new System.Windows.Forms.Button();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // listBox1
                // 
                this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(0, 0);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(150, 147);
                this.listBox1.TabIndex = 0;
                this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
                // 
                // textBox1
                // 
                this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.textBox1.Location = new System.Drawing.Point(156, 3);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(171, 20);
                this.textBox1.TabIndex = 1;
                this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
                this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
                // 
                // UpdateButton
                // 
                this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.UpdateButton.Location = new System.Drawing.Point(41, 37);
                this.UpdateButton.Name = "UpdateButton";
                this.UpdateButton.Size = new System.Drawing.Size(58, 23);
                this.UpdateButton.TabIndex = 2;
                this.UpdateButton.Text = "Прийняти";
                this.UpdateButton.UseVisualStyleBackColor = true;
                this.UpdateButton.Visible = false;
                this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
                // 
                // AddButton
                // 
                this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.AddButton.Location = new System.Drawing.Point(156, 37);
                this.AddButton.Name = "AddButton";
                this.AddButton.Size = new System.Drawing.Size(143, 23);
                this.AddButton.TabIndex = 3;
                this.AddButton.Text = "Додати";
                this.AddButton.UseVisualStyleBackColor = true;
                this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
                // 
                // DeleteButton
                // 
                this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.DeleteButton.Location = new System.Drawing.Point(156, 66);
                this.DeleteButton.Name = "DeleteButton";
                this.DeleteButton.Size = new System.Drawing.Size(143, 23);
                this.DeleteButton.TabIndex = 4;
                this.DeleteButton.Text = "Видалити";
                this.DeleteButton.UseVisualStyleBackColor = true;
                this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
                // 
                // ClearButton
                // 
                this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.ClearButton.Location = new System.Drawing.Point(156, 95);
                this.ClearButton.Name = "ClearButton";
                this.ClearButton.Size = new System.Drawing.Size(171, 23);
                this.ClearButton.TabIndex = 5;
                this.ClearButton.Text = "Видалити всі";
                this.ClearButton.UseVisualStyleBackColor = true;
                this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
                // 
                // AcceptButton
                // 
                this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.AcceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.AcceptButton.Location = new System.Drawing.Point(156, 124);
                this.AcceptButton.Name = "AcceptButton";
                this.AcceptButton.Size = new System.Drawing.Size(171, 23);
                this.AcceptButton.TabIndex = 6;
                this.AcceptButton.Text = "Зберегти зміни в буфер";
                this.AcceptButton.UseVisualStyleBackColor = true;
                this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.Location = new System.Drawing.Point(305, 66);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(22, 23);
                this.button1.TabIndex = 7;
                this.button1.Text = "v";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button2.Location = new System.Drawing.Point(305, 37);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(22, 23);
                this.button2.TabIndex = 8;
                this.button2.Text = "^";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(24, 83);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(75, 23);
                this.button3.TabIndex = 9;
                this.button3.Text = "button3";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Visible = false;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // VectorUserControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.AcceptButton);
                this.Controls.Add(this.ClearButton);
                this.Controls.Add(this.DeleteButton);
                this.Controls.Add(this.AddButton);
                this.Controls.Add(this.UpdateButton);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.listBox1);
                this.Name = "VectorUserControl";
                this.Size = new System.Drawing.Size(332, 151);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.ListBox listBox1;
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Button UpdateButton;
            private System.Windows.Forms.Button AddButton;
            private System.Windows.Forms.Button DeleteButton;
            private System.Windows.Forms.Button ClearButton;
            private System.Windows.Forms.Button AcceptButton;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;

        }
    }
}
