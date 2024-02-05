using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0027 : ISolution
    {
        public string Name => "Remove Element";
        public string Description => "Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.\r\n\r\nConsider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:\r\n\r\n    Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.\r\n    Return k.\r\n";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var val = 2;
            var result = RemoveElement(nums, val);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, val = {val}");
            Console.WriteLine($"Output: {result}");
        }

        public int RemoveElement(int[] nums, int val)
        {
            var count = 0;
            foreach (var num in nums)
            {
                if (num != val)
                    nums[count++] = num;
            }

            return count;
        }
    }
}
