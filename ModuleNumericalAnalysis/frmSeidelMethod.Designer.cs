namespace Modules.ModuleNumericalAnalysis
{
    partial class frmSeidelMethod
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
            this.answer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.epsilon = new System.Windows.Forms.TextBox();
            this.max_iter_numeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvFunctions = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.variableNumber = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Location = new System.Drawing.Point(268, 402);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(0, 17);
            this.answer.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(203, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 19;
            this.label4.Text = "Answer";
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(486, 68);
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(100, 22);
            this.epsilon.TabIndex = 18;
            // 
            // max_iter_numeric
            // 
            this.max_iter_numeric.Location = new System.Drawing.Point(665, 67);
            this.max_iter_numeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.max_iter_numeric.Name = "max_iter_numeric";
            this.max_iter_numeric.Size = new System.Drawing.Size(120, 22);
            this.max_iter_numeric.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(592, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Max iter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(414, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Epsilon";
            // 
            // dgvFunctions
            // 
            this.dgvFunctions.AllowUserToAddRows = false;
            this.dgvFunctions.AllowUserToDeleteRows = false;
            this.dgvFunctions.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFunctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunctions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.function,
            this.firstValue});
            this.dgvFunctions.Location = new System.Drawing.Point(286, 128);
            this.dgvFunctions.Name = "dgvFunctions";
            this.dgvFunctions.RowTemplate.Height = 24;
            this.dgvFunctions.Size = new System.Drawing.Size(344, 207);
            this.dgvFunctions.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(74, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "The number of variables";
            // 
            // variableNumber
            // 
            this.variableNumber.Location = new System.Drawing.Point(286, 69);
            this.variableNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variableNumber.Name = "variableNumber";
            this.variableNumber.Size = new System.Drawing.Size(120, 22);
            this.variableNumber.TabIndex = 12;
            this.variableNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variableNumber.ValueChanged += new System.EventHandler(this.variableNumber_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(630, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 63);
            this.button1.TabIndex = 11;
            this.button1.Text = "Get result";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Variable
            // 
            this.Variable.HeaderText = "Variable name";
            this.Variable.Name = "Variable";
            // 
            // function
            // 
            this.function.HeaderText = "Function";
            this.function.Name = "function";
            // 
            // firstValue
            // 
            this.firstValue.HeaderText = "First value";
            this.firstValue.Name = "firstValue";
            // 
            // frmSeidelMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(890, 503);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.epsilon);
            this.Controls.Add(this.max_iter_numeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFunctions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.variableNumber);
            this.Controls.Add(this.button1);
            this.Name = "frmSeidelMethod";
            this.Text = "frmSeidelMethod";
            this.Load += new System.EventHandler(this.frmSeidelMethod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label answer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox epsilon;
        private System.Windows.Forms.NumericUpDown max_iter_numeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvFunctions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown variableNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstValue;
    }
}