using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;
using Common;
using Modules.ExpertProcessingMethods.Methods;

namespace Modules.ExpertProcessingMethods
{
    partial class frmModule : Form
    {
        public int expertsCount;
        private int[,] rangeProp1;
        
        public frmModule()
        {
            InitializeComponent();
        }

        public void showTab(int num)
        {
            if (num>0 && num <= methodsTab.TabCount)
                methodsTab.SelectedIndex = num - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Method m = new TestedSumming();
            double t; 
            Object a;
            double[] marks = { 1, 0.5, 2 };

            double[] x1 = { 1, 1, 1, 1 };
            double[] x2 = { 2, 1.5, 1, 2 };
            double[] x3 = { 10, 10, 10, 3 };

            ArrayList opinions= new ArrayList();
            opinions.Add(x1);
            opinions.Add(x2);
            opinions.Add(x3);
            
            m.Execute(3,marks, opinions, out t,out a);
            MessageBox.Show(t.ToString());
            MessageBox.Show(a.ToString());


        }

//////////////////////Методы для буфера обмена/////////////////////////

        private double round100(double a)
        {
            return ((int)(a * 100 + 0.5)) / 100.0;
        }

        private double[] getDoubleArrayFromBuffer(BufferData bd)
        {
            if (bd == null) return null;
            if (!(bd is Vector<int>) && !(bd is Vector<double>))
                return null;

            int vectorLength = 0;
            if (bd is Vector<int>)
                vectorLength = (bd as Vector<int>).Value.Length;
            else
                vectorLength = (bd as Vector<double>).Value.Length;

            double[] res = new double[vectorLength];

            for (int i = 0; i < vectorLength; i++)
                if (bd is Vector<int>)
                    res[i] = round100((bd as Vector<int>)[i]);
                else
                    res[i] = round100((bd as Vector<double>)[i]);

            return res;
        }

        private int[,] rangeFromBuffer()
        {
            BufferData bd = Common.DataBuffer.Instance.LoadDialog();
            if (bd == null) return null;
            if (!(bd is Matrix<int>))
            {
                MessageBox.Show("Некоректний тип даних для даного методу");
                return null;
            }

            Matrix<int> mat = bd as Matrix<int>;

            return mat.Value;
        }

        bool checkDirectRange(int[,] grid)
        {
            int objCount = grid.GetLength(1);

            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 1; j <= objCount; j++)
                {
                    bool founded = false;
                    for (int k = 0; k < objCount; k++)
                        if (grid[i, k] == j)
                        {
                            founded = true;
                            break;
                        }
                    if (!founded)
                        return false;
                }
            return true;
        }

        bool checkUnDirectRange(int[,] grid)
        {
            int objCount = grid.GetLength(1);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                int max=0;
                for (int j = 0; j < objCount; j++)
                {
                    if (grid[i, j] > max) max = grid[i, j];
                    if (grid[i, j] < 1) return false;
                }

                if (max < 1) return false;

                for (int j = 1; j <= max; j++)
                {
                    bool founded = false;
                    for (int k = 0; k < objCount; k++)
                        if (grid[i, k] == j)
                        {
                            founded = true;
                            break;
                        }
                    if (!founded)
                        return false;
                }
            }

            return true;
        }

        private void gridToMatrix(int[,] grid, bool direct, DataGridView matrix, NumericUpDown upDown)
        {
            if (grid == null) return;
            if (grid.GetLength(0) != expertsCount)
            {
                MessageBox.Show("Розмірність матриці не відповідає кількості експертів");
                return;
            }

            if (direct && !checkDirectRange(grid))
            {
                MessageBox.Show("Матриця не відповідає строгому ранжуванню");
                return;
            }
            else if (!direct && !checkUnDirectRange(grid))
            {
                MessageBox.Show("Матриця не відповідає нестрогому ранжуванню");
                return;
            }

            int objCount = grid.GetLength(1);

            matrix.Columns.Clear();
            for (int column = 0; column < expertsCount; column++)
                matrix.Columns.Add("expert" + column.ToString(), "Експерт " + Convert.ToString(column + 1));

            matrix.RowCount = objCount;
            for (int i = 0; i < expertsCount; i++)
                for (int j = 0; j < objCount; j++)
                    matrix[i, j].Value = grid[i,j];

            if (upDown != null)    
                upDown.Value = Convert.ToDecimal(objCount);
        }

        private void gridToMatrix(int[,] grid, bool direct, DataGridView matrix)
        {
            gridToMatrix(grid, direct, matrix, null);
        }

        void bufferToMatrix(bool direct, DataGridView matrix, NumericUpDown upDown)
        {
            int[,] grid = rangeFromBuffer();
            gridToMatrix(grid, direct, matrix, upDown);
        }

