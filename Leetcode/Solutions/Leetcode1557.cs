using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1557 : ISolution
    {
        public string Name => "Minimum Number of Vertices to Reach All Nodes";
        public string Description => "Given a directed acyclic graph, with n vertices numbered from 0 to n-1, and an array edges where edges[i] = [fromi, toi] represents a directed edge from node fromi to node toi.\r\n\r\nFind the smallest set of vertices from which all nodes in the graph are reachable. It's guaranteed that a unique solution exists.\r\n\r\nNotice that you can return the vertices in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 6;
            var edges = new List<IList<int>>()
            {
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 2, 5 },
                new int[] { 3, 4 },
                new int[] { 4, 2 },
            };
            var result = FindSmallestSetOfVertices(n, edges);

            // Prettify
            Console.WriteLine($"Input: n = {n}, data = {string.Join(", ", edges.Select(e => e.GetString()))}, ");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
        {
            var result = new List<int>();
            var destinations = new HashSet<int>();

            for (int i = 0; i < edges.Count; i++)
                destinations.Add(edges[i][1]);

            for (int i = 0; i < n; i++)
                if (!destinations.Contains(i))
                    result.Add(i);

            return result;
        }
    }
}
