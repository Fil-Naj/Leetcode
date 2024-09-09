using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode3016 : ISolution
    {
        public string Name => "Minimum Number of Pushes to Type Word II";
        public string Description => "You are given a string word containing lowercase English letters.\r\n\r\nTelephone keypads have keys mapped with distinct collections of lowercase English letters, which can be used to form words by pushing them. For example, the key 2 is mapped with [\"a\",\"b\",\"c\"], we need to push the key one time to type \"a\", two times to type \"b\", and three times to type \"c\" .\r\n\r\nIt is allowed to remap the keys numbered 2 to 9 to distinct collections of letters. The keys can be remapped to any amount of letters, but each letter must be mapped to exactly one key. You need to find the minimum number of times the keys will be pushed to type the string word.\r\n\r\nReturn the minimum number of pushes needed to type word after remapping the keys.\r\n\r\nAn example mapping of letters to keys on a telephone keypad is given below. Note that 1, *, #, and 0 do not map to any letters.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var word = "aabbccddeeffgghhiiiiii";
            var result = MinimumPushes(word);

            // Prettify
            Console.WriteLine($"Input: word = {word}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinimumPushes(string word)
        {
            Dictionary<char, int> freq = [];

            foreach (var c in word)
            {
                if (!freq.TryAdd(c, 1))
                {
                    freq[c]++;
                }
            }

            var pushes = 0;
            var numCount = 0;
            foreach (var c in freq.OrderByDescending(c => c.Value))
            {
                pushes += ((numCount / 8) + 1) * c.Value;
                numCount++;
            }

            return pushes;
        }
    }
}
