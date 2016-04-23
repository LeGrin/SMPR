using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            double val = Double.Parse(txtElem.Text);
            double prob = Double.Parse(txtProb.Text);
            setA.AddDot(val, prob);
            sizeA.Text = setA.Dots.Count.ToString();
            refresh();
        }

        private void btnAddToB_Click(object sender, EventArgs e)
        {
            double val = Double.Parse(txtElem.Text);
            double prob = Double.Parse(txtProb.Text);
            setB.AddDot(val, prob);
            sizeB.Text = setA.Dots.Count.ToString();
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
            
            for (int i = 0; i < n; i++)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                setA.AddDot(x * 10, y);
            }

            for (int i = 0; i < m; i++)
            {
                setB.AddDot(random.NextDouble() * 10, random.NextDouble());
            }
            MessageBox.Show(n.ToString() + " " + m.ToString());
            refresh();
        }
    }
}
