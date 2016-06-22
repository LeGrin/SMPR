using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    /// <summary>
    /// Контрол для вибору чисел з багатьох проміжків(по одному значенню на проміжок).
    /// </summary>
    public partial class ctrlMultipleRangeSelector : ctrlMethodCallbackBase
    {
        private const int DefaultXLocation = 4;
        private const int StartYLocation = 4;
        private const int DefaultInterval = 4;
        private ICollection<ctrlRangeSelector> _rangeSelectors;

        /// <summary>
        /// Контрол для вибору чисел з багатьох проміжків(по числу на проміжок).
        /// </summary>
        public ctrlMultipleRangeSelector ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// Контрол для вибору чисел з багатьох проміжків(по числу на проміжок).
        /// </summary>
        /// <param name="minimaxes">Границі проміжків</param>
        internal ctrlMultipleRangeSelector ( IEnumerable<MinMaxPair> minimaxes )
            : this ( ) { Init ( minimaxes ); }

        /// <summary>
        /// Ініціалізація контрола
        /// </summary>
        /// <param name="minimaxes">Список пар мін. макс</param>
        internal void Init ( IEnumerable<MinMaxPair> minimaxes )
        {
            _rangeSelectors = new List<ctrlRangeSelector> ( );
            Controls.Clear ( );

            int yLocation = StartYLocation;
            foreach ( MinMaxPair minMax in minimaxes )
            {
                ctrlRangeSelector ctrl = new ctrlRangeSelector ( );
                ctrl.Init ( minMax );
                Controls.Add ( ctrl );
                _rangeSelectors.Add ( ctrl );

                ctrl.Location = new Point ( DefaultXLocation, yLocation );
                yLocation += ctrl.Height + DefaultInterval;
            }
        }
        /// <summary>
        /// Повертає коллекцію вибраних користувачем чисел.
        /// Повертає як IEnumerable, в якому запаковані значення, що повертає контрол ctrlRangeSelecor(на даний момент це double).
        /// </summary>
        public override object Value
        {
            get
            {
                ArrayList result = new ArrayList ( );
                foreach ( ctrlRangeSelector ctrl in _rangeSelectors )
                    result.Add ( ctrl.Value );
                return result;
            }
        }
        /// <summary>
        /// Валідація введених значень
        /// </summary>        
        public override bool IsValid ( )
        {
            bool isValid = true;
            foreach ( ctrlRangeSelector ctrl in _rangeSelectors )
                isValid &= ctrl.IsValid ( );

            return isValid;
        }
    }
}