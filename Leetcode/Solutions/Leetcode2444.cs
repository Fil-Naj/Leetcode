using Leetcode.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Leetcode.Solutions
{
    public class Leetcode2444 : ISolution
    {
        public string Name => "Count Subarrays With Fixed Bounds";
        public string Description => "You are given an integer array nums and two integers minK and maxK.\r\n\r\nA fixed-bound subarray of nums is a subarray that satisfies the following conditions:\r\n\r\n    The minimum value in the subarray is equal to minK.\r\n    The maximum value in the subarray is equal to maxK.\r\n\r\nReturn the number of fixed-bound subarrays.\r\n\r\nA subarray is a contiguous part of an array.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 3, 5, 2, 7, 5 };
            var minK = 1;
            var maxK = 5;
            var result = CountSubarrays(nums, minK, maxK);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, minK = {minK}, maxK = {maxK}");
            Console.WriteLine($"Output: {result}");
        }
 
        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            var result = 5000050000;
            var minIndex = -1; var maxIndex = -1; var left = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < minK || nums[i] > maxK)
                    left = i;

                if (nums[i] == minK)
                    minIndex = i;
                if (nums[i] ==  maxK)
                    maxIndex = i;

                result += Math.Max(0, Math.Min(maxIndex, minIndex) - left);
            }

            return result;
        }
    }
}
