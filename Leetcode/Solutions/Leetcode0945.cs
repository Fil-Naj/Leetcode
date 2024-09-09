using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0945 : ISolution
    {
        public string Name => "Minimum Increment to Make Array Unique";
        public string Description => "You are given an integer array nums. In one move, you can pick an index i where 0 <= i < nums.length and increment nums[i] by 1.\r\n\r\nReturn the minimum number of moves to make every value in nums unique.\r\n\r\nThe test cases are generated so that the answer fits in a 32-bit integer.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 3, 2, 1, 2, 1, 7 };
            var result = MinIncrementForUnique(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinIncrementForUnique(int[] nums)
        {
            if (nums.Length == 1) return 0;

            Array.Sort(nums);

            var count = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    nums[i]++;
                    count++;
                }
                else if (nums[i] < nums[i - 1])
                {
                    count += nums[i - 1] - nums[i] + 1;
                    nums[i] = nums[i - 1] + 1;
                }
            }

            return count;
        }
    }
}
