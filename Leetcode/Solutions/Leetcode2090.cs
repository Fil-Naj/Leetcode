using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2090 : ISolution
    {
        public string Name => "K Radius Subarray Averages";
        public string Description => "You are given a 0-indexed array nums of n integers, and an integer k.\r\n\r\nThe k-radius average for a subarray of nums centered at some index i with the radius k is the average of all elements in nums between the indices i - k and i + k (inclusive). If there are less than k elements before or after the index i, then the k-radius average is -1.\r\n\r\nBuild and return an array avgs of length n where avgs[i] is the k-radius average for the subarray centered at index i.\r\n\r\nThe average of x elements is the sum of the x elements divided by x, using integer division. The integer division truncates toward zero, which means losing its fractional part.\r\n\r\n    For example, the average of four elements 2, 3, 1, and 5 is (2 + 3 + 1 + 5) / 4 = 11 / 4 = 2.75, which truncates to 2.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 7, 4, 3, 9, 1, 8, 5, 2, 6 };
            var k = 3;
            var result = GetAverages(nums, k);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] GetAverages(int[] nums, int k)
        {
            if (k == 0) return nums;

            var n = nums.Length;
            var result = new int[n];
            Array.Fill(result, -1);

            if (2 * k >= n) return result;
            
            var sums = new long[n + 1];
            for (int i = 1; i < n + 1; i++)
            {
                sums[i] = sums[i - 1] + nums[i - 1];
            }

            for (int i = k; i < n - k; i++)
            {
                result[i] = (int)((sums[i + k + 1] - sums[i - k]) / (2 * k + 1));
            }

            return result;
        }
    }
}
