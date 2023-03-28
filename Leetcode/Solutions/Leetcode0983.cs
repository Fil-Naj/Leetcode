using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0983 : ISolution
    {
        public string Name => "Minimum Cost For Tickets";
        public string Description => "You have planned some train traveling one year in advance. The days of the year in which you will travel are given as an integer array days. Each day is an integer from 1 to 365.\r\n\r\nTrain tickets are sold in three different ways:\r\n\r\n    a 1-day pass is sold for costs[0] dollars,\r\n    a 7-day pass is sold for costs[1] dollars, and\r\n    a 30-day pass is sold for costs[2] dollars.\r\n\r\nThe passes allow that many days of consecutive travel.\r\n\r\n    For example, if we get a 7-day pass on day 2, then we can travel for 7 days: 2, 3, 4, 5, 6, 7, and 8.\r\n\r\nReturn the minimum number of dollars you need to travel every day in the given list of days.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var days = new int[] { 1, 4, 6, 7, 8, 20 };
            var costs = new int[] { 2, 7, 15 };
            var result = MincostTickets(days, costs);

            // Prettify
            Console.WriteLine($"Input: days = {days.GetString()}, costs = {costs}");
            Console.WriteLine($"Output: {result}");
        }

        public int MincostTickets(int[] days, int[] costs)
        {
            int[] dp = new int[days.Length];
            Array.Fill(dp, int.MaxValue);

            int[] tickets = new int[] { 1, 7, 30 };

            int Dfs(int i)
            {
                if (i == days.Length)
                    return 0;
                if (dp[i] != int.MaxValue)
                    return dp[i];

                for (int c = 0; c < 3; c++)
                {
                    int j = i;
                    while (j < days.Length && days[j] < days[i] + tickets[c])
                    {
                        j++;
                    }
                    dp[i] = Math.Min(dp[i], costs[c] + Dfs(j));
                }

                return dp[i];
            }

            return Dfs(0);
        }
    }
}
