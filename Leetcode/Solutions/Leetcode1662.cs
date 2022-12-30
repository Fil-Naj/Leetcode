using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1662 : ISolution
    {
        public string Name => "Check If Two String Arrays are Equivalent";
        public string Description => "Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.\r\n\r\nA string is represented by an array if the array elements concatenated in order forms the string.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var word1 = new string[] { "ab", "c" };
            var word2 = new string[] { "a", "bc" };
            var result = ArrayStringsAreEqual(word1, word2);

            // Prettify
            Console.WriteLine($"Input: word1 = {word1.GetString()}, word2 = {word2}");
            Console.WriteLine($"Output: {result}");
        }

        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return string.Join(string.Empty, word1) == string.Join(string.Empty, word2);
        }
    }
}