//////////////////////////Методы для экспертов//////////////////////////

        private void changeExpertsCount()
        {
            dataGridView1.RowCount = expertsCount;
            dataGridView2.RowCount = expertsCount;
            rangeTable1.Columns.Clear();
            rangeTable2.Columns.Clear();
        }

        private void expertCount_ValueChanged(object sender, EventArgs e)
        {
            expertsCount = decimal.ToInt32(expertCount.Value);

            while (expertWeights.RowCount < expertsCount)
            {
                expertWeights.Rows.Add();
                expertWeights[0, expertWeights.RowCount - 1].Value = 1;
            }

            while (expertWeights.RowCount > expertsCount)
                expertWeights.Rows.RemoveAt(expertWeights.RowCount - 1);

            changeExpertsCount();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < expertWeights.RowCount; i++)
                expertWeights[0, i].Value = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Random generator = new Random();
            for (int i = 0; i < expertWeights.RowCount; i++)
                expertWeights[0, i].Value = generator.Next(1, 100);
        }

        private double[] GetExpertTrust()
        {
            double[] expertTrust = new double[expertsCount];

            for (int i = 0; i < expertsCount; i++)
                    expertTrust[i] = round100(Convert.ToDouble(expertWeights[0, i].Value));

            return expertTrust;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BufferData bd = Common.DataBuffer.Instance.LoadDialog();
            if (bd == null) return;
            if (!(bd is Vector<int>) && !(bd is Vector<double>))
            {
                MessageBox.Show("Некоректний тип даних для даного методу");
                return;
            }

            double[] res = getDoubleArrayFromBuffer(bd);
            expertsCount = res.Length;
            expertWeights.RowCount = expertsCount;

            for (int i = 0; i < expertsCount; i++)
                expertWeights[0, i].Value = round100(res[i]).ToString();

            changeExpertsCount();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double[] export = new double[expertsCount];

            for (int i = 0; i < expertsCount; i++)
                export[i] = round100(Convert.ToDouble(expertWeights[0,i].Value));

            Vector<double> expertExport = new Vector<double>(export);

            Common.DataBuffer.Instance.SaveDialog(expertExport);
        }


        ////////////////////////////////////////////////////////////////////////
        private void Shuffle(ref int[] arr)
        {
            Random r = new Random();
            for (int i = 0; i < arr.Length*2; i++)
            { 
                int n1 = r.Next(0, arr.Length);
                int n2 = r.Next(0, arr.Length);
                int x = arr[n1];
                arr[n1] = arr[n2];
                arr[n2] = x;
            }
        }

        public int[,] generateRange(int expertCount, int objCount)
        {
            int[,] mat = new int[expertCount, objCount];
            Random generator = new Random();

            int[] numbers = new int[objCount];
            for (int k = 0; k < objCount; k++)
                numbers[k] = k+1;

            for (int i = 0; i < expertCount; i++)
            {
                Shuffle(ref numbers);
                for (int j = 0; j < objCount; j++)
                    mat[i, j] = numbers[j];
            }

            return mat;
        }

        public int[,] rangeToMatrix(DataGridView matrix, NumericUpDown objects, bool direct)
        {
            int objCount = decimal.ToInt32(objects.Value);
            matrix.Columns.Clear();
            for (int column = 0; column < expertsCount; column++)
                matrix.Columns.Add("expert"+column.ToString(), "Експерт "+Convert.ToString(column+1));

            matrix.RowCount = objCount;
            int[,] newRange;
            if (direct)
                newRange = generateRange(expertsCount, objCount);
            else
                newRange = generateNonDirectRange(expertsCount, objCount);

            for (int i = 0; i < expertsCount; i++)
                for (int j = 0; j < objCount; j++)
                    matrix[i, j].Value = Convert.ToInt32(newRange[i, j]);

            return newRange;
        }

        public int[,] generateNonDirectRange(int expertCount, int objCount)
        {
            int[,] mat = new int[expertCount, objCount];
            Random generator = new Random();
            for (int i = 0; i < expertCount; i++)
            {
                int[] numbers = new int[objCount];
                int place = 1; int curVariable = 1;
                for (int j = 0; j < objCount; j++)
                    if (generator.Next(curVariable)==0)
                    {
                        numbers[j] = place;
                        curVariable *= 3;
                    }
                    else
                    {
                        place++; curVariable = 3;
                        numbers[j] = place;
                    }
                Shuffle(ref numbers);
                for (int k = 0; k < objCount; k++)
                    mat[i, k] = numbers[k];
            }

            return mat;
        }

        public int[,] rangeFromMatrix(DataGridView matrix, NumericUpDown objects)
        {
            int objCount = decimal.ToInt32(objects.Value);

            int[,] curRange = new int[expertsCount, objCount];

            for (int i = 0; i < expertsCount; i++)
                for (int j = 0; j < objCount; j++)
                    curRange[i, j] = Convert.ToInt32(matrix[i, j].Value);

            return curRange;
        }

        public ArrayList arrayListFromMatrix(DataGridView matrix, NumericUpDown objects)
        {
            int objCount = decimal.ToInt32(objects.Value);

            ArrayList curRange = new ArrayList();

            for (int i = 0; i < expertsCount; i++)
            {
                int[] rangeByExpert = new int[objCount];
                for (int j = 0; j < objCount; j++)
                    rangeByExpert[j] = Convert.ToInt32(matrix[i, j].Value);

                curRange.Add(rangeByExpert);
            }

            return curRange;
        }

        private void rangeToMatrix(DataGridView matrix, int objCount, int[] result)
        {
            matrix.Columns.Clear();

            for (int i = 0; i < objCount; i++)
            {
                matrix.Columns.Add("Column" + i.ToString(), "Oб`єкт " + Convert.ToString(i + 1));
                matrix[i, 0].Value = result[i];
            }
        }

        //////////////Ранжування експертів корстувачеm////////////////////

        public void makeRangeByUser(DataGridView matrix, NumericUpDown objCounts, bool direct)
        {
            int objCount = Decimal.ToInt32(objCounts.Value);
            int [,] grid = new int[expertsCount, objCount];
            if (matrix.RowCount==objCount && matrix.ColumnCount == expertsCount)
                for (int i=0; i<expertsCount; i++)
                    for (int j=0; j<objCount;j++)
                        grid[i,j] = Convert.ToInt32(matrix[i,j].Value);

            if (direct && !checkDirectRange(grid))
                grid = new int[expertsCount, objCount];
            else if (!direct && !checkUnDirectRange(grid))
                grid = new int[expertsCount, objCount]; 
            try
            {
                ManyRankForm.Dialog(ref grid, direct);
            }
            catch (Exception)
            {
                MessageBox.Show("Ви намагаєтесь змінити некорректну матрицю!");
                return;
            }

            matrix.Columns.Clear();
            for (int column = 0; column < expertsCount; column++)
                matrix.Columns.Add("expert" + column.ToString(), "Експерт " + Convert.ToString(column + 1));

            matrix.RowCount = objCount;
            for (int i = 0; i < expertsCount; i++)
                for (int j = 0; j < objCount; j++)
                    matrix[i, j].Value = grid[i,j];

        }

        //////////////Перший експертний метод/////////////////
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount != expertsCount)
                dataGridView1.RowCount = expertsCount;

            Random generator = new Random();
            for (int i = 0; i < expertsCount; i++)
                dataGridView1[0, i].Value = Convert.ToDouble(generator.Next(1, 100 * expertsCount))/100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rows = dataGridView1.Rows.Count;
            double[] expertTrust = GetExpertTrust();
            ArrayList expertOpinion = new ArrayList();
            for (int i = 0; i < rows; i++)
            {
                expertOpinion.Add(round100(Convert.ToDouble(dataGridView1[0, i].Value)));
            }
            Method m = new SimpleSumming();
            double efficiency;
            object results;
            m.Execute(rows, expertTrust, expertOpinion, out efficiency, out results);
            textBox1.Text = round100(((double)results)).ToString();
            textBox2.Text = round100(efficiency).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Scalar<double> result = new Scalar<double>(round100(Convert.ToDouble(textBox1.Text)));
            Common.DataBuffer.Instance.SaveDialog(result);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BufferData bd= Common.DataBuffer.Instance.LoadDialog();
            if (bd == null) return;
            if (!(bd is Vector<int>) && !(bd is Vector<double>))
            {
                MessageBox.Show("Некоректний тип даних для даного методу");
                return;
            }

            double[] res = getDoubleArrayFromBuffer(bd);

            int minLength = Math.Min(expertsCount, res.Length);

            for (int i = 0; i < minLength; i++)
                dataGridView1[0, i].Value = round100(res[i]).ToString();

            for (int j = 0; j < expertsCount - minLength; j++)
                dataGridView1[0, j].Value = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count- 1);
        }

