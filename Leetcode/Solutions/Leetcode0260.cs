using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0260 : ISolution
    {
        public string Name => "Single Number III";
        public string Description => "Given an integer array nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. You can return the answer in any order.\r\n\r\nYou must write an algorithm that runs in linear runtime complexity and uses only constant extra space.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 1, 5, 3 };
            var result = SingleNumber(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] SingleNumber(int[] nums)
        {
            if (nums.Length == 2) return nums;

            var xor = 0;
            foreach (var num in nums)
            {
                xor ^= num;
            }

            int mask = 1;
            while ((xor & mask) == 0)
            {
                mask <<= 1;
            }

            int num1 = 0;
            int num2 = 0;

            foreach (int num in nums)
            {
                if ((num & mask) == 0)
                {
                    num1 ^= num;
                }
                else
                {
                    num2 ^= num;
                }
            }

            return [num1, num2];
        }
    }
}
