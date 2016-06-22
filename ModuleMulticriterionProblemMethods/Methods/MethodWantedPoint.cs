using System;
using System.Collections.Generic;
using System.Text;
using Modules.MulticriterionProblemMethods.DataTypes;
using Common.DataTypes;
using Modules.MulticriterionProblemMethods.View.Controls.MethodCallback;
using System.Collections;
using Modules.MulticriterionProblemMethods.Exceptions.Algorithm;

namespace Modules.MulticriterionProblemMethods.Methods
{
    internal class MethodWantedPoint : Method
    {
        #region Properties

        public override string Name
        {
            get { return Properties.Resources.MethodWantedPointName; }
        }

        #endregion

        #region Fields

        private Vector<int> _f, _h;// f*, h* - vectors.(maximums and minimums). more info in metodichka.
        private Matrix<double> _wk;// Wk(x) - matrix.
        private Vector<double> _wki;// Wki - vector.
        private Vector<double> _ksi;// Ksi - vector. Entered by OPR. hm <= Sim <= fm.
        private Vector<double> _pki;// Pki - vector. Weight coeficients of target functions.
        private int _p;// p. Must be equal count of criteriums.

        #endregion]

        #region Methods

        /// <summary>
        /// Calculates p.
        /// </summary>
        private void calculateP()
        {
            _p = Matrix.CriteriumsCount;
        }
        /// <summary>
        /// Calculates f*(maximumx) and h*(minimums).
        /// </summary>
        private void calculateFandH()
        {
            // Initializing temporary arrays, that will contain data for f* and h*.
            int[] f = new int[_p];
            int[] h = new int[_p];
            for (int i = 0; i < _p; i++)
            {
                f[i] = int.MinValue;
                h[i] = int.MaxValue;
            }
            // Calculating f* and h* data.
            int criteriumIndex = 0;
            foreach (Criterium c in Matrix.Criteriums)
            {
                foreach (Alternative a in Matrix.Alternatives)
                {
                    if (Matrix[a, c] > f[criteriumIndex])
                        f[criteriumIndex] = Matrix[a, c];

                    if (Matrix[a, c] < h[criteriumIndex])
                        h[criteriumIndex] = Matrix[a, c];
                }
                criteriumIndex++;
            }
            // Initializing f* and h*.
            _f = new Vector<int>();
            _f.Value = f;
            _h = new Vector<int>();
            _h.Value = h;
        }
        /// <summary>
        /// Calculates Wk(x)(matrix).
        /// </summary>
        private void calculateWk()
        {
            // Initializing temporary two-dimension array, that will contain data for W(k).
            double[,] wk = new double[Matrix.AlternativesCount, _p];
            // calculating wk data.
            int criteriumIndex = 0;
            foreach (Criterium c in Matrix.Criteriums)
            {
                int alternativeIndex = 0;
                foreach (Alternative a in Matrix.Alternatives)
                {
                    wk[alternativeIndex, criteriumIndex] =                    // wk = 
                        ((double)(_f[criteriumIndex] - Matrix[a, c]))//  (f*[k] - f(x)[k])
                        / (_f[criteriumIndex] - _h[criteriumIndex]);      // / (f*[k] - h*[]).  k є [1,p]
                    alternativeIndex++;
                }
                criteriumIndex++;
            }
            // Initializing Wk
            _wk = new Matrix<double>(wk);
        }
        /// <summary>
        /// Show OPR dialog, and OPR enters ksi (vector).
        /// </summary>
        private void getKsi()
        {
            // Calculating intervals(minimaxes).
            List<MinMaxPair> miniMaxes = new List<MinMaxPair>();
            for (int i = 0; i < _p; i++)
                miniMaxes.Add(new MinMaxPair(_h[i], _f[i]));
            // show user dialog for OPR.
            IEnumerable enteredKsi = (IEnumerable)DoCallback(new ctrlMultipleRangeSelector(miniMaxes),
                false, false, Properties.Resources.ChooseKsi);
            // initializing temporary variables, that will  contain data for Ksi.
            double[] ksi = new double[_p];
            int currIndex = 0;
            foreach (double d in enteredKsi)
            {
                ksi[currIndex] = d;
                currIndex++;
            }
            // Initializing Ksi
            _ksi = new Vector<double>();
            _ksi.Value = ksi;
        }
        /// <summary>
        /// Calculates vectoe Wki.
        /// </summary>
        private void calculateWki()
        {
            // Initializing temporary variables, that will contain data for Wki.
            double[] wki = new double[_p];
            // Calculating data for wki.
            for (int i = 0; i < _p; i++)
            {
                wki[i] = ((double)      // wki = 
                    (_f[i] - _ksi[i]))// ( fk*[k] - ksi[k] )
                    / (_f[i] - _h[i]); //  / (fk*[k] - h*[k]).  k є [1,p]
            }
            // Initializing wki
            _wki = new Vector<double>();
            _wki.Value = wki;
        }
        /// <summary>
        /// Calculates pi (weight coeficients of target functions).
        /// </summary>
        private void calculatePi()
        {
            // Initializing temporary variables, that will be contain data pki.
            double[] pki = new double[_p];
            // Calclating pki data.            
            for (int i = 0; i < _p; i++)
            {
                double d1 = 1;
                // Calculating d1.(d1 = Mult(wki)(except wki[k]))                
                for (int j = 0; j < _p; j++)
                {
                    if (j == i) continue;
                    d1 *= _wki[j];
                }

                double s2 = 0;
                // Calculating s2.(s2 = Sum(d2))                
                for (int j = 0; j < _p; j++)
                {
                    double d2 = 1;
                    // d2 = Mult(wki)(except wki[j])                    
                    for (int l = 0; l < _p; l++)
                    {
                        if (l == j) continue;
                        d2 *= _wki[l];
                    }
                    s2 += d2;
                }
                // pki = d1 / s2
                pki[i] = d1 / s2;
            }
            // Initializing pki
            _pki = new Vector<double>();
            _pki.Value = pki;
        }
        /// <summary>
        /// Resolvs single criterium task.
        /// </summary>
        private Alternative[] resolveSingleCriteriumTask()
        {
            // Some short description for this method:
            // 1.Building n singlecriterium subtasks(n == count of alternatives).
            // 2.Writing result of each subtask to array variable 't'.
            // 3.Index of element in array t, that is minimum will be number of 
            //   effective alternative.
            // Here we go:
            // Initializing data, that will contain result of each subtask.
            double[] t = new double[Matrix.AlternativesCount];
            for (int i = 0; i < Matrix.AlternativesCount; i++)
                t[i] = int.MinValue;
            // 1, 2. Resolving each singlecriterium subtask.
            for (int i = 0; i < Matrix.AlternativesCount; i++)
            {
                // find t for each alternative
                for (int j = 0; j < _p; j++)
                {
                    double a = _pki[j] * _wk[i, j];
                    if (t[i] <= a)
                        t[i] = a;
                }
            }
            //3.Here we have array t, that contain results of each subtask.
            // Lets find the index of item in array t, that is less then other items.
            // This index will be effecitve alternative.            
            double min = double.MaxValue;
            List<int> alternativeIndexes = new List<int>();
            for (int i = 0; i < Matrix.AlternativesCount; i++)
            {
                if (t[i] < min)
                {
                    alternativeIndexes.Clear();
                    min = t[i];
                }
                if (t[i] == min)
                {
                    alternativeIndexes.Add(i);
                }
            }
            // Here we have indexes of effective alternatives.
            // Selecting alternatives by indexes.
            List<Alternative> effectiveAlternatives = new List<Alternative>();
            foreach (int i in alternativeIndexes)
            {
                effectiveAlternatives.Add(Matrix.GetAlternativeByIndex(i));
            }
            // Result!
            return effectiveAlternatives.ToArray();
        }
        /// <summary>
        /// Shows dialog, when user can see effective alternatives and must decide, if it needed to do one more iteration.
        /// </summary>
        /// <param name="alternatives">Effective alternatives.</param>
        /// <returns>True - do one more iteration.</returns>
        private bool askIsOPRAgreeForOneMoreIteration(Alternative[] alternatives)
        {
            // show YesNo dialog
            //return (bool)DoCallback(new ctrlShowAlternativeAndYesNoDialog(alternatives),
                //false, true, "Повторити процедуру для введення нових значень Ksi?");
            return false;
        }

        /// <summary>
        /// Main method of this method :)
        /// Seeks effective alternatives.
        /// </summary>        
        internal override Alternative[] Do()
        {
            Alternative[] effectiveAternatives = new Alternative[] { };
            calculateP();
            calculateFandH();
            calculateWk();
            do
            {
                getKsi();
                calculateWki();
                calculatePi();
                effectiveAternatives = resolveSingleCriteriumTask();
            } while (askIsOPRAgreeForOneMoreIteration(effectiveAternatives));

            return effectiveAternatives;
        }

        #endregion
    }
}