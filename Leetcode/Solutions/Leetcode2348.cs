using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2348 : ISolution
    {
        public string Name => "Number of Zero-Filled Subarrays";
        public string Description => "Given an integer array nums, return the number of subarrays filled with 0.\r\n\r\nA subarray is a contiguous non-empty sequence of elements within an array.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { };
            var result = ZeroFilledSubarray(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public long ZeroFilledSubarray(int[] nums)
        {
            var sum = 0L;
            var left = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    sum += i - left;
                }
                else
                {
                    left = i;
                }
            }

            return sum;
        }
    }
}
