namespace Modules.ModuleNumericalAnalysis
{
    partial class frmPicardIteration
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
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.variableNumber = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvMatrix = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Location = new System.Drawing.Point(137, 449);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(0, 17);
            this.answer.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(76, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 29;
            this.label4.Text = "Answer";
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(504, 41);
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(100, 22);
            this.epsilon.TabIndex = 28;
            // 
            // max_iter_numeric
            // 
            this.max_iter_numeric.Location = new System.Drawing.Point(683, 40);
            this.max_iter_numeric.Name = "max_iter_numeric";
            this.max_iter_numeric.Size = new System.Drawing.Size(120, 22);
            this.max_iter_numeric.TabIndex = 27;
            this.max_iter_numeric.ValueChanged += new System.EventHandler(this.max_iter_numeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(612, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Max iter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(432, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 25;
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
            this.dgvFunctions.Location = new System.Drawing.Point(628, 104);
            this.dgvFunctions.Name = "dgvFunctions";
            this.dgvFunctions.RowTemplate.Height = 24;
            this.dgvFunctions.Size = new System.Drawing.Size(345, 272);
            this.dgvFunctions.TabIndex = 24;
            // 
            // Variable
            // 
            this.Variable.HeaderText = "Variable name";
            this.Variable.Name = "Variable";
            // 
            // function
            // 
            this.function.HeaderText = "function";
            this.function.Name = "function";
            // 
            // firstValue
            // 
            this.firstValue.HeaderText = "First value";
            this.firstValue.Name = "firstValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(76, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "The number of variables";
            // 
            // variableNumber
            // 
            this.variableNumber.Location = new System.Drawing.Point(304, 42);
            this.variableNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variableNumber.Name = "variableNumber";
            this.variableNumber.Size = new System.Drawing.Size(120, 22);
            this.variableNumber.TabIndex = 22;
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
            this.button1.Location = new System.Drawing.Point(838, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 63);
            this.button1.TabIndex = 21;
            this.button1.Text = "Get result";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvMatrix
            // 
            this.dgvMatrix.AllowUserToAddRows = false;
            this.dgvMatrix.AllowUserToDeleteRows = false;
            this.dgvMatrix.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrix.Location = new System.Drawing.Point(56, 104);
            this.dgvMatrix.Name = "dgvMatrix";
            this.dgvMatrix.RowTemplate.Height = 24;
            this.dgvMatrix.Size = new System.Drawing.Size(468, 272);
            this.dgvMatrix.TabIndex = 31;
            // 
            // frmPicardIteration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1057, 501);
            this.Controls.Add(this.dgvMatrix);
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
            this.Name = "frmPicardIteration";
            this.Text = "frmPicardIteration";
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrix)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown variableNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvMatrix;
    }
}