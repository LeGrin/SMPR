using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FuzzySets
{
    public abstract class FuzzySet
    {
        /// <summary>
        /// имя множества
        /// </summary>
        string name;
        /// <summary>
        /// имя множества
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// является ли множество дискретным
        /// </summary>
        public abstract bool Discrete { get; set;}
        /// <summary>
        /// левая граница множества
        /// </summary>
        public static double fromX=0.0;
        /// <summary>
        /// правая граница множества
        /// </summary>
        public static double toX=100.0;
        /// <summary>
        /// Максимальное кол-во точек, которое можно задать.
        /// оно-же кол-во точек, которые содержит в себе непрерывное множество
        /// </summary>
        public static int maxDotCount=2000;

        public static double xGridStep = 1.0;
        public static double yGridStep = 0.1;
        /// <summary>
        /// Рисует графическое представление матрицы
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public abstract Bitmap Render(Size size);
        /// <summary>
        /// Заполняет контрол. матрицей точек
        /// </summary>
        /// <param name="dgw">котрол</param>
        public abstract void ToMatrix(DataGridView dgw);
    }
}
