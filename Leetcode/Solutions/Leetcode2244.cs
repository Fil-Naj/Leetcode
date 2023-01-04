using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2244 : ISolution
    {
        public string Name => "Minimum Rounds to Complete All Tasks";
        public string Description => "You are given a 0-indexed integer array tasks, where tasks[i] represents the difficulty level of a task. In each round, you can complete either 2 or 3 tasks of the same difficulty level.\r\n\r\nReturn the minimum rounds required to complete all the tasks, or -1 if it is not possible to complete all the tasks.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var tasks = new int[] { 2, 2, 3, 3, 2, 4, 4, 4, 4, 4 };
            var result = MinimumRounds(tasks);

            // Prettify
            Console.WriteLine($"Input: data = {tasks.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Using LINQ to make a dictionary is slowwwwww
        // Using a Select statement to make annonymous objects is faster than using ToDictionary()
        // If we use a traditional for/foreach loop instead, we get similar time performance, but much less memory use
        // We can also do the check for validity before the main counting. Again, similar time performance, much better memory
        public int MinimumRounds(int[] tasks)
        {
            var freq = new Dictionary<int, int>();
            foreach (var task in tasks)
                freq[task] = freq.ContainsKey(task) ? freq[task] + 1 : 1;

            var result = 0;

            if (freq.Values.Contains(1)) return -1;

            foreach (var task in freq)
            {
                var byThree = GetDivAndMod(task.Value, 3);

                result += byThree.Div + (byThree.Mod > 0 ? 1 : 0);
            }

            return result;
        }

        private (int Div, int Mod) GetDivAndMod(int value, int by) 
            => (value / by, value % by);
    }
}
