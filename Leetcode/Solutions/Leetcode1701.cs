using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1701 : ISolution
    {
        public string Name => "Average Waiting Time";
        public string Description => "There is a restaurant with a single chef. You are given an array customers, where customers[i] = [arrivali, timei]:\r\n\r\n    arrivali is the arrival time of the ith customer. The arrival times are sorted in non-decreasing order.\r\n    timei is the time needed to prepare the order of the ith customer.\r\n\r\nWhen a customer arrives, he gives the chef his order, and the chef starts preparing it once he is idle. The customer waits till the chef finishes preparing his order. The chef does not prepare food for more than one customer at a time. The chef prepares food for customers in the order they were given in the input.\r\n\r\nReturn the average waiting time of all customers. Solutions within 10-5 from the actual answer are considered accepted.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[][] customers = [[2, 3], [6, 3], [7, 5], [11, 3], [15, 2], [18, 1]];
            var result = AverageWaitingTime(customers);

            // Prettify
            Console.WriteLine($"Input: customers = {customers.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public double AverageWaitingTime(int[][] customers)
        {
            if (customers.Length == 1) return 0;

            var t = customers[0][0] + customers[0][1];
            double waitTime = customers[0][1];

            for (var i = 1; i < customers.Length; i++)
            {
                var custStartTime = customers[i][0];
                var custOrderTime = customers[i][1];

                waitTime += Math.Max(t - custStartTime, 0) + custOrderTime;

                t = Math.Max(t, custStartTime) + custOrderTime;
            }

            return waitTime / customers.Length;
        }
    }
}
