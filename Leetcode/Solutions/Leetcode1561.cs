using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1561 : ISolution
    {
        public string Name => "Maximum Number of Coins You Can Get";
        public string Description => "There are 3n piles of coins of varying size, you and your friends will take piles of coins as follows:\r\n\r\n    In each step, you will choose any 3 piles of coins (not necessarily consecutive).\r\n    Of your choice, Alice will pick the pile with the maximum number of coins.\r\n    You will pick the next pile with the maximum number of coins.\r\n    Your friend Bob will pick the last pile.\r\n    Repeat until there are no more piles of coins.\r\n\r\nGiven an array of integers piles where piles[i] is the number of coins in the ith pile.\r\n\r\nReturn the maximum number of coins that you can have.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var piles = new int[] { 9, 8, 7, 6, 5, 1, 2, 3, 4 };
            var result = MaxCoins(piles);

            // Prettify
            Console.WriteLine($"Input: piles = {piles.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxCoins(int[] piles)
        {
            Array.Sort(piles, (a, b) => b - a);
            var n = piles.Length / 3;
            var l = piles.Length - n;
            var sum = 0;
            for (int i = 1; i < l; i += 2)
            {
                sum += piles[i];
            }

            return sum;
        }
    }
}
