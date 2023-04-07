using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0704 : ISolution
    {
        public string Name => "Binary Search";
        public string Description => "Given an array of integers nums which is sorted in ascending order, and an integer target, write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.\r\n\r\nYou must write an algorithm with O(log n) runtime complexity.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { -1, 0, 3, 5, 9, 12 };
            var target = 13;
            var result = Search(nums, target);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, target = {target}");
            Console.WriteLine($"Output: {result}");
        }

        public int Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length;
            while (l < r)
            {
                int pivot = (l + r) / 2;
                if (nums[pivot] < target)
                    l = pivot + 1;
                else if (nums[pivot] > target)
                    r = pivot - 1;
                else
                    return pivot;
            }

            return l >= 0 && l < nums.Length - 1 && nums[l] == target ? l : -1;
        }
    }
}
