using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1639 : ISolution
    {
        public string Name => "Number of Ways to Form a Target String Given a Dictionary";
        public string Description => "You are given a list of strings of the same length words and a string target.\r\n\r\nYour task is to form target using the given words under the following rules:\r\n\r\n    target should be formed from left to right.\r\n    To form the ith character (0-indexed) of target, you can choose the kth character of the jth string in words if target[i] = words[j][k].\r\n    Once you use the kth character of the jth string of words, you can no longer use the xth character of any string in words where x <= k. In other words, all characters to the left of or at index k become unusuable for every string.\r\n    Repeat the process until you form the string target.\r\n\r\nNotice that you can use multiple characters from the same string in words provided the conditions above are met.\r\n\r\nReturn the number of ways to form target from words. Since the answer may be too large, return it modulo 10^9 + 7.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var words = new string[]
            {
                "acca",
                "bbbb",
                "caca"
            };
            var target = "aba";
            var result = NumWays(words, target);

            // Prettify
            Console.WriteLine($"Input: words = {words.GetString()}, target = {target}");
            Console.WriteLine($"Output: {result}");
        }

        // Dfs with memoisation
        public int NumWays(string[] words, string target)
        {
            var n = words.Length;
            var w = words[0].Length;
            var t = target.Length;
            int mod = 1000000007;

            if (w < t) return 0;

            int[,] letterCount = new int[w, 26];
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    letterCount[i, word[i] - 'a']++;
                }
            }

            long[,] dp = new long[w, t];

            long Dfs(int letter, int targetLetter)
            {
                var ltrCount = letterCount[letter, target[targetLetter] - 'a'];

                if (ltrCount == 0)
                    return 0;

                if (targetLetter == t - 1)
                    return ltrCount;

                if (dp[letter, targetLetter] > 0)
                    return dp[letter, targetLetter];

                var res = 0L;
                var current = ltrCount;
                var maxL = Math.Min(w, w - (t - targetLetter) + 1);
                for (int j = letter + 1; j <= maxL; j++)
                {
                    res += Dfs(j, targetLetter + 1) % mod;
                }

                dp[letter, targetLetter] = res * current % mod;
                return dp[letter, targetLetter];
            }

            var result = 0L;
            var maxLetter = Math.Min(w, w - t + 1);
            for (int i = 0; i < maxLetter; i++)
            {
                result += Dfs(i, 0) % mod;
            }

            return (int)(result % mod);
        }
    }
}