// ///////////////////////// 2-й експертний метод /////////////////////////////////////
        private void generateButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount != expertsCount)
                dataGridView2.RowCount = expertsCount;

            Random generator = new Random();
            for (int i = 0; i < expertsCount; i++)
            {
                double[] rand = new double[3];
                for (int j = 0; j < 3; j++)
                    rand[j] = Convert.ToDouble(generator.Next(1, 100 * expertsCount)) / 100;

                Array.Sort(rand);
                for (int j = 0; j < 3; j++)
                    dataGridView2[j, i].Value = rand[j];
            }
        } 
        
        private void bufferButton2_Click(object sender, EventArgs e)
        {
            BufferData bd = Common.DataBuffer.Instance.LoadDialog();
            if (!(bd is Matrix<int>) && !(bd is Matrix<double>))
            {
                MessageBox.Show("Завантажено неправильний тип даних з буферу обміну.");
                return;
            }

            if ((bd is Matrix<int>) && (bd as Matrix<int>).Row(0).Value.Length != 3)
            {
                MessageBox.Show("Неправильна розмірність матриці. Конвертування неможливе.");
                return;
            }

            if ((bd is Matrix<double>) && (bd as Matrix<double>).Row(0).Value.Length != 3)
            {
                MessageBox.Show("Неправильна розмірність матриці. Конвертування неможливе.");
                return;
            }

            int rowCount = 0;
            if (bd is Matrix<double>)
                rowCount = (bd as Matrix<double>).Column(0).Value.Length;
            else
                rowCount = (bd as Matrix<int>).Column(0).Value.Length;

            int realCount = Math.Min(expertsCount, rowCount);
            for (int i = 0; i < realCount; i++)
                for (int j = 0; j < 3; j++)
                    if (bd is Matrix<double>)
                        dataGridView2[j, i].Value = (bd as Matrix<double>)[j, i];
                    else
                        dataGridView2[j, i].Value = (bd as Matrix<int>)[j, i];

            for (int i = realCount + 1; i < expertsCount; i++)
                for (int j = 0; j < 3; j++)
                    dataGridView2[j, i].Value = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int rows = dataGridView2.Rows.Count;
            double[] expertTrust = GetExpertTrust();
            ArrayList expertOpinion = new ArrayList();
            for (int i = 0; i < rows; i++)
            {
                double[] opinions = new double[3];
                for (int j = 0; j < 3; j++)
                    opinions[j] = Convert.ToDouble(dataGridView2[j, i].Value);
                expertOpinion.Add(opinions);
            }
            double gamma1 = Convert.ToDouble(optimData.Text);
            double gamma2 = Convert.ToDouble(realData.Text);
            double gamma3 = Convert.ToDouble(pessData.Text);
            double gamma4 = Convert.ToDouble(koefData.Text);
            TestedSumming m = new TestedSumming();
            m.Init(gamma1, gamma2, gamma3, gamma4);
            double efficiency;
            object results;
            m.Execute(rows, expertTrust, expertOpinion, out efficiency, out results);
            textBox4.Text = round100(((double)results)).ToString();
            textBox3.Text = round100(efficiency).ToString();
        }

        private void method1_CheckedChanged(object sender, EventArgs e)
        {
            optimData.Text = "1";
            realData.Text = "4";
            pessData.Text = "1";
            koefData.Text = "36";
        }

        private void method2_CheckedChanged(object sender, EventArgs e)
        {
            optimData.Text = "3";
            realData.Text = "0";
            pessData.Text = "2";
            koefData.Text = "25";
        }

        private void method3_CheckedChanged(object sender, EventArgs e)
        {
            optimData.Text = "2";
            realData.Text = "0";
            pessData.Text = "3";
            koefData.Text = "25";
        }

        private void goToOwn(object sender, EventArgs e)
        {
            methodOwn.Select();
        }

        private void goToOwn(object sender, KeyPressEventArgs e)
        {
               methodOwn.Select();
        }

