using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0005 : ISolution
    {
        public string Name => "Longest Palindromic Substring";
        public string Description => "Given a string s, return the longest\r\npalindromic\r\nsubstring\r\nin s.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string sentence = "babad";
            var result = LongestPalindrome(sentence);

            Console.WriteLine($"Input: s = {sentence}");
            Console.WriteLine($"Output: {result}");
        }

        public string LongestPalindrome(string s)
        {
            var result = string.Empty;
            var resultCount = 0;

            int n = s.Length;

            // We will examine a palindrome from the inside out
            // Given a starting centre point 'l', where l = r or r = l + 1
            // We check to see if chars at l and r are equal. If they are, move each along thei respective direciton by 1
            // Repeat until edge is reached or no longer palindromic (chars differ)
            Action<int, int> GrowSandwich = (l, r) =>
            {
                var lp = l;
                var rp = r;

                while (lp >= 0 && rp <= n - 1 && s[lp] == s[rp])
                {
                    var len = rp - lp + 1;
                    if (len > resultCount)
                    {
                        resultCount = len;
                        result = s[lp..(rp + 1)];
                    }

                    // Expand start and end
                    lp -= 1;
                    rp += 1;
                }
            };

            for (int i = 0; i < n; i++) 
            {
                // Incase of odd length (where 'i' is the meat in the sandwich)
                GrowSandwich(i, i);

                // Incase of even length (where 'i' is the caboose of a train)
                GrowSandwich(i, i + 1);
            }

            return result;
        }
    }
}
