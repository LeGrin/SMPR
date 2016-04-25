namespace Modules.ModuleFuzzyLogic
{
    partial class BinRelationsPropForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.matrix = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addDim = new System.Windows.Forms.Button();
            this.removeDim = new System.Windows.Forms.Button();
            this.analyzeMatrixButton = new System.Windows.Forms.Button();
            this.resultList = new System.Windows.Forms.ListView();
            this.transitiveClosureButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // matrix
            // 
            this.matrix.AllowUserToAddRows = false;
            this.matrix.AllowUserToDeleteRows = false;
            this.matrix.AllowUserToResizeColumns = false;
            this.matrix.AllowUserToResizeRows = false;
            this.matrix.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrix.ColumnHeadersVisible = false;
            this.matrix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.matrix.DefaultCellStyle = dataGridViewCellStyle1;
            this.matrix.Dock = System.Windows.Forms.DockStyle.Left;
            this.matrix.Location = new System.Drawing.Point(0, 0);
            this.matrix.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.matrix.Name = "matrix";
            this.matrix.RowHeadersVisible = false;
            this.matrix.RowTemplate.Height = 24;
            this.matrix.Size = new System.Drawing.Size(526, 530);
            this.matrix.TabIndex = 0;
            this.matrix.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.matrix_CellValidating);
            this.matrix.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.matrix_CellValueChanged);
            this.matrix.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.matrix_ColumnAdded);
            this.matrix.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.matrix_DefaultValuesNeeded);
            this.matrix.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.matrix_RowsAdded);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // addDim
            // 
            this.addDim.Location = new System.Drawing.Point(621, 12);
            this.addDim.Name = "addDim";
            this.addDim.Size = new System.Drawing.Size(55, 53);
            this.addDim.TabIndex = 1;
            this.addDim.Text = "+";
            this.addDim.UseVisualStyleBackColor = true;
            this.addDim.Click += new System.EventHandler(this.addDim_Click);
            // 
            // removeDim
            // 
            this.removeDim.Location = new System.Drawing.Point(548, 12);
            this.removeDim.Name = "removeDim";
            this.removeDim.Size = new System.Drawing.Size(55, 53);
            this.removeDim.TabIndex = 2;
            this.removeDim.Text = "-";
            this.removeDim.UseVisualStyleBackColor = true;
            this.removeDim.Click += new System.EventHandler(this.removeDim_Click);
            // 
            // analyzeMatrixButton
            // 
            this.analyzeMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analyzeMatrixButton.Location = new System.Drawing.Point(548, 84);
            this.analyzeMatrixButton.Name = "analyzeMatrixButton";
            this.analyzeMatrixButton.Size = new System.Drawing.Size(160, 48);
            this.analyzeMatrixButton.TabIndex = 3;
            this.analyzeMatrixButton.Text = "Проаналізувати";
            this.analyzeMatrixButton.UseVisualStyleBackColor = true;
            this.analyzeMatrixButton.Click += new System.EventHandler(this.analyzeMatrixButton_Click);
            // 
            // resultList
            // 
            this.resultList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultList.GridLines = true;
            this.resultList.Location = new System.Drawing.Point(548, 167);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(331, 304);
            this.resultList.TabIndex = 4;
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.List;
            // 
            // transitiveClosureButton
            // 
            this.transitiveClosureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.transitiveClosureButton.Location = new System.Drawing.Point(724, 84);
            this.transitiveClosureButton.Name = "transitiveClosureButton";
            this.transitiveClosureButton.Size = new System.Drawing.Size(155, 48);
            this.transitiveClosureButton.TabIndex = 5;
            this.transitiveClosureButton.Text = "Транзитивне замикання";
            this.transitiveClosureButton.UseVisualStyleBackColor = true;
            this.transitiveClosureButton.Click += new System.EventHandler(this.transitiveClosureButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(548, 477);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(160, 41);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Завантажити";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(724, 477);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(155, 41);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Зберегти";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // BinRelationsPropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 530);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.transitiveClosureButton);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.analyzeMatrixButton);
            this.Controls.Add(this.removeDim);
            this.Controls.Add(this.addDim);
            this.Controls.Add(this.matrix);
            this.Name = "BinRelationsPropForm";
            this.Text = "Властивості бінарних нечітких множин";
            ((System.ComponentModel.ISupportInitialize)(this.matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView matrix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button addDim;
        private System.Windows.Forms.Button removeDim;
        private System.Windows.Forms.Button analyzeMatrixButton;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.Button transitiveClosureButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
    }
}