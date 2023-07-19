using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0435 : ISolution
    {
        public string Name => "Non-overlapping Intervals";
        public string Description => "Given an array of intervals intervals where intervals[i] = [starti, endi], return the minimum number of intervals you need to remove to make the rest of the intervals non-overlapping.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[][] 
            { 
                new int[] { 1, 2 },
                new int[] { 2, 3 },
                new int[] { 3, 4 },
                new int[] { 1, 3 },
            };
            var result = EraseOverlapIntervals(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString(delimiter: ", ")}");
            Console.WriteLine($"Output: {result}");
        }

        public int EraseOverlapIntervals(int[][] intervals)
        {
            var n = intervals.Length;

            Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[1] - b[1]));

            var end = intervals[0][1];
            var count = n - 1;
            for (int i = 1; i < n; i++)
            {
                if (intervals[i][0] >= end)
                {
                    end = intervals[i][1];
                    count--;
                }
            }

            return count;
        }
    }
}
