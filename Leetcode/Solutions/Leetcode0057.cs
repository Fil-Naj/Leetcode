using Leetcode.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Leetcode.Solutions
{
    public class Leetcode0057 : ISolution
    {
        public string Name => "Insert Interval";
        public string Description => "You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.\r\n\r\nInsert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).\r\n\r\nReturn intervals after the insertion.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var intervals = new int[][]
            { 
                new int[] { 1, 5 },
                //new int[] { 3, 5 },
                //new int[] { 6, 7 },
                //new int[] { 8, 10 },
                //new int[] { 12, 16 },
            };
            var newInterval = new int[] { 2, 3 };
            var result = Insert(intervals, newInterval);

            // Prettify
            Console.WriteLine($"Input: intervals = {intervals.GetString()}, newInterval = {newInterval.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // If no existing intervals, new interval will be only one there
            if (intervals.Length == 0) return new int[][] { newInterval };

            var result = new List<int[]>();

            var startInt = newInterval[0]; var endInt = newInterval[1];
            var isInserted = false;
            foreach (var interval in intervals)
            {
                var start = interval[0];
                var end = interval[1];

                // If overlap, adjust overlapping interval start/end points
                if (end <= endInt && end >= startInt || start <= endInt && start >= startInt)
                {
                    startInt = Math.Min(startInt, start);
                    endInt = Math.Max(end, endInt);
                    continue;
                }

                // If new interval completely contained within existing interval, remove need to add in new interval
                if (start <= startInt && end >= endInt) isInserted = true;

                // If current interval start is past the new interval, and in the new interval
                if (start > endInt && !isInserted)
                {
                    result.Add(new int[] { startInt, endInt });
                    isInserted = true;
                }

                // If gets to here, means no overlapping so just add in undisturbed interval
                result.Add(interval);
            }

            // Ensure new interval is added in
            if (!isInserted) result.Add(new int[] { startInt, endInt });

            return result.ToArray();
        }
    }
}
