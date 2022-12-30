using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0350 : ISolution
    {
        public string Name => "Intersection of Two Arrays II";
        public string Description => "Given two integer arrays nums1 and nums2, return an array of their intersection. Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums1 = new int[] { 1, 2, 2, 1 };
            var nums2 = new int[] { 2, 2 };
            var result = Intersect_Linq(nums1, nums2);

            // Prettify
            Console.WriteLine($"Input: nums1 = {nums1.GetString()}, nums1 = {nums2.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> numbers = new();
            foreach (int num in nums1)
            {
                if (numbers.TryGetValue(num, out var _))
                    numbers[num]++;
                else
                    numbers.Add(num, 1);
            }

            var result = new List<int>();

            foreach (int num in nums2)
            {
                if (numbers.TryGetValue(num, out var count) && count > 0)
                {
                    result.Add(num);
                    numbers[num]--;
                }
            }

            return result.ToArray();
        }

        public int[] Intersect_Linq(int[] nums1, int[] nums2)
        {
            var intersect = nums1.Intersect(nums2);
            return intersect.ToArray();
        }
    }
}
