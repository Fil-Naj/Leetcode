using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0004 : ISolution
    {
        public string Name => "Median of Two Sorted Arrays";
        public string Description => "Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums1 = new int[] { 1, 2 };
            var nums2 = new int[] { 3, 4 };
            var result = FindMedianSortedArrays(nums1, nums2);

            // Prettify it
            Console.WriteLine($"Input: nums1 = {nums1}, nums2 = {nums2}");
            Console.WriteLine($"Output: {result}");
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var joined = nums1.Concat(nums2).OrderBy(n => n).ToList();
            return joined.Count % 2 == 0 ? 
                (double)(joined[joined.Count / 2 - 1] + joined[joined.Count / 2]) / 2 :
                joined[joined.Count / 2];
        }
    }
}
