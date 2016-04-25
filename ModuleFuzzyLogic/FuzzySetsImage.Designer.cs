namespace Modules.ModuleFuzzyLogic
{
    partial class FuzzySetsImage
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSets = new System.Windows.Forms.DataGridView();
            this.numericUpDownElements = new System.Windows.Forms.NumericUpDown();
            this.radioButtonClear = new System.Windows.Forms.RadioButton();
            this.radioButtonFuzzy = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewFuzzyImage = new System.Windows.Forms.DataGridView();
            this.radioButtonSubsets = new System.Windows.Forms.RadioButton();
            this.radioButtonRatio = new System.Windows.Forms.RadioButton();
            this.dataGridViewAnswer = new System.Windows.Forms.DataGridView();
            this.buttonProsses = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownSizeSubset = new System.Windows.Forms.NumericUpDown();
            this.Clear = new System.Windows.Forms.Button();
            this.labeb6 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDowSetC = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewSetC = new System.Windows.Forms.DataGridView();
            this.comboBoxClearImage = new System.Windows.Forms.ComboBox();
            this.numericUpDownClearImage = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFuzzyImage = new System.Windows.Forms.ComboBox();
            this.numericUpDownFuzzyImage = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAddB = new System.Windows.Forms.Button();
            this.buttonLoadB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuzzyImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeSubset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowSetC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClearImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuzzyImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(227, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Відображення нечітких множин";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(471, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Оберіть кількість елементів множини";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Введіть нечітку множину";
            // 
            // dataGridViewSets
            // 
            this.dataGridViewSets.AllowUserToAddRows = false;
            this.dataGridViewSets.AllowUserToDeleteRows = false;
            this.dataGridViewSets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSets.Location = new System.Drawing.Point(32, 37);
            this.dataGridViewSets.Name = "dataGridViewSets";
            this.dataGridViewSets.Size = new System.Drawing.Size(436, 86);
            this.dataGridViewSets.TabIndex = 4;
            this.dataGridViewSets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSets_CellContentClick);
            this.dataGridViewSets.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewSets_CellValidating);
            // 
            // numericUpDownElements
            // 
            this.numericUpDownElements.Location = new System.Drawing.Point(474, 54);
            this.numericUpDownElements.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownElements.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownElements.Name = "numericUpDownElements";
            this.numericUpDownElements.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownElements.TabIndex = 5;
            this.numericUpDownElements.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownElements.ValueChanged += new System.EventHandler(this.numericUpDownElements_ValueChanged);
            // 
            // radioButtonClear
            // 
            this.radioButtonClear.AutoSize = true;
            this.radioButtonClear.Location = new System.Drawing.Point(171, 159);
            this.radioButtonClear.Name = "radioButtonClear";
            this.radioButtonClear.Size = new System.Drawing.Size(125, 17);
            this.radioButtonClear.TabIndex = 8;
            this.radioButtonClear.TabStop = true;
            this.radioButtonClear.Text = "Чітке відображення";
            this.radioButtonClear.UseVisualStyleBackColor = true;
            this.radioButtonClear.CheckedChanged += new System.EventHandler(this.radioButtonClear_CheckedChanged);
            // 
            // radioButtonFuzzy
            // 
            this.radioButtonFuzzy.AutoSize = true;
            this.radioButtonFuzzy.Location = new System.Drawing.Point(449, 159);
            this.radioButtonFuzzy.Name = "radioButtonFuzzy";
            this.radioButtonFuzzy.Size = new System.Drawing.Size(136, 17);
            this.radioButtonFuzzy.TabIndex = 9;
            this.radioButtonFuzzy.TabStop = true;
            this.radioButtonFuzzy.Text = "Нечітке відображення";
            this.radioButtonFuzzy.UseVisualStyleBackColor = true;
            this.radioButtonFuzzy.CheckedChanged += new System.EventHandler(this.radioButtonFuzzy_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введіть функцію";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(295, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = " Задайте відображення";
            // 
            // dataGridViewFuzzyImage
            // 
            this.dataGridViewFuzzyImage.AllowUserToAddRows = false;
            this.dataGridViewFuzzyImage.AllowUserToDeleteRows = false;
            this.dataGridViewFuzzyImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFuzzyImage.Location = new System.Drawing.Point(231, 253);
            this.dataGridViewFuzzyImage.Name = "dataGridViewFuzzyImage";
            this.dataGridViewFuzzyImage.Size = new System.Drawing.Size(245, 128);
            this.dataGridViewFuzzyImage.TabIndex = 15;
            this.dataGridViewFuzzyImage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFuzzyImage_CellContentClick);
            // 
            // radioButtonSubsets
            // 
            this.radioButtonSubsets.AutoSize = true;
            this.radioButtonSubsets.Location = new System.Drawing.Point(241, 206);
            this.radioButtonSubsets.Name = "radioButtonSubsets";
            this.radioButtonSubsets.Size = new System.Drawing.Size(122, 17);
            this.radioButtonSubsets.TabIndex = 16;
            this.radioButtonSubsets.TabStop = true;
            this.radioButtonSubsets.Text = "Нечіткі підмножини";
            this.radioButtonSubsets.UseVisualStyleBackColor = true;
            this.radioButtonSubsets.CheckedChanged += new System.EventHandler(this.radioButtonSubsets_CheckedChanged);
            // 
            // radioButtonRatio
            // 
            this.radioButtonRatio.AutoSize = true;
            this.radioButtonRatio.Location = new System.Drawing.Point(489, 206);
            this.radioButtonRatio.Name = "radioButtonRatio";
            this.radioButtonRatio.Size = new System.Drawing.Size(250, 17);
            this.radioButtonRatio.TabIndex = 17;
            this.radioButtonRatio.TabStop = true;
            this.radioButtonRatio.Text = "Співідношення з множиною С у вигляді С*f(x)";
            this.radioButtonRatio.UseVisualStyleBackColor = true;
            this.radioButtonRatio.CheckedChanged += new System.EventHandler(this.radioButtonRatio_CheckedChanged);
            // 
            // dataGridViewAnswer
            // 
            this.dataGridViewAnswer.AllowUserToAddRows = false;
            this.dataGridViewAnswer.AllowUserToDeleteRows = false;
            this.dataGridViewAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAnswer.Location = new System.Drawing.Point(32, 441);
            this.dataGridViewAnswer.Name = "dataGridViewAnswer";
            this.dataGridViewAnswer.Size = new System.Drawing.Size(707, 90);
            this.dataGridViewAnswer.TabIndex = 23;
            this.dataGridViewAnswer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAnswer_CellContentClick);
            // 
            // buttonProsses
            // 
            this.buttonProsses.Location = new System.Drawing.Point(32, 409);
            this.buttonProsses.Name = "buttonProsses";
            this.buttonProsses.Size = new System.Drawing.Size(130, 26);
            this.buttonProsses.TabIndex = 24;
            this.buttonProsses.Text = "Обчислити";
            this.buttonProsses.UseVisualStyleBackColor = true;
            this.buttonProsses.Click += new System.EventHandler(this.buttonProsses_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Задати розмір підмножини";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // numericUpDownSizeSubset
            // 
            this.numericUpDownSizeSubset.Location = new System.Drawing.Point(406, 227);
            this.numericUpDownSizeSubset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSizeSubset.Name = "numericUpDownSizeSubset";
            this.numericUpDownSizeSubset.Size = new System.Drawing.Size(34, 20);
            this.numericUpDownSizeSubset.TabIndex = 26;
            this.numericUpDownSizeSubset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSizeSubset.ValueChanged += new System.EventHandler(this.numericUpDownSizeSubset_ValueChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(612, 537);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(127, 30);
            this.Clear.TabIndex = 27;
            this.Clear.Text = "Очистити ";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // labeb6
            // 
            this.labeb6.AutoSize = true;
            this.labeb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeb6.Location = new System.Drawing.Point(301, 141);
            this.labeb6.Name = "labeb6";
            this.labeb6.Size = new System.Drawing.Size(139, 15);
            this.labeb6.TabIndex = 28;
            this.labeb6.Text = "Оберіть відображення";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(508, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Задайте розмір С";
            // 
            // numericUpDowSetC
            // 
            this.numericUpDowSetC.Location = new System.Drawing.Point(610, 262);
            this.numericUpDowSetC.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowSetC.Name = "numericUpDowSetC";
            this.numericUpDowSetC.Size = new System.Drawing.Size(29, 20);
            this.numericUpDowSetC.TabIndex = 30;
            this.numericUpDowSetC.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDowSetC.ValueChanged += new System.EventHandler(this.numericUpDowSetC_ValueChanged);
            // 
            // dataGridViewSetC
            // 
            this.dataGridViewSetC.AllowUserToAddRows = false;
            this.dataGridViewSetC.AllowUserToDeleteRows = false;
            this.dataGridViewSetC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSetC.Location = new System.Drawing.Point(494, 285);
            this.dataGridViewSetC.Name = "dataGridViewSetC";
            this.dataGridViewSetC.Size = new System.Drawing.Size(245, 96);
            this.dataGridViewSetC.TabIndex = 31;
            this.dataGridViewSetC.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewSetC_CellValidating);
            // 
            // comboBoxClearImage
            // 
            this.comboBoxClearImage.FormattingEnabled = true;
            this.comboBoxClearImage.Items.AddRange(new object[] {
            "x",
            "x^2",
            "x^3",
            "x^4",
            "sin(x)",
            "cos(x)",
            "tg(x)",
            "log10(x)",
            "ln(x)",
            "e^x"});
            this.comboBoxClearImage.Location = new System.Drawing.Point(97, 227);
            this.comboBoxClearImage.Name = "comboBoxClearImage";
            this.comboBoxClearImage.Size = new System.Drawing.Size(70, 21);
            this.comboBoxClearImage.TabIndex = 32;
            // 
            // numericUpDownClearImage
            // 
            this.numericUpDownClearImage.DecimalPlaces = 2;
            this.numericUpDownClearImage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownClearImage.Location = new System.Drawing.Point(32, 227);
            this.numericUpDownClearImage.Name = "numericUpDownClearImage";
            this.numericUpDownClearImage.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownClearImage.TabIndex = 34;
            // 
            // comboBoxFuzzyImage
            // 
            this.comboBoxFuzzyImage.FormattingEnabled = true;
            this.comboBoxFuzzyImage.Items.AddRange(new object[] {
            "x",
            "x^2",
            "x^3",
            "x^4",
            "sin(x)",
            "cos(x)",
            "tg(x)",
            "log10(x)",
            "ln(x)",
            "e^x"});
            this.comboBoxFuzzyImage.Location = new System.Drawing.Point(601, 229);
            this.comboBoxFuzzyImage.Name = "comboBoxFuzzyImage";
            this.comboBoxFuzzyImage.Size = new System.Drawing.Size(73, 21);
            this.comboBoxFuzzyImage.TabIndex = 35;
            // 
            // numericUpDownFuzzyImage
            // 
            this.numericUpDownFuzzyImage.DecimalPlaces = 2;
            this.numericUpDownFuzzyImage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownFuzzyImage.Location = new System.Drawing.Point(538, 230);
            this.numericUpDownFuzzyImage.Name = "numericUpDownFuzzyImage";
            this.numericUpDownFuzzyImage.Size = new System.Drawing.Size(56, 20);
            this.numericUpDownFuzzyImage.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(508, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "f(x)";
            // 
            // buttonAddB
            // 
            this.buttonAddB.Location = new System.Drawing.Point(459, 537);
            this.buttonAddB.Name = "buttonAddB";
            this.buttonAddB.Size = new System.Drawing.Size(135, 30);
            this.buttonAddB.TabIndex = 39;
            this.buttonAddB.Text = "Добавити в буфер";
            this.buttonAddB.UseVisualStyleBackColor = true;
            this.buttonAddB.Click += new System.EventHandler(this.buttonAddB_Click);
            // 
            // buttonLoadB
            // 
            this.buttonLoadB.Location = new System.Drawing.Point(474, 88);
            this.buttonLoadB.Name = "buttonLoadB";
            this.buttonLoadB.Size = new System.Drawing.Size(119, 22);
            this.buttonLoadB.TabIndex = 40;
            this.buttonLoadB.Text = "Загрузити з буфера";
            this.buttonLoadB.UseVisualStyleBackColor = true;
            this.buttonLoadB.Click += new System.EventHandler(this.buttonLoadB_Click);
            // 
            // FuzzySetsImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 570);
            this.Controls.Add(this.buttonLoadB);
            this.Controls.Add(this.buttonAddB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownFuzzyImage);
            this.Controls.Add(this.comboBoxFuzzyImage);
            this.Controls.Add(this.numericUpDownClearImage);
            this.Controls.Add(this.comboBoxClearImage);
            this.Controls.Add(this.dataGridViewSetC);
            this.Controls.Add(this.numericUpDowSetC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labeb6);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.numericUpDownSizeSubset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonProsses);
            this.Controls.Add(this.dataGridViewAnswer);
            this.Controls.Add(this.radioButtonRatio);
            this.Controls.Add(this.radioButtonSubsets);
            this.Controls.Add(this.dataGridViewFuzzyImage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonFuzzy);
            this.Controls.Add(this.radioButtonClear);
            this.Controls.Add(this.numericUpDownElements);
            this.Controls.Add(this.dataGridViewSets);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FuzzySetsImage";
            this.Text = "FuzzySetsImage";
            this.Load += new System.EventHandler(this.FuzzySetsImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuzzyImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSizeSubset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDowSetC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSetC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClearImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFuzzyImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewSets;
        private System.Windows.Forms.NumericUpDown numericUpDownElements;
        private System.Windows.Forms.RadioButton radioButtonClear;
        private System.Windows.Forms.RadioButton radioButtonFuzzy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewFuzzyImage;
        private System.Windows.Forms.RadioButton radioButtonSubsets;
        private System.Windows.Forms.RadioButton radioButtonRatio;
        private System.Windows.Forms.DataGridView dataGridViewAnswer;
        private System.Windows.Forms.Button buttonProsses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownSizeSubset;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label labeb6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDowSetC;
        private System.Windows.Forms.DataGridView dataGridViewSetC;
        private System.Windows.Forms.ComboBox comboBoxClearImage;
        private System.Windows.Forms.NumericUpDown numericUpDownClearImage;
        private System.Windows.Forms.ComboBox comboBoxFuzzyImage;
        private System.Windows.Forms.NumericUpDown numericUpDownFuzzyImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAddB;
        private System.Windows.Forms.Button buttonLoadB;
    }
}