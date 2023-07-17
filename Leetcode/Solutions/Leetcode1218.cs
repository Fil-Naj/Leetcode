using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1218 : ISolution
    {
        public string Name => "Longest Arithmetic Subsequence of Given Difference";
        public string Description => "Given an integer array arr and an integer difference, return the length of the longest subsequence in arr which is an arithmetic sequence such that the difference between adjacent elements in the subsequence equals difference.\r\n\r\nA subsequence is a sequence that can be derived from arr by deleting some or no elements without changing the order of the remaining elements.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 };
            var difference = -2;
            var result = LongestSubsequence(arr, difference);

            // Prettify
            Console.WriteLine($"Input: arr = {arr.GetString()}, difference = {difference}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestSubsequence(int[] arr, int difference)
        {
            var n = arr.Length;
            var result = 1;
            Dictionary<int, int> dp = new();
            for (int i = 0; i < n; i++)
            {
                var num = arr[i];
                if (dp.ContainsKey(num - difference))
                    dp[num] = dp[num - difference] + 1;
                else
                    dp[num] = 1;

                result = Math.Max(result, dp[num]);
            }

            return result;
        }
    }
}
