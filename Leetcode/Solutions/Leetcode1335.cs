using Leetcode.Extensions;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json.Serialization;

namespace Leetcode.Solutions
{
    public class Leetcode1335 : ISolution
    {
        public string Name => "Minimum Difficulty of a Job Schedule";
        public string Description => "You want to schedule a list of jobs in d days. Jobs are dependent (i.e To work on the ith job, you have to finish all the jobs j where 0 <= j < i).\r\n\r\nYou have to finish at least one task every day. The difficulty of a job schedule is the sum of difficulties of each day of the d days. The difficulty of a day is the maximum difficulty of a job done on that day.\r\n\r\nYou are given an integer array jobDifficulty and an integer d. The difficulty of the ith job is jobDifficulty[i].\r\n\r\nReturn the minimum difficulty of a job schedule. If you cannot find a schedule for the jobs return -1.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var jobDifficulty = new int[] { 6, 5, 4, 3, 2, 1 };
            // var jobDifficulty = new int[] { 7, 1, 7, 1, 7, 1 };
            var d = 2;
            var result = MinDifficulty_BottomUp(jobDifficulty, d);

            // Prettify
            Console.WriteLine($"Input: data = {jobDifficulty.GetString()}, target = {d}");
            Console.WriteLine($"Output: {result}");
        }

        private int[][] _dp;

        public int MinDifficulty_BottomUp(int[] jobDifficulty, int d)
        {
            _dp = new int[d + 1][];
            for (var i = 0; i < d + 1; i++)
            {
                var item = new int[jobDifficulty.Length];
                Array.Fill(item, int.MaxValue);
                _dp[i] = item;
            }

            var n = jobDifficulty.Length;
            var max = 0;

            // Set max for right side
            for (int i = n - 1; i >= d - 1; i--)
            {
                max = Math.Max(max, jobDifficulty[i]);
                _dp[d][i] = max;
            }

            for (int day = d - 1; day > 0; day--)
            {
                // max end day given num days to split 
                int end = n - 1 - (d - day);

                // left
                int start = day - 1;

                for (int i = start; i <= end; i++)
                {
                    max = 0;
                    for (int j = start; j <= end; j++)
                    {
                        max = Math.Max(max, jobDifficulty[i]);
                        _dp[day][i] = Math.Min(_dp[day][i], max + _dp[day + 1][j + 1]);
                    }
                }
            }

            foreach (var row in _dp)
                Console.WriteLine(row.GetString());
            return _dp[1][0];

        }

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d) return -1;

            _dp = new int[d + 1][];
            for (var i = 0; i < d + 1; i++)
            {
                var item = new int[jobDifficulty.Length];
                Array.Fill(item, -1);
                _dp[i] = item;
            }

            DFS(jobDifficulty, d, 0);

            foreach (var row in _dp)
                Console.WriteLine(row.GetString());
            return _dp[d][0];
        }

        public int DFS(int[] jobDifficulty, int d, int index)
        {
            if (d == 1)
            {
                int max = 0;
                while (index < jobDifficulty.Length)
                {
                    max = Math.Max(max, jobDifficulty[index++]);
                }
                return max;
            }

            if (_dp[d][index] != -1)
                return _dp[d][index];

            int leftMax = 0;

            int result = int.MaxValue;
            for (int i = index; i < jobDifficulty.Length - d + 1; i++)
            {
                leftMax = Math.Max(leftMax, jobDifficulty[i]);
                int rightMax = DFS(jobDifficulty, d - 1, i + 1);
                result = Math.Min(result, leftMax + rightMax);
            }

            _dp[d][index] = result;

            return _dp[d][index];
        }
    }
}
