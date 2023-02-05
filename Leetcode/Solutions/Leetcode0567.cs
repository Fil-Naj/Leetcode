using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0567 : ISolution
    {
        public string Name => "Permutation in String";
        public string Description => "Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.\r\n\r\nIn other words, return true if one of s1's permutations is the substring of s2.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s1 = "ab";
            string s2 = "eidboaoo";
            var result = CheckInclusion(s1, s2);

            Console.WriteLine($"Input: s1 = {s1}, s2 = {s2}");
            Console.WriteLine($"Output: {result}");
        }

        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length) return false;

            var len = s1.Length;
            var toFind = GetFrequencies(s1);
            var word = new int[26];

            for (int i = 0; i < s2.Length; i++)
            {
                if ((i - len) >= 0)
                {
                    word[s2[i - len] - 'a']--;
                }

                word[s2[i] - 'a']++;

                if (word.SequenceEqual(toFind)) return true;
            }

            return false;
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
