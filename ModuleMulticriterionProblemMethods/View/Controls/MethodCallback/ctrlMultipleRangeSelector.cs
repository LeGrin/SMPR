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
    /// ������� ��� ������ ����� � �������� �������(�� ������ �������� �� �������).
    /// </summary>
    public partial class ctrlMultipleRangeSelector : ctrlMethodCallbackBase
    {
        private const int DefaultXLocation = 4;
        private const int StartYLocation = 4;
        private const int DefaultInterval = 4;
        private ICollection<ctrlRangeSelector> _rangeSelectors;

        /// <summary>
        /// ������� ��� ������ ����� � �������� �������(�� ����� �� �������).
        /// </summary>
        public ctrlMultipleRangeSelector ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// ������� ��� ������ ����� � �������� �������(�� ����� �� �������).
        /// </summary>
        /// <param name="minimaxes">������� �������</param>
        internal ctrlMultipleRangeSelector ( IEnumerable<MinMaxPair> minimaxes )
            : this ( ) { Init ( minimaxes ); }

        /// <summary>
        /// ����������� ��������
        /// </summary>
        /// <param name="minimaxes">������ ��� ��. ����</param>
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
        /// ������� ��������� �������� ������������ �����.
        /// ������� �� IEnumerable, � ����� ��������� ��������, �� ������� ������� ctrlRangeSelecor(�� ����� ������ �� double).
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
        /// �������� �������� �������
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