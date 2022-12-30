using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode50 : ISolution
    {
        public string Name => "Pow(x, n)";
        public string Description => "Implement pow(x, n), which calculates x raised to the power n (i.e., x^n).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var x = 2.00;
            var n = 10;
            var result = MyPow(x, n);

            // Print stuff to make look nice
            Console.WriteLine($"Input: x = {x}, n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public double MyPow(double x, int n)
        {
            return Math.Pow(x, n);
        }
    }
}
