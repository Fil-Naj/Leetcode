using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1027 : ISolution
    {
        public string Name => "Longest Arithmetic Subsequence";
        public string Description => "Given an array nums of integers, return the length of the longest arithmetic subsequence in nums.\r\n\r\nNote that:\r\n\r\n    A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.\r\n    A sequence seq is arithmetic if seq[i + 1] - seq[i] are all the same value (for 0 <= i < seq.length - 1).\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 9, 4, 7, 2, 10 };
            var result = LongestArithSeqLength(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestArithSeqLength(int[] nums)
        {
            var n = nums.Length;
            var result = 2;
            Dictionary<int, int>[] dp = new Dictionary<int, int>[n];

            for (var i = 0; i < n; i++)
            {
                dp[i] = new();
                for (var j = 0; j < i; j++)
                {
                    var diff = nums[i] - nums[j];

                    dp[i][diff] = (dp[j] is not null && dp[j].TryGetValue(diff, out var val) ? val : 1) + 1;
                    result = Math.Max(result, dp[i][diff]);
                }
            }

            return result;
        }
    }
}
