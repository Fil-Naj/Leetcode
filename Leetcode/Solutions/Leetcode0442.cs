using Leetcode.Extensions;
using System.Collections.Generic;

namespace Leetcode.Solutions
{
    public class Leetcode0442 : ISolution
    {
        public string Name => "Find All Duplicates in an Array";
        public string Description => "Given an integer array nums of length n where all the integers of nums are in the range [1, n] and each integer appears once or twice, return an array of all the integers that appears twice.\r\n\r\nYou must write an algorithm that runs in O(n) time and uses only constant extra space.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };
            var result = FindDuplicates(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> FindDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return [];

            List<int> result = [];
            for (var i = 0; i < nums.Length; i++)
            {
                var index = Math.Abs(nums[i]) - 1;

                if (nums[index] > 0)
                    nums[index] = -nums[index];
                else
                    result.Add(index + 1);
            }

            return result;
        }
    }
}
