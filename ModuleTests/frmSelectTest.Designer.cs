using System.Threading;
namespace Modules.Tests
{
    partial class frmSelectTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectTest));
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Test";
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    this.button1.Text = "Запустити тест";
                    break;


                case "ru-RU":
                    this.button1.Text = "Запустить тест";
                    break;

                case "en-US":
                    this.button1.Text = "Run Test";
                    break;

                    default:
                    this.button1.Text = "Run Test";
                    break;
            }
            
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(333, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    this.button2.Text = "Відміна";
                    break;


                case "ru-RU":
                    this.button2.Text = "Отмена";
                    break;

                case "en-US":
                    this.button2.Text = "Cancel";
                    break;

                default:
                    this.button2.Text = "Cancel";
                    break;
            }
            
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSelectTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 103);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSelectTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //this.Text = "Вибір тесту";
            switch (Thread.CurrentThread.CurrentUICulture.Name)
            {
                case "uk-UA":
                    this.Text = "Вибір теста";
                    break;


                case "ru-RU":
                    this.Text = "Выбор теста";
                    break;

                case "en-US":
                    this.Text = "Select test";
                    break;

                default:
                    this.Text = "Select test";
                    break;
            }
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;



    }
}