using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
//using System.Random;
//using System.Math;
namespace Clasterization
{  
    class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            //Form1 form = new Form1();
            
           /* double[][] mass = Load("1.txt");
            List<Claster> clast = Conection_Method(mass, mass.Length,1,0.7);

            foreach (Claster cl in clast)
            {
                cl.Show(); Console.Write("_____________ ");
            }*/
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());



        }
    }
}
