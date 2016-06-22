using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Modules.DecisionsUnderFuzzyConditionsMethods
{
    public partial class OptionsForm : Form
    {
        static double fromX;

        public static double FromX
        {
            get { return OptionsForm.fromX; }
            set { OptionsForm.fromX = value; }
        }
        static double toX;

        public static double ToX
        {
            get { return OptionsForm.toX; }
            set { OptionsForm.toX = value; }
        }
        static double xStep;

        public static double XStep
        {
            get { return OptionsForm.xStep; }
            set { OptionsForm.xStep = value; }
        }
        static double yStep;

        public static double YStep
        {
            get { return OptionsForm.yStep; }
            set { OptionsForm.yStep = value; }
        }
        static int approx;

        public static int Approx
        {
            get { return OptionsForm.approx; }
            set { OptionsForm.approx = value; }
        }
        public OptionsForm()
        {
            InitializeComponent();
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                fromX = double.Parse(textBox1.Text);
                toX = double.Parse(textBox2.Text);
                xStep = double.Parse(textBox3.Text);
                yStep = double.Parse(textBox4.Text);
                approx = (int)numericUpDown1.Value;
            }
            catch
            {
                MessageBox.Show("Не корректний формат данних");
                this.DialogResult = DialogResult.Cancel;
            }
            if (toX <= fromX)
            {
                MessageBox.Show("Не корректний проміжок обчислень");
                this.DialogResult = DialogResult.Cancel;
            }
            if (yStep <= 0 || xStep <= 0 || yStep > 1.0 || xStep > toX - fromX)
            {
                MessageBox.Show("Не корректне значення данних");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void OptionsForm_Shown(object sender, EventArgs e)
        {
            textBox1.Text = fromX.ToString();
            textBox2.Text = toX.ToString();
            textBox3.Text = xStep.ToString();
            textBox4.Text = yStep.ToString();
            numericUpDown1.Value = approx;
        }
    }
}