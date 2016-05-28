namespace Modules.ModuleFuzzyLogic
{
    partial class LarsenAlgorithmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.setA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setB1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setB2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setA1,
            this.setA2,
            this.setB1,
            this.setB2,
            this.setC1,
            this.setC2});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(644, 213);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.onCellValidation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Множини подаються у форматі ЧИСЛО/ЙМОВІРНІСТЬ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обчислити";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // setA1
            // 
            this.setA1.HeaderText = "Множина A1";
            this.setA1.Name = "setA1";
            // 
            // setA2
            // 
            this.setA2.HeaderText = "Множина A2";
            this.setA2.Name = "setA2";
            // 
            // setB1
            // 
            this.setB1.HeaderText = "Множина B1";
            this.setB1.Name = "setB1";
            // 
            // setB2
            // 
            this.setB2.HeaderText = "Множина B2";
            this.setB2.Name = "setB2";
            // 
            // setC1
            // 
            this.setC1.HeaderText = "Множина C1";
            this.setC1.Name = "setC1";
            // 
            // setC2
            // 
            this.setC2.HeaderText = "Множина C2";
            this.setC2.Name = "setC2";
            // 
            // LarsenAlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 453);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LarsenAlgorithmForm";
            this.Text = "Алгоритм Ларсена";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn setB1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setB2;
        private System.Windows.Forms.DataGridViewTextBoxColumn setC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setC2;
    }
}