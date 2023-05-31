using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0785 : ISolution
    {
        public string Name => "Is Graph Bipartite?";
        public string Description => "There is an undirected graph with n nodes, where each node is numbered between 0 and n - 1. You are given a 2D array graph, where graph[u] is an array of nodes that node u is adjacent to. More formally, for each v in graph[u], there is an undirected edge between node u and node v. The graph has the following properties:\r\n\r\n    There are no self-edges (graph[u] does not contain u).\r\n    There are no parallel edges (graph[u] does not contain duplicate values).\r\n    If v is in graph[u], then u is in graph[v] (the graph is undirected).\r\n    The graph may not be connected, meaning there may be two nodes u and v such that there is no path between them.\r\n\r\nA graph is bipartite if the nodes can be partitioned into two independent sets A and B such that every edge in the graph connects a node in set A and a node in set B.\r\n\r\nReturn true if and only if it is bipartite.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var graph = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 0, 2 },
                new int[] { 0, 1, 3 },
                new int[] { 0, 2 },
            };
            var result = IsBipartite(graph);

            // Prettify

            Console.WriteLine($"Input: graph = {string.Join(", ", graph.Select(r => r.GetString()))}");
            Console.WriteLine($"Output: {result}");
        }

        public bool IsBipartite(int[][] graph)
        {
            var n = graph.Length;
            bool?[] colours = new bool?[graph.Length];

            Queue<int> queue = new();

            bool Bfs(int n)
            {
                queue.Enqueue(n);
                colours[n] = true;

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();

                    foreach (var edge in graph[node])
                    {
                        if (!colours[edge].HasValue)
                        {
                            colours[edge] = !colours[node];
                            queue.Enqueue(edge);
                        }
                        else
                        {
                            // Colours between touching nodes are the same, therefore not bipartite
                            if (colours[edge] == colours[node])
                                return false;
                        }
                    }
                }

                return true;
            }

            for (int i = 0; i < n; i++)
            {
                if (colours[i].HasValue) continue;

                if (!Bfs(i)) return false;
            }


            return true;
        }
    }
}
