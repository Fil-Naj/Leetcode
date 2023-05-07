using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1456 : ISolution
    {
        public string Name => "Maximum Number of Vowels in a Substring of Given Length";
        public string Description => "Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.\r\n\r\nVowel letters in English are 'a', 'e', 'i', 'o', and 'u'.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abciiidef";
            var k = 3;
            var result = MaxVowels(s, k);

            // Prettify
            Console.WriteLine($"Input: s = {s}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxVowels(string s, int k)
        {
            var l = 0; var r = 0;
            var sum = 0;
            var result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                sum += CharacterCost(s[l]);
                l++;
                if (l - r >= k + 1)
                {
                    sum -= CharacterCost(s[r]);
                    r++;
                }

                result = Math.Max(sum, result);
            }

            return result;
        }

        private static int CharacterCost(char c) => c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ? 1 : 0;
    }
}
