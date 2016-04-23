namespace ModuleFuzzyLogic
{
    partial class fuzzyPreferenceRelations
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpAndDownElementsCount = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewElements = new System.Windows.Forms.DataGridView();
            this.Xelement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewMu = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpAndDownElementsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuzzy Preference Relations";
            // 
            // numericUpAndDownElementsCount
            // 
            this.numericUpAndDownElementsCount.Location = new System.Drawing.Point(15, 46);
            this.numericUpAndDownElementsCount.Name = "numericUpAndDownElementsCount";
            this.numericUpAndDownElementsCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpAndDownElementsCount.TabIndex = 1;
            this.numericUpAndDownElementsCount.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // dataGridViewElements
            // 
            this.dataGridViewElements.AllowUserToAddRows = false;
            this.dataGridViewElements.AllowUserToDeleteRows = false;
            this.dataGridViewElements.AllowUserToResizeColumns = false;
            this.dataGridViewElements.AllowUserToResizeRows = false;
            this.dataGridViewElements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Xelement});
            this.dataGridViewElements.Location = new System.Drawing.Point(15, 70);
            this.dataGridViewElements.MultiSelect = false;
            this.dataGridViewElements.Name = "dataGridViewElements";
            this.dataGridViewElements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridViewElements.Size = new System.Drawing.Size(120, 283);
            this.dataGridViewElements.TabIndex = 2;
            // 
            // Xelement
            // 
            this.Xelement.HeaderText = "Element";
            this.Xelement.Name = "Xelement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of elements:";
            // 
            // dataGridViewMu
            // 
            this.dataGridViewMu.AllowUserToAddRows = false;
            this.dataGridViewMu.AllowUserToDeleteRows = false;
            this.dataGridViewMu.AllowUserToResizeColumns = false;
            this.dataGridViewMu.AllowUserToResizeRows = false;
            this.dataGridViewMu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMu.Location = new System.Drawing.Point(141, 70);
            this.dataGridViewMu.Name = "dataGridViewMu";
            this.dataGridViewMu.RowHeadersVisible = false;
            this.dataGridViewMu.Size = new System.Drawing.Size(430, 254);
            this.dataGridViewMu.TabIndex = 4;
            // 
            // fuzzyPreferenceRelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 359);
            this.Controls.Add(this.dataGridViewMu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewElements);
            this.Controls.Add(this.numericUpAndDownElementsCount);
            this.Controls.Add(this.label1);
            this.Name = "fuzzyPreferenceRelations";
            this.Text = "fuzzyPreferenceRelations";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpAndDownElementsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpAndDownElementsCount;
        private System.Windows.Forms.DataGridView dataGridViewElements;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xelement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewMu;
    }
}