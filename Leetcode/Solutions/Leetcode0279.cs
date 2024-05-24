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

        // Lagrange's Four Square theorem states that "every natural number can be represented as a sum of four non-negative integer squares"
        // Therefore, only four possible results: 1, 2, 3, 4
        public int NumSquares(int n)
        {
            // If n is perfect square, return 1
            if (IsPerfectSquare(n)) return 1;

            // The result is 4 if and only if n can be written in the form of 4^k*(8*m + 7), as per
            // Legendre's three-square theorem.

            // Reduce to (8*m + 7)
            while (n % 4 == 0) 
                n /= 4;

            // If the remainder of n is 7, therefore satisfies (8*m + 7)
            // Therefore, n satisfies 4^k*(8*m + 7) and the answer is 4
            if (n % 8 == 7)
                return 4;

            // Check whether 2 is the result
            int sqrtN = (int)Math.Sqrt(n);
            for (int i = 1; i <= sqrtN; i++)
            {
                if (IsPerfectSquare(n - i * i))
                {
                    return 2;
                }
            }

            // In all other cases, return 3
            return 3;
        }

        private bool IsPerfectSquare(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }
    }
}
