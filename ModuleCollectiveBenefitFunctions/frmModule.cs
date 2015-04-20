using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.CollectiveBenefitFunctions
{
    public delegate void LoadDataDelegate();
    public delegate void SaveDataDelegate(Vector<int> v1, Vector<int> v2);

    partial class frmModule : Form
    {
        public event EventHandler DataCalculate;
        public event LoadDataDelegate DataLoad;
        public event SaveDataDelegate DataSave;
        
        int iMemberCount;
        ArrayList TB = new ArrayList();
        ArrayList LB = new ArrayList();
        ArrayList TB1 = new ArrayList();
        ArrayList LB1 = new ArrayList();

        int cx = 10;
        int iCount;

        public frmModule(List<Method> methods, Method method)
        {
            InitializeComponent();

            cbFunctions.DataSource = methods;

            if (method != null)
            {
                cbFunctions.SelectedItem = method;
            }

        }

        private void UD_Members_ValueChanged(object sender, EventArgs e)
        {
            iCount = (int)UD_Members.Value;
            if (iCount < iMemberCount)
            {
                for (int i = TB.Count - 1; i >= iCount; --i)
                {
                    cx = ((TextBox)TB[i]).Left;
                    ((TextBox)TB[i]).Dispose();
                    TB.RemoveAt(i);
                    ((Label)LB[i]).Dispose();
                    LB.RemoveAt(i);

                    if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName && 
                        TB1.Count != 0)
                    {
                        ((TextBox)TB1[i]).Dispose();
                        TB1.RemoveAt(i);
                        ((Label)LB1[i]).Dispose();
                        LB1.RemoveAt(i);
                    }
                }
            }
            else if (iCount > iMemberCount)
            {
                CreateMembers();
            }
            iMemberCount = iCount;
        }

        public void SetData(Vector<int> vector1, Vector<int> vector2)
        {
            UD_Members.Value = iMemberCount = iCount = vector1.Value.Length;
            iCount = 1;
            tb_Q.Text = "0";
            tb_P.Text = "0";
            cx = 5;
            lb_WPU.Text = lb_WPU.Text.Substring(0, 8);
            lb_WqU.Text = lb_WqU.Text.Substring(0, 10);
            lb_WnU.Text = lb_WnU.Text.Substring(0, 8);
            lb_W0U.Text = lb_W0U.Text.Substring(0, 8);
            lb_WoU.Text = lb_WoU.Text.Substring(0, 10);
            lb_JqU.Text = lb_JqU.Text.Substring(0, 8);
            lb_JoU.Text = lb_JoU.Text.Substring(0, 8);
            lb_GU.Text = lb_GU.Text.Substring(0, 7);

            for (int i = TB.Count - 1; i >= 0; --i)
            {
                ((TextBox)TB[i]).Dispose();
                TB.RemoveAt(i);
                ((Label)LB[i]).Dispose();
                LB.RemoveAt(i);

                if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName && TB1.Count != 0)
                {
                    ((TextBox)TB1[i]).Dispose();
                    TB1.RemoveAt(i);
                    ((Label)LB1[i]).Dispose();
                    LB1.RemoveAt(i);
                }
            }

            for (iCount = 0; iCount < iMemberCount + 1; ++iCount)
            {
                CreateMembers();
                ((TextBox)TB[iCount - 1]).Text = vector1.Value[iCount - 1].ToString();
                if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName)
                    ((TextBox)TB1[iCount - 1]).Text = vector2.Value[iCount - 1].ToString();
            }
        }

        public bool GetPigu()
        {
            return (cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName;
        }

        private void CreateMembers()
        {
            Label lb = new Label();
            lb.Parent = panel1;
            lb.AutoSize = true;
            lb.Left = cx;
            lb.Top = 0;
            lb.Text = "Член" + iCount;
            LB.Add(lb);

            TextBox tb = new TextBox();
            tb.Parent = panel1;
            tb.Width = lb.Width;
            tb.Left = cx;
            tb.Top = 15;
            tb.Text = "0";
            TB.Add(tb);

            if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName)
            {
                Label lb1 = new Label();
                lb1.Parent = panel1;
                lb1.AutoSize = true;
                lb1.Left = cx;
                lb1.Top = 40;
                lb1.Text = "Член" + iCount;
                LB1.Add(lb1);

                TextBox tb1 = new TextBox();
                tb1.Parent = panel1;
                tb1.Width = lb.Width;
                tb1.Left = cx;
                tb1.Top = 55;
                tb1.Text = "0";
                TB1.Add(tb1);
            }

            cx = lb.Left + lb.Width + 3;
        }

        private void bnResult_Click(object sender, EventArgs e)
        {
            if (DataCalculate != null) DataCalculate(this, new EventArgs());
            else MessageBox.Show("Нема прив'язки event'a головної форми DataCalculate !!!",
                    "Помилка події", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool HasData()
        {
            if (UD_Members.Value == 0)
                return false;
            return true;
        }

        public Method GetMethod()
        {
            return cbFunctions.SelectedItem as Method;
        }

        public Data GetData()
        {
            int[] iArr1 = new int[TB.Count];
            int[] iArr2 = null;

            for (int i = 0; i < TB.Count; ++i)
                iArr1[i] = Convert.ToInt32(((TextBox)TB[i]).Text);

            if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName)
            {
                iArr2 = new int[TB1.Count];
                for (int i = 0; i < TB1.Count; ++i)
                    iArr2[i] = Convert.ToInt32(((TextBox)TB1[i]).Text);
            }

            Data data = new Data();
            data.SetData(new Vector<int>(iArr1), new Vector<int>(iArr2),
                         new Scalar<double>(Convert.ToDouble(tb_Q.Text)),
                         new Scalar<double>(Convert.ToDouble(tb_P.Text)),
                         LB1.Count);
            return data;
        }

        public void ShowResult(Scalar<double>[] result)
        {
            if (result != null)
            {
                switch ((cbFunctions.SelectedItem as Method).Name)
                {
                    case "Метод Функцій колективної корисності":
                        lb_WPU.Text = lb_WPU.Text.Substring(0, 8) + string.Format("{0:F3}", result[0].Value);
                        lb_WqU.Text = lb_WqU.Text.Substring(0, 10) + string.Format("{0:F3}", result[1].Value);
                        lb_W0U.Text = lb_W0U.Text.Substring(0, 8) + string.Format("{0:F3}", result[2].Value);
                        lb_WoU.Text = lb_WoU.Text.Substring(0, 10) + string.Format("{0:F3}", result[3].Value);
                        break;
                    case "Метод ФКК Неша":
                        lb_WnU.Text = lb_WnU.Text.Substring(0, 8) + string.Format("{0:F3}", result[0].Value);
                        break;
                    case "Метод Індексів Аткенсона":
                        lb_JqU.Text = lb_JqU.Text.Substring(0, 8) + string.Format("{0:F3}", result[0].Value);
                        lb_JoU.Text = lb_JoU.Text.Substring(0, 8) + string.Format("{0:F3}", result[1].Value);
                        break;
                    case "Метод Індекса Джині":
                        lb_GU.Text = lb_GU.Text.Substring(0, 7) + string.Format("{0:F3}", result[0].Value);
                        break;
                    case "Принцип передачі Пігу-Дальтона":
                        if (result[0] != 0)
                            lbDalton.Text = "Принцип Пігу-Дальтона виконується";
                        else
                            lbDalton.Text = "Принцип Пігу-Дальтона не виконується";
                            break;
                }
            }
        }

        private void cbFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName)
            {
                foreach (Label l in LB)
                    l.Dispose();
                foreach (TextBox tb in TB)
                    tb.Dispose();

                cx = 5;
                iMemberCount = 0;
                UD_Members.Value = 0;
            }

            foreach (Label l in LB1)
                l.Dispose();
            foreach (TextBox tb in TB1)
                tb.Dispose();

            switch ((cbFunctions.SelectedItem as Method).Name)
            {
                case "Метод Функцій колективної корисності":
                    gbFKK.Visible = true;
                    lb_WPU.Visible = true;
                    lb_W0U.Visible = true;
                    lb_WqU.Visible = true;
                    lb_WoU.Visible = true;
                    label7.Visible = true;
                    label12.Visible = true;

                    lbNesh.Visible = false;
                    lb_WnU.Visible = false;
                    lb_WnU.Visible = false;
                    gbIND.Visible = false;
                    groupBox1.Visible = false;
                    break;
                case "Метод ФКК Неша":
                    gbFKK.Visible = true;
                    lb_WnU.Visible = true;
                    lbNesh.Visible = true;

                    lb_WPU.Visible = false;
                    lb_W0U.Visible = false;
                    lb_WqU.Visible = false;
                    lb_WoU.Visible = false;
                    label7.Visible = false;
                    label12.Visible = false;
                    gbIND.Visible = false;
                    groupBox1.Visible = false;
                    break;
                case "Метод Індексів Аткенсона":
                    gbIND.Visible = true;
                    lbAtkinson.Visible = true;
                    lb_JqU.Visible = true;
                    lb_JoU.Visible = true;

                    gbFKK.Visible = false;
                    groupBox1.Visible = false;
                    lb_GU.Visible = false;
                    lbDjini.Visible = false;
                    lbDalton.Visible = false;
                    break;
                case "Метод Індекса Джині":
                    gbIND.Visible = true;
                    lb_GU.Visible = true;
                    lbDjini.Visible = true;

                    lbAtkinson.Visible = false;
                    lb_JqU.Visible = false;
                    lb_JoU.Visible = false;
                    gbFKK.Visible = false;
                    groupBox1.Visible = false;
                    break;
                case "Принцип передачі Пігу-Дальтона":
                    groupBox1.Visible = true;

                    gbFKK.Visible = false;
                    gbIND.Visible = false;
                    break;
            }
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            int[] iArr1 = new int[TB.Count];
            int[] iArr2 = new int[TB1.Count];

            for (int i = 0; i < TB.Count; ++i)
                iArr1[i] = Convert.ToInt32(((TextBox)TB[i]).Text);

            if ((cbFunctions.SelectedItem as Method).Name == Properties.Resources.PiguMethodName)
            {
                for (int i = 0; i < TB1.Count; ++i)
                    iArr2[i] = Convert.ToInt32(((TextBox)TB1[i]).Text);

                if (DataSave != null) DataSave(new Vector<int>(iArr1), new Vector<int>(iArr2));
                else MessageBox.Show("Нема прив'язки event'a головної форми DataLoad !!!",
                    "Помилка події", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (DataSave != null) DataSave(new Vector<int>(iArr1), null);
            else MessageBox.Show("Нема прив'язки event'a головної форми DataLoad !!!",
                "Помилка події", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (DataLoad != null) DataLoad();
            else MessageBox.Show("Нема прив'язки event'a головної форми DataLoad !!!",
                    "Помилка події", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}