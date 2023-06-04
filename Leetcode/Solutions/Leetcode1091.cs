using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1091 : ISolution
    {
        public string Name => "Shortest Path in Binary Matrix";
        public string Description => "Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.\r\n\r\nA clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:\r\n\r\n    All the visited cells of the path are 0.\r\n    All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).\r\n\r\nThe length of a clear path is the number of visited cells of this path.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var grid = new int[][]
            {
                new int[] { 0, 0, 0 },
                new int[] { 1, 1, 0 },
                new int[] { 1, 1, 0 },
            };
            var result = ShortestPathBinaryMatrix(grid);

            // Prettify
            Console.WriteLine($"Input: data =");
            grid.PrintMatrix();
            Console.WriteLine($"Output: {result}");
        }

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            // If start or finish not 0 (zero)
            if (grid[0][0] == 1 || grid[m - 1][n - 1] == 1) return -1;

            Queue<(int x, int y)> queue = new();
            bool[,] visited = new bool[m, n];

            visited[0, 0] = true;
            queue.Enqueue((0, 0));

            void Enqueue(int x, int y)
            {
                // If out of bounds
                if (x < 0 || x >= n || y < 0 || y >= m) return;

                // If already visited
                if (visited[x, y]) return;

                // If not a zero
                if (grid[x][y] == 1) return;

                visited[x, y] = true;
                queue.Enqueue((x, y));
            }

            var tiles = 0;
            while (queue.Count > 0)
            {
                var movesInStep = queue.Count;
                tiles++;

                for (int i = 0; i < movesInStep; i++)
                {
                    var (x, y) = queue.Dequeue();
                    if (x == n - 1 && y == m - 1) return tiles;

                    Enqueue(x - 1, y - 1);  // Up and left
                    Enqueue(x, y - 1);      // Up
                    Enqueue(x + 1, y - 1);  // Up and right
                    Enqueue(x - 1, y);      // Left
                    Enqueue(x + 1, y);      // Right
                    Enqueue(x - 1, y + 1);  // Down and left
                    Enqueue(x, y + 1);      // Down
                    Enqueue(x + 1, y + 1);  // Down and right
                }
            }

            return -1;
        }
    }
}
