using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Clasterization
{
    public class Algo
    {
        public class Claster
        {
            private int _name;
            private int _size;
            private List<Claster> _list;

            public Claster(int n)
            {
                _name = n;
                _list = new List<Claster>();
            }
            public void Add(Claster cl)
            {
                _list.Add(cl);
            }
            public int getName()
            {

                return _name;

            }

            public List<Claster> getValue()
            {


                return _list;

            }

            public void Show(Reslt reslt1)
            {
                //Console.Write("Claster name = " + _name + "\n");
                // Console.Write("Claster name = " + _name + "\n");
                if (_list.Count != 0)
                {
                    reslt1.Write(" " + getName() + " ");
                    reslt1.Write(" ( ");
                    foreach (Claster cl in _list)
                    {
                        cl.Show(reslt1);
                    }
                    reslt1.Write(" ) ");
                }
                else
                {
                    reslt1.Write(" ( ");
                    reslt1.Write(" " + getName() + " ");
                    reslt1.Write(" ) ");
                }
                
            }
        }
        public static bool isequal(double x, double y)
        {

            if (Math.Abs(x - y) < 0.0000001) return true;
            else return false;
        }
        public static double findmax(double[][] mass, int[] isUsed, int size)
        {
            double max = 0;
            for (int i = 0; i < size - 1; ++i)
            {
                for (int j = i + 1; j < size; ++j)
                {
                    if (isUsed[i] != isUsed[j])
                    {
                        if (max < mass[i][j])
                        {
                            max = mass[i][j];
                        }
                    }
                }
            }
            return max;

        }
        public static double findmax(double[][] mass, int[] isUsed, int size, double eps)
        {
            double max = 0;
            for (int i = 0; i < size - 1; ++i)
            {
                for (int j = i + 1; j < size; ++j)
                {
                    if (isUsed[i] != isUsed[j])
                    {
                        if (max < mass[i][j])
                        {
                            max = mass[i][j];
                        }
                    }
                }
            }
            if (max >= eps)
            {
                return max;
            }
            return -1;

        }
        public static List<int> Single(double[][] mass, int[] isUsed, int size)
        {
            double max = findmax(mass, isUsed, size);
            List<int> tmp = new List<int>();
            List<int> list = new List<int>();
            for (int i = 0; i < size - 1; ++i)
            {
                for (int j = i + 1; j < size; ++j)
                {
                    if (isUsed[i] != isUsed[j])
                    {
                        if (isequal(max, mass[i][j]))
                        {
                            if (!list.Contains(i))
                            {
                                if (!tmp.Contains(isUsed[i]))
                                {
                                    tmp.Add(isUsed[i]);
                                    list.Add(i);
                                }
                            }
                            if (!list.Contains(j))
                            {
                                if (!tmp.Contains(isUsed[j]))
                                {
                                    tmp.Add(isUsed[j]);
                                    list.Add(j);
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public static List<int> Full(double[][] mass, int[] isUsed, int size, double eps)
        {
            double max = findmax(mass, isUsed, size, eps);
            List<int> tmp = new List<int>();
            List<int> list = new List<int>();
            if (max != -1)
            {
                for (int i = 0; i < size - 1; ++i)
                {
                    for (int j = i + 1; j < size; ++j)
                    {
                        if (isUsed[i] != isUsed[j])
                        {
                            if (isequal(max, mass[i][j]))
                            {
                                if (!list.Contains(i))
                                {
                                    if (!tmp.Contains(isUsed[i]))
                                    {
                                        tmp.Add(isUsed[i]);
                                        list.Add(i);
                                    }
                                }
                                if (!list.Contains(j))
                                {
                                    if (!tmp.Contains(isUsed[j]))
                                    {
                                        tmp.Add(isUsed[j]);
                                        list.Add(j);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public static int min(List<int> lst)
        {
            int m = 1000000;
            foreach (int i in lst)
            {
                if (i < m)
                {
                    m = i;
                }
            }

            return m;
        }
        public static List<int> hasCommon(int ind, int[] cl)
        {
            List<int> lst = new List<int>();
            for (int i = 0; i < cl.Length; ++i)
            {
                if (cl[ind] == cl[i])
                {
                    lst.Add(i);
                }
            }
            return lst;
        }
        public static List<Claster> Conection_Method(double[][] mass, int size, int type, double eps)
        {
            int[] clast = new int[size];
            bool[] used = new bool[size];
            Claster[] clist = new Claster[size];
            for (int i = 0; i < size; ++i)
            {
                clast[i] = i;
                clist[i] = new Claster(i);
            }
            List<int> pair = new List<int>();
            int k = 0;
            int f = 0;
            List<int> tmp = new List<int>();
            while (f < size)
            {
                if (type == 0)
                {
                    pair = Single(mass, clast, size);
                }
                else if (type == 1)
                {
                    pair = Full(mass, clast, size, eps);
                }
                // f += pair.Count;
                if (pair.Count != 0)
                {
                    k = min(pair);
                    Claster cl = new Claster(-1 * (k + 1));
                    foreach (int e in pair)
                    {
                        if (!used[e]) { used[e] = true; f++; }
                        cl.Add(clist[e]);
                        tmp = hasCommon(e, clast);
                        foreach (int el in tmp)
                        {
                            clist[el] = cl;
                            clast[el] = k;
                        }

                    }
                }
                else
                {
                    f++;
                }
            }
            tmp.Clear();
            List<Claster> claster = new List<Claster>();
            for (int i = 0; i < size; ++i)
            {
                if (!tmp.Contains(clast[i]))
                {
                    tmp.Add(clast[i]);
                    claster.Add(clist[i]);
                }
            }

            return claster;
        }

        /*public static double[][] Load()
        {
            
            
            double[][] mass;
            using (TextReader reader = File.OpenText(file))
            {

                string text = reader.ReadLine();
                string[] bits1 = text.Split(' ');
                int size = int.Parse(bits1[0]);
                mass = new double[size][];
                while ((text = reader.ReadLine()) != null)
                {
                    string[] bits = text.Split(' ');
                    mass[i] = new double[size];
                    for (int j = 0; j < bits.Length; ++j)
                    {
                        mass[i][j] = double.Parse(bits[j]);
                    }
                    i++;
                }

            }
            return mass;
        }*/

        public class FObject
        {
            public int name;
            public List<double> options;
            public bool isEqual(FObject obj)
            {
                for (int i = 0; i < obj.options.Count; ++i)
                {
                    if (obj.options.ElementAt(i) != options.ElementAt(i))
                    {
                        return false;
                    }
                }
                return true;
            }


        }

        /*public static List<FObject> ObjectLoad()
        { 
        
        }*/
        public static double EuclideNorm(FObject ob1, FObject ob2)
        {
            double sol = 0;
            double tmp = 0;
            for (int i = 0; i < ob1.options.Count; ++i)
            {
                tmp = (((ob1.options.ElementAt(i)) - (ob2.options.ElementAt(i))));
                sol = sol + (tmp * tmp);
            }

            return Math.Sqrt(sol);
        }







        public static double getFmax(FObject obj)
        {
            double max = -1 * 10e100;
            foreach (double e in obj.options)
            {
                if (e > max)
                {
                    max = e;
                }
            }
            return max;
        }
        public static double getFmin(FObject obj)
        {
            double min = 10e100;
            foreach (double e in obj.options)
            {
                if (e < min)
                {
                    min = e;
                }
            }
            return min;
        }
        public static FObject getMassCenter(List<FObject> objects, int size)
        {
            FObject sol = new FObject();
            sol.options = new List<double>();
            for (int i = 0; i < size; ++i)
            {
                sol.options.Add(0.0);
            }


            foreach (FObject obj in objects)
            {

                for (int j = 0; j < sol.options.Count; ++j)
                {
                    sol.options[j] += obj.options[j];

                }
            }


            for (int i = 0; i < size; ++i)
            {
                sol.options[i] *= 1.0 / objects.Count;
            }

            return sol;
        }
        public class Taxon
        {
            //public  int mass_center;
            public List<FObject> obj_list;
            public FObject mass_center;
            public void Show(PaintEventArgs e, Pen p, SolidBrush b, List<FObject> points)
            {   //FObject obj1 = obj_list[0];
                //Console.WriteLine(obj_list.Count);
                foreach (FObject obj in obj_list)
                {
                    //e.Graphics.DrawEllipse(p, new Rectangle((int)points[obj.name].options[0], (int)points[obj.name].options[1], 3, 3));
                    //e.Graphics.DrawLine(p, new Point((int)points[obj1.name].options[0], (int)points[obj1.name].options[1]), new Point((int)points[obj.name].options[0], (int)points[obj.name].options[1]));
                    e.Graphics.DrawEllipse(p, new Rectangle((int)points[obj.name].options[0], (int)points[obj.name].options[1], 3, 3));
                    e.Graphics.FillEllipse(b, new Rectangle((int)points[obj.name].options[0], (int)points[obj.name].options[1], 3, 3));

                }
            }
        }

        public static List<FObject> ListCopy(List<FObject> objects)
        {
            List<FObject> list = new List<FObject>();

            foreach (FObject obj in objects)
            {
                list.Add(obj);
            }
            return list;
        }

        public static List<FObject> ListCopyXX(List<FObject> objects)
        {
            List<FObject> list = new List<FObject>();

            foreach (FObject obj in objects)
            {
                FObject obj1 = new FObject();
                obj1.name = obj.name;
                obj1.options = new List<double>();
                foreach (double dl in obj.options)
                {
                    obj1.options.Add(dl);

                }
                list.Add(obj1);
            }
            return list;
        }

        public static void DeleteObjects(List<FObject> tax, List<FObject> objects)
        {
            foreach (FObject obj in tax)
            {
                objects.Remove(obj);
            }
        }
        public static List<Taxon> ForelAlgo(List<FObject> objects, int count)
        {
            double mx = double.MinValue;
            double mn = double.MaxValue;
            List<FObject> tmpobj1 = ListCopyXX(objects);
            // tmpobj = ListCopyXX(objects);
            foreach (FObject obj in tmpobj1)
            {
                double mxx = getFmax(obj);
                double mnx = getFmin(obj);
                if (mxx > mx)
                {
                    mx = getFmax(obj);
                }
                if (mnx < mn)
                {

                    mn = getFmin(obj);
                }
            }
            foreach (FObject obj in tmpobj1)
            {

                int i = 0;
                /*foreach (double tp in obj.options)
                {
                    obj.options[i] = 
                    i++;
                }*/
                for (int ll = 0; ll < obj.options.Count; ++ll)
                {
                    obj.options[ll] = (obj.options[ll] - mn) / (mx - mn);

                }

            }
            List<FObject> tmpobj;
            List<Taxon> tlist = new List<Taxon>();
            int k = 0;
            double R = 0;
            int size = (tmpobj1[0].options.Count);
            R = Math.Sqrt(size) / 2;
            Random rnd = new Random();



            int p = 0;
            while (k < count)
            {
                tmpobj = ListCopy(tmpobj1);
                //k = 0;
                R = R - ((p + 1) * R / 10);
                k = 0;
                tlist.Clear();
                while (tmpobj.Count != 0)
                {
                    List<FObject> tax = new List<FObject>();


                    int c = rnd.Next(0, tmpobj.Count);
                    FObject tm = tmpobj.ElementAt(c);

                    do
                    {
                        foreach (FObject ob in tmpobj)
                        {
                            double en = EuclideNorm(ob, tm);
                            if (en <= R)
                            {
                                tax.Add(ob);
                            }
                        }
                        FObject ms = getMassCenter(tax, tm.options.Count);
                        if (tm.isEqual(ms))
                        {
                            break;
                        }
                        else
                        {
                            tm = ms;
                            tax.Clear();
                        }

                    } while (true);

                    Taxon tx = new Taxon();
                    tx.obj_list = tax;
                    tx.mass_center = tm;
                    tlist.Add(tx);
                    DeleteObjects(tax, tmpobj);
                    k++;
                }
                p += 1;
            }
            return tlist;
        }
        public static void CompactAlgo()
        {

        }

        public static List<Taxon> KMeansAlgo(List<FObject> points, int eps)
        {
            if (eps >= points.Count) {
                List<Taxon> taxlist = new List<Taxon>();
                for (int i = 0; i < points.Count; i++)
                {
                    Taxon tax = new Taxon();
                    tax.obj_list = new List<FObject>();
                    tax.obj_list.Add(points[i]);
                    taxlist.Add(tax);
                }
                return taxlist;
            }//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            int te = 0;
            List<Taxon> tlist = getCenters(points, eps);
            List<Taxon> tlist_old = new List<Taxon>();
            while (true)
            {
                //Console.Write("Iteration # " + te++);
                tlist_old = tlist;
                tlist = getmoddists(points, tlist);
                for (int i = 0; i < tlist.Count; i++) tlist[i].mass_center = getMassCenter(tlist[i].obj_list, 2);
            if (eq(tlist, tlist_old)) break;
            }
            return tlist;

        }

        private static bool eq(List<Taxon> tlist, List<Taxon> tlist_old)
        {
            int counter = 0;
            if ((tlist.Count == 0) || (tlist_old.Count == 0)) return false;
            if (tlist_old.Count != tlist.Count) return false;
            for (int i = 0; i < tlist.Count; i++)
                for (int j = 0; j < tlist.Count; j++)
                    if (tlist[i].mass_center.isEqual(tlist_old[j].mass_center))
                    {
                        counter++;
                        break;
                    }
            if (counter == tlist.Count) return true;
            else return false;
            /*
            bool equ = true;
            for (int i = 0; i < tlist.Count; i++)
                if (!tlist[i].mass_center.isEqual(tlist_old[i].mass_center)) equ = false;
            return equ;*/
        }


        private static List<Taxon> getCenters(List<FObject> points, int eps)
        {
            double[] dists = new double[points.Count];
            int[] centers = new int[eps];
            int startinpos = (new Random()).Next(0, points.Count);
            centers[0] = startinpos;
            
            for (int i = 1; i < eps; i++)
            {
                double sum = 0.0;
                dists = getdists(points, centers, i);
                for (int j = 0; j < dists.Length; j++)
                {
                    if (exists(j, centers, i)) continue;
                    else sum += dists[j];
                }
                double randdist = (new Random()).NextDouble() * sum;
                double distcount = 0.0;
                for (int j = 0; j < dists.Length; j++)
                    if (exists(j, centers, i)) continue;
                    else
                    {
                        distcount += dists[j];
                    if (distcount >= randdist)
                    {
                        centers[i] = j;
                        break;
                    }
            }
            }
            List<Taxon> taxlist = new List<Taxon>();
            for (int i = 0; i < centers.Length; i++)
            {
                Taxon tax = new Taxon();
                tax.mass_center = points[centers[i]];
                taxlist.Add(tax);
            }
            return taxlist;
        }

        private static bool exists(int j, int[] centers, int currnum)
        {
            for (int i = 0; i < currnum; i++)
                if (centers[i] == j) return true;
            return false;

        }

        private static List<Taxon> getmoddists(List<FObject> points, List<Taxon> taxons)
        {
            int[] totax = new int[points.Count];
            double[] dists = new double[points.Count];
            for (int i = 0; i < dists.Length; i++) dists[i] = double.MaxValue;
            for (int i = 0; i < taxons.Count; i++ )
            {
                double x1 = taxons[i].mass_center.options[0];
                double y1 = taxons[i].mass_center.options[1];
                for (int j = 0; j < dists.Length; j++)
                {
                    double x2 = points[j].options[0];
                    double y2 = points[j].options[1];
                    double dist = (x1 - x2) * (x1 - x2) + (y1 - y2) + (y1 - y2);
                    if (dist < dists[j])
                    {
                        dists[j] = dist;
                        totax[j] = i;
                    }
                }
            }
            for (int i = 0; i < taxons.Count; i++) taxons[i].obj_list = new List<FObject>();
            for (int i = 0; i < totax.Length; i++) taxons[totax[i]].obj_list.Add(points[i]);
            return taxons;
        }

        private static double[] getdists(List<FObject> points, int[] centers, int currnum)
        {
            double[] dists = new double[points.Count];
            for (int i = 0; i < dists.Length; i++) dists[i] = double.MaxValue;
                for (int i = 0; i < currnum; i++)
                {
                    double x1 = points[centers[i]].options[0];
                    double y1 = points[centers[i]].options[1];
                    for (int j = 0; j < dists.Length; j++)
                    {
                        double x2 = points[j].options[0];
                        double y2 = points[j].options[1];
                        double dist = (x1 - x2) * (x1 - x2) + (y1 - y2) + (y1 - y2);
                        if (dist < dists[j]) dists[j] = dist;
                    }   
                }
                return dists;
        }
    }
}
