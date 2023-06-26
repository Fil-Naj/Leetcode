using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0714 : ISolution
    {
        public string Name => "Best Time to Buy and Sell Stock with Transaction Fee";
        public string Description => "You are given an array prices where prices[i] is the price of a given stock on the ith day, and an integer fee representing a transaction fee.\r\n\r\nFind the maximum profit you can achieve. You may complete as many transactions as you like, but you need to pay the transaction fee for each transaction.\r\n\r\nNote: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var prices = new int[] { 1, 3, 2, 8, 4, 9 };
            var fee = 2;
            var result = MaxProfit(prices, fee);

            // Prettify
            Console.WriteLine($"Input: prices = {prices.GetString()}, fee = {fee}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxProfit(int[] prices, int fee)
        {
            var buy = int.MinValue;
            var sell = 0;

            foreach (var price in prices)
            {
                buy = Math.Max(buy, sell - price);
                sell = Math.Max(sell, buy + price - fee);
            }

            return sell;
        }
    }
}
