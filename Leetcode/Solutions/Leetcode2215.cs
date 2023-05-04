using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2215 : ISolution
    {
        public string Name => "Find the Difference of Two Arrays";
        public string Description => "Given two 0-indexed integer arrays nums1 and nums2, return a list answer of size 2 where:\r\n\r\n    answer[0] is a list of all distinct integers in nums1 which are not present in nums2.\r\n    answer[1] is a list of all distinct integers in nums2 which are not present in nums1.\r\n\r\nNote that the integers in the lists may be returned in any order.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var num1 = new int[] { 3, 2, 4 };
            var num2 = new int[] { 3, 2, 4 };

            var result = FindDifference(num1, num2);

            // Prettify
            Console.WriteLine($"Input: num1 = {num1.GetString()}, target = {num2.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            HashSet<int> nums1Set = new HashSet<int>(nums1);
            HashSet<int> nums2Set = new HashSet<int>(nums2);

            return new List<IList<int>>()
            {
                nums1Set.Where((a) => !nums2Set.Contains(a)).ToList(),
                nums2Set.Where((a) => !nums1Set.Contains(a)).ToList(),
            };
        }
    }
}
