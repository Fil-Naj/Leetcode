using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2439 : ISolution
    {
        public string Name => "Minimize Maximum of Array";
        public string Description => "You are given a 0-indexed array nums comprising of n non-negative integers.\r\n\r\nIn one operation, you must:\r\n\r\n    Choose an integer i such that 1 <= i < n and nums[i] > 0.\r\n    Decrease nums[i] by 1.\r\n    Increase nums[i - 1] by 1.\r\n\r\nReturn the minimum possible value of the maximum integer of nums after performing any number of operations.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 13, 13, 20, 0, 8, 9, 9 };
            var result = MinimizeArrayValue(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinimizeArrayValue(int[] nums)
        {
            var result = nums[0];
            double sum = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                result = Math.Max(result, (int)Math.Ceiling(sum / (i + 1)));
            }

            return result;
        }
    }
}
