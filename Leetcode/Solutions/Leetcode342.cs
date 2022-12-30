using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode342 : ISolution
    {
        public string Name => "Power of Four";
        public string Description => "Given an integer n, return true if it is a power of four. Otherwise, return false.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            int n = 16;
            var result = IsPowerOfFour(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public static bool IsPowerOfFour(int n)
        {
            var power = 4;
            while (power < n)
                power *= 4;
            return power == n;
        }
    }
}
