namespace Modules.ModuleNumericalAnalysis
{
    partial class frmFixedPointIteration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFixedPointIteration));
            this.button1 = new System.Windows.Forms.Button();
            this.variableNumber = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFunctions = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.max_iter_numeric = new System.Windows.Forms.NumericUpDown();
            this.epsilon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.Label();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // variableNumber
            // 
            resources.ApplyResources(this.variableNumber, "variableNumber");
            this.variableNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variableNumber.Name = "variableNumber";
            this.variableNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.variableNumber.ValueChanged += new System.EventHandler(this.variableNumber_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvFunctions
            // 
            resources.ApplyResources(this.dgvFunctions, "dgvFunctions");
            this.dgvFunctions.AllowUserToAddRows = false;
            this.dgvFunctions.AllowUserToDeleteRows = false;
            this.dgvFunctions.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvFunctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunctions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.function,
            this.firstValue});
            this.dgvFunctions.Name = "dgvFunctions";
            this.dgvFunctions.RowTemplate.Height = 24;
            this.dgvFunctions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // max_iter_numeric
            // 
            resources.ApplyResources(this.max_iter_numeric, "max_iter_numeric");
            this.max_iter_numeric.Name = "max_iter_numeric";
            // 
            // epsilon
            // 
            resources.ApplyResources(this.epsilon, "epsilon");
            this.epsilon.Name = "epsilon";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // answer
            // 
            resources.ApplyResources(this.answer, "answer");
            this.answer.Name = "answer";
            // 
            // Variable
            // 
            resources.ApplyResources(this.Variable, "Variable");
            this.Variable.Name = "Variable";
            // 
            // function
            // 
            resources.ApplyResources(this.function, "function");
            this.function.Name = "function";
            // 
            // firstValue
            // 
            resources.ApplyResources(this.firstValue, "firstValue");
            this.firstValue.Name = "firstValue";
            // 
            // frmFixedPointIteration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
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
            this.Name = "frmFixedPointIteration";
            ((System.ComponentModel.ISupportInitialize)(this.variableNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max_iter_numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown variableNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFunctions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown max_iter_numeric;
        private System.Windows.Forms.TextBox epsilon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn function;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstValue;
    }
}