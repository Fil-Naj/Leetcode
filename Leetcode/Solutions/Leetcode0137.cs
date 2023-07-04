using System.IO.Pipes;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0137 : ISolution
    {
        public string Name => "Single Number II";
        public string Description => "Given an integer array nums where every element appears three times except for one, which appears exactly once. Find the single element and return it.\r\n\r\nYou must implement a solution with a linear runtime complexity and use only constant extra space.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 2, 2, 3, 2 };
            var result = SingleNumber(nums);

            // Prettify
            Console.WriteLine($"Input: {nameof(nums)} = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Bit Manipulation for the win (stolen solution)
        // Essentially, for every bit in the ints, we count the number of ones (1's) in that spot
        // We then mod that count by 3. If there is a remainder, then the single number has a 1 in that spot
        // The 1's are then stored in their correct spot in the `result` variable, which we return
        // Time: O(n), Space: O(1)
        // Very cool
        public int SingleNumber(int[] nums)
        {
            var result = 0;

            for (int i = 0; i < 32; i++)
            {
                var sum = 0;
                foreach (var num in nums)
                    sum += num >> i & 1;
                sum %= 3;
                result |= sum << i;
            }

            return result;
        }
    }
}
