using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0121 : ISolution
    {
        public string Name => "Best Time to Buy and Sell Stock";
        public string Description => "You are given an array prices where prices[i] is the price of a given stock on the ith day.\r\n\r\nYou want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.\r\n\r\nReturn the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            // var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var prices = new int[] { 1, 2 };
            var result = MaxProfit(prices);

            // Prettify
            Console.WriteLine($"Input: prices = {prices.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Could have been simplified just to used pointers
        public int MaxProfit(int[] prices)
        {
            var n = prices.Length;
            if (n == 1) return 0;

            int profit = 0;

            int[] dp = new int[n];
            dp[0] = prices[0];

            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(dp[i - 1], prices[i]);
                if (prices[i] - dp[i] > profit)
                    profit = prices[i] - dp[i];
            }
            return profit;
        }
    }
}
