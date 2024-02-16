using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1481 : ISolution
    {
        public string Name => "Least Number of Unique Integers after K Removals";
        public string Description => "Given an array of integers arr and an integer k. Find the least number of unique integers after removing exactly k elements.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 4, 3, 1, 1, 3, 3, 2 };
            var k = 3;
            var result = FindLeastNumOfUniqueInts(arr, k);

            // Prettify
            Console.WriteLine($"Input: arr = {arr.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindLeastNumOfUniqueInts(int[] arr, int k)
        {
            Dictionary<int, int> freq = [];
            foreach (var num in arr)
            {
                if (!freq.TryGetValue(num, out int value))
                {
                    value = 0;
                    freq[num] = value;
                }
                freq[num] = ++value;
            }

            var sorted = freq.Select(x => x.Value).ToArray();
            Array.Sort(sorted);

            var l = 0;
            while (k > 0)
            {
                if (sorted[l] <= k)
                {
                    k -= sorted[l];
                    l++;
                }
                else
                {
                    k = 0;
                }
            }

            return sorted.Length - l;
        }
    }
}
