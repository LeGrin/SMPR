using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Common.DataTypes;

namespace Modules.VotingMethods
{
    public abstract class Method : Common.MethodAbstract
    {
        public abstract int ShowPoints { get; }

        protected int numberCandidates, numberVoters;

        public abstract bool PointsAsOrder { get; }

        public int[] SortByPoints(int[] points, int[] sequence)
        {
            Array.Sort(points, sequence);
            Array.Reverse(sequence);
            Array.Reverse(points);

            int curr_place = 1;
            for (int i = 1; i < points.Length; i++)
                if (points[i-1] == points[i])
                {
                    for (int j = 0; j < sequence.Length; ++j)
                        if (sequence[j] == i + 1)
                            sequence[j] = curr_place;
                } 
                else 
                    ++curr_place;

            return sequence;
        }

        /// <summary>
        /// have a sequence which indexes correspond the candidates and values is their places
        ///returning a sequence which indexes correspond the places and values is the candidates
        /// </summary>
        /// <param name="sequence">input sequence</param>
        /// <returns></returns>
        public int[] TransformSequenceToCandidates(int[] sequence)
        {
            int[] res = new int[numberCandidates];

            for (int i = 0; i < numberCandidates; i++)
                res[sequence[i] - 1] = i+1;

            return res;
        }


        /// <summary>
        /// have a sequence which indexes correspond the places and values is the candidates
        /// returning a sequence which indexes correspond the candidates and values is their places
        /// </summary>
        /// <param name="sequence">input sequence</param>
        /// <returns></returns>
        public int[] TransformSequenceToPlaces(int[] sequence)
        {
            int[] res = new int[numberCandidates];

            for (int i = 0; i < numberCandidates; i++)
                res[sequence[i] - 1] = i+1;

            return res;
        }

        public int[] ExceptCandidatesFromSequence(int[] sequence, int[] candidatesToExcept)
        {
            int[] nSequence = new int[sequence.Length - candidatesToExcept.Length];
            int lastEl = 0;

            for (int i=0; i<sequence.Length; i++)
                if (!(Array.IndexOf(candidatesToExcept, sequence[i]) >=0))
                {
                    nSequence[lastEl] = sequence[i];
                    lastEl++;
                }

            return nSequence;
        }

        public int[,] ExceptCandidatesFromProfile(int[,] profile, int[] outCandidates)
        {
            int[,] nProfile = new int[profile.GetLength(0) - outCandidates.Length, profile.GetLength(1)];
            int[] lastEl = new int[nProfile.GetLength(1)];

            for (int i = 0; i < profile.GetLength(0); i++)
                for (int j = 0; j < profile.GetLength(1); j++)
                {
                    if (!(Array.IndexOf(outCandidates, profile[i,j]) >= 0))
                    {
                        nProfile[lastEl[j], j] = profile[i, j];
                        lastEl[j]++;
                    }
                }

            return nProfile;
        }

        public virtual int[] ProcessMethod(int numberCandidates, int numberVoters, int[] numberVotes, int[,] votes, int[] points)
        {
            return new int[1];
        }
    }
}
