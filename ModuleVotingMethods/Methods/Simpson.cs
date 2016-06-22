using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    class Simpson : Method
    {
        private static string exText = Properties.Resources.methodSimpsonException;
        public override string Name
        {
            get { return Properties.Resources.MethodSimpson; }
        }

        public Simpson()
        {
        }

        public override int ShowPoints
        {
            get
            {
                return 0;
            }
        }

        public override bool PointsAsOrder
        {
            get
            {
                return false;
            }
        }

        public int GetSimpsonWinner(int nCandidates, int[] numberVotes, int[,] votes)
        {
            int[,] K = new int[numberCandidates, numberCandidates];

            for (int i = 0; i<nCandidates; i++)
                for (int j = 0; j < numberVoters; j++)
                {
                    for (int k = i+1; k < nCandidates; k++)
                        K[votes[i, j] - 1, votes[k, j] - 1] += numberVotes[j];
                }

            int[] min = new int[numberCandidates];
            int minVal;

            for (int i = 0; i < numberCandidates; i++)
            {
                minVal = Int32.MaxValue;
                for (int j = 0; j < numberCandidates; j++)
                    if ((K[i, j] < minVal) && (K[i, j] > 0))
                        minVal = K[i, j];

                if (minVal < Int32.MaxValue)
                    min[i] = minVal;
            }

            int max = min[0], maxInd = 0;

            for (int i = 1; i < numberCandidates; i++)
            {
                if (min[i] == max)
                {
                    max++;
                    maxInd = -2;
                    continue;
                }

                if (min[i] > max)
                {
                    max = min[i];
                    maxInd = i;
                }
            }

            return maxInd + 1;
        }

        public int[] Rec(int nCandidates, int[] numberVotes, int[,] votes)
        {
            if (nCandidates == 1)
                return new int[] { votes[0, 0] };

            int[] result = new int[nCandidates];
            int[] appendSequence;
            int currentWinner = -1;

            currentWinner = GetSimpsonWinner(nCandidates, numberVotes, votes);

            if (currentWinner == -1)
                throw new MethodException(exText, this);

            result[0] = currentWinner;
            appendSequence = Rec(nCandidates - 1, numberVotes, ExceptCandidatesFromProfile(votes, new int[] { currentWinner }));

            for (int i = 0; i < nCandidates - 1; i++)
                result[i + 1] = appendSequence[i];

            return result;
        }

        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            base.numberCandidates = numberCandidates;
            base.numberVoters = numberVoters;
            int[] sequence;

            try
            {
                sequence = Rec(numberCandidates, numberVotes, votes);
            }
            catch (MethodException ex)
            {
                throw ex;
            }

            return TransformSequenceToPlaces(sequence);
        }
    }
}
