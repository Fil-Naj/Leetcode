using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0279 : ISolution
    {
        public string Name => "Perfect Squares";
        public string Description => "Given an integer n, return the least number of perfect square numbers that sum to n.\r\n\r\nA perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 13;
            var result = NumSquares(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        // Constaint is 1 <= n <= 10_000. To reach upper limit, max base is 100
        private static readonly int[] PerfectSquares = BuildPerfectSquares();

        public int NumSquares(int n)
        {
            if (n == 1) return 1;

            var count = int.MaxValue;
            var startIndex = Array.BinarySearch(PerfectSquares, n);
            for (int i = startIndex > 0 ? startIndex : -2 - startIndex; i >= 0; i--)
            {
                var possible = n / PerfectSquares[i];
                if (possible > 0)
                {
                    var next = NumSquares(n - possible * PerfectSquares[i]);
                    count = Math.Min(count, possible + next);
                }
                
            }

            return count == int.MaxValue ? 0 : count;
        }

        private static int[] BuildPerfectSquares()
        {
            var perfectSquares = new int[100];
            for (var i = 1; i <= perfectSquares.Length; i++)
                perfectSquares[i - 1] = i * i;

            return perfectSquares;
        }
    }
}
