using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0209 : ISolution
    {
        public string Name => "Minimum Size Subarray Sum";
        public string Description => "Given an array of positive integers nums and a positive integer target, return the minimal length of a\r\nsubarray\r\nwhose sum is greater than or equal to target. If there is no such subarray, return 0 instead.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var target = 7;
            var nums = new int[] { 1, 4, 4 };
            var result = MinSubArrayLen(target, nums);

            // Prettify
            Console.WriteLine($"Input: target = {target}, nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinSubArrayLen(int target, int[] nums)
        {
            var smallest = int.MaxValue;

            var r = 0;

            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum >= target)
                {
                    var current = i - r + 1;

                    while (sum >= target)
                    {
                        sum -= nums[r];
                        r++;
                        current--;
                    }

                    smallest = Math.Min(smallest, current + 1);
                }
            }

            return smallest == int.MaxValue ? 0 : smallest;
        }
    }
}
