using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1493 : ISolution
    {
        public string Name => "Longest Subarray of 1's After Deleting One Element";
        public string Description => "Given a binary array nums, you should delete one element from it.\r\n\r\nReturn the size of the longest non-empty subarray containing only 1's in the resulting array. Return 0 if there is no such subarray.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 0, 1, 1, 1, 0, 0, 1, 1, 0, 1 };
            var result = LongestSubarray(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestSubarray(int[] nums)
        {
            if (nums.Length == 1) return 0;

            var from = -1;
            var count = 0;
            var result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    count = i - from - 1;
                    from = i;
                }
                else
                {
                    count++;
                }

                result = Math.Max(count, result);
            }

            return result == nums.Length ? result - 1 : result;
        }
    }
}
