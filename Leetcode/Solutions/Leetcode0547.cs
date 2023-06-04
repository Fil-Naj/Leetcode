using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0547 : ISolution
    {
        public string Name => "Number of Provinces";
        public string Description => "There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly with city c, then city a is connected indirectly with city c.\r\n\r\nA province is a group of directly or indirectly connected cities and no other cities outside of the group.\r\n\r\nYou are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.\r\n\r\nReturn the total number of provinces.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[][]
            {
                new int[] { 1, 1, 0 },
                new int[] { 1, 1, 0 },
                new int[] { 0, 0, 1 },
            };
            var result = FindCircleNum(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindCircleNum(int[][] isConnected)
        {
            var n = isConnected.Length;
            bool[] visited = new bool[n];

            void Bfs(int j)
            {
                Queue<int> queue = new();
                queue.Enqueue(j);
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    for (int i = 0; i < n; i++)
                    {
                        if (i == node || visited[i] || isConnected[node][i] == 0) continue;

                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }

            var provinces = 0;
            for (int i = 0; i < n; i++)
            {
                if (visited[i]) continue;

                visited[i] = true;
                Bfs(i);
                provinces++;
            }

            return provinces;
        }
    }
}
