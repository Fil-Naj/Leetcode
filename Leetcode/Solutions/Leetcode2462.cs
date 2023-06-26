using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2462 : ISolution
    {
        public string Name => "Total Cost to Hire K Workers";
        public string Description => "You are given a 0-indexed integer array costs where costs[i] is the cost of hiring the ith worker.\r\n\r\nYou are also given two integers k and candidates. We want to hire exactly k workers according to the following rules:\r\n\r\n    You will run k sessions and hire exactly one worker in each session.\r\n    In each hiring session, choose the worker with the lowest cost from either the first candidates workers or the last candidates workers. Break the tie by the smallest index.\r\n        For example, if costs = [3,2,7,7,1,2] and candidates = 2, then in the first hiring session, we will choose the 4th worker because they have the lowest cost [3,2,7,7,1,2].\r\n        In the second hiring session, we will choose 1st worker because they have the same lowest cost as 4th worker but they have the smallest index [3,2,7,7,2]. Please note that the indexing may be changed in the process.\r\n    If there are fewer than candidates workers remaining, choose the worker with the lowest cost among them. Break the tie by the smallest index.\r\n    A worker can only be chosen once.\r\n\r\nReturn the total cost to hire exactly k workers.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var costs = new int[] { 17, 12, 10, 2, 7, 2, 11, 20, 8 };
            var k = 3;
            var candidates = 4;
            var result = TotalCost(costs, k, candidates);

            // Prettify
            Console.WriteLine($"Input: costs = {costs.GetString()}, k = {k}, candidates = {candidates}");
            Console.WriteLine($"Output: {result}");
        }

        public long TotalCost(int[] costs, int k, int candidates)
        {
            PriorityQueue<int, int> left = new();
            PriorityQueue<int, int> right = new();

            var l = 0; var r = costs.Length - 1;
            long totalCost = 0;
            while (k > 0)
            {
                while (left.Count < candidates && l <= r)
                {
                    left.Enqueue(costs[l], costs[l]);
                    l++;
                }

                while (right.Count < candidates && l <= r)
                {
                    right.Enqueue(costs[r], costs[r]);
                    r--;
                }

                var leftCost = left.TryPeek(out var le, out var _) ? le : int.MaxValue;
                var rightCost = right.TryPeek(out var ri, out var _) ? ri : int.MaxValue;

                if (leftCost <= rightCost)
                    totalCost += left.Dequeue();
                else
                    totalCost += right.Dequeue();

                k--;
            }

            return totalCost;
        }
    }
}
