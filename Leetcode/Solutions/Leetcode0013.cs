using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0013 : ISolution
    {
        public string Name => "Roman to Integer";
        public string Description => "Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.\r\n\r\nSymbol       Value\r\nI             1\r\nV             5\r\nX             10\r\nL             50\r\nC             100\r\nD             500\r\nM             1000\r\n\r\nFor example, 2 is written as II in Roman numeral, just two ones added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.\r\n\r\nRoman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:\r\n\r\n    I can be placed before V (5) and X (10) to make 4 and 9. \r\n    X can be placed before L (50) and C (100) to make 40 and 90. \r\n    C can be placed before D (500) and M (1000) to make 400 and 900.\r\n\r\nGiven a roman numeral, convert it to an integer.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "MCMXCIV";
            var result = RomanToInt(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        private static readonly Dictionary<char, int> RomanNumerals = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
            { 'M', 1000 },
        };

        public int RomanToInt(string s)
        {
            var sum = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var current = RomanNumerals[s[i]];
                // If next number (if exists), is more than current number, reduce sum by current number
                if (i + 1 < s.Length && current < RomanNumerals[s[i + 1]])
                    sum -= current;
                else
                    sum += current;
            }

            return sum;
        }
    }
}
