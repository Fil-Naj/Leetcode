using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode976 : ISolution
    {
        public string Name => "Largest Perimeter Triangle";
        public string Description => "Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[] { 2, 1, 2 };
            var result = LargestPerimeter(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LargestPerimeter(int[] nums)
        {
            var sorted = nums.OrderByDescending(n => n).ToArray();

            for (int i = 0; i < sorted.Length - 2; i++)
            {
                if (IsLegitTriangle(sorted[i + 2], sorted[i + 1], sorted[i]))
                    return sorted[i] + sorted[i + 1] + sorted[i + 2];
            }

            return 0;
        }

        public bool IsLegitTriangle(int x, int y, int z)
        {
            return (x + y) > z;
        }
    }
}
