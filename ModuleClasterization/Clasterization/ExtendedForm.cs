using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clasterization
{
    
    public partial class ExtendedForm : Form
    {
        int size = 0;
        double[][] matr; 
        bool set = false;
        public ExtendedForm()
        {
            InitializeComponent();
        }

        public double[][] return_matr(){
        return matr;
        }

        public int return_size()
        {
            return size;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            size = (int)numericUpDown1.Value;
            dataGridView1.RowCount = size;
            dataGridView1.ColumnCount = size;
            for (int i = 0; i < size; i++)
                dataGridView1.Columns[i].Width = 30;
            for (int i = 0; i < size; i++)
                dataGridView1.Rows[i].Height = 30;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matr = new double[size][];
            if (size != 0)
            {
                //ДЕЙСТВИЕ СОХРАНЕНИЯ В МАТРИЦУ

                for (int i = 0; i < size; i++)
                {
                    matr[i] = new double[size];
                    for (int j = 0; j < size; j++)
                    {
                        matr[i][j] = Convert.ToDouble(dataGridView1[i, j].Value);
                    }
                }
                this.Close();
            }
        }
    }
}
