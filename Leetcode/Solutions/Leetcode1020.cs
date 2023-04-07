using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1020 : ISolution
    {
        public string Name => "Number of Enclaves";
        public string Description => "You are given an m x n binary matrix grid, where 0 represents a sea cell and 1 represents a land cell.\r\n\r\nA move consists of walking from one land cell to another adjacent (4-directionally) land cell or walking off the boundary of the grid.\r\n\r\nReturn the number of land cells in grid for which we cannot walk off the boundary of the grid in any number of moves.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var grid = new int[][]
            {
                new int[] { 0, 0, 0, 0 },
                new int[] { 1, 0, 1, 0 },
                new int[] { 0, 1, 1, 0 },
                new int[] { 0, 0, 0, 0 },
            };
            var result = NumEnclaves(grid);

            // Prettify
            Console.WriteLine($"Input: grid = {string.Join("\n", grid.Select(r => r.GetString()))}");
            Console.WriteLine($"Output: {result}");
        }

        public int NumEnclaves(int[][] grid)
        {
            var result = 0;

            var m = grid.Length;
            var n = grid[0].Length;

            void Dfs(int row, int col)
            {
                // If out of bounds or in water, cannot search
                if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == 0) return;

                grid[row][col] = 0;

                Dfs(row - 1, col);
                Dfs(row + 1, col);
                Dfs(row, col - 1);
                Dfs(row, col + 1);
            }

            // Get the edges (column edges)
            for (int i = 0; i < m; i++)
            {
                if (grid[i][0] == 1) Dfs(i, 0);
                if (grid[i][n - 1] == 1) Dfs(i, n - 1);
            }

            for (int i = 0; i < n; i++)
            {
                if (grid[0][i] == 1) Dfs(0, i);
                if (grid[m - 1][i] == 1) Dfs(m - 1, i);
            }

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    result += grid[i][j] == 1 ? 1 : 0;

            return result;
        }
    }
}
