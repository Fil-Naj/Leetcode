using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2360 : ISolution
    {
        public string Name => "Longest Cycle in a Graph";
        public string Description => "You are given a directed graph of n nodes numbered from 0 to n - 1, where each node has at most one outgoing edge.\r\n\r\nThe graph is represented with a given 0-indexed array edges of size n, indicating that there is a directed edge from node i to node edges[i]. If there is no outgoing edge from node i, then edges[i] == -1.\r\n\r\nReturn the length of the longest cycle in the graph. If no cycle exists, return -1.\r\n\r\nA cycle is a path that starts and ends at the same node.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var edges = new int[] { 3, 3, 4, 2, 3 };
            var result = LongestCycle(edges);

            // Prettify
            Console.WriteLine($"Input: edges = {edges.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestCycle(int[] edges)
        {
            // So plan is to visit all nodes!
            // We will start at n = 0
            // As one node can only travel to one other node, we will DFS
            // We will keep track of the current path using a dictionary
            // The key will be the index n, and the value will be the position in the path at which the node was encountered 
            // E.g., 1st = 0, 2nd = 1, etc.
            // We will also keep track of globally visited nodes so we do not find the same loop more than once
            // Iterate through every node from 0 to n - 1
            // If visited in previous dfs, skip. We have already explored all future possible paths
            // No loops, then return -1
            var result = -1;
            HashSet<int> globallyVisited = new();

            for (int i  = 0; i < edges.Length; i++)
            {
                var node = i;
                if (globallyVisited.Contains(node)) continue;

                var distance = 0;
                Dictionary<int, int> pathVisited = new() { { node, distance } };
                globallyVisited.Add(node);

                while (edges[node] > -1)
                {
                    var dest = edges[node];
                    distance++;

                    if (pathVisited.TryGetValue(dest, out var dist))
                    {
                        result = Math.Max(result, distance - dist);
                        break;
                    }

                    if (globallyVisited.Contains(dest)) break;

                    pathVisited.Add(dest, distance);
                    globallyVisited.Add(dest);

                    node = dest;
                }
            }

            return result;
        }
    }
}
