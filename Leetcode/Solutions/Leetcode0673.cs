using Leetcode.Extensions;
using System.Linq.Expressions;

namespace Leetcode.Solutions
{
    public class Leetcode0673 : ISolution
    {
        public string Name => "Number of Longest Increasing Subsequence";
        public string Description => "Given an integer array nums, return the number of longest increasing subsequences.\r\n\r\nNotice that the sequence has to be strictly increasing.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 3, 5, 4, 7 };
            var result = FindNumberOfLIS(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindNumberOfLIS(int[] nums)
        {
            var n = nums.Length;

            var dp = new int[n]; 
            Array.Fill(dp, 1);
            
            var count = new int[n];
            Array.Fill(count, 1);

            var maxLength = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            count[i] = count[j];
                        }
                        else if (dp[j] + 1 == dp[i])
                        {
                            count[i] += count[j];
                        }
                    }
                }

                maxLength = Math.Max(maxLength, dp[i]);
            }

            var result = 0;
            for (int i = 0; i < n; i++)
            {
                if (dp[i] == maxLength)
                {
                    result += count[i];
                }
            }

            return result;
        }
    }
}
