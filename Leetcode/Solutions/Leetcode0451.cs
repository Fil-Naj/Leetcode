using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0451 : ISolution
    {
        public string Name => "Sort Characters By Frequency";
        public string Description => "Given a string s, sort it in decreasing order based on the frequency of the characters. The frequency of a character is the number of times it appears in the string.\r\n\r\nReturn the sorted string. If there are multiple answers, return any of them.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "cccaaa";
            var result = FrequencySort(s);

            // Prettify
            Console.WriteLine($"Input: data = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string FrequencySort(string s)
        {
            Dictionary<char, int> freq = [];
            foreach (var c in s)
            {
                if (!freq.TryGetValue(c, out int value))
                {
                    value = 0;
                    freq[c] = value;
                }
                freq[c] = ++value;
            }

            StringBuilder sb = new();
            foreach (var item in freq.OrderByDescending(x => x.Value))
            {
                sb.Append(item.Key, item.Value);
            }

            return sb.ToString();
        }
    }
}
