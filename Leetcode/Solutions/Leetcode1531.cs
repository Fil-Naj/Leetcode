using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    [ToBeContinued("Have a look at how it works, watch a video cos this is kinda confusing.")]
    public class Leetcode1531 : ISolution
    {
        public string Name => "String Compression II";
        public string Description => "Run-length encoding is a string compression method that works by replacing consecutive identical characters (repeated 2 or more times) with the concatenation of the character and the number marking the count of the characters (length of the run). For example, to compress the string \"aabccc\" we replace \"aa\" by \"a2\" and replace \"ccc\" by \"c3\". Thus the compressed string becomes \"a2bc3\".\r\n\r\nNotice that in this problem, we are not adding '1' after single characters.\r\n\r\nGiven a string s and an integer k. You need to delete at most k characters from s such that the run-length encoded version of s has minimum length.\r\n\r\nFind the minimum length of the run-length encoded version of s after deleting at most k characters.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var s = "aaabcccd";
            var s = "aabbaa";
            //var s = "abcdefghijklmnopqrstuvwxyz";
            var k = 2;
            var result = GetLengthOfOptimalCompression(s, k);

            // Prettify
            Console.WriteLine($"Input: s = {s}, k= {k}");
            Console.WriteLine($"Output: {result}");
        }

        private char[] _chars;
        private int[][] dp;
        private int n;

        public int GetLengthOfOptimalCompression(string s, int k)
        {
            _chars = s.ToArray();
            n = s.Length;
            dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                var row = new int[k + 1];
                Array.Fill(row, -1);
                dp[i] = row;
            } 
            var ans = Dp(0, k);
            foreach (var row in dp)
            {
                Console.WriteLine(row.GetString());
            }
            return ans;
        }

        private int Dp(int i, int k)
        {
            if (k < 0) return n;
            if (n <= i + k) return 0;

            int ans = dp[i][k];
            if (ans != -1) return ans;

            ans = Dp(i + 1, k - 1);
            int length = 0; int same = 0; int diff = 0;

            for (int j = i; j < n && diff <= k; j++)
            {
                if (_chars[j] == _chars[i])
                {
                    same++;
                    if (same <= 2 || same == 10 || same == 100) length++;
                }
                else
                {
                    diff++;
                }
                ans = Math.Min(ans, length + Dp(j + 1, k - diff));
            }
            dp[i][k] = ans;
            return ans;
        }

        //private int DFS(string s, int k)
        //{
        //    if (k == 0) return CompressString(s).Length;

        //    var length = s.Length;
        //    var minLength = int.MaxValue;
        //    for (int i = 0; i < length; i++)
        //    {
        //        var nextString = s.Remove(i, 1);
        //        minLength = Math.Min(DFS(nextString, k - 1), minLength);
        //    }
        //    return minLength;
        //}

        //public string CompressString(string s)
        //{
        //    StringBuilder sb = new();
        //    var count = 1;
        //    char prev = s[0];

        //    var length = s.Length;

        //    for (int i = 1; i < length; i++)
        //    {
        //        var c = s[i];
        //        if (c != prev)
        //        {
        //            sb.Append(string.Format("{0}{1}", prev, count > 1 ? count : string.Empty));
        //            count = 1;
        //            prev = c;
        //        }
        //        else
        //        {
        //            count++;
        //        }
        //    }
        //    // Add last character
        //    sb.Append(string.Format("{0}{1}", prev, count > 1 ? count : string.Empty));

        //    return sb.ToString();
        //}
    }
}
