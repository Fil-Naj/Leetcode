using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0739 : ISolution
    {
        public string Name => "Daily Temperatures";
        public string Description => "Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] data = [73, 74, 75, 71, 69, 72, 76, 73];
            var result = DailyTemperatures(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] DailyTemperatures(int[] temperatures)
        {
            var n = temperatures.Length;
            var result = new int[n];

            Stack<int> stack = [];

            for (var i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && temperatures[i] >= temperatures[stack.Peek()])
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                {
                    result[i] = stack.Peek() - i;
                }

                stack.Push(i);
            }

            return result;
        }
    }
}
