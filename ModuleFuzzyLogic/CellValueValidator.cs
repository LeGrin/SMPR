using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.ModuleFuzzyLogic
{
    class CellValueValidator
    {
        /// <summary>
        /// Check if value is correct for given cell and return value if it's correct. Throws if value isn't correct
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <param name="value"></param>
        /// <returns> if string is empty (0,0), else parsed value and probability</returns>
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
    }
}
