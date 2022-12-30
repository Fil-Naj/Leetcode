using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    // Inspiration (Source): https://just4once.gitbooks.io/leetcode-notes/content/leetcode/binary-search/718-maximum-length-of-repeated-subarray.html
    public class Leetcode0718 : ISolution
    {
        public string Name => "Maximum Length of Repeated Subarray";
        public string Description => "Given two integer arrays nums1 and nums2, return the maximum length of a subarray that appears in both arrays.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums1 = new int[] { 1, 2, 3, 2, 1 };
            var nums2 = new int[] { 3, 2, 1, 4, 7 };
            var result = FindLength(nums1, nums2);

            // Prettify
            Console.WriteLine($"Input: nums1 = {nums1.GetString()}, nums2 = {nums2.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Utilises Dynamic Programming
        // Time: O(nm), Space: O(nm)
        public int FindLength(int[] nums1, int[] nums2)
        {
            int m = nums1.Length;
            int n = nums2.Length;

            int[,] dp = new int[m + 1, n + 1];

            int result = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (nums1[i] == nums2[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                        result = Math.Max(result, dp[i + 1, j + 1]);
                    }
                }
            }
            return result;
        }
    }
}
