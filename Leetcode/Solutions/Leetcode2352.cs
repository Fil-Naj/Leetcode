using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2352 : ISolution
    {
        public string Name => "Equal Row and Column Pairs";
        public string Description => "Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj) such that row ri and column cj are equal.\r\n\r\nA row and column pair is considered equal if they contain the same elements in the same order (i.e., an equal array).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var grid = new int[][]
            {
                new int[] { 3, 1, 2, 2 },
                new int[] { 1, 4, 4, 5 },
                new int[] { 2, 4, 2, 2 },
                new int[] { 2, 4, 2, 2 },
            };

            var result = EqualPairs(grid);

            // Prettify
            grid.PrintMatrix();
            Console.WriteLine($"Output: {result}");
        }

        public int EqualPairs(int[][] grid)
        {
            int n = grid.Length;

            Dictionary<string, int> rows = new();

            for (int i = 0; i < n; i++)
            {
                var row = string.Join(",", grid[i]);
                if (!rows.ContainsKey(row))
                    rows.Add(row, 0);
                rows[row]++;
            }

            var pairs = 0;
            for (int i = 0; i < n; i++)
            {
                List<int> column = new();
                for (int j = 0; j < n; j++)
                    column.Add(grid[j][i]);

                var col = string.Join(",", column);
                if (rows.TryGetValue(col, out var numPairs))
                    pairs += numPairs;
            }

            return pairs;
        }
    }
}
