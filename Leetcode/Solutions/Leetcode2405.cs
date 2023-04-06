using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2405 : ISolution
    {
        public string Name => "Optimal Partition of String";
        public string Description => "Given a string s, partition the string into one or more substrings such that the characters in each substring are unique. That is, no letter appears in a single substring more than once.\r\n\r\nReturn the minimum number of substrings in such a partition.\r\n\r\nNote that each character should belong to exactly one substring in a partition.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "abacaba";
            var result = PartitionString(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int PartitionString(string s)
        {
            var result = 1;
            HashSet<char> letters = new();
            foreach (var letter in s)
            {
                if (letters.Contains(letter))
                {
                    result++;
                    letters.Clear();
                    letters.Add(letter);
                }
                else
                {
                    letters.Add(letter);
                }
            }

            return result;
        }
    }
}
