using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode53 : ISolution
    {
        public string Name => "Maximum Subarray";
        public string Description => "Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            var result = MaxSubArray(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxSubArray(int[] nums)
        {
            var n = nums.Length;
            int[] dp = new int[n];

            dp[0] = nums[0];

            int best = dp[0];
            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                best = Math.Max(dp[i], best);
            }
            return best;
        }
    }
}
