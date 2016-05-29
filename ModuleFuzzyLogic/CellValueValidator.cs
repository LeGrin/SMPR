using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Modules.ModuleFuzzyLogic
{
    class CellValueValidator
    {
        /// <summary>
        /// Перевірити на коректність дані та отримати розпарсені значення
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="value"></param>
        /// <returns>пару (0, 0), якщо рядок порожній, інакше пару ЧИСЛО і ЗНАЧЕННЯ Ф-Ї НАЛЕЖНОСТІ</returns>
        public static KeyValuePair<double, double> ValidateValue(string value) {
            if (value.Equals(string.Empty)) return new KeyValuePair<double,double>(0,0);

            string[] nums = value.Split(new char[] { '/' });
            if (nums.Length != 2)
                throw new ArgumentException("Рядок повен бути у форматі ЧИСЛО/ЙМОВІРНІСТЬ");
            double val, prob;
            if (!Double.TryParse(nums[0], out val))
                throw new ArgumentException("Перше число повинне бути дійсним");
            if (!(Double.TryParse(nums[1], out prob) 
                && 0<=prob 
                && prob<=1))
                throw new ArgumentException("Друге число повинне бути дійсним числом із [0,1]");
            return new KeyValuePair<double, double>(val, prob);
        }

        /// <summary>
        /// Отримати нечітку множину із контролю
        /// </summary>
        /// <param name="gridView">Дані</param>
        /// <param name="colNum">Номер колонки із множиною</param>
        /// <returns>нечітку множину, або null якщо існують дублікати</returns>
        public static FuzzySets.FuzzySet1D DecipherSet(DataGridView gridView, int colNum) {
            FuzzySets.FuzzySet1D res = new FuzzySets.FuzzySet1D();
            for (int i = 0; i < gridView.Rows.Count; ++i) {
                if (gridView.Rows[i].Cells[colNum].Value == null) continue;
                string strVal = gridView.Rows[i].Cells[colNum].Value.ToString();
                if (strVal.Equals(string.Empty)) continue;

                KeyValuePair<double, double> val = CellValueValidator.ValidateValue(strVal);
                if (res.Dots.ContainsKey(val.Key)) {
                    MessageBox.Show(String.Format("Існують декілька однакових значень! " +
                        "Видаліть всі крім одного із них. Значення {0}, позиція {1}", val.Key, i+1));
                    return null;
                }
                res.AddDot(val.Key, val.Value);
            }
            return res;
        }

         public static void Shuffle<T> (Random rng, T[] array)
         {
             int n = array.Length;
             while (n > 1) 
             {
                 int k = rng.Next(n--);
                 T temp = array[n];
                 array[n] = array[k];
                 array[k] = temp;
             }
         }


        /// <summary>
        /// Створити випадкові множини
        /// </summary>
        /// <param name="dataGrid">Компонента, в яку добавити</param>
        /// <param name="colCount">Кількість множин</param>
         public static void CreateRandomSets(DataGridView dataGrid, int colCount) {
            dataGrid.Rows.Clear();
            dataGrid.Rows.Add(10);
            int[] vals = new int[100];
            for (int j = 0; j < 100; ++j)
                vals[j] = j + 1;

            Random rand = new Random();
            for (int i = 0; i < colCount; ++i) {
                int n = rand.Next(1, 10);
                CellValueValidator.Shuffle<int>(rand, vals);

                for (int j = 0; j < n; ++j) {
                    dataGrid.Rows[j].Cells[i].Value = String.Format("{0}/{1}", 
                        vals[j], Math.Round(rand.NextDouble(), 3));
                }
            }
         }

        /// <summary>
        /// Компаратор для DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SortCompare(object sender,
            DataGridViewSortCompareEventArgs e)
        {
            Predicate<string> isEmpty = (string str) => str.Equals(string.Empty);
            e.Handled = true;
            if (e.CellValue1 == null && e.CellValue2 == null) { e.SortResult = 0; return; }
            if (e.CellValue1 == null) { e.SortResult =  1; return; }
            if (e.CellValue2 == null) { e.SortResult = -1; return; }

            string strVal1 = e.CellValue1.ToString();
            string strVal2 = e.CellValue2.ToString();
            if (isEmpty(strVal1) && isEmpty(strVal2)) { e.SortResult = 0; return; }
            if (isEmpty(strVal1)) { e.SortResult =  1; return; }
            if (isEmpty(strVal2)) { e.SortResult = -1; return; }

            char[] separ = { '/' };
            double v1 = Double.Parse(e.CellValue1.ToString().Split(separ)[0]);
            double v2 = Double.Parse(e.CellValue2.ToString().Split(separ)[0]);
            e.SortResult = v1.CompareTo(v2);
        }

        public static void FromFuzzySetToDataGridView(DataGridView dataGrid, int colNum, FuzzySets.FuzzySet1D set)
        {
            // clear columns values
            foreach (DataGridViewRow row in dataGrid.Rows) {
                row.Cells[colNum].Value = null;
            }
            // add rows if needed
            if (dataGrid.Rows.Count < set.Dots.Count) {
                dataGrid.Rows.Add(set.Dots.Count - dataGrid.Rows.Count);
            }

            int rowCnt = 0;
            foreach (var dot in set.Dots) {
                string val = String.Format("{0}/{1}", dot.Key, dot.Value);
                dataGrid.Rows[rowCnt++].Cells[colNum].Value = val;
            }
        }
    }
}
