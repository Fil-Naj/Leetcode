using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1208 : ISolution
    {
        public string Name => "Get Equal Substrings Within Budget";
        public string Description => "You are given two strings s and t of the same length and an integer maxCost.\r\n\r\nYou want to change s to t. Changing the ith character of s to ith character of t costs |s[i] - t[i]| (i.e., the absolute difference between the ASCII values of the characters).\r\n\r\nReturn the maximum length of a substring of s that can be changed to be the same as the corresponding substring of t with a cost less than or equal to maxCost. If there is no substring from s that can be changed to its corresponding substring from t, return 0.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abcd";
            var t = "bcdf";
            var maxCost = 3;
            var result = EqualSubstring(s, t, maxCost);

            // Prettify
            Console.WriteLine($"Input: s = {s}, t = {t}, maxCost = {maxCost}");
            Console.WriteLine($"Output: {result}");
        }

        public int EqualSubstring(string s, string t, int maxCost)
        {
            var n = s.Length;
            var cost = 0;
            var ans = 0;

            // Use two pointers to define the current substring window
            for (int left = 0, right = 0; right < n; right++)
            {
                // Calculate cost for converting current character
                cost += Math.Abs(s[right] - t[right]);

                // If cost exceeds limit, shrink window from left
                while (cost > maxCost)
                {
                    cost -= Math.Abs(s[left] - t[left]);
                    left++;
                }

                // Update maximum valid substring length
                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }
    }
}
