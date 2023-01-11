using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1443 : ISolution
    {
        public string Name => "Minimum Time to Collect All Apples in a Tree";
        public string Description => "Given an undirected tree consisting of n vertices numbered from 0 to n-1, which has some apples in their vertices. You spend 1 second to walk over one edge of the tree. Return the minimum time in seconds you have to spend to collect all apples in the tree, starting at vertex 0 and coming back to this vertex.\r\n\r\nThe edges of the undirected tree are given in the array edges, where edges[i] = [ai, bi] means that exists an edge connecting the vertices ai and bi. Additionally, there is a boolean array hasApple, where hasApple[i] = true means that vertex i has an apple; otherwise, it does not have any apple.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 7;
            var edges = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 4 },
                new int[] { 1, 5 },
                new int[] { 2, 3 },
                new int[] { 2, 6 },
            };
            var hasApple = new List<bool>() { false, false, true, false, true, true, false };
            var result = MinTime(n, edges, hasApple);

            // Prettify
            Console.WriteLine($"Input: n = {n}, edges = {edges.GetString()}, hasApple = {hasApple.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinTime(int n, int[][] edges, IList<bool> hasApple)
        {
            List<int>[] adj = new List<int>[n];
            var appleCount = 0;
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
                appleCount += hasApple[i] ? 1 : 0;
            }

            if (appleCount == 0) return 0;

            foreach (var edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            int Dfs(int to, int from)
            {
                var time = 0;

                foreach (var child in adj[to])
                {
                    if (child == from) continue;

                    var childTime = Dfs(child, to);

                    if (childTime > 0 || hasApple[child])
                    {
                        time += 2 + childTime;
                    }
                }

                return time;
            };

            return Dfs(0, -1);
        }
    }
}
