using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1402 : ISolution
    {
        public string Name => "Reducing Dishes";
        public string Description => "A chef has collected data on the satisfaction level of his n dishes. Chef can cook any dish in 1 unit of time.\r\n\r\nLike-time coefficient of a dish is defined as the time taken to cook that dish including previous dishes multiplied by its satisfaction level i.e. time[i] * satisfaction[i].\r\n\r\nReturn the maximum sum of like-time coefficient that the chef can obtain after dishes preparation.\r\n\r\nDishes can be prepared in any order and the chef can discard some dishes to get this maximum value.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var satisfaction = new int[] { -1, -8, 0, 5, -9 };

            // Prettify
            Console.WriteLine($"Input: satisfaction = {satisfaction.GetString()}");

            var result = MaxSatisfaction(satisfaction);

            Console.WriteLine($"Output: {result}");
        }

        public int MaxSatisfaction(int[] satisfaction)
        {
            Array.Sort(satisfaction, (a, b) =>  b - a);

            var result = 0;
            var satisSum = 0;
            for (int i = 0; i < satisfaction.Length; i++)
            {
                var sum = result + satisSum + satisfaction[i];
                if (sum < result)
                    return result;
                else
                    result = sum;

                satisSum += satisfaction[i];
            }

            return result;
        }
    }
}
