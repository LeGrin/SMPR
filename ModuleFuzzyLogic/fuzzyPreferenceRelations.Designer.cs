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
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPageStrictPreferences = new System.Windows.Forms.TabPage();
            this.tabPageLaxPreferences = new System.Windows.Forms.TabPage();
            this.dataGridViewMu = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAttitudeOfIndifference = new System.Windows.Forms.TabPage();
            this.tabPageQuasiEquivalence = new System.Windows.Forms.TabPage();
            this.tabPageNonDominated = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpAndDownElementsCount)).BeginInit();
            this.tabPageLaxPreferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMu)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.numericUpAndDownElementsCount.ValueChanged += new System.EventHandler(this.numericUpAndDownElementsCount_ValueChanged);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPageStrictPreferences
            // 
            this.tabPageStrictPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPageStrictPreferences.Name = "tabPageStrictPreferences";
            this.tabPageStrictPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStrictPreferences.Size = new System.Drawing.Size(403, 309);
            this.tabPageStrictPreferences.TabIndex = 1;
            this.tabPageStrictPreferences.Text = "Strict Preferences";
            this.tabPageStrictPreferences.UseVisualStyleBackColor = true;
            // 
            // tabPageLaxPreferences
            // 
            this.tabPageLaxPreferences.Controls.Add(this.dataGridViewMu);
            this.tabPageLaxPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPageLaxPreferences.Name = "tabPageLaxPreferences";
            this.tabPageLaxPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLaxPreferences.Size = new System.Drawing.Size(472, 309);
            this.tabPageLaxPreferences.TabIndex = 0;
            this.tabPageLaxPreferences.Text = "Lax Preferences";
            this.tabPageLaxPreferences.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMu
            // 
            this.dataGridViewMu.AllowUserToAddRows = false;
            this.dataGridViewMu.AllowUserToDeleteRows = false;
            this.dataGridViewMu.AllowUserToResizeColumns = false;
            this.dataGridViewMu.AllowUserToResizeRows = false;
            this.dataGridViewMu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMu.Location = new System.Drawing.Point(6, 9);
            this.dataGridViewMu.Name = "dataGridViewMu";
            this.dataGridViewMu.RowHeadersVisible = false;
            this.dataGridViewMu.Size = new System.Drawing.Size(460, 297);
            this.dataGridViewMu.TabIndex = 4;
            this.dataGridViewMu.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMu_CellValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLaxPreferences);
            this.tabControl1.Controls.Add(this.tabPageStrictPreferences);
            this.tabControl1.Controls.Add(this.tabPageAttitudeOfIndifference);
            this.tabControl1.Controls.Add(this.tabPageQuasiEquivalence);
            this.tabControl1.Controls.Add(this.tabPageNonDominated);
            this.tabControl1.Location = new System.Drawing.Point(154, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(480, 335);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageAttitudeOfIndifference
            // 
            this.tabPageAttitudeOfIndifference.Location = new System.Drawing.Point(4, 22);
            this.tabPageAttitudeOfIndifference.Name = "tabPageAttitudeOfIndifference";
            this.tabPageAttitudeOfIndifference.Size = new System.Drawing.Size(403, 309);
            this.tabPageAttitudeOfIndifference.TabIndex = 2;
            this.tabPageAttitudeOfIndifference.Text = "Attitude of indifference";
            this.tabPageAttitudeOfIndifference.UseVisualStyleBackColor = true;
            // 
            // tabPageQuasiEquivalence
            // 
            this.tabPageQuasiEquivalence.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuasiEquivalence.Name = "tabPageQuasiEquivalence";
            this.tabPageQuasiEquivalence.Size = new System.Drawing.Size(403, 309);
            this.tabPageQuasiEquivalence.TabIndex = 3;
            this.tabPageQuasiEquivalence.Text = "Quasi Equivalence";
            this.tabPageQuasiEquivalence.UseVisualStyleBackColor = true;
            // 
            // tabPageNonDominated
            // 
            this.tabPageNonDominated.Location = new System.Drawing.Point(4, 22);
            this.tabPageNonDominated.Name = "tabPageNonDominated";
            this.tabPageNonDominated.Size = new System.Drawing.Size(403, 309);
            this.tabPageNonDominated.TabIndex = 4;
            this.tabPageNonDominated.Text = "tabPage1";
            this.tabPageNonDominated.UseVisualStyleBackColor = true;
            // 
            // fuzzyPreferenceRelations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 359);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpAndDownElementsCount);
            this.Controls.Add(this.label1);
            this.Name = "fuzzyPreferenceRelations";
            this.Text = "fuzzyPreferenceRelations";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpAndDownElementsCount)).EndInit();
            this.tabPageLaxPreferences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMu)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpAndDownElementsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPageStrictPreferences;
        private System.Windows.Forms.TabPage tabPageLaxPreferences;
        private System.Windows.Forms.DataGridView dataGridViewMu;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAttitudeOfIndifference;
        private System.Windows.Forms.TabPage tabPageQuasiEquivalence;
        private System.Windows.Forms.TabPage tabPageNonDominated;
    }
}