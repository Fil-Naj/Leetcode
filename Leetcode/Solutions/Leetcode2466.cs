using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2466 : ISolution
    {
        public string Name => "Divide Array Into Arrays With Max Difference";
        public string Description => "You are given an integer array nums of size n and a positive integer k.\r\n\r\nDivide the array into one or more arrays of size 3 satisfying the following conditions:\r\n\r\n    Each element of nums should be in exactly one array.\r\n    The difference between any two elements in one array is less than or equal to k.\r\n\r\nReturn a 2D array containing all the arrays. If it is impossible to satisfy the conditions, return an empty array. And if there are multiple answers, return any of them.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 4, 2, 9, 8, 2, 12, 7, 12, 10, 5, 8, 5, 5, 7, 9, 2, 5, 11 };
            var k = 14;
            var result = DivideArray(nums, k);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}, target = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[][] DivideArray(int[] nums, int k)
        {
            Array.Sort(nums);
            var result = new List<int[]>();
            for (var i = 0; i < nums.Length; i += 3)
            {
                if (nums[i + 2] - nums[i] > k) return [];

                result.Add([nums[i], nums[i + 1], nums[i + 2]]);
            }

            return [.. result];
        }
    }
}
