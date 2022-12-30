using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode692 : ISolution
    {
        public string Name => "Top K Frequent Words";
        public string Description => "Given an array of strings words and an integer k, return the k most frequent strings.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var words = new string[] { "i", "love", "leetcode", "i", "love", "coding" };
            var k = 6;
            var result = TopKFrequent(words, k);

            // Prettify
            Console.WriteLine($"Input: words = {words.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> frequencies = new();
            foreach (var word in words)
            {
                if (frequencies.ContainsKey(word))
                    frequencies[word]++;
                else
                    frequencies.Add(word, 1);
            }

            return frequencies.OrderByDescending(w => w.Value).ThenBy(w => w.Key).Take(k).Select(w => w.Key).ToList();
        }
    }
}
