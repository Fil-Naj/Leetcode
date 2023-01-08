using Leetcode.Extensions;
using System.Collections;

namespace Leetcode.Solutions
{
    public class Leetcode0290 : ISolution
    {
        public string Name => "Word Pattern";
        public string Description => "Given a pattern and a string s, find if s follows the same pattern.\r\n\r\nHere follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.Given a pattern and a string s, find if s follows the same pattern.\r\n\r\nHere follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var pattern = "abba";
            var s = "dog cat cat fish";
            var result = WordPattern(pattern, s);

            // Prettify
            Console.WriteLine($"Input: pattern = {pattern}, s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public bool WordPattern(string pattern, string s)
        {
            Dictionary<string, char> dictionary = new();

            var words = s.Split(" ");

            if (words.Length != pattern.Length) return false;

            for (int i = 0; i < words.Length; i++)
            {
                if (dictionary.TryGetValue(words[i], out var letter))
                {
                    if (letter != pattern[i]) return false;
                }
                else
                {
                    if (dictionary.ContainsValue(pattern[i])) return false;

                    dictionary[words[i]] = pattern[i];
                }
            }
            return true;
        }
    }
}
