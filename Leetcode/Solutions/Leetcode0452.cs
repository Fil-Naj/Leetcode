using Leetcode.Extensions;
using System.Numerics;

namespace Leetcode.Solutions
{
    public class Leetcode0452 : ISolution
    {
        public string Name => "Minimum Number of Arrows to Burst Balloons";
        public string Description => "There are some spherical balloons taped onto a flat wall that represents the XY-plane. The balloons are represented as a 2D integer array points where points[i] = [xstart, xend] denotes a balloon whose horizontal diameter stretches between xstart and xend. You do not know the exact y-coordinates of the balloons.\r\n\r\nArrows can be shot up directly vertically (in the positive y-direction) from different points along the x-axis. A balloon with xstart and xend is burst by an arrow shot at x if xstart <= x <= xend. There is no limit to the number of arrows that can be shot. A shot arrow keeps traveling up infinitely, bursting any balloons in its path.\r\n\r\nGiven the array points, return the minimum number of arrows that must be shot to burst all balloons.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var points = new int[][] 
            { 
                new int[2]  { 10, 16 },
                new int[2]  { 2, 8 },
                new int[2]  { 1, 6 },
                new int[2]  { 7, 12 },
            };
            var result = FindMinArrowShots(points);

            // Prettify
            Console.WriteLine($"Input: points = {points.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindMinArrowShots(int[][] points)
        {
            // Sort balloons by their end points in ascending order
            Array.Sort(points, (a, b) => a[1] < b[1] ? -1 : 1);

            var result = 1;
            int prev = 0;

            for (int i = 1; i < points.Length; i++)
            {
                // If start point of next balloon is past the end of the previosly popped balloon, need new arrow
                // New arrow means new end point reference, which is just the end point of the new balloon
                if (points[i][0] > points[prev][1])
                {
                    result++;
                    prev = i;
                }
            }

            return result;
        }
    }
}
