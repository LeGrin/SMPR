using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Clasterization
{
    public partial class MainForm : Form
    {
        public List<Algo.FObject> points;
        bool isClicked = false;
        int X = 0;
        int Y = 0;
        int taxcount = 0;
        bool isTax = false;
        public List<Algo.Taxon> tax_list;
        public MainForm()
        {
            InitializeComponent();
            points = new List<Algo.FObject>();
            tax_list = new List<Algo.Taxon>();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isTax)
            {
                X = e.X;
                Y = e.Y;
                isClicked = true;
                Algo.FObject obj = new Algo.FObject();
                // obj.name = points.Count();
                obj.options = new List<double>();
                obj.name = points.Count;
                obj.options.Add((double)X);
                obj.options.Add((double)Y);

                points.Add(obj);
            }
                pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isTax)
            {
                Pen p = new Pen(Color.Red);
                SolidBrush b = new SolidBrush(Color.Red); 
                foreach (Algo.FObject obj in points)
                {
                    e.Graphics.DrawEllipse(p, new Rectangle((int)obj.options[0], (int)obj.options[1], 3, 3));
                    e.Graphics.FillEllipse(b, new Rectangle((int)obj.options[0], (int)obj.options[1], 3, 3));

                    // e.Graphics.DrawLine(p, new Point(X, Y), new Point(X + 10, Y+10));

                }
            }
            else 
            {
            //Console.WriteLine(tax_list.Count);
                int color_counter = 1;
                
                foreach (Algo.Taxon obj in tax_list)
                {
                    //Console.WriteLine(i);
                    //Random rand = new Random();
                    //Color currtaxoncolor = new Color();
                    //currtaxoncolor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
                    int i = color_counter;
                    i = i % 7;
                    int rd = 255 * (i / 4);
                    i = i % 4;
                    int gr = 255 * (i / 2);
                    i = i % 2;
                    int bl = 255 * i;
                    Color currtaxoncolor = Color.FromArgb(rd, gr, bl);
                    color_counter++;
                    SolidBrush b = new SolidBrush(currtaxoncolor);
                    Pen p = new Pen(currtaxoncolor);
                    obj.Show(e, p, b, points);
                    // e.Graphics.DrawLine(p, new Point(X, Y), new Point(X + 10, Y+10));

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExtendedForm form1 = new ExtendedForm();
            if (form1.ShowDialog() == DialogResult.OK);
            double[][] mass = form1.return_matr();//Algo.Load("1.txt");
            List<Algo.Claster> clast = Algo.Conection_Method(mass, mass.Length, 0, 0.3);
            Reslt reslt1 = new Reslt();
            foreach (Algo.Claster cl in clast)
            {
                cl.Show(reslt1); reslt1.Write("_____________ ");
            }
            reslt1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                ExtendedForm form1 = new ExtendedForm();
            if (form1.ShowDialog() == DialogResult.OK);
            double[][] mass = form1.return_matr();
                //double[][] mass = Algo.Load("1.txt");
                double eps = double.Parse(textBox2.Text);
                List<Algo.Claster> clast = Algo.Conection_Method(mass, mass.Length, 1, eps);

                Reslt reslt1 = new Reslt();
                foreach (Algo.Claster cl in clast)
                {
                    cl.Show(reslt1); reslt1.Write("_____________ ");
                }
                reslt1.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int eps = int.Parse(textBox1.Text);
                if (points.Count != 0)
                {
                    tax_list = Algo.ForelAlgo(points, eps);
                    isTax = true;
                }
                label1.Text = "Кількість кластерів = " + tax_list.Count + "\nКлацніть в будь-якому місці графічного\nредактора для відображення розбиття\nна кластери";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            points = new List<Algo.FObject>();
            isClicked = false;
            X = 0;
            Y = 0;
            taxcount = 0;
            isTax = false;
            label1.Text = "";
            tax_list = new List<Algo.Taxon>();
            Utilities.ResetAllControls(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                int eps = int.Parse(textBox3.Text);
                if (points.Count != 0)
                {
                    tax_list = Algo.KMeansAlgo(points, eps);
                    isTax = true;
                }
                label6.Text = "Клацніть в будь-якому місці графічного\nредактора для відображення розбиття\nна кластери";
            }
        }
  
    }
     
   
}

