using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0918 : ISolution
    {
        public string Name => "Maximum Sum Circular Subarray";
        public string Description => "Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.\r\n\r\nA circular array means the end of the array connects to the beginning of the array. Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].\r\n\r\nA subarray may only include each element of the fixed buffer nums at most once. Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, -2, 3, -2 };
            var result = MaxSubarraySumCircular(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxSubarraySumCircular(int[] nums)
        {
            var total = 0; 
            var maxSum = nums[0]; 
            var currentMax = 0; 
            var minSum = nums[0]; 
            var currentMin = 0;
            foreach (var num in nums)
            {
                currentMax = Math.Max(currentMax + num, num);
                maxSum = Math.Max(maxSum, currentMax);
                currentMin = Math.Min(currentMin + num, num);
                minSum = Math.Min(minSum, currentMin);

                total += num;
            }
            return maxSum > 0 ? Math.Max(maxSum, total - minSum) : maxSum;
        }
    }
}
