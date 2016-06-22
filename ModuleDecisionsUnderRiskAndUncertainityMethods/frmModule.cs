using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.DecisionsUnderRiskAndUncertainityMethods
{
    public partial class frmModule : Form
    {
        public List<Button> BList;
        public List<Method> methods;
        public Method meth;
        public List<System.Windows.Forms.Control> boxes;

        public frmModule(List<Method> m, Method meth)
        {
            methods = m;
            this.meth = meth;
            BList = new List<Button>();
            InitializeComponent();
            this.GvMatr.Rows.Add();
            this.GVP.Rows.Add();
            Init_Null_Matr();
            #region boxes
            boxes = new List<Control>();
            boxes.Add(this.radioButton1);
            boxes.Add(this.radioButton2);
            boxes.Add(this.checkBox1);
            boxes.Add(this.checkBox2);
            boxes.Add(this.checkBox3);
            boxes.Add(this.checkBox4);
            boxes.Add(this.checkBox5);
            boxes.Add(this.checkBox6);
            boxes.Add(this.checkBox7);
            boxes.Add(this.checkBox8);
            boxes.Add(this.checkBox10);
            #endregion
            if (meth != null)
                if (meth.Match(2))
                    radioButton2.Checked = true;
            GenButtons(true);
        }
        public void GenButtons(bool menuGen)
        {
            int i = 1;
            foreach (Button b in BList)
                panel1.Controls.Remove(b);
            BList.Clear();
            foreach (Method m in methods)
            {
                Method method = m;
                if (menuGen)
                {
                    #region Menu Items Generation
                    ToolStripMenuItem b2 = new ToolStripMenuItem();
                    b2.Text = m.GetName();
                    b2.Tag = method;
                    if (method == meth)
                        b2.Checked = true;
                    b2.Click += delegate(object sender, EventArgs e)
                    {
                        if (b2.Checked)
                        {
                            b2.Checked = false;
                            this.meth = null;
                            GenButtons(false);
                        }
                        else
                        {
                            ToolStripMenuItem ditems = (ToolStripMenuItem)menuStrip1.Items[3];
                            foreach (ToolStripMenuItem it in ditems.DropDownItems)
                                it.Checked = false;
                            b2.Checked = true;
                            this.meth = (Method)b2.Tag;
                            if (meth != null)
                            {
                                if (meth.Match(2))
                                    radioButton2.Checked = true;
                                else
                                    radioButton1.Checked = true;
                            }
                            for (int eee = 2; eee < 11; eee++)
                            {
                                ((CheckBox)boxes[eee]).Checked = false;
                            }
                            GenButtons(false);
                        }
                    };
                    ToolStripMenuItem item = (ToolStripMenuItem)menuStrip1.Items[3];
                    item.DropDownItems.Add(b2);
                    #endregion
                }
                if (m.Match(critCalc()))
                {
                    #region Button Generation
                    Button b1 = new Button();
                    //if (method == meth)
                    //{
                    //    b1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                    //}
                    b1.Top = 15 * i;
                    i += 2;
                    b1.Left = 10;
                    b1.Width = panel1.Width - 20;
                    b1.Text = m.GetName();
                    b1.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    b1.Click += delegate(Object s, EventArgs ea)
                    {
                        if (checkBox9.Checked)
                        {
                            TestDialog dlg = new TestDialog(method);
                            dlg.setMethod(this);
                            dlg.ShowDialog();
                        }
                        else
                        {
                            double[,] mat = new double[GvMatr.RowCount, GvMatr.ColumnCount];
                            double[] prob = new double[GVP.ColumnCount];
                            double alfa, a;
                            foreach (DataGridViewRow row in GvMatr.Rows)
                                foreach (DataGridViewCell c in row.Cells)
                                {
                                    mat[c.RowIndex, c.ColumnIndex] = System.Double.Parse(c.Value.ToString());
                                }
                            NormProb();
                            foreach (DataGridViewRow row in GVP.Rows)
                                foreach (DataGridViewCell c in row.Cells)
                                {
                                    prob[c.ColumnIndex] = System.Double.Parse(c.Value.ToString());
                                }
                            try
                            {
                                alfa = System.Double.Parse(textBox1.Text);
                            }
                            catch (FormatException)
                            {
                                alfa = 0;
                            }
                            try
                            {
                                a = System.Double.Parse(textBox2.Text);
                            }
                            catch (FormatException)
                            {
                                a = matrMin();
                            }
                            method.Init(mat, prob, alfa, a);
                            int result = method.RunMethod();
                            label5.Text = (result + 1).ToString();
                            Font f = new Font(radioButton1.Font, System.Drawing.FontStyle.Bold);
                            label5.Font = f;
                            for (int j = 0; j < GvMatr.Rows.Count; ++j)
                                GvMatr.Rows[j].DefaultCellStyle.BackColor = GvMatr.Rows[j].DefaultCellStyle.SelectionBackColor
                                    = (j == result) ? Color.Yellow : Color.White;
                            GvMatr[0, result].Selected = true;
                            GvMatr.CurrentCell = GvMatr[0, result];
                        }
                    };
                    b1.MouseMove += delegate(Object sender, MouseEventArgs e)
                    {
                        Font f = new Font(radioButton1.Font, System.Drawing.FontStyle.Bold);
                        for (int j = 0; j < 11; j++)
                            if (method.Match((int)Math.Pow(2, j))) boxes[j].Font = f;
                    };
                    b1.MouseLeave += delegate(Object sender, EventArgs e)
                    {
                        Font f = new Font(radioButton1.Font, System.Drawing.FontStyle.Regular);
                        foreach (Control c in boxes)
                        {
                            c.Font = f;
                        }
                    };
                    panel1.Controls.Add(b1);
                    BList.Add(b1);
                    #endregion
                }
            }
        }
        private void frmModule_Resize(object sender, EventArgs e)
        {
            GvMatr.Width = this.Width - 565;
            GVP.Width = this.Width;// - 565;
            label1.Left = this.Width - 565 - 138;
            label2.Left = this.Width - 565 - 138;
            trackBar1.Width = this.Width - 565 - 150;
            trackBar2.Width = this.Width - 565 - 150;
            foreach (DataGridViewColumn col in GvMatr.Columns)
            {
                col.Width = (GvMatr.Width - 10) / GvMatr.ColumnCount;
            }
            foreach (DataGridViewColumn col in GVP.Columns)
            {
                col.Width = (GVP.Width - 10) / GVP.ColumnCount;
            }
            GvMatr.Height = this.Height - 230;
            GVP.Top = this.Height - 70;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = (trackBar1.Value + 1).ToString();
            while (GvMatr.ColumnCount < trackBar1.Value + 1)
            {
                DataGridViewColumn col = new DataGridViewColumn(GvMatr.Columns[0].CellTemplate);
                GvMatr.Columns.Add(col);
            }
            while (GvMatr.ColumnCount > trackBar1.Value + 1)
                GvMatr.Columns.RemoveAt(GvMatr.ColumnCount - 1);
            foreach (DataGridViewColumn col in GvMatr.Columns)
            {
                col.Width = (GvMatr.Width - 10) / GvMatr.ColumnCount;
            }
            while (GVP.ColumnCount < trackBar1.Value + 1)
            {
                DataGridViewColumn col = new DataGridViewColumn(GVP.Columns[0].CellTemplate);
                GVP.Columns.Add(col);
            }
            while (GVP.ColumnCount > trackBar1.Value + 1)
                GVP.Columns.RemoveAt(GvMatr.ColumnCount - 1);
            foreach (DataGridViewColumn col in GVP.Columns)
            {
                col.Width = (GVP.Width - 10) / GvMatr.ColumnCount;
            }
            Init_Null_Matr();
            randomizeProbabilities();
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = (trackBar2.Value + 1).ToString();
            while (GvMatr.RowCount < trackBar2.Value + 1)
            {
                GvMatr.Rows.Add();
            }
            while (GvMatr.RowCount > trackBar2.Value + 1)
                GvMatr.Rows.RemoveAt(GvMatr.RowCount - 1);
            Init_Null_Matr();
            randomizeProbabilities();
        }
        private void Init_Null_Matr()
        {
            foreach (DataGridViewRow row in GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (!(c.Value is Int32))
                        c.Value = 0;
                }
            foreach (DataGridViewRow row in GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (!(c.Value is double))
                        c.Value = 1.0;
                }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            GenButtons(false);
            this.label5.Text = "";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                GVP.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button7.Visible = false;
                label8.Visible = false;
                menuStrip1.Items[2].Enabled = false;
            }
            GenButtons(false);
            this.label5.Text = "";

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                GVP.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label8.Visible = true;
                menuStrip1.Items[2].Enabled = true;
                randomizeProbabilities();
            }
            GenButtons(false);
            this.label5.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            BufferData t = Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegate);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали матрицю");
            else
                InputMatr(t);
        }
        private void InputMatr(BufferData buff)
        {
            if (buff is Matrix<double>)
            {
                Matrix<double> t = (Matrix<double>)buff;
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (t.Value[c.ColumnIndex, c.RowIndex] < Double.Parse(minv.Text) || t.Value[c.ColumnIndex, c.RowIndex] > Double.Parse(maxv.Text))
                        {
                            MessageBox.Show("Невідповідність данних: " + t.Value[c.ColumnIndex, c.RowIndex]);
                            return;
                        }
                    }
            }
            if (buff is Matrix<int>)
            {
                Matrix<int> t = (Matrix<int>)buff;
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (t.Value[c.ColumnIndex, c.RowIndex] < Int32.Parse(minv.Text) || t.Value[c.ColumnIndex, c.RowIndex] > Int32.Parse(maxv.Text))
                        {
                            MessageBox.Show("Невідповідність данних: " + t.Value[c.ColumnIndex, c.RowIndex]);
                            return;
                        }
                    }
            }
            if (buff is Matrix<long>)
            {
                Matrix<long> t = (Matrix<long>)buff;
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (t.Value[c.ColumnIndex, c.RowIndex] < Double.Parse(minv.Text) || t.Value[c.ColumnIndex, c.RowIndex] > Int32.Parse(maxv.Text))
                        {
                            MessageBox.Show("Невідповідність данних: " + t.Value[c.ColumnIndex, c.RowIndex]);
                            return;
                        }
                    }
            }



            if (buff is Matrix<double>)
            {
                Matrix<double> t = (Matrix<double>)buff;
                trackBar1.Value = t.Value.GetLength(0) - 1;
                EventArgs e = new EventArgs();
                trackBar1_Scroll(this, e);
                trackBar2.Value = t.Value.GetLength(1) - 1;
                trackBar2_Scroll(this, e);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Value = t.Value[c.ColumnIndex, c.RowIndex];
                    }
            }
            if (buff is Matrix<int>)
            {
                Matrix<int> t = (Matrix<int>)buff;
                trackBar1.Value = t.Value.GetLength(0) - 1;
                EventArgs e = new EventArgs();
                trackBar1_Scroll(this, e);
                trackBar2.Value = t.Value.GetLength(1) - 1;
                trackBar2_Scroll(this, e);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Value = t.Value[c.RowIndex, c.ColumnIndex];
                    }
            }
            if (buff is Matrix<long>)
            {
                Matrix<long> t = (Matrix<long>)buff;
                trackBar1.Value = t.Value.GetLength(0) - 1;
                EventArgs e = new EventArgs();
                trackBar1_Scroll(this, e);
                trackBar2.Value = t.Value.GetLength(1) - 1;
                trackBar2_Scroll(this, e);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Value = t.Value[c.RowIndex, c.ColumnIndex];
                    }
            }
        }
        public bool ValidationCallbackDelegate(BufferData obj)
        {
            if (obj is Matrix<int>)
            {
                Matrix<int> matr = (Matrix<int>)obj;
                if (matr.Value.GetLength(0) > 10)
                    return false;
                else if (matr.Value.GetLength(1) > 10)
                    return false;
                else
                {
                    bool pos = true;
                    for (int i = 0; i < matr.Value.GetLength(0); i++)
                        for (int j = 0; j < matr.Value.GetLength(1); j++)
                            if (matr.Value[i, j] < 0) pos = false;
                    return pos;
                }
            }
            if (obj is Matrix<long>)
            {
                Matrix<long> matr = (Matrix<long>)obj;
                if (matr.Value.GetLength(0) > 10)
                    return false;
                else if (matr.Value.GetLength(1) > 10)
                    return false;
                else
                {
                    bool pos = true;
                    for (int i = 0; i < matr.Value.GetLength(0); i++)
                        for (int j = 0; j < matr.Value.GetLength(1); j++)
                            if (matr.Value[i, j] < 0) pos = false;
                    return pos;
                }
            }
            if (obj is Matrix<double>)
            {
                Matrix<double> matr = (Matrix<double>)obj;
                if (matr.Value.GetLength(0) > 10)
                    return false;
                else if (matr.Value.GetLength(1) > 10)
                    return false;
                else
                {
                    bool pos = true;
                    for (int i = 0; i < matr.Value.GetLength(0); i++)
                        for (int j = 0; j < matr.Value.GetLength(1); j++)
                            if (matr.Value[i, j] < 0) pos = false;
                    return pos;
                }
            }
            else
                return false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < GvMatr.Rows.Count; ++j)
                GvMatr.Rows[j].DefaultCellStyle.BackColor = GvMatr.Rows[j].DefaultCellStyle.SelectionBackColor
                    = Color.White;
            System.Random r = new Random();
            foreach (DataGridViewRow row in GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Value = Int32.Parse(minv.Text) + r.Next(Int32.Parse(maxv.Text) - Int32.Parse(minv.Text));
                }
        }
        public void NormProb()
        {
            double p = 0;
            int i = 0;
            foreach (DataGridViewRow row in GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    p += round100(System.Double.Parse(c.Value.ToString()));
                    i++;
                }
            if (p == 0)
                foreach (DataGridViewRow row in GVP.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Value = round100((1.0 / i)).ToString();
                    }
            else
                foreach (DataGridViewRow row in GVP.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        c.Value = round100((System.Double.Parse(c.Value.ToString()) / p)).ToString();
                    }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            randomizeProbabilities();
        }

        private double round100(double a)
        {
            return ((int)(a * 100 + 0.5)) / 100.0;
        }

        private void randomizeProbabilities()
        {
            Random r = new Random();
            foreach (DataGridViewRow row in GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Value = round100(r.NextDouble());
                }
            NormProb();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Vector<double> t = (Vector<double>)Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegateP);
            if (t == null)
                MessageBox.Show("Ви неправильно обрали вектор");
            else
                InputVect(t);

        }
        private void InputVect(Vector<double> buff)
        {
            foreach (DataGridViewRow row in GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Value = buff.Value[c.ColumnIndex];
                }

        }
        public bool ValidationCallbackDelegateP(BufferData obj)
        {
            if (obj is Vector<double>)
            {
                Vector<double> vect = (Vector<double>)obj;
                if (vect.Value.Length != trackBar1.Value + 1)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public int critCalc()
        {
            int i;
            i = 0;
            if (radioButton1.Checked) i += 1;
            if (radioButton2.Checked) i += 2;
            if (checkBox1.Checked) i += 4;
            if (checkBox2.Checked) i += 8;
            if (checkBox3.Checked) i += 16;
            if (checkBox4.Checked) i += 32;
            if (checkBox5.Checked) i += 64;
            if (checkBox6.Checked) i += 128;
            if (checkBox7.Checked) i += 256;
            if (checkBox8.Checked) i += 512;
            if (checkBox10.Checked) i += 1024;
            return i;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            double[,] mat = new double[GvMatr.ColumnCount, GvMatr.RowCount];
            foreach (DataGridViewRow row in GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    mat[c.ColumnIndex, c.RowIndex] = System.Double.Parse(c.Value.ToString());
                }
            Matrix<double> m = new Matrix<double>(mat);
            Common.DataBuffer.Instance.SaveDialog(m);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            double[] prob = new double[GVP.ColumnCount];
            foreach (DataGridViewRow row in GVP.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    prob[c.ColumnIndex] = System.Double.Parse(c.Value.ToString());
                }
            Vector<double> vect = new Vector<double>(prob);
            Common.DataBuffer.Instance.SaveDialog(vect);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (label5.Text != " ")
            {
                Scalar<int> s = new Scalar<int>(System.Int32.Parse(label5.Text));
                Common.DataBuffer.Instance.Save("Альтернатива", s);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double i = System.Double.Parse(textBox1.Text);
                if (i < 0 || i > 1)
                    textBox1.Text = "0";
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    textBox1.Text = "";
            }
        }
        private double matrMax()
        {
            double i = 0;
            foreach (DataGridViewRow row in GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (System.Double.Parse(c.Value.ToString()) > i) i = System.Double.Parse(c.Value.ToString());
                }
            return i;
        }
        public double matrMin()
        {
            double i = Double.MaxValue;
            foreach (DataGridViewRow row in GvMatr.Rows)
                foreach (DataGridViewCell c in row.Cells)
                {
                    if (System.Double.Parse(c.Value.ToString()) < i) i = System.Double.Parse(c.Value.ToString());
                }
            return i;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double i = System.Double.Parse(textBox2.Text);
                if (i < matrMin() || i > matrMax())
                    textBox2.Text = matrMax().ToString();
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                    textBox1.Text = "";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Scalar<double> s = (Scalar<double>)Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegateAlfa);
            if (s != null)
                textBox1.Text = s.Value.ToString();
            else
                MessageBox.Show("Невірне Альфа");
        }
        public bool ValidationCallbackDelegateAlfa(BufferData obj)
        {
            if (obj is Scalar<double>)
            {
                Scalar<double> s = (Scalar<double>)obj;
                if (s.Value < 0 || s.Value > 1)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        public bool ValidationCallbackDelegateA(BufferData obj)
        {
            if (obj is Scalar<double>)
            {
                Scalar<double> s = (Scalar<double>)obj;
                if (s.Value < matrMin() || s.Value > matrMax())
                    return false;
                else
                    return true;
            }
            if (obj is Scalar<int>)
            {
                Scalar<int> s = (Scalar<int>)obj;
                if (s.Value < matrMin() || s.Value > matrMax())
                    return false;
                else
                    return true;
            }
            if (obj is Scalar<long>)
            {
                Scalar<long> s = (Scalar<long>)obj;
                if (s.Value < matrMin() || s.Value > matrMax())
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            BufferData obj = Common.DataBuffer.Instance.LoadDialog(ValidationCallbackDelegateA);
            if (obj != null)
            {
                if (obj is Scalar<double>)
                {
                    Scalar<double> s = (Scalar<double>)obj;
                    textBox2.Text = s.Value.ToString();
                }
                if (obj is Scalar<int>)
                {
                    Scalar<int> s = (Scalar<int>)obj;
                    textBox2.Text = s.Value.ToString();
                }
                if (obj is Scalar<long>)
                {
                    Scalar<long> s = (Scalar<long>)obj;
                    textBox2.Text = s.Value.ToString();
                }
            }
            else
                MessageBox.Show("Невірне А");
        }
        private void GVP_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GVP.Rows[e.RowIndex];
                DataGridViewCell c = row.Cells[e.ColumnIndex];
                try
                {
                    double i = System.Double.Parse(e.FormattedValue.ToString());
                    e.Cancel = false;
                    if (i < 0)
                    {
                        MessageBox.Show(String.Format("Неправильно введено елемент матриці {0}", e.ColumnIndex + 1));
                        e.Cancel = true;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show(String.Format("Неправильно введено елемент матриці {0}", e.ColumnIndex + 1));
                    e.Cancel = true;
                }
            }
        }
        private void GvMatr_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GvMatr.Rows[e.RowIndex];
                DataGridViewCell c = row.Cells[e.ColumnIndex];
                try
                {
                    double i = System.Double.Parse(e.FormattedValue.ToString());
                    e.Cancel = false;
                    if (i < 0)
                    {
                        MessageBox.Show(String.Format("Неправильно введено елемент матриці[{0},{1}]", e.RowIndex + 1, e.ColumnIndex + 1));
                        e.Cancel = true;
                    }

                }
                catch (FormatException)
                {
                    MessageBox.Show(String.Format("Неправильно введено елемент матриці[{0},{1}]", e.RowIndex + 1, e.ColumnIndex + 1));
                    e.Cancel = true;
                }
            }


        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int max = 0;
            foreach (Method m in methods)
            {
                if (m.Match(critCalc()))
                {
                    max++;
                    TestDialog dlg = new TestDialog(m);
                    dlg.setMethod(this);
                    dlg.ShowDialog();
                    if (dlg.getResult() == true) count++;

                }
            }

            MessageBox.Show(Properties.Resources.YourResult + count + Properties.Resources.of + max);
        }

        private void minv_Leave(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                double t = Double.Parse(minv.Text);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (System.Double.Parse(c.Value.ToString()) < t)
                        {
                            s += c.Value.ToString() + "; ";
                        }
                    }
                if (s != "")
                {
                    MessageBox.Show("Невірні значення: " + s);
                    minv.Text = min_v.ToString();
                }
            }
            catch (Exception exc)
            {
                minv.Text = min_v.ToString();
                MessageBox.Show("Не розпізнано мінімальне значення!");
            }
        }

        private void maxv_Leave(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                double t = Double.Parse(maxv.Text);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (System.Double.Parse(c.Value.ToString()) > t)
                        {
                            s += c.Value.ToString() + "; ";
                        }
                    }
                if (s != "")
                {
                    MessageBox.Show("Невірні значення: " + s);
                    maxv.Text = max_v.ToString();
                }
            }
            catch (Exception exc)
            {
                maxv.Text = max_v.ToString();
                MessageBox.Show("Не розпізнано максимальне значення!");
            }
        }


        double min_v = 0, max_v = 200;
        private void minv_Enter(object sender, EventArgs e)
        {
            min_v = Double.Parse(minv.Text);
        }
        private void maxv_Enter(object sender, EventArgs e)
        {
            max_v = Double.Parse(maxv.Text);
        }

        private void GvMatr_Leave(object sender, EventArgs e)
        {
            string s = "";        
            try
            {

                double t = Double.Parse(maxv.Text);
                foreach (DataGridViewRow row in GvMatr.Rows)
                    foreach (DataGridViewCell c in row.Cells)
                    {
                        if (System.Double.Parse(c.Value.ToString()) > t)
                        {
                            s += c.Value.ToString() + "; ";
                        }
                    }
                if (s != "")
                {
                    MessageBox.Show("Невірні значення: " + s);
                    maxv.Text = max_v.ToString();
                }
            }
            catch(Exception exc)
            {
            }
        }
    }
}