using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0035 : ISolution
    {
        public string Name => "Search Insert Position";
        public string Description => "Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.\r\n\r\nYou must write an algorithm with O(log n) runtime complexity.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 3, 5, 6 };
            var target = 7;
            var result = SearchInsert(nums, target);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, target = {target}");
            Console.WriteLine($"Output: {result}");
        }

        public int SearchInsert(int[] nums, int target)
        {
            var index = Array.BinarySearch(nums, target);
            return index >= 0 ? index : (-1) - index;
        }
    }
}
