using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2849 : ISolution
    {
        public string Name => "Determine if a Cell Is Reachable at a Given Time";
        public string Description => "You are given four integers sx, sy, fx, fy, and a non-negative integer t.\r\n\r\nIn an infinite 2D grid, you start at the cell (sx, sy). Each second, you must move to any of its adjacent cells.\r\n\r\nReturn true if you can reach cell (fx, fy) after exactly t seconds, or false otherwise.\r\n\r\nA cell's adjacent cells are the 8 cells around it that share at least one corner with it. You can visit the same cell several times.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var sx = 3;
            var sy = 1;
            var fx = 7;
            var fy = 3;
            var t = 3;
            var result = IsReachableAtTime(sx, sy, fx, fy, t);

            // Prettify
            Console.WriteLine($"Input: sx = {sx}, sy = {sy}, fx = {fx}, fy = {fy}, t = {t},");
            Console.WriteLine($"Output: {result}");
        }

        public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            if (sx == fx && sy == fy && t == 1) return false;

            var x_diff = Math.Abs(fx - sx);
            var y_diff = Math.Abs(fy - sy);

            return y_diff + Math.Max(x_diff - y_diff, 0) <= t;
        }
    }
}
