using Leetcode.Extensions;
using System.Diagnostics.CodeAnalysis;
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

            var anagram = GetFrequencies(p);
            var word = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                // Remove frequency count of letter getting kicked out from the front
                if ((i - anaCount) >= 0)
                    word[s[i - anaCount] - 'a']--;

                word[s[i] - 'a']++;

                if (word.SequenceEqual(anagram))
                    result.Add(i - anaCount + 1);
            }

            return result;
        }

        public int[] GetFrequencies(string s)
        {
            var freq = new int[26];
            foreach (var letter in s)
            {
                freq[letter - 'a']++;
            }
            return freq;
        }
    }
}
