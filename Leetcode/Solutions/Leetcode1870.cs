using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1870 : ISolution
    {
        public string Name => "Minimum Speed to Arrive on Time";
        public string Description => "You are given a floating-point number hour, representing the amount of time you have to reach the office. To commute to the office, you must take n trains in sequential order. You are also given an integer array dist of length n, where dist[i] describes the distance (in kilometers) of the ith train ride.\r\n\r\nEach train can only depart at an integer hour, so you may need to wait in between each train ride.\r\n\r\n    For example, if the 1st train ride takes 1.5 hours, you must wait for an additional 0.5 hours before you can depart on the 2nd train ride at the 2 hour mark.\r\n\r\nReturn the minimum positive integer speed (in kilometers per hour) that all the trains must travel at for you to reach the office on time, or -1 if it is impossible to be on time.\r\n\r\nTests are generated such that the answer will not exceed 107 and hour will have at most two digits after the decimal point.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var dist = new int[] { 3, 2, 4 };
            var hour = 6d;
            var result = MinSpeedOnTime(dist, hour);

            // Prettify
            Console.WriteLine($"Input: dist = {dist.GetString()}, hour = {hour}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinSpeedOnTime(int[] dist, double hour)
        {
            if (dist.Length - 1 > hour) return -1;

            var n = dist.Length;

            var l = 0; var r = 10_000_000;
            while (l < r)
            {
                var pivot = l + ((r - l) >> 1);

                var time = 0d;
                for (int i = 0; i < n - 1; i++)
                    time += Math.Ceiling((double)dist[i] / pivot);

                time += (double)dist[n - 1] / pivot;

                if (time <= hour)
                    r = pivot;
                else
                    l = pivot + 1;
            }

            return l;
        }
    }
}
