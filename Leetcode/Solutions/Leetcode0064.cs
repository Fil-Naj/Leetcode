using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0064 : ISolution
    {
        public string Name => "Minimum Path Sum";
        public string Description => "Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right, which minimizes the sum of all numbers along its path.\r\n\r\nNote: You can only move either down or right at any point in time.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var grid = new int[][] {
            //    new int[] { 1, 3, 1 },
            //    new int[] { 1, 5, 1 },
            //    new int[] { 4, 2, 1 },
            //};
            var grid = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
            };
            var result = MinPathSum(grid);

            // Prettify
            Console.WriteLine($"Input: grid = [{string.Join(", ", grid.Select(o => o.GetString()))}]");
            Console.WriteLine($"Output: {result}");
        }

        //public int MinPathSum(int[][] grid)
        //{
        //    int m = grid.Length;
        //    int n = grid[0].Length;

        //    PriorityQueue<(int x, int y), int> queue = new();
        //    queue.Enqueue((0, 0), grid[0][0]);
        //    HashSet<(int x, int y)> visited = new() { (0, 0) };

        //    while (queue.TryDequeue(out var node, out var sum))
        //    {
        //        if (node.x == n - 1 && node.y == m - 1) return sum;

        //        // Try go right
        //        if (node.x < n - 1 && !visited.Contains((node.x + 1, node.y)))
        //        {
        //            queue.Enqueue((node.x + 1, node.y), sum + grid[node.y][node.x + 1]);
        //            visited.Add((node.x + 1, node.y));
        //        }

        //        // Try go down
        //        if (node.y < m - 1 && !visited.Contains((node.x, node.y + 1)))
        //        {
        //            queue.Enqueue((node.x, node.y + 1), sum + grid[node.y + 1][node.x]);
        //            visited.Add((node.x, node.y + 1));
        //        }
        //    }

        //    return -1;
        //}

        // Dynamic Programmin approach
        public int MinPathSum(int[][] grid)
        {
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (col == 0 && row == 0) continue;

                    if (col == 0) 
                        grid[row][col] = grid[row - 1][col] + grid[row][col];
                    else if (row == 0) 
                        grid[row][col] = grid[row][col - 1] + grid[row][col];
                    else 
                        grid[row][col] = Math.Min(grid[row][col - 1], grid[row - 1][col]) + grid[row][col];
                }
            }

            return grid[^1][grid[0].Length - 1];
        }
    }
}
