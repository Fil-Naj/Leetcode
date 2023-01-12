using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1519 : ISolution
    {
        public string Name => "Number of Nodes in the Sub-Tree With the Same Label";
        public string Description => "You are given a tree (i.e. a connected, undirected graph that has no cycles) consisting of n nodes numbered from 0 to n - 1 and exactly n - 1 edges. The root of the tree is the node 0, and each node of the tree has a label which is a lower-case character given in the string labels (i.e. The node with the number i has the label labels[i]).\r\n\r\nThe edges array is given on the form edges[i] = [ai, bi], which means there is an edge between nodes ai and bi in the tree.\r\n\r\nReturn an array of size n where ans[i] is the number of nodes in the subtree of the ith node which have the same label as node i.\r\n\r\nA subtree of a tree T is the tree consisting of a node in T and all of its descendant nodes.";
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
            var labels = "abaedcd";
            var result = CountSubTrees(n, edges, labels);

            // Prettify
            Console.WriteLine($"Input: n = {n}, edges = {edges.GetString()}, labels = {labels}");
            Console.WriteLine($"Output: {result}");
        }

        public int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            // Create adjaceny matrix
            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                adj[edge[0]].Add(edge[1]);
                adj[edge[1]].Add(edge[0]);
            }

            var result = new int[n];

            int[] Traverse(int to, int from)
            {
                var currentResult = new int[26];
                
                foreach (int child in adj[to])
                {
                    if (child != from)
                    {
                        var freq = Traverse(child, to);

                        for (int i = 0; i < 26; i++)
                        {
                            currentResult[i] += freq[i];
                        }
                    }
                }

                currentResult[labels[to] - 'a']++;
                result[to] = currentResult[labels[to] - 'a'];

                return currentResult;
            }

            Traverse(0, -1);

            return result.Take(n).ToArray();
        }
    }
}
