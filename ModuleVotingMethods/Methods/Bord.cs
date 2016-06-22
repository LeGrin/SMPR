using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    public class Bord : Method
    {
        public override string Name
        {
            get { return Properties.Resources.MethodBord; }
        }

        public Bord()
        {
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


        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            base.numberCandidates = numberCandidates;
            base.numberVoters = numberVoters;

            int[] sequence = new int[numberCandidates], result = new int[numberCandidates];

            for (int i = 0; i < numberCandidates; i++)
                result[i] = i + 1;

            for (int i = 0; i < numberVoters; i++)
                for (int j = 0; j < numberCandidates; j++)
                    sequence[votes[j, i] - 1] += numberVotes[i] * points[j];

            return SortByPoints(sequence, result);
        }
    }
}
