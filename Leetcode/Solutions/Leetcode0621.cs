using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0621 : ISolution
    {
        public string Name => "Task Scheduler";
        public string Description => "You are given an array of CPU tasks, each represented by letters A to Z, and a cooling time, n. Each cycle or interval allows the completion of one task. Tasks can be completed in any order, but there's a constraint: identical tasks must be separated by at least n intervals due to cooling time.\r\n\r\n​Return the minimum number of intervals required to complete all tasks.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var tasks = new char[] { 'A', 'C', 'A', 'B', 'D', 'B' };
            var n = 1;
            var result = LeastInterval(tasks, n);

            // Prettify
            Console.WriteLine($"Input: tasks = {tasks.GetString()}, n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public int LeastInterval(char[] tasks, int n)
        {
            var counts = new int[26];

            // Count how many tasks for a specific char there is
            foreach (var c in tasks)
            {
                counts[c - 'A']++;
            }

            // Sort in descending order
            Array.Sort(counts, (a, b) => b - a);

            var maxCount = counts[0] - 1;

            // Idles required on most occuring task, assuming no tasks in between
            var idles = maxCount * n;

            // For all other tasks, if we can fill the gaps, reduce amount of idles required
            for (var i = 1; i < 26; i++)
            {
                idles -= Math.Min(maxCount, counts[i]);
            }

            return Math.Max(idles, 0) + tasks.Length;
        }
    }
}
