using Leetcode.Extensions;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;

namespace Leetcode.Solutions
{
    public class Leetcode0438 : ISolution
    {
        public string Name => "Find All Anagrams in a String";
        public string Description => "Given two strings s and p, return an array of all the start indices of p's anagrams in s. You may return the answer in any order.\r\n\r\nAn Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = "cbaebabacd";
            string p = "abc";
            var result = FindAnagrams(s, p);

            Console.WriteLine($"Input: s = {s}, p = {p}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            var result = new List<int>();

            if (p.Length > s.Length) return result;

            var anaCount = p.Length;

            Dictionary<char, int> word = new();
            Dictionary<char, int> anagram = p.GroupBy(x => x).ToDictionary(x => x.Key, y => y.Count());

            for (int i = 0; i < s.Length; i++)
            {
                // Remove character outside realm of the start
                if (i - anaCount >= 0)
                {
                    word[s[i - anaCount]]--;
                }

                if (word.ContainsKey(s[i]))
                {
                    word[s[i]]++;
                }
                else
                {
                    word[s[i]] = 1;
                }

                if (IsAnagram(word, anagram))
                    result.Add(i - anaCount + 1);
            }

            return result;
        }

        public bool IsAnagram(Dictionary<char, int> word, Dictionary<char, int> anagram)
        {
            if (word.Values.Where(x => x > 0).Count() != anagram.Count) return false;

            foreach (var letter in word)
            {
                if (letter.Value > 0 && (!anagram.TryGetValue(letter.Key, out var count) || letter.Value != count))
                    return false;
            }

            return true;
        }
    }
}
