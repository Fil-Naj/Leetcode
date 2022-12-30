using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0797 : ISolution
    {
        public string Name => "All Paths From Source to Target";
        public string Description => "Given a directed acyclic graph (DAG) of n nodes labeled from 0 to n - 1, find all possible paths from node 0 to node n - 1 and return them in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var graph = new int[][] 
            { 
                new int[] { 1, 2 },
                new int[] { 3 },
                new int[] { 3 },
                new int[] { }
            };
            var result = AllPathsSourceTarget(graph);

            // Prettify
            Console.WriteLine($"Input: graph = {graph.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            int n = graph.Length;
            var visited = new List<int> { 0 };
            List<IList<int>> result = new();

            Queue<(int node, List<int> visited)> queue = new();
            queue.Enqueue((0, visited));

            while (queue.Count > 0) 
            {
                var node = queue.Dequeue();

                if (node.node == n - 1)
                {
                    result.Add(node.visited);
                    continue;
                }

                foreach (var nextNode in graph[node.node])
                {
                    if (!node.visited.Contains(nextNode))
                    {
                        List<int> nextVisited = new(node.visited);
                        nextVisited.Add(nextNode);
                        queue.Enqueue((nextNode, nextVisited));
                    }
                }
            }

            return result;
        }
    }
}
