using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    public class RelativeMajority : Method
    {
        public override string Name
        {
            get { return Properties.Resources.MethodRelativeMajority; }
        }

        public RelativeMajority()
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


        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            base.numberCandidates = numberCandidates;
            base.numberVoters = numberVoters;

            int[] sequence = new int[numberCandidates], result = new int[numberCandidates];

            for (int i = 0; i < numberCandidates; i++)
                result[i] = i + 1;

            for (int i = 0; i < numberVoters; i++)
                sequence[votes[0, i] - 1] += numberVotes[i];

            return SortByPoints(sequence, result);
        }
    }
}
