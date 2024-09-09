using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0647 : ISolution
    {
        public string Name => "Palindromic Substrings";
        public string Description => "Given a string s, return the number of palindromic substrings in it.\r\n\r\nA string is a palindrome when it reads the same backward as forward.\r\n\r\nA substring is a contiguous sequence of characters within the string.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abc";
            var result = CountSubstrings(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int CountSubstrings(string s)
        {
            var count = 0;
            for (var r = 1; r <= s.Length; r++)
            {
                for (var l = 0; l < r; l++)
                {
                    if (IsPalindrome(s[l..r])) count++;
                }
            }


            return count;
        }

        private bool IsPalindrome(string s)
        {
            var n = s.Length;
            var mid = n / 2;
            for (var i = 0; i < mid; i++)
            {
                if (s[i] != s[n - 1 - i]) return false;
            }

            return true;
        }
    }
}
