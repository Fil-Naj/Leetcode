using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0334 : ISolution
    {
        public string Name => "Increasing Triplet Subsequence";
        public string Description => "Given an integer array nums, return true if there exists a triple of indices (i, j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices exists, return false.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 2, 1, 5, 0, 4, 6 };
            var result = IncreasingTriplet(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;

            int i = int.MaxValue;
            int j = int.MaxValue;

            for (var n = 0; n < nums.Length; n++)
            {
                if (nums[n] <= i)
                    i = nums[n];
                else if (nums[n] <= j)
                    j = nums[n];
                else
                    return true;
            }
            return false;
        }
    }
}
