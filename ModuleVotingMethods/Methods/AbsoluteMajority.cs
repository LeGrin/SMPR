//using System;
//using System.Collections.Generic;
//using System.Text;
//using Common.DataTypes;

//namespace Modules.VotingMethods.Methods
//{
//    class AbsoluteMajority : Method
//    {
//        public override string Name
//        {
//            get { return Properties.Resources.MethodAbsoluteMajority; }
//        }

//        public AbsoluteMajority()
//        {
//        }

//        public override int ShowPoints
//        {
//            get
//            {
//                return 0;
//            }
//        }

//        public override bool PointsAsOrder
//        {
//            get
//            {
//                return false;
//            }
//        }

//        //public int[] Rec(int nCandidates, int nVoters, int[] numberVotes, int[,] votes)
//        //{
//        //    int[] sequence = new int[nCandidates], result = new int[nCandidates];
//        //    int[] appendSequence;
//        //    int sumVotes = 0;

//        //    for (int i = 0; i < nVoters; i++)
//        //    {
//        //        sequence[votes[0, i] - 1] += numberVotes[i];
//        //        sumVotes += numberVotes[i];
//        //    }

//        //    for (int i = 0; i < nCandidates; i++)
//        //        if (sequence[i] * 2 > sumVotes)
//        //        {
//        //            result[0] = i;
//        //            if (result.Length == 1)
//        //                return result;

//        //            appendSequence = Rec(nCandidates - 1, nVoters, numberVotes, ExceptCandidatesFromProfile(votes, new int[] { i }));
//        //            for (int j = 0; j < appendSequence.Length; j++)
//        //                result[j + 1] = appendSequence[j];

//        //            return result;
//        //        }

//        //    RelativeMajority rel = new RelativeMajority();
//        //    int[] seq = rel.ProcessMethod(nCandidates, nVoters, numberVotes, votes, new int[] { 0 });
//        //    int[] exceptCand = new int[2];
//        //    int k = 0;

//        //    for (int i = 0; i < seq.Length; i++)
//        //        if (seq[i] == 1)
//        //            exceptCand[k++] = i;

//        //    if (k==1)
//        //        for (int i=0; i<seq.Length; i++)
//        //            if (seq[i] == 2)
//        //            {
//        //                exceptCand[1] = i;
//        //                break;
//        //            }

//        //    int[,] nVotes = ExceptCandidatesFromProfile(votes, ExceptCandidatesFromSequence(sequence, exceptCand));

//        //}

//        public override int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
//        {
//            base.numberCandidates = numberCandidates;
//            base.numberVoters = numberVoters;

//            int[] sequence = new int[numberCandidates], result = new int[numberCandidates];

//            for (int i = 0; i < numberCandidates; i++)
//                result[i] = i + 1;

//            for (int i = 0; i < numberVoters; i++)
//                sequence[votes[0, i] - 1] += numberVotes[i];

//            return SortByPoints(sequence, result);
//        }
//    }
//}
