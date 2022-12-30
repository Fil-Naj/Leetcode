using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1706 : ISolution
    {
        public string Name => "Where Will the Ball Fall";
        public string Description => "You have a 2-D grid of size m x n representing a box, and you have n balls. The box is open on the top and bottom sides.\r\n\r\nEach cell in the box has a diagonal board spanning two corners of the cell that can redirect a ball to the right or to the left.\r\n\r\n    A board that redirects the ball to the right spans the top-left corner to the bottom-right corner and is represented in the grid as 1.\r\n    A board that redirects the ball to the left spans the top-right corner to the bottom-left corner and is represented in the grid as -1.\r\n\r\nWe drop one ball at the top of each column of the box. Each ball can get stuck in the box or fall out of the bottom. A ball gets stuck if it hits a \"V\" shaped pattern between two boards or if a board redirects the ball into either wall of the box.\r\n\r\nReturn an array answer of size n where answer[i] is the column that the ball falls out of at the bottom after dropping the ball from the ith column at the top, or -1 if the ball gets stuck in the box.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var grid = new int[][]
            //{
            //    new int[] { 1, 1,1,-1,-1 },
            //    new int[] {1,1,1,-1,-1 },
            //    new int[] {-1,-1,-1,1,1 },
            //    new int[] { 1, 1, 1, 1, 1 },
            //    new int[] { -1, -1, -1, -1, -1 },
            //};
            var grid = new int[][]
            {
                new int[] { 1,-1,-1,1,-1,1,1,1,1,1,-1,1,1,1,1,1,1,-1,-1,-1,-1,-1,-1,1,-1,1,-1,1,-1,-1,-1,-1,1,-1,1,1,-1,-1,-1,-1,-1,1 },
                new int[] {-1,1,1,1,-1,-1,-1,-1,1,1,1,-1,-1,-1,1,-1,-1,1,1,1,1,1,1,-1,1,-1,-1,-1,-1,-1,1,-1,1,-1,-1,-1,-1,1,1,-1,1,1 },
                new int[] {1 ,-1,-1,-1,-1,1,-1,1,1,1,1,1,1,1,-1,1,-1,-1,-1,1,-1,-1,1,-1,1,-1,1,-1,-1,1,-1,1,-1,1,1,-1,-1,1,1,-1,1,-1 },
            };
            //var grid = new int[][]
            //{
            //    new int[] { -1 },
            //};
            var result = FindBall(grid);
            PrintGrid(grid);
            // Prettify
            Console.WriteLine($"Input: data = {grid.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] FindBall(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                int row = 0;
                int col = i;

                // While falling down box
                while (row < m)
                {
                    int tilt = grid[row][col];

                    int neighbour = tilt + col;
                    // Has reached the side of the grid
                    if (neighbour < 0 || neighbour >= n)
                        break;

                    // Is stuck in the V
                    if (grid[row][neighbour] != tilt)
                        break;

                    // Time to move
                    row++;
                    col = neighbour;
                }
                result[i] = row < m ? -1 : col;
            }

            return result;
        }

        private void PrintGrid(int[][] grid)
        {
            for (int i = 0; i < grid[0].Length; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            foreach (var row in grid)
            {
                foreach (int tilt in row)
                    Console.Write(tilt == 1 ? "\\" : "/");
                Console.WriteLine();
            }
        }
    }
}
