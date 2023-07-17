using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1514 : ISolution
    {
        public string Name => "Path with Maximum Probability";
        public string Description => "You are given an undirected weighted graph of n nodes (0-indexed), represented by an edge list where edges[i] = [a, b] is an undirected edge connecting the nodes a and b with a probability of success of traversing that edge succProb[i].\r\n\r\nGiven two nodes start and end, find the path with the maximum probability of success to go from start to end and return its success probability.\r\n\r\nIf there is no path from start to end, return 0. Your answer will be accepted if it differs from the correct answer by at most 1e-5.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 6;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 1, 2 },
                new int[] { 0, 2 },
            };
            var succProb = new double[] { 0.5, 0.5, 0.2 };
            var start = 0;
            var end = 2;
            var result = MaxProbability(n, edges, succProb, start, end);

            // Prettify
            Console.WriteLine($"Input: n = {n}, edges = {edges.GetString(delimiter: ", ")}, succProb = {succProb.GetString()}, start = {start}, end = {end}");
            Console.WriteLine($"Output: {result}");
        }

        public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
        {
            Dictionary<int, List<(int to, double prob)>> adj = new();
            for (int i = 0; i < succProb.Length; i++)
            {
                if (!adj.ContainsKey(edges[i][0]))
                    adj[edges[i][0]] = new();
                if (!adj.ContainsKey(edges[i][1]))
                    adj[edges[i][1]] = new();

                adj[edges[i][0]].Add((edges[i][1], succProb[i]));
                adj[edges[i][1]].Add((edges[i][0], succProb[i]));
            }

            // If start or end completely disconnected, return 0
            if (!adj.ContainsKey(start) || !adj.ContainsKey(end)) return 0;

            var probabilities = new double[n];
            probabilities[start] = 1;

            Queue<int> queue = new();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                foreach (var (to, prob) in adj[node])
                {
                    var newProb = probabilities[node] * prob;
                    if (newProb <= probabilities[to]) continue;

                    probabilities[to] = newProb;
                    queue.Enqueue(to);
                }
            }

            return probabilities[end];
        }
    }
}
