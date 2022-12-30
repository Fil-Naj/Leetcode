using Leetcode.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Leetcode.Solutions
{
    public class Leetcode3 : ISolution
    {
        public string Name => "Longest Substring Without Repeating Characters";
        public string Description => "Given a string s, find the length of the longest substring without repeating characters.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string sentence = "dvdf";
            var result = LengthOfLongestSubstring(sentence);

            Console.WriteLine($"Input: s = {sentence}");
            Console.WriteLine($"Output: {result}");
        }

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> letterPositions = new();
            int longestStringLength = 0;

            // We shall use pointers to keep track of the start/end of the substring
            int back = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (letterPositions.ContainsKey(c))
                {
                    var length = letterPositions.Count;
                    if (length > longestStringLength)
                        longestStringLength = length;
                    RemovePreviousLetters(letterPositions, letterPositions[c]);
                }
                letterPositions.Add(c, i);
            }

            var current = letterPositions.Count;
            return longestStringLength > current ? longestStringLength : current;
        }

        private void RemovePreviousLetters(Dictionary<char, int> letterPositions, int positon)
        {
            foreach (char letter in letterPositions.Keys)
            {
                if (letterPositions[letter] <= positon)
                    letterPositions.Remove(letter);
            }
        }
    }
}
