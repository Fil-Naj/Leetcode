using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0540 : ISolution
    {
        public string Name => "Single Element in a Sorted Array";
        public string Description => "You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once.\r\n\r\nReturn the single element that appears only once.\r\n\r\nYour solution must run in O(log n) time and O(1) space.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 3, 3, 7, 7, 10, 11, 11 };
            var result = SingleNonDuplicate(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int SingleNonDuplicate(int[] nums)
        {
            var l = 0;
            var r = nums.Length - 1;

            if (nums.Length == 1) return nums[0];

            if (nums[l] != nums[1]) return nums[l];
            if (nums[r] != nums[r - 1]) return nums[r];

            while (l + 1 < r)
            {
                int pivot = (l + r) >> 1;

                var num = nums[pivot];
                var isEven = pivot % 2 == 0;

                if (num == nums[pivot + 1])
                {
                    if (isEven)
                    {
                        l = pivot;
                    }
                    else
                    {
                        r = pivot;
                    }
                }
                else if (num == nums[pivot - 1])
                    if (isEven)
                    {
                        r = pivot;
                    }
                    else
                    {
                        l = pivot;
                    }
                else return num;
            }

            return nums[l];
        }
    }
}
