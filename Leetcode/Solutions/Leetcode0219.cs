using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0219 : ISolution
    {
        public string Name => "Contains Duplicate II";
        public string Description => "Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 3, 2, 4 };
            var k = 6;
            var result = ContainsNearbyDuplicate(nums, k);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> numbersToIndex = new();
            for (int j = 0; j < nums.Length; j++)
            {
                if (numbersToIndex.TryGetValue(nums[j], out var i))
                {
                    if (j - i <= k)
                        return true;
                    numbersToIndex[nums[j]] = j;
                }
                else
                {
                    numbersToIndex.Add(nums[j], j);
                }
            }
            return false;
        }
    }
}
