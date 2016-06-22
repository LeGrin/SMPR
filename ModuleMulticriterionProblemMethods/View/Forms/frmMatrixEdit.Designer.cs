using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using Modules.MulticriterionProblemMethods.View.Controls;
namespace Modules.MulticriterionProblemMethods.View.Forms
{
    partial class frmMatrixEdit
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
            if ( disposing && ( components != null ) )
            {
                components.Dispose ( );
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatrixEdit));
            this.gbMatrix = new System.Windows.Forms.GroupBox();
            this.ctrlMatrix = new Modules.MulticriterionProblemMethods.View.Controls.ctrlMatrix();
            this.ctrlMatrixContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.firstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fifthToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sixToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sevenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbMatrix.SuspendLayout();
            this.ctrlMatrixContextMenuStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMatrix
            // 
            resources.ApplyResources(this.gbMatrix, "gbMatrix");
            this.gbMatrix.Controls.Add(this.ctrlMatrix);
            this.gbMatrix.Name = "gbMatrix";
            this.gbMatrix.TabStop = false;
            // 
            // ctrlMatrix
            // 
            resources.ApplyResources(this.ctrlMatrix, "ctrlMatrix");
            this.ctrlMatrix.Name = "ctrlMatrix";
            this.ctrlMatrix.ReadOnly = false;
            // 
            // ctrlMatrixContextMenuStrip
            // 
            resources.ApplyResources(this.ctrlMatrixContextMenuStrip, "ctrlMatrixContextMenuStrip");
            this.ctrlMatrixContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstToolStripMenuItem,
            this.fourthToolStripMenuItem,
            this.sevenToolStripMenuItem});
            this.ctrlMatrixContextMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ctrlMatrixContextMenuStrip.Name = "contextMenuStrip1";
            // 
            // firstToolStripMenuItem
            // 
            resources.ApplyResources(this.firstToolStripMenuItem, "firstToolStripMenuItem");
            this.firstToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secondToolStripMenuItem,
            this.thirdToolStripMenuItem});
            this.firstToolStripMenuItem.Name = "firstToolStripMenuItem";
            // 
            // secondToolStripMenuItem
            // 
            resources.ApplyResources(this.secondToolStripMenuItem, "secondToolStripMenuItem");
            this.secondToolStripMenuItem.Name = "secondToolStripMenuItem";
            this.secondToolStripMenuItem.Click += new System.EventHandler(this._addAlternative);
            // 
            // thirdToolStripMenuItem
            // 
            resources.ApplyResources(this.thirdToolStripMenuItem, "thirdToolStripMenuItem");
            this.thirdToolStripMenuItem.Name = "thirdToolStripMenuItem";
            this.thirdToolStripMenuItem.Click += new System.EventHandler(this._removeAlternative);
            // 
            // fourthToolStripMenuItem
            // 
            resources.ApplyResources(this.fourthToolStripMenuItem, "fourthToolStripMenuItem");
            this.fourthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fifthToolStripMenuItem1,
            this.sixToolStripMenuItem1});
            this.fourthToolStripMenuItem.Name = "fourthToolStripMenuItem";
            // 
            // fifthToolStripMenuItem1
            // 
            resources.ApplyResources(this.fifthToolStripMenuItem1, "fifthToolStripMenuItem1");
            this.fifthToolStripMenuItem1.Name = "fifthToolStripMenuItem1";
            this.fifthToolStripMenuItem1.Click += new System.EventHandler(this._addCriterium);
            // 
            // sixToolStripMenuItem1
            // 
            resources.ApplyResources(this.sixToolStripMenuItem1, "sixToolStripMenuItem1");
            this.sixToolStripMenuItem1.Name = "sixToolStripMenuItem1";
            this.sixToolStripMenuItem1.Click += new System.EventHandler(this._removeCriterium);
            // 
            // sevenToolStripMenuItem
            // 
            resources.ApplyResources(this.sevenToolStripMenuItem, "sevenToolStripMenuItem");
            this.sevenToolStripMenuItem.Name = "sevenToolStripMenuItem";
            this.sevenToolStripMenuItem.Click += new System.EventHandler(this._clearMatrix);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this._clearMatrix);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this._removeCriterium);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this._addCriterium);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this._removeAlternative);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this._addAlternative);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Controls.Add(this.btnOk);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // frmMatrixEdit
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbMatrix);
            this.Name = "frmMatrixEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMatrixEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMatrixEdit_FormClosed);
            this.gbMatrix.ResumeLayout(false);
            this.ctrlMatrixContextMenuStrip.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMatrix;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip ctrlMatrixContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem firstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fourthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fifthToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sixToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sevenToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        public ctrlMatrix ctrlMatrix;

    }
}