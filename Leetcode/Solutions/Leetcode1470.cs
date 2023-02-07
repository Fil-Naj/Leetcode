using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1470 : ISolution
    {
        public string Name => "Shuffle the Array";
        public string Description => "Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].\r\n\r\nReturn the array in the form [x1,y1,x2,y2,...,xn,yn].";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 2, 5, 1, 3, 4, 7 };
            var n = 3;
            var result = Shuffle(nums, n);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}, n = {n}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] Shuffle(int[] nums, int n)
        {
            var result = new int[nums.Length];
            for (int i = 0; i < n; i++)
            {
                result[i * 2] = nums[i];
                result[i * 2 + 1] = nums[i + n];
            }

            return result;
        }
    }
}
