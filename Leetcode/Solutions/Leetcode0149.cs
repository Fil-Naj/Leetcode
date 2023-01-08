using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0149 : ISolution
    {
        public string Name => "Max Points on a Line";
        public string Description => "Given an array of points where points[i] = [xi, yi] represents a point on the X-Y plane, return the maximum number of points that lie on the same straight line.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var points = new int[][] 
            {
                new int[] { 1, 1 },
                new int[] { 3, 2 },
                new int[] { 5, 3 },
                new int[] { 4, 1 },
                new int[] { 2, 3 },
                new int[] { 1, 4 },
            };
            var result = MaxPoints(points);

            // Prettify
            Console.WriteLine($"Input: data = {points.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // My original take
        // Plan was to find every line between every pair of points in the form of y = mx + c
        // We store every line and the points contained on that line in a dictionary
        // Return the line with the most points on it
        public int MaxPoints(int[][] points)
        {
            if (points.Length == 1) return 1;

            Dictionary<(decimal m, decimal c, decimal? x), HashSet<(int x, int y)>> map = new();

            for (int start = 0; start < points.Length - 1; start++)
            {
                var startPoint = (points[start][0], points[start][1]);
                for (int end = start + 1; end < points.Length; end++)
                {
                    var line = GetLine(points[start][0], points[start][1], points[end][0], points[end][1]);

                    var endPoint = (points[end][0], points[end][1]);

                    if (map.ContainsKey(line))
                    {
                        map[line].Add(startPoint);
                        map[line].Add(endPoint);
                    }
                    else
                    {
                        map.Add(line, new HashSet<(int x, int y)>() { startPoint });
                        map[line].Add(endPoint);
                    }
                }
            }

            foreach (var line in map)
            {
                Console.WriteLine($"m = {line.Key.m}, c = {line.Key.c}, x = {line.Key.x}, Count = {string.Join(", ", line.Value)}");
            }

            return map.Values.Max(l => l.Count);
        }

        // Returns the variables m and c of the formula y = mx + c for a pair of points
        // Returns a nullable variable if the line is a vertical line. x signifies the x value of that vertical line
        public (decimal m, decimal c, decimal? x) GetLine(decimal x1, decimal y1, decimal x2, decimal y2)
        {
            decimal m = 0; decimal c = 0; decimal? x = null;

            if (x1 > x2)
            {
                m = (y1 - y2) / (x1 - x2);
            }
            else if (x2 > x1)
            {
                m = (y2 - y1) / (x2 - x1);
            }
            else
            {
                x = x1;
                return (m, c, x);
            }

            c = y1 - (m * x1);

            return (m, c, x);
        }


        // Revised take
        // When finding the lines between a given starting point and any other point avaliable, we will find every other possible point to exist on that line
        // If, for each starting point, we instead stored the lines that point was a part of,
        // and the number of points on that line, we save memory as we do not have to remember what points are on what line.
        // The calculation is also simplified as we only have to find the slope, and not the entire line formula (e.g., c (the y-intercept))
        public int MaxPoints2(int[][] points)
        {
            if (points.Length == 1) return 1;

            var result = 0;

            for (int start = 0; start < points.Length - 1; start++)
            {
                Dictionary<decimal, int> map = new();

                for (int end = start + 1; end < points.Length; end++)
                {
                    var slope = 0M;

                    if (points[start][0] == points[end][0])
                    {
                        slope = decimal.MaxValue;
                    }
                    else
                    {
                        slope = (decimal)(points[end][1] - points[start][1]) / (decimal)(points[end][0] - points[start][0]);
                    }

                    if (map.ContainsKey(slope))
                        map[slope]++;
                    else
                        map.Add(slope, 2);

                    result = Math.Max(result, map[slope]);
                }
            }

            return result;
        }
    }
}
