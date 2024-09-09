using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0287 : ISolution
    {
        public string Name => "Find the Duplicate Number";
        public string Description => "Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.\r\n\r\nThere is only one repeated number in nums, return this repeated number.\r\n\r\nYou must solve the problem without modifying the array nums and uses only constant extra space.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 3, 4, 2, 2 };
            var result = FindDuplicate(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindDuplicate(int[] nums)
        {
            // Fast pointer, slow pointer approach
            var slow = 0;
            var fast = 0;

            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            } while (slow != fast);

            slow = 0;
            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];
            }

            return slow;
        }
    }
}
