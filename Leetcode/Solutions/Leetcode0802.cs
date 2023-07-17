using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0802 : ISolution
    {
        public string Name => "Find Eventual Safe States";
        public string Description => "There is a directed graph of n nodes with each node labeled from 0 to n - 1. The graph is represented by a 0-indexed 2D integer array graph where graph[i] is an integer array of nodes adjacent to node i, meaning there is an edge from node i to each node in graph[i].\r\n\r\nA node is a terminal node if there are no outgoing edges. A node is a safe node if every possible path starting from that node leads to a terminal node (or another safe node).\r\n\r\nReturn an array containing all the safe nodes of the graph. The answer should be sorted in ascending order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[][] 
            { 
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 5 },
                new int[] { 0 },
                new int[] { 5 },
                Array.Empty<int>(),
                Array.Empty<int>(),
            };
            var target = 6;
            var result = EventualSafeNodes(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString(delimiter: ", ")}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> EventualSafeNodes(int[][] graph)
        {
            var terminalNodes = new HashSet<int>();
            var visited = new HashSet<int>();
            return Enumerable.Range(0, graph.Length).Where(IsTerminal).ToArray();

            bool IsTerminal(int node)
            {
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    if (graph[node].All(IsTerminal))
                    {
                        terminalNodes.Add(node);
                    }
                }

                return terminalNodes.Contains(node);
            }
        }
    }
}
