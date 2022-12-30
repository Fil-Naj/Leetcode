using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    [ToBeContinued("Got bored, is a version of BFS until the side is reached. How exciting")]
    public class Leetcode1926 : ISolution
    {
        public string Name => "Nearest Exit from Entrance in Maze\r\n";
        public string Description => "You are given an m x n matrix maze (0-indexed) with empty cells (represented as '.') and walls (represented as '+'). You are also given the entrance of the maze, where entrance = [entrancerow, entrancecol] denotes the row and column of the cell you are initially standing at.\r\n\r\nIn one step, you can move one cell up, down, left, or right. You cannot step into a cell with a wall, and you cannot step outside the maze. Your goal is to find the nearest exit from the entrance. An exit is defined as an empty cell that is at the border of the maze. The entrance does not count as an exit.\r\n\r\nReturn the number of steps in the shortest path from the entrance to the nearest exit, or -1 if no such path exists.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[] { 3, 2, 4 };
            var target = 6;
            //var result = TwoSum(data, target);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}, target = {target}");
            //Console.WriteLine($"Output: {result.GetString()}");
        }

        public int NearestExit(char[][] maze, int[] entrance)
        {
            const char Wall = '+';
            int m = maze.Length;
            int n = maze[0].Length;

            Func<int, bool> isOnZeroBorder = (rc) => rc == 0;
            Func<int, bool> isOnRightBorder = (col) => col == n;
            Func<int, bool> isOnBottomBorder = (row) => row == m;
            Func<int, int, bool> isAtExit = (x, y) => (isOnZeroBorder(x) || isOnRightBorder(x)) && (isOnZeroBorder(y) || isOnBottomBorder(y));

            bool[,] visited = new bool[n, m];
            Func<(int x, int y), bool> isVisited = (pos) => visited[pos.y, pos.x];

            Queue<(int x, int y)> queue = new();
            queue.Enqueue((entrance[0], entrance[1]));
            visited[entrance[1], entrance[0]] = true;

            // BFS with counting for steps
            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();

                // if (visited[pos]) return;
            }
            return 0;
        }


    }
}
