namespace Modules.ModuleFuzzyLogic
{
    partial class frmBinOperations
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
            this.operationsBox = new System.Windows.Forms.ComboBox();
            this.btnGetResult = new System.Windows.Forms.Button();
            this.btnAddToB = new System.Windows.Forms.Button();
            this.labelA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtElem = new System.Windows.Forms.TextBox();
            this.txtProb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AddToA = new System.Windows.Forms.Button();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.dgvB = new System.Windows.Forms.DataGridView();
            this.dgvRes = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sizeA = new System.Windows.Forms.TextBox();
            this.sizeB = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lLamda = new System.Windows.Forms.Label();
            this.txtLamda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).BeginInit();
            this.SuspendLayout();
            // 
            // operationsBox
            // 
            this.operationsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationsBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.operationsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.operationsBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.operationsBox.Location = new System.Drawing.Point(91, 417);
            this.operationsBox.Name = "operationsBox";
            this.operationsBox.Size = new System.Drawing.Size(261, 28);
            this.operationsBox.TabIndex = 3;
            this.operationsBox.SelectedIndexChanged += new System.EventHandler(this.operationsBox_SelectedIndexChanged);
            this.operationsBox.DropDownClosed += new System.EventHandler(this.operationsBox_DropDownClosed);
            this.operationsBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.operationsBox_DragDrop);
            // 
            // btnGetResult
            // 
            this.btnGetResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetResult.Location = new System.Drawing.Point(475, 385);
            this.btnGetResult.Name = "btnGetResult";
            this.btnGetResult.Size = new System.Drawing.Size(178, 60);
            this.btnGetResult.TabIndex = 4;
            this.btnGetResult.Text = "=";
            this.btnGetResult.UseVisualStyleBackColor = true;
            this.btnGetResult.Click += new System.EventHandler(this.btnGetResult_Click);
            // 
            // btnAddToB
            // 
            this.btnAddToB.Location = new System.Drawing.Point(796, 243);
            this.btnAddToB.Name = "btnAddToB";
            this.btnAddToB.Size = new System.Drawing.Size(100, 22);
            this.btnAddToB.TabIndex = 6;
            this.btnAddToB.Text = "Добавить в В";
            this.btnAddToB.UseVisualStyleBackColor = true;
            this.btnAddToB.Click += new System.EventHandler(this.btnAddToB_Click);
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelA.Location = new System.Drawing.Point(9, 8);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(148, 26);
            this.labelA.TabIndex = 7;
            this.labelA.Text = "Множество А";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(238, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Множество В";
            // 
            // txtElem
            // 
            this.txtElem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtElem.Location = new System.Drawing.Point(795, 189);
            this.txtElem.Name = "txtElem";
            this.txtElem.Size = new System.Drawing.Size(100, 20);
            this.txtElem.TabIndex = 9;
            // 
            // txtProb
            // 
            this.txtProb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProb.Location = new System.Drawing.Point(796, 217);
            this.txtProb.Name = "txtProb";
            this.txtProb.Size = new System.Drawing.Size(100, 20);
            this.txtProb.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(470, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 11;
            this.label2.Text = "Результат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(717, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Значение";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(700, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Вероятность";
            // 
            // AddToA
            // 
            this.AddToA.Location = new System.Drawing.Point(689, 243);
            this.AddToA.Name = "AddToA";
            this.AddToA.Size = new System.Drawing.Size(101, 22);
            this.AddToA.TabIndex = 14;
            this.AddToA.Text = "Добавить в A";
            this.AddToA.UseVisualStyleBackColor = true;
            this.AddToA.Click += new System.EventHandler(this.AddToA_Click);
            // 
            // dgvA
            // 
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.Location = new System.Drawing.Point(12, 37);
            this.dgvA.Name = "dgvA";
            this.dgvA.Size = new System.Drawing.Size(178, 313);
            this.dgvA.TabIndex = 15;
            // 
            // dgvB
            // 
            this.dgvB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvB.Location = new System.Drawing.Point(243, 37);
            this.dgvB.Name = "dgvB";
            this.dgvB.Size = new System.Drawing.Size(178, 313);
            this.dgvB.TabIndex = 16;
            // 
            // dgvRes
            // 
            this.dgvRes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRes.Location = new System.Drawing.Point(475, 37);
            this.dgvRes.Name = "dgvRes";
            this.dgvRes.Size = new System.Drawing.Size(178, 313);
            this.dgvRes.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(754, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 57);
            this.button1.TabIndex = 18;
            this.button1.Text = "заполнить случайными";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(727, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Елемнтов в А = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(727, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Елемнтов в В = ";
            // 
            // sizeA
            // 
            this.sizeA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sizeA.Location = new System.Drawing.Point(833, 34);
            this.sizeA.Name = "sizeA";
            this.sizeA.Size = new System.Drawing.Size(51, 20);
            this.sizeA.TabIndex = 21;
            // 
            // sizeB
            // 
            this.sizeB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sizeB.Location = new System.Drawing.Point(833, 74);
            this.sizeB.Name = "sizeB";
            this.sizeB.Size = new System.Drawing.Size(51, 20);
            this.sizeB.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(243, 385);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 26);
            this.button3.TabIndex = 24;
            this.button3.Text = "Загрузить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 353);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 26);
            this.button4.TabIndex = 25;
            this.button4.Text = "Сохранить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(243, 353);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(178, 26);
            this.button5.TabIndex = 26;
            this.button5.Text = "Сохранить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(14, 385);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(178, 26);
            this.button6.TabIndex = 28;
            this.button6.Text = "Загрузить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(475, 353);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(178, 26);
            this.button7.TabIndex = 29;
            this.button7.Text = "Сохранить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lLamda
            // 
            this.lLamda.AutoSize = true;
            this.lLamda.Location = new System.Drawing.Point(91, 452);
            this.lLamda.Name = "lLamda";
            this.lLamda.Size = new System.Drawing.Size(41, 13);
            this.lLamda.TabIndex = 30;
            this.lLamda.Text = "Лямда";
            // 
            // txtLamda
            // 
            this.txtLamda.Enabled = false;
            this.txtLamda.Location = new System.Drawing.Point(133, 452);
            this.txtLamda.Name = "txtLamda";
            this.txtLamda.Size = new System.Drawing.Size(219, 20);
            this.txtLamda.TabIndex = 31;
            // 
            // frmBinOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 553);
            this.Controls.Add(this.txtLamda);
            this.Controls.Add(this.lLamda);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sizeB);
            this.Controls.Add(this.sizeA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRes);
            this.Controls.Add(this.dgvB);
            this.Controls.Add(this.dgvA);
            this.Controls.Add(this.AddToA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProb);
            this.Controls.Add(this.txtElem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelA);
            this.Controls.Add(this.btnAddToB);
            this.Controls.Add(this.btnGetResult);
            this.Controls.Add(this.operationsBox);
            this.Name = "frmBinOperations";
            this.Text = "frmBinOperations";
            this.Load += new System.EventHandler(this.frmBinOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox operationsBox;
        private System.Windows.Forms.Button btnGetResult;
        private System.Windows.Forms.Button btnAddToB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtElem;
        private System.Windows.Forms.TextBox txtProb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddToA;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.DataGridView dgvB;
        private System.Windows.Forms.DataGridView dgvRes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox sizeA;
        private System.Windows.Forms.TextBox sizeB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lLamda;
        private System.Windows.Forms.TextBox txtLamda;
    }
}