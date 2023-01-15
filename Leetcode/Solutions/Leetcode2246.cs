using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2246 : ISolution
    {
        public string Name => "Longest Path With Different Adjacent Characters";
        public string Description => "You are given a tree (i.e. a connected, undirected graph that has no cycles) rooted at node 0 consisting of n nodes numbered from 0 to n - 1. The tree is represented by a 0-indexed array parent of size n, where parent[i] is the parent of node i. Since node 0 is the root, parent[0] == -1.\r\n\r\nYou are also given a string s of length n, where s[i] is the character assigned to node i.\r\n\r\nReturn the length of the longest path in the tree such that no pair of adjacent nodes on the path have the same character assigned to them.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var parent = new int[] { -1, 0, 0, 1, 1, 2 };
            var s = "abacbe";
            var result = LongestPath(parent, s);

            // Prettify
            Console.WriteLine($"Input: parent = {parent.GetString()}, s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestPath(int[] parent, string s)
        {
            int n = parent.Length;

            // Create adjaceny matrix
            List<int>[] adj = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adj[i] = new List<int>();
            }

            for (int i = 1; i < n; i++)
            {
                adj[parent[i]].Add(i);
            }

            var result = 1;

            int Dfs(int node)
            {
                var max1 = 0; var max2 = 0;

                foreach (var child in adj[node])
                {
                    var res = Dfs(child);

                    if (res > max1)
                    {
                        max2 = max1;
                        max1 = res;
                    }
                    else if (res > max2)
                    {
                        max2 = res;
                    }
                }

                var total = max1 + max2 + 1;
                result = Math.Max(total, result);


                var from = parent[node];
                // In case of root node
                if (from == -1) return -1;

                // In case of not root node
                return s[node] != s[from] ? max1 + 1 : 0;
            }

            Dfs(0);

            return result;    
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
