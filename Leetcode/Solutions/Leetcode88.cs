using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode88 : ISolution
    {
        public string Name => "Merge Sorted Array";
        public string Description => "ou are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.\r\n\r\nMerge nums1 and nums2 into a single array sorted in non-decreasing order.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
            var nums2 = new int[] { 2, 5, 6 };
            int m = 3;
            int n = 3;

            // Prettify
            Console.WriteLine($"Input: nums1 = {nums1.GetString()}, nums1 = {nums2.GetString()}");
            Merge(nums1, m, nums2, n);
            Console.WriteLine($"Output: {nums1.GetString()}");
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index = 0;
            int l = 0;
            int r = 0;
            var nums1_actual = nums1.Take(m).ToArray();
            while (index < nums1.Length)
            {
                if (l == m)
                {
                    nums1[index] = nums2[r];
                    r++;
                }
                else if (r == n)
                {
                    nums1[index] = nums1_actual[l];
                    l++;
                }
                else if (nums1_actual[l] < nums2[r])
                {
                    nums1[index] = nums1_actual[l];
                    l++;
                }
                else
                {
                    nums1[index] = nums2[r];
                    r++;
                }
                index++;
            }
        }
    }
}
