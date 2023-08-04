using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0017 : ISolution
    {
        public string Name => "Letter Combinations of a Phone Number";
        public string Description => "Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.\r\n\r\nA mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var digits = "2";
            var result = LetterCombinations(digits);

            // Prettify
            Console.WriteLine($"Input: digits = {digits}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        private readonly Dictionary<char, char[]> _numbers = new()
        {
            { '2', new[] { 'a', 'b', 'c' } },
            { '3', new[] { 'd', 'e', 'f' } },
            { '4', new[] { 'g', 'h', 'i' } },
            { '5', new[] { 'j', 'k', 'l' } },
            { '6', new[] { 'm', 'n', 'o' } },
            { '7', new[] { 'p', 'q', 'r', 's' } },
            { '8', new[] { 't', 'u', 'v' } },
            { '9', new[] { 'w', 'x', 'y', 'z' } }
        };

        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0) return new List<string>();

            var result = new List<string>();
            
            var n = digits.Length;
            char[] str = new char[n];

            void Dfs(int index)
            {
                if (index == n)
                {
                    result.Add(new string(str));
                    return;
                }

                foreach (var c in _numbers[digits[index]])
                {
                    str[index] = c;
                    Dfs(index + 1);
                }
            }

            Dfs(0);

            return result;
        }
    }
}
