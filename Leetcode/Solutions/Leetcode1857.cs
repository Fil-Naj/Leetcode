using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1857 : ISolution
    {
        public string Name => "Largest Color Value in a Directed Graph";
        public string Description => "There is a directed graph of n colored nodes and m edges. The nodes are numbered from 0 to n - 1.\r\n\r\nYou are given a string colors where colors[i] is a lowercase English letter representing the color of the ith node in this graph (0-indexed). You are also given a 2D array edges where edges[j] = [aj, bj] indicates that there is a directed edge from node aj to node bj.\r\n\r\nA valid path in the graph is a sequence of nodes x1 -> x2 -> x3 -> ... -> xk such that there is a directed edge from xi to xi+1 for every 1 <= i < k. The color value of the path is the number of nodes that are colored the most frequently occurring color along that path.\r\n\r\nReturn the largest color value of any valid path in the given graph, or -1 if the graph contains a cycle.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var colors = "abaca";
            //var edges = new int[][] 
            //{ 
            //    new int[] { 0, 1 },
            //    new int[] { 0, 2 },
            //    new int[] { 2, 3 },
            //    new int[] { 3, 4 },
            //};
            var colors = "a";
            var edges = new int[][]
            {
                new int[] { 0, 0 },
            };
            var result = LargestPathValue(colors, edges);

            // Prettify
            Console.WriteLine($"Input: colors = {colors}, edges = {string.Join(", ", edges.Select(e => e.GetString()))}");
            Console.WriteLine($"Output: {result}");
        }

        public int LargestPathValue(string colors, int[][] edges)
        {
            HashSet<int> visited = new();
            HashSet<int> path = new();
            Dictionary<int, List<int>> adj = new();
            var dp = new int[colors.Length, 26];

            foreach (var edge in edges)
            {
                var from = edge[0]; var to = edge[1];
                if (adj.ContainsKey(from))
                    adj[from].Add(to);
                else
                    adj[from] = new List<int>() { to };
            }

            var isLooping = false;
            int result = 0;

            int Dfs(int node)
            {
                if (path.Contains(node))
                {
                    isLooping = true;
                    return -1;
                }

                if (visited.Contains(node)) return 0;

                visited.Add(node);
                path.Add(node);

                var colour = colors[node] - 'a';
                dp[node, colour] = 1;

                var children = adj.TryGetValue(node, out var val) ? val : new List<int>();
                foreach (var child in children)
                {
                    if (Dfs(child) == -1) return -1;

                    for (int i = 0; i < 26; i++)
                    {
                        dp[node, i] = Math.Max(dp[node, i], dp[child, i] + (i == colour ? 1 : 0));
                    }
                }
                path.Remove(node);

                var res = 0;
                for (int i = 0; i < 26; i++)
                    res = Math.Max(dp[node, i], res);
                return res;
            }


            for (int i = 0; i < colors.Length; i++)
            {
                if (isLooping) return -1;

                path.Clear();
                result = Math.Max(Dfs(i), result);
            }

            return isLooping ? -1 : result;
        }
    }
}
