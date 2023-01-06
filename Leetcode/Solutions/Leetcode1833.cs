using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1833 : ISolution
    {
        public string Name => "Maximum Ice Cream Bars";
        public string Description => "At the store, there are n ice cream bars. You are given an array costs of length n, where costs[i] is the price of the ith ice cream bar in coins. The boy initially has coins coins to spend, and he wants to buy as many ice cream bars as possible. \r\n\r\nReturn the maximum number of ice cream bars the boy can buy with coins coins.\r\n\r\nNote: The boy can buy the ice cream bars in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var costs = new int[] { 1, 3, 2, 4, 1 };
            var coins = 7;
            var result = MaxIceCream(costs, coins);

            // Prettify
            Console.WriteLine($"Input: costs = {costs.GetString()}, coins = {coins}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);

            int result = 0;

            while (result < costs.Length && coins >= costs[result]) 
            {
                coins -= costs[result];
                result++;
            }

            return result;
        }
    }
}
