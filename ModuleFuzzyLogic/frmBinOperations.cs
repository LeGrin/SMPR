using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.DataTypes;
namespace Modules.ModuleFuzzyLogic
{
    public partial class frmBinOperations : Form
    {
        FuzzySets.FuzzySet1D setA;
        FuzzySets.FuzzySet1D setB;
        FuzzySets.FuzzySet1D setRes;
        public frmBinOperations()
        {
            InitializeComponent();
            setA = new FuzzySets.FuzzySet1D();
            setB = new FuzzySets.FuzzySet1D();
            setRes = new FuzzySets.FuzzySet1D();

            refresh();

            operationsBox.Items.Add("  /  ");
            operationsBox.Items.Add("  |  ");
            operationsBox.Items.Add("  &  ");
            operationsBox.Items.Add("  *  ");// Алгебраическое произведение
            operationsBox.Items.Add("  +  ");// Алгебраическая сумма 
            operationsBox.Items.Add("  -  "); // Семетрична сума
            operationsBox.Items.Add(" Дизъюнктивная сумма ");
            operationsBox.Items.Add(" Граничное пересечение ");
            operationsBox.Items.Add(" Граничное объединение ");
            operationsBox.Items.Add(" Лямда сума ");
            operationsBox.SelectedIndex = 0;

        }

        private void frmBinOperations_Load(object sender, EventArgs e)
        {
            sizeA.Text = "0";
            sizeB.Text = "0";
        }

        private void refresh()
        {
            setA.ToMatrix(dgvA);
            setB.ToMatrix(dgvB);
            setRes.ToMatrix(dgvRes);
        }



        private void AddToA_Click(object sender, EventArgs e)
        {
            try
            {
                double val = Double.Parse(txtElem.Text);
                double prob = Double.Parse(txtProb.Text);
                setA.AddDot(val, prob);
                sizeA.Text = setA.Dots.Count.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Некоректний ввід");
            }
            refresh();
        }

        private void btnAddToB_Click(object sender, EventArgs e)
        {
            try
            {
                double val = Double.Parse(txtElem.Text);
                double prob = Double.Parse(txtProb.Text);
                setB.AddDot(val, prob);
                sizeB.Text = setA.Dots.Count.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Некоректний ввід");
            }
            refresh();
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            int ch = operationsBox.SelectedIndex;

            if (ch == 0) setRes = setA / setB;
            if (ch == 1) setRes = setA | setB;
            if (ch == 2) setRes = setA & setB;
            if (ch == 3) setRes = setA * setB;
            if (ch == 4) setRes = setA + setB;
            if (ch == 5) setRes = setA - setB;
            if (ch == 6) setRes = FuzzySets.FuzzySet1D.dSum(setA, setB);
            if (ch == 7) setRes = FuzzySets.FuzzySet1D.gIntersect(setA, setB);
            if (ch == 8) setRes = FuzzySets.FuzzySet1D.gUnion(setA, setB);


            if (ch == 9)
            {
                try
                {
                    double lamda = double.Parse(txtLamda.Text);
                    lamda = Math.Max(0, lamda);
                    lamda = Math.Min(lamda, 1);
                    txtLamda.Text = lamda.ToString();
                    setRes = FuzzySets.FuzzySet1D.alphaSum(setA, setB, lamda);
                }
                catch (Exception exx)
                {
                    MessageBox.Show("Помилка виникла при обчисленні лямда суми");
                }
            }

            refresh();
        }

        private void operationsBox_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void operationsBox_DropDownClosed(object sender, EventArgs e)
        {
        }


        // random generation setA setB with recieved sizes.
        private void button1_Click(object sender, EventArgs e)
        {
            setA.clearDots();
            setB.clearDots();
            int n = Int32.Parse(sizeA.Text);
            int m = Int32.Parse(sizeB.Text);
            if (n < 0) n = 0;
            if (m < 0) m = 0;
            if (n > 1000) n = 1000;
            if (m > 1000) m = 1000;
            
            Random random = new Random();

            for (int i = 0; i < n;)
            {
                double x = random.NextDouble() * random.Next(0, 10);
                x = double.Parse(String.Format("{0:0.00}", x));
                double y = random.NextDouble() * random.NextDouble();
                y = double.Parse(String.Format("{0:0.00}", y));
                if (setA.AddDot(x, y) && setA.Dots.Count == i + 1) i++;
            }

            for (int i = 0; i < m;)
            {
                double x = random.NextDouble() * random.Next(0, 10);
                x = double.Parse(String.Format("{0:0.00}", x));
                double y = random.NextDouble() * random.NextDouble();
                y = double.Parse(String.Format("{0:0.00}", y));
                if (setB.AddDot(x, y) && setB.Dots.Count == i + 1) i++;
            }
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BufferData t = Common.DataBuffer.Instance.LoadDialog(FuzzySets.FuzzySet1D.ValidationCallback);
            if (t != null)
            {
                setA = new FuzzySets.FuzzySet1D(((Matrix<double>)t).Value);
            }
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Common.DataTypes.Matrix<double> m = new Common.DataTypes.Matrix<double>(setA.toMassiv());
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Common.DataTypes.Matrix<double> m = new Common.DataTypes.Matrix<double>(setB.toMassiv());
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BufferData t = Common.DataBuffer.Instance.LoadDialog(FuzzySets.FuzzySet1D.ValidationCallback);
            if (t == null)
                MessageBox.Show("ERROR");
            else
            {
                setB = new FuzzySets.FuzzySet1D(((Matrix<double>)t).Value);
            }
            refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Common.DataTypes.Matrix<double> m = new Common.DataTypes.Matrix<double>(setRes.toMassiv());
            Common.DataBuffer.Instance.SaveDialog(m);
        }

        private void operationsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lLamda.Visible = operationsBox.SelectedIndex == 9;
            txtLamda.Enabled = operationsBox.SelectedIndex == 9;
        }
    }
}
