using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0198 : ISolution
    {
        public string Name => "House Robber";
        public string Description => "You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.\r\n\r\nGiven an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 2, 3, 1 };
            var result = Rob(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // DP woo!!!
        public int Rob(int[] nums)
        {
            int pre = 0; int cur = 0;
            foreach (int num in nums)
            {
                int temp = Math.Max(pre + num, cur);
                pre = cur;
                cur = temp;
            }
            return cur;
        }
    }
}
