using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Modules.MulticriterionProblemMethods.Inerfaces;
using Modules.MulticriterionProblemMethods.DataTypes;

namespace Modules.MulticriterionProblemMethods.View.Controls.MethodCallback
{
    /// <summary>
    /// Allows to choosed value from some interva(range).
    /// </summary>
    public partial class ctrlRangeSelector : ctrlMethodCallbackBase
    {
        private double _value;
        private double _numbersAfterDot = 2;

        /// <summary>
        /// Acussary or smt.
        /// </summary>
        public double NumbersAfterDot
        {
            get { return _numbersAfterDot; }
            set { _numbersAfterDot = value; }
        }
        /// <summary>
        /// Allows to choosed value from some interva(range).
        /// </summary>
        public ctrlRangeSelector ( )
        {
            InitializeComponent ( );
        }
        /// <summary>
        /// Returns choosed value.
        /// Returns object, but for real it is double :)
        /// </summary>
        public override object Value
        {
            get
            {
                _value = _parseValueToDouble ( trbValue.Value );
                return _value;
            }
        }
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="parameters">
        /// parameters["Min"]: minValue
        /// parameters["Max"]: maxValue        
        /// </param>        
        internal void Init ( MinMaxPair miniMax )
        {
            trbValue.Maximum = Convert.ToInt32 ( miniMax.Max * Math.Pow ( 10, _numbersAfterDot ) );
            trbValue.Minimum = Convert.ToInt32 ( miniMax.Min * Math.Pow ( 10, _numbersAfterDot ) );
            trbValue.Value = ( trbValue.Minimum + trbValue.Maximum ) / 2;
            lblMax.Text = string.Format ( "H* = {0}", _parseValueToDouble ( trbValue.Maximum ) );
            lblMin.Text = string.Format ( "F* = {0}", _parseValueToDouble ( trbValue.Minimum ) );

            double avgValue = _parseValueToDouble ( ( trbValue.Maximum + trbValue.Minimum ) / 2 );
            lblAvg.Text = string.Format ( "Avg = {0}", avgValue );
            textBox1.Text = avgValue.ToString ( );

            if ( trbValue.Maximum - trbValue.Minimum > 1000 )
                trbValue.TickStyle = TickStyle.None;
            if ( trbValue.Maximum == trbValue.Minimum )
                Enabled = false;
        }
        /// <summary>
        /// Returns true, if all entered values are oK!
        /// </summary>        
        public override bool IsValid ( )
        {
            return double.TryParse ( textBox1.Text, out _value );
        }
        /// <summary>
        /// Returns value of trackbar as double.
        /// </summary>        
        private double _parseValueToDouble ( int value )
        {
            return ( ( double ) value ) / Math.Pow ( 10, _numbersAfterDot );
        }

        private void trbValue_ValueChanged ( object sender, EventArgs e )
        {
            textBox1.Text = _parseValueToDouble ( trbValue.Value ).ToString ( );
        }
        private void btnMinus_Click ( object sender, EventArgs e )
        {
            trbValue.Value = Math.Max ( trbValue.Value - trbValue.LargeChange, trbValue.Minimum );
        }
        private void btnPlus_Click ( object sender, EventArgs e )
        {
            trbValue.Value = Math.Min ( trbValue.Value + trbValue.LargeChange, trbValue.Maximum );
        }
    }
}