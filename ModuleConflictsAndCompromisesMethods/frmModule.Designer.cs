namespace Modules.ConflictsAndCompromises
{
    partial class frmModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModule));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gameOptions = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.resultList = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.playerList = new System.Windows.Forms.ComboBox();
            this.columnCounter = new System.Windows.Forms.NumericUpDown();
            this.rowCounter = new System.Windows.Forms.NumericUpDown();
            this.player2Func = new System.Windows.Forms.ComboBox();
            this.player1Func = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.autoFillOptions = new System.Windows.Forms.GroupBox();
            this.autoFillMax = new System.Windows.Forms.NumericUpDown();
            this.autoFillMin = new System.Windows.Forms.NumericUpDown();
            this.autoFillBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.autoFillFlag = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToBufferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eightìToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testBox = new System.Windows.Forms.GroupBox();
            this.tester = new Modules.ConflictsAndCompromises.Tester();
            this.skipModuleBtn = new System.Windows.Forms.Button();
            this.finishTestBtn = new System.Windows.Forms.Button();
            this.answerBox = new System.Windows.Forms.GroupBox();
            this.clearAnswerBtn = new System.Windows.Forms.Button();
            this.submitAnswerBtn = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.TextBox();
            this.gameGrid1 = new Modules.ConflictsAndCompromises.GameGrid();
            this.gameOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCounter)).BeginInit();
            this.autoFillOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillMin)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.testBox.SuspendLayout();
            this.answerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameOptions
            // 
            resources.ApplyResources(this.gameOptions, "gameOptions");
            this.gameOptions.Controls.Add(this.label9);
            this.gameOptions.Controls.Add(this.resultList);
            this.gameOptions.Controls.Add(this.label8);
            this.gameOptions.Controls.Add(this.label7);
            this.gameOptions.Controls.Add(this.methodList);
            this.gameOptions.Controls.Add(this.playerList);
            this.gameOptions.Controls.Add(this.columnCounter);
            this.gameOptions.Controls.Add(this.rowCounter);
            this.gameOptions.Controls.Add(this.player2Func);
            this.gameOptions.Controls.Add(this.player1Func);
            this.gameOptions.Controls.Add(this.label4);
            this.gameOptions.Controls.Add(this.label3);
            this.gameOptions.Controls.Add(this.label2);
            this.gameOptions.Controls.Add(this.label1);
            this.gameOptions.Controls.Add(this.autoFillOptions);
            this.gameOptions.Name = "gameOptions";
            this.gameOptions.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // resultList
            // 
            resources.ApplyResources(this.resultList, "resultList");
            this.resultList.AccessibleRole = System.Windows.Forms.AccessibleRole.List;
            this.resultList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.resultList.HoverSelection = true;
            this.resultList.Name = "resultList";
            this.resultList.UseCompatibleStateImageBehavior = false;
            this.resultList.View = System.Windows.Forms.View.List;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // methodList
            // 
            resources.ApplyResources(this.methodList, "methodList");
            this.methodList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.methodList.FormattingEnabled = true;
            this.methodList.Name = "methodList";
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            // 
            // playerList
            // 
            resources.ApplyResources(this.playerList, "playerList");
            this.playerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerList.FormattingEnabled = true;
            this.playerList.Items.AddRange(new object[] {
            resources.GetString("playerList.Items"),
            resources.GetString("playerList.Items1")});
            this.playerList.Name = "playerList";
            this.playerList.SelectedIndexChanged += new System.EventHandler(this.playerList_SelectedIndexChanged);
            // 
            // columnCounter
            // 
            resources.ApplyResources(this.columnCounter, "columnCounter");
            this.columnCounter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.columnCounter.Name = "columnCounter";
            this.columnCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.columnCounter.ValueChanged += new System.EventHandler(this.columnCounter_ValueChanged);
            // 
            // rowCounter
            // 
            resources.ApplyResources(this.rowCounter, "rowCounter");
            this.rowCounter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.rowCounter.Name = "rowCounter";
            this.rowCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.rowCounter.ValueChanged += new System.EventHandler(this.rowCounter_ValueChanged);
            // 
            // player2Func
            // 
            resources.ApplyResources(this.player2Func, "player2Func");
            this.player2Func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player2Func.FormattingEnabled = true;
            this.player2Func.Items.AddRange(new object[] {
            resources.GetString("player2Func.Items"),
            resources.GetString("player2Func.Items1")});
            this.player2Func.Name = "player2Func";
            this.player2Func.SelectedIndexChanged += new System.EventHandler(this.player2Func_SelectedIndexChanged);
            // 
            // player1Func
            // 
            resources.ApplyResources(this.player1Func, "player1Func");
            this.player1Func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1Func.FormattingEnabled = true;
            this.player1Func.Items.AddRange(new object[] {
            resources.GetString("player1Func.Items"),
            resources.GetString("player1Func.Items1")});
            this.player1Func.Name = "player1Func";
            this.player1Func.SelectedIndexChanged += new System.EventHandler(this.player1Func_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // autoFillOptions
            // 
            resources.ApplyResources(this.autoFillOptions, "autoFillOptions");
            this.autoFillOptions.Controls.Add(this.autoFillMax);
            this.autoFillOptions.Controls.Add(this.autoFillMin);
            this.autoFillOptions.Controls.Add(this.autoFillBtn);
            this.autoFillOptions.Controls.Add(this.label6);
            this.autoFillOptions.Controls.Add(this.label5);
            this.autoFillOptions.Controls.Add(this.autoFillFlag);
            this.autoFillOptions.Name = "autoFillOptions";
            this.autoFillOptions.TabStop = false;
            // 
            // autoFillMax
            // 
            resources.ApplyResources(this.autoFillMax, "autoFillMax");
            this.autoFillMax.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.autoFillMax.Name = "autoFillMax";
            this.autoFillMax.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.autoFillMax.ValueChanged += new System.EventHandler(this.AutofillValues_Validation);
            // 
            // autoFillMin
            // 
            resources.ApplyResources(this.autoFillMin, "autoFillMin");
            this.autoFillMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.autoFillMin.Name = "autoFillMin";
            this.autoFillMin.ValueChanged += new System.EventHandler(this.AutofillValues_Validation);
            // 
            // autoFillBtn
            // 
            resources.ApplyResources(this.autoFillBtn, "autoFillBtn");
            this.autoFillBtn.Name = "autoFillBtn";
            this.autoFillBtn.UseVisualStyleBackColor = true;
            this.autoFillBtn.Click += new System.EventHandler(this.autoFillBtn_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // autoFillFlag
            // 
            resources.ApplyResources(this.autoFillFlag, "autoFillFlag");
            this.autoFillFlag.Checked = true;
            this.autoFillFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFillFlag.Name = "autoFillFlag";
            this.autoFillFlag.UseVisualStyleBackColor = true;
            this.autoFillFlag.CheckedChanged += new System.EventHandler(this.autoFillFlag_CheckedChanged);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.eightìToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            resources.ApplyResources(this.gameToolStripMenuItem, "gameToolStripMenuItem");
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFromBufferToolStripMenuItem,
            this.saveToBufferToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Click += new System.EventHandler(this.gameToolStripMenuItem_Click);
            // 
            // loadFromBufferToolStripMenuItem
            // 
            resources.ApplyResources(this.loadFromBufferToolStripMenuItem, "loadFromBufferToolStripMenuItem");
            this.loadFromBufferToolStripMenuItem.Name = "loadFromBufferToolStripMenuItem";
            this.loadFromBufferToolStripMenuItem.Click += new System.EventHandler(this.LoadFromBuffer_Click);
            // 
            // saveToBufferToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToBufferToolStripMenuItem, "saveToBufferToolStripMenuItem");
            this.saveToBufferToolStripMenuItem.Name = "saveToBufferToolStripMenuItem";
            this.saveToBufferToolStripMenuItem.Click += new System.EventHandler(this.SaveToBuffer_Click);
            // 
            // eightìToolStripMenuItem
            // 
            resources.ApplyResources(this.eightìToolStripMenuItem, "eightìToolStripMenuItem");
            this.eightìToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nineToolStripMenuItem,
            this.tenToolStripMenuItem});
            this.eightìToolStripMenuItem.Name = "eightìToolStripMenuItem";
            // 
            // nineToolStripMenuItem
            // 
            resources.ApplyResources(this.nineToolStripMenuItem, "nineToolStripMenuItem");
            this.nineToolStripMenuItem.Checked = true;
            this.nineToolStripMenuItem.CheckOnClick = true;
            this.nineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nineToolStripMenuItem.Name = "nineToolStripMenuItem";
            this.nineToolStripMenuItem.Click += new System.EventHandler(this.nineToolStripMenuItem_Click);
            // 
            // tenToolStripMenuItem
            // 
            resources.ApplyResources(this.tenToolStripMenuItem, "tenToolStripMenuItem");
            this.tenToolStripMenuItem.CheckOnClick = true;
            this.tenToolStripMenuItem.Name = "tenToolStripMenuItem";
            this.tenToolStripMenuItem.Click += new System.EventHandler(this.òåñòToolStripMenuItem_Click);
            // 
            // testBox
            // 
            resources.ApplyResources(this.testBox, "testBox");
            this.testBox.Controls.Add(this.tester);
            this.testBox.Controls.Add(this.skipModuleBtn);
            this.testBox.Controls.Add(this.finishTestBtn);
            this.testBox.Controls.Add(this.answerBox);
            this.testBox.Name = "testBox";
            this.testBox.TabStop = false;
            // 
            // tester
            // 
            resources.ApplyResources(this.tester, "tester");
            this.tester.BackColor = System.Drawing.Color.White;
            this.tester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tester.Name = "tester";
            // 
            // skipModuleBtn
            // 
            resources.ApplyResources(this.skipModuleBtn, "skipModuleBtn");
            this.skipModuleBtn.Name = "skipModuleBtn";
            this.skipModuleBtn.UseVisualStyleBackColor = true;
            this.skipModuleBtn.Click += new System.EventHandler(this.skipModuleBtn_Click);
            // 
            // finishTestBtn
            // 
            resources.ApplyResources(this.finishTestBtn, "finishTestBtn");
            this.finishTestBtn.Name = "finishTestBtn";
            this.finishTestBtn.UseVisualStyleBackColor = true;
            this.finishTestBtn.Click += new System.EventHandler(this.finishTestBtn_Click);
            // 
            // answerBox
            // 
            resources.ApplyResources(this.answerBox, "answerBox");
            this.answerBox.Controls.Add(this.clearAnswerBtn);
            this.answerBox.Controls.Add(this.submitAnswerBtn);
            this.answerBox.Controls.Add(this.answer);
            this.answerBox.Name = "answerBox";
            this.answerBox.TabStop = false;
            // 
            // clearAnswerBtn
            // 
            resources.ApplyResources(this.clearAnswerBtn, "clearAnswerBtn");
            this.clearAnswerBtn.Name = "clearAnswerBtn";
            this.clearAnswerBtn.UseVisualStyleBackColor = true;
            this.clearAnswerBtn.Click += new System.EventHandler(this.clearAnswerBtn_Click);
            // 
            // submitAnswerBtn
            // 
            resources.ApplyResources(this.submitAnswerBtn, "submitAnswerBtn");
            this.submitAnswerBtn.Name = "submitAnswerBtn";
            this.submitAnswerBtn.UseVisualStyleBackColor = true;
            this.submitAnswerBtn.Click += new System.EventHandler(this.submitAnswerBtn_Click);
            // 
            // answer
            // 
            resources.ApplyResources(this.answer, "answer");
            this.answer.Name = "answer";
            // 
            // gameGrid1
            // 
            resources.ApplyResources(this.gameGrid1, "gameGrid1");
            this.gameGrid1.AllowUserToAddRows = false;
            this.gameGrid1.AllowUserToDeleteRows = false;
            this.gameGrid1.AllowUserToResizeColumns = false;
            this.gameGrid1.AllowUserToResizeRows = false;
            this.gameGrid1.ColumnHeadersVisible = false;
            this.gameGrid1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gameGrid1.DefaultCellStyle = dataGridViewCellStyle1;
            this.gameGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.gameGrid1.Game = null;
            this.gameGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(200)))));
            this.gameGrid1.Mode = Modules.ConflictsAndCompromises.GameGrid.GridMode.Normal;
            this.gameGrid1.MultiSelect = false;
            this.gameGrid1.Name = "gameGrid1";
            this.gameGrid1.Output = null;
            this.gameGrid1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gameGrid1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            // 
            // frmModule
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gameOptions);
            this.Controls.Add(this.testBox);
            this.Controls.Add(this.gameGrid1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmModule";
            this.gameOptions.ResumeLayout(false);
            this.gameOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCounter)).EndInit();
            this.autoFillOptions.ResumeLayout(false);
            this.autoFillOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoFillMin)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.testBox.ResumeLayout(false);
            this.answerBox.ResumeLayout(false);
            this.answerBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gameOptions;
        private System.Windows.Forms.GroupBox autoFillOptions;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromBufferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToBufferToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown columnCounter;
        private System.Windows.Forms.NumericUpDown rowCounter;
        private System.Windows.Forms.ComboBox player2Func;
        private System.Windows.Forms.ComboBox player1Func;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown autoFillMax;
        private System.Windows.Forms.NumericUpDown autoFillMin;
        private System.Windows.Forms.Button autoFillBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox autoFillFlag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.ComboBox playerList;
        private GameGrid gameGrid1;
        private System.Windows.Forms.ToolStripMenuItem eightìToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenToolStripMenuItem;
        private System.Windows.Forms.GroupBox testBox;
        private System.Windows.Forms.Button skipModuleBtn;
        private System.Windows.Forms.Button finishTestBtn;
        private System.Windows.Forms.GroupBox answerBox;
        private System.Windows.Forms.Button clearAnswerBtn;
        private System.Windows.Forms.Button submitAnswerBtn;
        private System.Windows.Forms.TextBox answer;
        private Tester tester;
        private System.Windows.Forms.ListView resultList;
        private System.Windows.Forms.Label label9;
    }
}