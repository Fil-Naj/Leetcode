using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1143 : ISolution
    {
        public string Name => "Longest Common Subsequence";
        public string Description => "Given two strings text1 and text2, return the length of their longest common subsequence. If there is no common subsequence, return 0.\r\n\r\nA subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters.\r\n\r\n    For example, \"ace\" is a subsequence of \"abcde\".\r\n\r\nA common subsequence of two strings is a subsequence that is common to both strings.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var text1 = "abcde";
            var text2 = "bbbab";
            var result = LongestCommonSubsequence(text1, text2);

            // Prettify
            Console.WriteLine($"Input: text1 = {text1}, text2 = {text2}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestCommonSubsequence(string text1, string text2)
        {
            var n = text1.Length;
            var m = text2.Length;

            var dp = new int[n + 1, m + 1];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (text1[i] == text2[j])
                        dp[i + 1, j + 1] = 1 + dp[i, j];
                    else
                        dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }

            return dp[n, m];
        }
    }
}
