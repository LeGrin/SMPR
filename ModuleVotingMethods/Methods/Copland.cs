using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    class Copland : Method
    {
        private static string exText = Properties.Resources.methodCopplandException;
        public override string Name
        {
            get { return Properties.Resources.MethodCopland; }
        }

        public Copland()
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

        public int GetCoplandWinner(int nCandidates, int[] numberVotes, int[,] votes)
        {
            int[,] K = new int[numberCandidates, numberCandidates];

            for (int i = 0; i<nCandidates; i++)
                for (int j = 0; j < numberVoters; j++)
                {
                    for (int k = 0; k < nCandidates; k++)
                    {
                        int c = Math.Sign(k-i);
                        K[votes[i, j] - 1, votes[k, j] - 1] += c * numberVotes[j];
                    }
                }

            int winner = 0, winnerPoints = 0, points;
            for (int i = 0; i < numberCandidates; i++)
                winnerPoints += Math.Sign(K[0, i]);
            if (winnerPoints == 0)
                winner = -2;

            for (int i = 1; i < numberCandidates; i++)
            {
                points = 0;
                for (int j = 0; j < numberCandidates; j++)
                    points += Math.Sign(K[i, j]);

                if (points > winnerPoints)
                {
                    winner = i;
                    winnerPoints = points;
                }
                else if ((points == winnerPoints) && (points > 0))
                    return -1;
            }

            return winner + 1;
        }

        public int[] Rec(int nCandidates, int[] numberVotes, int[,] votes)
        {
            if (nCandidates == 1)
                return new int[] { votes[0, 0] };

            int[] result = new int[nCandidates];
            int[] appendSequence;
            int currentWinner = -1;

            currentWinner = GetCoplandWinner(nCandidates, numberVotes, votes);

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
