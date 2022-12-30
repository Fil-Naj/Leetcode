using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0338 : ISolution
    {
        public string Name => "Counting Bits";
        public string Description => "Given an integer n, return an array ans of length n + 1 such that for each i (0 <= i <= n), ans[i] is the number of 1's in the binary representation of i.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 6;
            var result = CountBits(n);

            // Prettify
            Console.WriteLine($"Input:, n = {n}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] CountBits(int n)
        {
            int length = n + 1;
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = CountNumberOf1s(i);
            }

            return result;
        }

        private int CountNumberOf1s(int x)
        {
            x = (x & (0x55555555)) + ((x >> 1) & (0x55555555));
            x = (x & (0x33333333)) + ((x >> 2) & (0x33333333));
            x = (x & (0x0f0f0f0f)) + ((x >> 4) & (0x0f0f0f0f));
            x = (x & (0x00ff00ff)) + ((x >> 8) & (0x00ff00ff));
            x = (x & (0x0000ffff)) + ((x >> 16) & (0x0000ffff));
            return x;
        }
    }
}
