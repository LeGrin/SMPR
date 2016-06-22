namespace Common
{
    namespace DataTypes
    {
        partial class MatrixUserControl
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

            #region Component Designer generated code

            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
                this.reservedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.addColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.переміститиРядокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.rowвверхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.rowвнизToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.переміститиСтовпчикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.columnвлівоToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
                this.columnвправоToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
                this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
                this.acceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.видалитиРядокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.очиститиВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.button1 = new System.Windows.Forms.Button();
                this.label1 = new System.Windows.Forms.Label();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                this.contextMenuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AllowUserToDeleteRows = false;
                this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.ColumnHeadersVisible = false;
                this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.RowHeadersVisible = false;
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
                this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
                this.dataGridView1.Size = new System.Drawing.Size(211, 153);
                this.dataGridView1.TabIndex = 0;
                this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
                this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
                // 
                // contextMenuStrip1
                // 
                this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservedToolStripMenuItem,
            this.addColumnToolStripMenuItem,
            this.addRowToolStripMenuItem,
            this.переміститиРядокToolStripMenuItem,
            this.переміститиСтовпчикToolStripMenuItem,
            this.toolStripSeparator1,
            this.acceptToolStripMenuItem,
            this.видалитиРядокToolStripMenuItem,
            this.очиститиВсеToolStripMenuItem,
            this.refreshToolStripMenuItem});
                this.contextMenuStrip1.Name = "contextMenuStrip1";
                this.contextMenuStrip1.Size = new System.Drawing.Size(187, 208);
                // 
                // reservedToolStripMenuItem
                // 
                this.reservedToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
                this.reservedToolStripMenuItem.Name = "reservedToolStripMenuItem";
                this.reservedToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.reservedToolStripMenuItem.Text = "(reserved)";
                // 
                // addColumnToolStripMenuItem
                // 
                this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
                this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.addColumnToolStripMenuItem.Text = "Вставити стовпчик";
                this.addColumnToolStripMenuItem.Click += new System.EventHandler(this.addColumnToolStripMenuItem_Click);
                // 
                // addRowToolStripMenuItem
                // 
                this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
                this.addRowToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.addRowToolStripMenuItem.Text = "Вставити рядок";
                this.addRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
                // 
                // переміститиРядокToolStripMenuItem
                // 
                this.переміститиРядокToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowвверхToolStripMenuItem,
            this.rowвнизToolStripMenuItem});
                this.переміститиРядокToolStripMenuItem.Name = "переміститиРядокToolStripMenuItem";
                this.переміститиРядокToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.переміститиРядокToolStripMenuItem.Text = "Перемістити рядок";
                // 
                // rowвверхToolStripMenuItem
                // 
                this.rowвверхToolStripMenuItem.Name = "rowвверхToolStripMenuItem";
                this.rowвверхToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
                this.rowвверхToolStripMenuItem.Text = "Вверх";
                this.rowвверхToolStripMenuItem.Click += new System.EventHandler(this.rowвлівоToolStripMenuItem_Click);
                // 
                // rowвнизToolStripMenuItem
                // 
                this.rowвнизToolStripMenuItem.Name = "rowвнизToolStripMenuItem";
                this.rowвнизToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
                this.rowвнизToolStripMenuItem.Text = "Вниз";
                this.rowвнизToolStripMenuItem.Click += new System.EventHandler(this.rowвнизToolStripMenuItem_Click);
                // 
                // переміститиСтовпчикToolStripMenuItem
                // 
                this.переміститиСтовпчикToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnвлівоToolStripMenuItem1,
            this.columnвправоToolStripMenuItem1});
                this.переміститиСтовпчикToolStripMenuItem.Name = "переміститиСтовпчикToolStripMenuItem";
                this.переміститиСтовпчикToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.переміститиСтовпчикToolStripMenuItem.Text = "Перемістити стовпчик";
                // 
                // columnвлівоToolStripMenuItem1
                // 
                this.columnвлівоToolStripMenuItem1.Name = "columnвлівоToolStripMenuItem1";
                this.columnвлівоToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
                this.columnвлівоToolStripMenuItem1.Text = "Вліво";
                this.columnвлівоToolStripMenuItem1.Click += new System.EventHandler(this.columnвлівоToolStripMenuItem1_Click);
                // 
                // columnвправоToolStripMenuItem1
                // 
                this.columnвправоToolStripMenuItem1.Name = "columnвправоToolStripMenuItem1";
                this.columnвправоToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
                this.columnвправоToolStripMenuItem1.Text = "Вправо";
                this.columnвправоToolStripMenuItem1.Click += new System.EventHandler(this.columnвправоToolStripMenuItem1_Click);
                // 
                // toolStripSeparator1
                // 
                this.toolStripSeparator1.Name = "toolStripSeparator1";
                this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
                // 
                // acceptToolStripMenuItem
                // 
                this.acceptToolStripMenuItem.Name = "acceptToolStripMenuItem";
                this.acceptToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.acceptToolStripMenuItem.Text = "Видалити стовпчик";
                this.acceptToolStripMenuItem.Click += new System.EventHandler(this.acceptToolStripMenuItem_Click);
                // 
                // видалитиРядокToolStripMenuItem
                // 
                this.видалитиРядокToolStripMenuItem.Name = "видалитиРядокToolStripMenuItem";
                this.видалитиРядокToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.видалитиРядокToolStripMenuItem.Text = "Видалити рядок";
                this.видалитиРядокToolStripMenuItem.Click += new System.EventHandler(this.видалитиРядокToolStripMenuItem_Click);
                // 
                // очиститиВсеToolStripMenuItem
                // 
                this.очиститиВсеToolStripMenuItem.Name = "очиститиВсеToolStripMenuItem";
                this.очиститиВсеToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.очиститиВсеToolStripMenuItem.Text = "Очистити все";
                this.очиститиВсеToolStripMenuItem.Click += new System.EventHandler(this.очиститиВсеToolStripMenuItem_Click);
                // 
                // refreshToolStripMenuItem
                // 
                this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
                this.refreshToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
                this.refreshToolStripMenuItem.Text = "Refresh";
                this.refreshToolStripMenuItem.Visible = false;
                this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.button1.Location = new System.Drawing.Point(0, 159);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(211, 23);
                this.button1.TabIndex = 1;
                this.button1.Text = "Зберегти зміни в буфер";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // label1
                // 
                this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.label1.AutoSize = true;
                this.label1.BackColor = System.Drawing.Color.DarkGray;
                this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.label1.ForeColor = System.Drawing.Color.DarkRed;
                this.label1.Location = new System.Drawing.Point(17, 55);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(167, 36);
                this.label1.TabIndex = 2;
                this.label1.Text = "Даних занадто багато \r\nдля відобораження";
                this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.label1.Visible = false;
                // 
                // MatrixUserControl
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.Controls.Add(this.label1);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.dataGridView1);
                this.Name = "MatrixUserControl";
                this.Size = new System.Drawing.Size(211, 183);
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                this.contextMenuStrip1.ResumeLayout(false);
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.DataGridView dataGridView1;
            private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
            private System.Windows.Forms.ToolStripMenuItem addColumnToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem acceptToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem reservedToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem переміститиРядокToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem rowвверхToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem rowвнизToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem переміститиСтовпчикToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem columnвлівоToolStripMenuItem1;
            private System.Windows.Forms.ToolStripMenuItem columnвправоToolStripMenuItem1;
            private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            private System.Windows.Forms.ToolStripMenuItem видалитиРядокToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem очиститиВсеToolStripMenuItem;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
            private System.Windows.Forms.Label label1;
        }
    }
}