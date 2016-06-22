using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    class AlternativeVoices : Method
    {
        public override string Name
        {
            get { return Properties.Resources.MethodAlternativeVoices; }
        }

        public override int ShowPoints
        {
            get
            {
                return 1;
            }
        }

        public override bool PointsAsOrder
        {
            get
            {
                return false;
            }
        }

        public int[] GetAlternativeLooser(int nCandidates, int[] numberVotes, int[,] votes, int[] points)
        {
            int[] sequence = new int[numberCandidates], pointed = new int[numberCandidates];


            for (int i = 0; i < numberVoters; i++)
                for (int j = 0; j < nCandidates; j++)
                {
                    sequence[votes[j, i] - 1] += numberVotes[i] * points[j];
                    pointed[votes[j, i] - 1] = 1;
                }

            int minPoints = Int32.MaxValue;
            List<int> loosers = new List<int>();
            for (int i = 0; i < numberCandidates; i++)
            {
                if ((sequence[i] < minPoints) && (pointed[i] > 0))
                {
                    minPoints = sequence[i];
                    loosers.Clear();
                    loosers.Add(i+1);
                    continue;
                }

                if (sequence[i] == minPoints)
                    loosers.Add(i+1);
            }

            return loosers.ToArray();
        }

        public int[] Rec(int nCandidates, int[] numberVotes, int[,] votes, int[] points)
        {
            if (nCandidates == 1)
                return new int[] { votes[0, 0] };

            int[] result = new int[nCandidates];
            int[] appendSequence;
            int[] currentLooser;

            currentLooser = GetAlternativeLooser(nCandidates, numberVotes, votes, points);

            for (int i = 0; i < currentLooser.Length; i++)
                result[i] = currentLooser[i];

            if (nCandidates - currentLooser.Length > 0)
                appendSequence = Rec(nCandidates - currentLooser.Length, numberVotes, ExceptCandidatesFromProfile(votes, currentLooser), points);
            else return result;

            for (int i = 0; i < nCandidates - 1; i++)
                result[i + currentLooser.Length] = appendSequence[i];

            return result;
        }

        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            base.numberCandidates = numberCandidates;
            base.numberVoters = numberVoters;
            int[] sequence;

            try
            {
                sequence = Rec(numberCandidates, numberVotes, votes, points);
                Array.Reverse(sequence);
            }
            catch (MethodException ex)
            {
                throw ex;
            }

            return TransformSequenceToPlaces(sequence);
        }
    }
}
