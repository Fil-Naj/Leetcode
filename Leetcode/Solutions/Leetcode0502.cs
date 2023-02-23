using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0502 : ISolution
    {
        public string Name => "IPO";
        public string Description => "Suppose LeetCode will start its IPO soon. In order to sell a good price of its shares to Venture Capital, LeetCode would like to work on some projects to increase its capital before the IPO. Since it has limited resources, it can only finish at most k distinct projects before the IPO. Help LeetCode design the best way to maximize its total capital after finishing at most k distinct projects.\r\n\r\nYou are given n projects where the ith project has a pure profit profits[i] and a minimum capital of capital[i] is needed to start it.\r\n\r\nInitially, you have w capital. When you finish a project, you will obtain its pure profit and the profit will be added to your total capital.\r\n\r\nPick a list of at most k distinct projects from given projects to maximize your final capital, and return the final maximized capital.\r\n\r\nThe answer is guaranteed to fit in a 32-bit signed integer.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var k = 3;
            var w = 0;
            var profits = new int[] { 1, 2, 3 };
            var capital = new int[] { 0, 1, 2 };
            var result = FindMaximizedCapital(k, w, profits, capital);

            // Prettify
            Console.WriteLine($"Input: k = {k}, w = {w}, profits = {profits.GetString()}, capital = {capital.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            PriorityQueue<int, int> available = new(Comparer<int>.Create((x, y) => y - x));

            Dictionary<int, List<int>> costsToProfits = new();
            for (int i = 0; i < profits.Length; i++)
            {
                // If available from start, add that baby in to the list of potential projects
                if (capital[i] <= w)
                {
                    available.Enqueue(profits[i], profits[i]);
                    continue;
                }

                if (costsToProfits.ContainsKey(capital[i]))
                {
                    costsToProfits[capital[i]].Add(profits[i]);
                }
                else
                {
                    costsToProfits[capital[i]] = new List<int> { profits[i] };
                }
            }

            var projectsDone = 0;
            // While we have time for work and there is work to do
            while (projectsDone < k && available.Count > 0)
            {
                w += available.Dequeue();
                projectsDone++;

                var toRemove = new List<int>();
                // Add in the newly avaivale projects
                foreach (var item in costsToProfits)
                {
                    if (item.Key > w) continue;

                    foreach (var project in item.Value)
                    {
                        available.Enqueue(project, project);
                    }
                    toRemove.Add(item.Key);
                }

                foreach (var item in toRemove)
                {
                    costsToProfits.Remove(item);
                }
            }

            return w;
        }
    }
}
