using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1137 : ISolution
    {
        public string Name => "N-th Tribonacci Number";
        public string Description => "The Tribonacci sequence Tn is defined as follows: \r\n\r\nT0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.\r\n\r\nGiven n, return the value of Tn.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 0;
            var result = Tribonacci(n);

            // Prettify
            Console.WriteLine($"Input: n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1 || n == 2) return 1;

            int?[] trib = new int?[n + 1];

            // Set the initial values
            trib[0] = 0; trib[1] = 1; trib[2] = 1;

            int Trib(int n)
            {
                if (trib[n].HasValue) return trib[n].Value;

                var result = Trib(n - 1) + Trib(n - 2) + Trib(n - 3);
                trib[n] = result;

                return result;
            }

            return Trib(n);
        }
    }
}
