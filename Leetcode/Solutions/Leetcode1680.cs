using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1680 : ISolution
    {
        public string Name => "Concatenation of Consecutive Binary Numbers";
        public string Description => "Given an integer n, return the decimal value of the binary string formed by concatenating the binary representations of 1 to n in order, modulo 109 + 7.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 12;
            var result = ConcatenatedBinary(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public int ConcatenatedBinary(int n)
        {
            long result = 0;
            var modulo = 1000000007;
            for (int i = 1; i <= n; i++)
            {
                var length = Convert.ToString(i, 2).Length;
                result = result << length;
                result += i;
                result %= modulo;
            }
            return (int)result;
        }
    }
}
