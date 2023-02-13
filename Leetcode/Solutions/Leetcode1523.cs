using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1523 : ISolution
    {
        public string Name => "Count Odd Numbers in an Interval Range";
        public string Description => "Given two non-negative integers low and high. Return the count of odd numbers between low and high (inclusive).";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var low = 7;
            var high = 10;
            var result = CountOdds(low, high);

            // Prettify
            Console.WriteLine($"Input: low = {low}, high = {high}");
            Console.WriteLine($"Output: {result}");
        }

        public int CountOdds(int low, int high)
        {
            return (int)Math.Ceiling(((decimal)high - (decimal)low) / 2m) + (low % 2 == 1 && high % 2 == 1 ? 1 : 0);
        }
    }
}
