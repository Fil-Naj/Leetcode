using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0128 : ISolution
    {
        public string Name => "Longest Consecutive Sequence";
        public string Description => "Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.\r\n\r\nYou must write an algorithm that runs in O(n) time.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
            var result = LongestConsecutive(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> numbers = new(nums);

            int Dfs(int num)
            {
                if (!numbers.Remove(num)) return 0;

                return Dfs(num + 1) + Dfs(num - 1) + 1;
            }

            var maxCount = 0;
            foreach (var num in nums)
            {
                maxCount = Math.Max(maxCount, Dfs(num));
            }

            return maxCount;
        }
    }
}
