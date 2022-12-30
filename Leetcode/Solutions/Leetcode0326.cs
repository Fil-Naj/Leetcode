using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0326 : ISolution
    {
        public string Name => "Power of Three";
        public string Description => "Given an integer n, return true if it is a power of three. Otherwise, return false.";

        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            int n = 27;
            var result = IsPowerOfThree(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public static bool IsPowerOfThree(int n)
        {
            return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;
        }
    }
}
