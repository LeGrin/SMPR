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
        /// ��� ���������
        /// </summary>
        string name;
        /// <summary>
        /// ��� ���������
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// �������� �� ��������� ����������
        /// </summary>
        public abstract bool Discrete { get; set;}
        /// <summary>
        /// ����� ������� ���������
        /// </summary>
        public static double fromX=0.0;
        /// <summary>
        /// ������ ������� ���������
        /// </summary>
        public static double toX=10.0;
        /// <summary>
        /// ������������ ���-�� �����, ������� ����� ������.
        /// ���-�� ���-�� �����, ������� �������� � ���� ����������� ���������
        /// </summary>
        public static int maxDotCount=2000;

        public static double xGridStep = 1.0;
        public static double yGridStep = 0.1;
        /// <summary>
        /// ������ ����������� ������������� �������
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public abstract Bitmap Render(Size size);
        /// <summary>
        /// ��������� �������. �������� �����
        /// </summary>
        /// <param name="dgw">������</param>
        public abstract void ToMatrix(DataGridView dgw);
    }
}
