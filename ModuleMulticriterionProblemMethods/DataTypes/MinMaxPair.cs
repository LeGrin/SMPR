using System;
using System.Collections.Generic;
using System.Text;

namespace Modules.MulticriterionProblemMethods.DataTypes
{
    internal struct MinMaxPair
    {
        private readonly double _min;
        public double Min
        {
            get { return _min; }
        }

        private readonly double _max;
        public double Max
        {
            get { return _max; }
        }

        public MinMaxPair ( double min, double max )
        {
            _min = min;
            _max = max;
        }
    }
}
