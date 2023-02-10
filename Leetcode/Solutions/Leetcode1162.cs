using Leetcode.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Leetcode.Solutions
{
    public class Leetcode1162 : ISolution
    {
        public string Name => "As Far from Land as Possible";
        public string Description => "Given an n x n grid containing only values 0 and 1, where 0 represents water and 1 represents land, find a water cell such that its distance to the nearest land cell is maximized, and return the distance. If no land or water exists in the grid, return -1.\r\n\r\nThe distance used in this problem is the Manhattan distance: the distance between two cells (x0, y0) and (x1, y1) is |x0 - x1| + |y0 - y1|.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var grid = new int[][] 
            {
                new int[] { 1,0,1 },
                new int[] { 0,0,0 },
                new int[] { 1,0,1 },
            };
            var result = MaxDistance(grid);

            // Prettify
            Console.WriteLine($"Input: data = \n{string.Join("\n", grid.Select(l => l.GetString()))}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxDistance(int[][] grid)
        {
            List<(int x, int y)> land = new();
            var total = grid.Length * grid[0].Length;
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == 1)
                        land.Add((x, y));
                }
            }

            if (land.Count == 0 || land.Count == total) return -1;

            var max = 0;
            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == 1) continue;

                    var closest = int.MaxValue;
                    foreach (var cell in land)
                    {
                        var dist = Math.Abs(cell.x - x) + Math.Abs(cell.y - y);
                        closest = Math.Min(dist, closest);
                    }

                    max = Math.Max(max, closest);
                }
            }

            return max;
        }
    }
}
