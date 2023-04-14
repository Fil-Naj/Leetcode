using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0516 : ISolution
    {
        public string Name => "Longest Palindromic Subsequence";
        public string Description => "Given a string s, find the longest palindromic subsequence's length in s.\r\n\r\nA subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "bbbab";
            var result = LongestPalindromeSubseq(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestPalindromeSubseq(string s)
        {
            var n = s.Length;
            var m = s.Length;

            var reverse = new string (s.Reverse().ToArray());

            var dp = new int[n + 1, m + 1];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (s[i] == reverse[j])
                        dp[i + 1, j + 1] = 1 + dp[i, j];
                    else
                        dp[i + 1, j + 1] = Math.Max(dp[i, j + 1], dp[i + 1, j]);
                }
            }

            return dp[n, m];
        }
    }
}
