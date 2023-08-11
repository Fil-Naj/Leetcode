using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0518 : ISolution
    {
        public string Name => "Coin Change II";
        public string Description => "You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.\r\n\r\nReturn the number of combinations that make up that amount. If that amount of money cannot be made up by any combination of the coins, return 0.\r\n\r\nYou may assume that you have an infinite number of each kind of coin.\r\n\r\nThe answer is guaranteed to fit into a signed 32-bit integer.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var amount = 3;
            var coins = new int[] { 2 };
            var result = Change(amount, coins);

            // Prettify
            Console.WriteLine($"Input: amount = {amount}, coins = {coins.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int Change(int amount, int[] coins)
        {
            var dp = new int[amount + 1];
            dp[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = coin; i <= amount; i++)
                    dp[i] += dp[i - coin];
            }

            return dp[amount];
        }
    }
}
