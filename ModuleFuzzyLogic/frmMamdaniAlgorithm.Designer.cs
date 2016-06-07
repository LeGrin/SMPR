namespace Modules.ModuleFuzzyLogic
{
    partial class frmMamdaniAlgorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMamdaniAlgorithm));
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.setA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setB1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setB2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mainTableLayout.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onCompute);
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.setA1,
            this.setA2,
            this.setB1,
            this.setB2,
            this.setC1,
            this.setC2});
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.onCellValidation);
            // 
            // setA1
            // 
            this.setA1.FillWeight = 120F;
            resources.ApplyResources(this.setA1, "setA1");
            this.setA1.Name = "setA1";
            // 
            // setA2
            // 
            this.setA2.FillWeight = 120F;
            resources.ApplyResources(this.setA2, "setA2");
            this.setA2.Name = "setA2";
            // 
            // setB1
            // 
            this.setB1.FillWeight = 120F;
            resources.ApplyResources(this.setB1, "setB1");
            this.setB1.Name = "setB1";
            // 
            // setB2
            // 
            resources.ApplyResources(this.setB2, "setB2");
            this.setB2.Name = "setB2";
            // 
            // setC1
            // 
            resources.ApplyResources(this.setC1, "setC1");
            this.setC1.Name = "setC1";
            // 
            // setC2
            // 
            resources.ApplyResources(this.setC2, "setC2");
            this.setC2.Name = "setC2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // mainTableLayout
            // 
            resources.ApplyResources(this.mainTableLayout, "mainTableLayout");
            this.mainTableLayout.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.mainTableLayout.Controls.Add(this.dataGridView1, 0, 1);
            this.mainTableLayout.Controls.Add(this.label1, 0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.button5, 4, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.onGenRandom);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.onClearRows);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.onSaveToBuffer);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.onLoadFromBuffer);
            // 
            // frmMamdaniAlgorithm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainTableLayout);
            this.Name = "frmMamdaniAlgorithm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mainTableLayout.ResumeLayout(false);
            this.mainTableLayout.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn setA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn setB1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setB2;
        private System.Windows.Forms.DataGridViewTextBoxColumn setC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn setC2;

    }
}