// /////////////////////////////////3-й експертний метод/////////////////////////////
        private void button11_Click_1(object sender, EventArgs e)
        {
            rangeProp1 = rangeToMatrix(rangeTable1, objCount1, true);
        }

        private void makeButton1_Click(object sender, EventArgs e)
        {
            makeRangeByUser(rangeTable1, objCount1, true);
        }

        private void bufferButton3_Click(object sender, EventArgs e)
        {
            bufferToMatrix(true, rangeTable1, objCount1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double[] expertTrust = GetExpertTrust();
            int objCount = Decimal.ToInt32(objCount1.Value);

            ArrayList expertOpinions = arrayListFromMatrix(rangeTable1, objCount1);

            Method method = new SimpleRange();

            double efficiency = 0;
            Object result;

            method.Execute(expertsCount, expertTrust, expertOpinions, out efficiency, out result);
            int[] resultRange = result as int[];
            

            rangeResult1.Columns.Clear();
         
            concordResult1.Text = efficiency.ToString();
            for (int i = 0; i < objCount; i++)
            {
                rangeResult1.Columns.Add("Column" + i.ToString(), "Oб`єкт " + Convert.ToString(i + 1));
                rangeResult1[i, 0].Value = resultRange[i];
            }
       }


// /////////////////////////////////4-й експертний метод/////////////////////////////

        private void makeButton2_Click(object sender, EventArgs e)
        {
            makeRangeByUser(rangeTable2, objCount2, false);
        }

        private void generateButton4_Click(object sender, EventArgs e)
        {
            rangeProp1 = rangeToMatrix(rangeTable2, objCount2, false);
        }

        private void bufferButton4_Click(object sender, EventArgs e)
        {
            bufferToMatrix(false, rangeTable2, objCount2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            double[] expertTrust = GetExpertTrust();
            int objCount = Decimal.ToInt32(objCount2.Value);

            ArrayList expertOpinions = arrayListFromMatrix(rangeTable2, objCount2);

            Method method = new NonDirectRange();

            double efficiency = 0;
            Object result;

            method.Execute(expertsCount, expertTrust, expertOpinions, out efficiency, out result);
            int[] resultRange = result as int[];


            concordResult2.Text = efficiency.ToString();
            rangeToMatrix(rangeResult2, objCount, resultRange);
        }

        private void frmModule_Load(object sender, EventArgs e)
        {

        }

        ////////////////////////////////////// Метод Кондорсе ///////////////////////////////////////

        private void generateButton5_Click(object sender, EventArgs e)
        {
            rangeProp1 = rangeToMatrix(rangeTable3, objCount3, true);
        }
        private void makeButton3_Click(object sender, EventArgs e)
        {
            makeRangeByUser(rangeTable3, objCount3, true);
        }

        private void bufferButton5_Click(object sender, EventArgs e)
        {
            bufferToMatrix(true, rangeTable3, objCount3);
        }

        private void goButton5_Click(object sender, EventArgs e)
        {
            double[] expertTrust = GetExpertTrust();
            int objCount = Decimal.ToInt32(objCount3.Value);

            ArrayList expertOpinions = arrayListFromMatrix(rangeTable3, objCount3);

            Method method = new KondorseMethod();

            double efficiency = 0;
            Object result;

            method.Execute(expertsCount, expertTrust, expertOpinions, out efficiency, out result);
            int[] resultRange = result as int[];


            rangeToMatrix(rangeResult3, objCount, resultRange);
        }

        /////////////////////////////////// Метод парних порівнянь /////////////////////////////////////

        private void button15_Click(object sender, EventArgs e)
        {
            makeRangeByUser(rangeTable4, objCount4, false);
        }

        private void bufferButton6_Click(object sender, EventArgs e)
        {
            bufferToMatrix(false, rangeTable4, objCount4);
        }

        private void goButton6_Click(object sender, EventArgs e)
        {
            double[] expertTrust = GetExpertTrust();
            int objCount = Decimal.ToInt32(objCount4.Value);

            ArrayList expertOpinions = arrayListFromMatrix(rangeTable4, objCount4);

            Method method = new PairCompareMethod();

            double efficiency = 0;
            Object result;

            method.Execute(expertsCount, expertTrust, expertOpinions, out efficiency, out result);
            int[] resultRange = result as int[];

            concordResult4.Text = efficiency.ToString();
            rangeToMatrix(rangeResult4, objCount, resultRange);
        }

        private void generateButton6_Click(object sender, EventArgs e)
        {
            rangeProp1 = rangeToMatrix(rangeTable4, objCount4, false);
        }

        /////////////////////////////////// Алгебраїчні методи /////////////////////////////////////
        private void makeButton5_Click(object sender, EventArgs e)
        {
            makeRangeByUser(rangeTable5, objCount5, false);
        }

        private void bufferButton7_Click(object sender, EventArgs e)
        {
            bufferToMatrix(false, rangeTable5, objCount5);
        }

        private void generateButton7_Click(object sender, EventArgs e)
        {
            rangeToMatrix(rangeTable5, objCount5, false);
        }

        private void goButton7_Click(object sender, EventArgs e)
        {
            double[] expertTrust = GetExpertTrust();
            int objCount = Decimal.ToInt32(objCount5.Value);

            ArrayList expertOpinions = arrayListFromMatrix(rangeTable5, objCount5);

            Method method = new AlgebraicMethod();

            double efficiency = 0;
            Object result;

            method.Execute(expertsCount, expertTrust, expertOpinions, out efficiency, out result);

            AlgebraicResult results = result as AlgebraicResult;

            algResult1.RowCount = objCount;
            algResult1.ColumnCount = objCount;
            for (int i = 0; i < objCount; i++)
            {
                algResult1.Columns[i].Width = 20;
                for (int j = 0; j < objCount; j++)
                    algResult1[i, j].Value = results.KemeniSnell[i, j];
            }

            algResult2.RowCount = objCount;
            algResult2.ColumnCount = objCount;
            for (int i = 0; i < objCount; i++)
            {
                algResult2.Columns[i].Width = 20;
                for (int j = 0; j < objCount; j++)
                    algResult2[i, j].Value = results.Middle[i, j];
            }

            algResult3.RowCount = objCount;
            algResult3.ColumnCount = objCount;
            for (int i = 0; i < objCount; i++)
            {
                algResult3.Columns[i].Width = 20;
                for (int j = 0; j < objCount; j++)
                    algResult3[i, j].Value = results.Compromise[i, j];
            }

            rangeToMatrix(KukSaifordResult, objCount, results.KukSaiford);
        }

        private void frmModule_Resize(object sender, EventArgs e)
        {
            methodsTab.Left = 192;
            methodsTab.Height = this.Height;
            methodsTab.Width = this.Width - 190;
        }






    }
}