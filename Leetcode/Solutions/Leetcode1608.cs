using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1608 : ISolution
    {
        public string Name => "Special Array With X Elements Greater Than or Equal X";
        public string Description => "You are given an array nums of non-negative integers. nums is considered special if there exists a number x such that there are exactly x numbers in nums that are greater than or equal to x.\r\n\r\nNotice that x does not have to be an element in nums.\r\n\r\nReturn x if the array is special, otherwise, return -1. It can be proven that if nums is special, the value for x is unique.\r\n\r\n ";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] nums = [0, 4, 3, 0, 4];
            var result = SpecialArray(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int SpecialArray(int[] nums)
        {
            Array.Sort(nums);

            for (var i = 0; i <= nums.Length; i++)
            {
                var index = SearchIndex(nums, i);

                if (nums.Length - index == i)
                    return i;
            }

            return -1;
        }

        public int SearchIndex(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length;

            while (l < r)
            {
                var pivot = l + (r - l) / 2;

                if (nums[pivot] < target)
                {
                    l = pivot + 1;
                }
                else
                {
                    r = pivot;
                }
            }

            return l;
        }
    }
}
