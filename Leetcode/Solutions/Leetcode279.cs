using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode279 : ISolution
    {
        public string Name => "Perfect Squares";
        public string Description => "Given an integer n, return the least number of perfect square numbers that sum to n.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 6;
            var result = NumSquares(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public int NumSquares(int n)
        {
            for (int i = 1; i < 32; i++)
                Console.Write($"{i}, ");
            return 0;
        }
    }
}
