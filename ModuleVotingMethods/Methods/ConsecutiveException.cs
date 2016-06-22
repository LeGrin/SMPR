using System;
using System.Collections.Generic;
using System.Text;
using Common.DataTypes;

namespace Modules.VotingMethods.Methods
{
    class ConsecutiveException : Method
    {
        private static string exText = Properties.Resources.methodConsecutiveExceptionException;
        public override string Name
        {
            get { return Properties.Resources.MethodConsecutiveException; }
        }

        public ConsecutiveException()
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
                return true;
            }
        }

        public int GetComparing(int nCandidates, int cand1, int cand2, int[] numberVotes, int[,] votes)
        {
            int points1 = 0, points2 = 0;

            for (int i = 0; i < numberVoters; i++)
            {
                if (votes[0, i] == cand1)
                    points1 += numberVotes[i];
                else if (votes[0, i] == cand2)
                    points2 += numberVotes[i];
            }

            if (points1 == points2)
                return -1;

            if (points1 > points2)
                return cand2;
            else return cand1;

        }

        public int[] Rec(int nCandidates, int[] order, int[] numberVotes, int[,] votes)
        {
            int currentLooser = -1;

            List<int> lstOrder = new List<int>(order), res = new List<int>();

            while (lstOrder.Count > 1)
            {
                currentLooser = GetComparing(lstOrder.Count, lstOrder[0], lstOrder[1], numberVotes, votes);

                if (currentLooser == -1)
                    throw new MethodException(exText, this);

                if (currentLooser == lstOrder[0])
                    lstOrder.RemoveAt(0);
                else lstOrder.RemoveAt(1);

                res.Add(currentLooser);
            }

            res.Add(lstOrder[0]);

            res.Reverse();
            return res.ToArray();
        }

        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            base.numberCandidates = numberCandidates;
            base.numberVoters = numberVoters;
            int[] sequence;

            try
            {
                sequence = Rec(numberCandidates, points, numberVotes, votes);
            }
            catch (MethodException ex)
            {
                throw ex;
            }

            return TransformSequenceToPlaces(sequence);
        }
    }
}
