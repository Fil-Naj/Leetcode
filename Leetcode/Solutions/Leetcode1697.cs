using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1697 : ISolution
    {
        public string Name => "Checking Existence of Edge Length Limited Paths";
        public string Description => "An undirected graph of n nodes is defined by edgeList, where edgeList[i] = [ui, vi, disi] denotes an edge between nodes ui and vi with distance disi. Note that there may be multiple edges between two nodes.\r\n\r\nGiven an array queries, where queries[j] = [pj, qj, limitj], your task is to determine for each queries[j] whether there is a path between pj and qj such that each edge on the path has a distance strictly less than limitj .\r\n\r\nReturn a boolean array answer, where answer.length == queries.length and the jth value of answer is true if there is a path for queries[j] is true, and false otherwise.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 3;
            var edgeList = new int[][] 
            { 
                new int[] { 0, 1, 2 },
                new int[] { 1, 2, 4 },
                new int[] { 2, 0, 8 },
                new int[] { 1, 0, 16 },
            };
            var queries = new int[][]
            {
                new int[] { 0, 1, 2 },
                new int[] { 0, 2, 5 },
            };
            var result = DistanceLimitedPathsExist(n, edgeList, queries);

            // Prettify
            Console.WriteLine($"Input: n = {n}, edgeList = {string.Join(", ", edgeList.Select(e => e.GetString()))}, queries = {string.Join(", ", queries.Select(q => q.GetString()))}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            UnionFind uf = new(n);

            // We need to sort the queries in asc order of their limit
            // But doing so will mess up their order, and therefore the answer
            // So, we need to assign a number to the query so we know the order to return the answers in
            var sortedQueries = queries.Select((item, i) => new { Start = item[0], End = item[1], Limit = item[2], Index = i })
                .OrderBy(i => i.Limit);

            // Let us sort the edgeList in order of edge so that we can build our graph step by step in order of egde length
            Array.Sort(edgeList, Comparer<int[]>.Create((a, b) => a[2] - b[2]));

            // Now, for each query, we add in every edge in the graph that has an edge length of less than the queries limit
            // To not have to build the graph again and again, we keep track of what edges we have added up to, using edgesAdded
            var edgesAdded = 0;
            var result = new bool[queries.Length];
            foreach  (var query in sortedQueries)
            {
                while (edgesAdded < edgeList.Length && edgeList[edgesAdded][2] < query.Limit)
                {
                    uf.Union(edgeList[edgesAdded][0], edgeList[edgesAdded][1]);
                    edgesAdded++;
                }

                result[query.Index] = uf.Find(query.Start) == uf.Find(query.End);
            }

            return result;
        }

        public class UnionFind
        {
            public int[] _parent;

            public UnionFind(int n)
            {
                // Define parent array
                _parent = new int[n];
                
                // Set each index to be a parent of itself (i.e., _parent[i] = i)
                for (int i = 0; i < n; i++) _parent[i] = i;
            }

            public int Find(int x) 
            {
                // If the component we are trying to find is not the main parent, search for the main parent
                if (x != _parent[x])
                    _parent[x] = Find(_parent[x]);

                return _parent[x];
            }

            public void Union(int x, int y)
            {
                int i = Find(x);
                int j = Find(y);

                // We can do other stuff with it here in order to determine how to decide who is the parent and who is the child
                _parent[Math.Min(i, j)] = Math.Max(i, j);
            }
        }
    }
}
