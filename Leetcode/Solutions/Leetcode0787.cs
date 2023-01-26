using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0787 : ISolution
    {
        public string Name => "Cheapest Flights Within K Stops";
        public string Description => "There are n cities connected by some number of flights. You are given an array flights where flights[i] = [fromi, toi, pricei] indicates that there is a flight from city fromi to city toi with cost pricei.\r\n\r\nYou are also given three integers src, dst, and k, return the cheapest price from src to dst with at most k stops. If there is no such route, return -1.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 4;
            var flights = new int[][] 
            { 
                new int[] { 0, 1, 100 },
                new int[] { 1, 2, 100 },
                new int[] { 2, 0, 100 },
                new int[] { 1, 3, 600 },
                new int[] { 2, 3, 200 },
            };
            var src = 0;
            var dst = 3;
            var k = 1;
            var result = FindCheapestPrice(n, flights, src, dst, k);

            // Prettify
            Console.WriteLine($"Input: n = {n}, flights = {flights.GetString()}, src = {src}, dst ={dst}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        // Implementation of Bellman-Ford
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            var prices = new int[n];
            Array.Fill(prices, int.MaxValue);

            prices[src] = 0;

            for (int i = 0; i < k + 1; i++)
            {
                int[] tempPrices = new int[n];
                prices.CopyTo(tempPrices, 0);

                foreach (var flight in flights)
                {
                    var from = flight[0]; var to = flight[1]; var cost = flight[2];

                    if (prices[from] == int.MaxValue) continue;

                    if (prices[from] + cost < tempPrices[to])
                    {
                        tempPrices[to] = prices[from] + cost;
                    }
                }

                prices = tempPrices;
            }

            return prices[dst] == int.MaxValue ? - 1 : prices[dst];
        }
    }
}
