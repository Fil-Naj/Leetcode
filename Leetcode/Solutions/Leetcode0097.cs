using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0097 : ISolution
    {
        public string Name => "Interleaving String";
        public string Description => "Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1 and s2.\r\n\r\nAn interleaving of two strings s and t is a configuration where s and t are divided into n and m\r\nsubstrings\r\nrespectively, such that:\r\n\r\n    s = s1 + s2 + ... + sn\r\n    t = t1 + t2 + ... + tm\r\n    |n - m| <= 1\r\n    The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3 + s3 + ...\r\n\r\nNote: a + b is the concatenation of strings a and b.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s1 = "aabcc";
            var s2 = "dbbca";
            var s3 = "aadbbcbcac";
            var result = IsInterleave(s1, s2, s3);

            // s2
            Console.WriteLine($"Input: s1 = {s1}, target = {s2}, s3 = {s3}");
            Console.WriteLine($"Output: {result}");
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            Dictionary<(int i, int j), bool> dp = new();

            bool Dfs(int i, int j)
            {
                if (dp.TryGetValue((i, j), out var p))
                    return p;

                if (i + j >= s3.Length) return true;

                var currentChar = s3[i + j];
                var possible = false;

                if (i < s1.Length && s1[i] == currentChar)
                    possible |= Dfs(i + 1, j);

                if (j < s2.Length && s2[j] == currentChar)
                    possible |= Dfs(i, j + 1);

                dp[(i, j)] = possible;
                return possible;
            }

            return Dfs(0, 0);
        }
    }
}
