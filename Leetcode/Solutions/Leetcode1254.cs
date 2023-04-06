using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1254 : ISolution
    {
        public string Name => "Number of Closed Islands";
        public string Description => "Given a 2D grid consists of 0s (land) and 1s (water).  An island is a maximal 4-directionally connected group of 0s and a closed island is an island totally (all left, top, right, bottom) surrounded by 1s.\r\n\r\nReturn the number of closed islands.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var grid = new int[][]
            {
                new int[] { 1, 1, 1, 1, 1, 1, 1, 0 },
                new int[] { 1, 0, 0, 0, 0, 1, 1, 0 },
                new int[] { 1, 0, 1, 0, 1, 1, 1, 0 },
                new int[] { 1, 0, 0, 0, 0, 1, 0, 1 },
                new int[] { 1, 1, 1, 1, 1, 1, 1, 0 },
            };
            var result = ClosedIsland(grid);

            // Prettify
            Console.WriteLine($"Input: grid = \n{string.Join("\n", grid.Select(r => r.GetString()))}");
            Console.WriteLine($"Output: {result}");
        }

        // The idea is that if an island touches the side of the grid, it is not completely surrounded by water
        // Therefore, visit every island.
        // While traversing the island, if piece is on the egde, fail that island
        // Ensure to traverse entire island before failing it
        // Time: O(m·n), Space: O(m·n)
        public int ClosedIsland(int[][] grid)
        {
            bool[,] visited = new bool[grid.Length, grid[0].Length];
            int n = grid.Length;    // for rows
            int m = grid[0].Length; // for cols

            var result = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    if (visited[row, col]) continue;

                    if (grid[row][col] == 1)
                    {
                        visited[row, col] = true;
                        continue;
                    }

                    // BFS to find entire island
                    Queue<(int r, int c)> queue = new();
                    queue.Enqueue((row, col));
                    visited[row, col] = true;
                    bool isTouchingEdge = false;

                    while (queue.Count > 0)
                    {
                        var (r, c) = queue.Dequeue();
                        if (r == 0 || r == n - 1 || c == 0 || c == m - 1)
                            isTouchingEdge = true;

                        // Up
                        if (r > 0 && !visited[r - 1, c] && grid[r - 1][c] == 0)
                        {
                            queue.Enqueue((r - 1, c));
                            visited[r - 1, c] = true;
                        }

                        // Down
                        if (r < n - 1 && !visited[r + 1, c] && grid[r + 1][c] == 0)
                        {
                            queue.Enqueue((r + 1, c));
                            visited[r + 1, c] = true;
                        }

                        // Left
                        if (c > 0 && !visited[r, c - 1] && grid[r][c - 1] == 0)
                        {
                            queue.Enqueue((r, c - 1));
                            visited[r, c - 1] = true;
                        }

                        // Right
                        if (c < m - 1 && !visited[r, c + 1] && grid[r][c + 1] == 0)
                        {
                            queue.Enqueue((r, c + 1));
                            visited[r, c + 1] = true;
                        }
                    }

                    result += isTouchingEdge ? 0 : 1;
                }
            }

            return result;
        }
    }
}
