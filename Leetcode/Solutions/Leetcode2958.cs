using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2958 : ISolution
    {
        public string Name => "Length of Longest Subarray With at Most K Frequency";
        public string Description => "You are given an integer array nums and an integer k.\r\n\r\nThe frequency of an element x is the number of times it occurs in an array.\r\n\r\nAn array is called good if the frequency of each element in this array is less than or equal to k.\r\n\r\nReturn the length of the longest good subarray of nums.\r\n\r\nA subarray is a contiguous non-empty sequence of elements within an array.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 2, 3, 1, 2, 3, 1, 2 };
            var k = 2;
            var result = MaxSubarrayLength(nums, k);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxSubarrayLength(int[] nums, int k)
        {
            Dictionary<int, int> freq = [];
            var l = 0;
            var r = 0;
            var maxLength = 0;
            var n = nums.Length;

            while (r < n)
            {
                var num = nums[r++];
                if (!freq.TryGetValue(num, out int value))
                {
                    value = 0;
                    freq[num] = value;
                }
                freq[num] = ++value;

                if (freq[num] <= k)
                {
                    maxLength = Math.Max(maxLength, r - l);
                }
                else
                {
                    while (freq[num] > k)
                    {
                        freq[nums[l]]--;
                        l++;
                    }
                }
            }

            return maxLength;
        }
    }
}
