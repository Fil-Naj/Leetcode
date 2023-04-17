using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1431 : ISolution
    {
        public string Name => "Kids With the Greatest Number of Candies";
        public string Description => "There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, and an integer extraCandies, denoting the number of extra candies that you have.\r\n\r\nReturn a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, they will have the greatest number of candies among all the kids, or false otherwise.\r\n\r\nNote that multiple kids can have the greatest number of candies.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var candies = new int[] { 3, 2, 4 };
            var extraCandies = 6;
            var result = KidsWithCandies(candies, extraCandies);

            // Prettify
            Console.WriteLine($"Input: candies = {candies.GetString()}, extraCandies = {extraCandies}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var currentMax = candies.Max();
            var result = new bool[candies.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                result[i] = candies[i] + extraCandies >= currentMax;
            }

            return result;
        }

        public IList<bool> KidsWithCandiesLinq(int[] candies, int extraCandies)
        {
            var currentMax = candies.Max();
            
            return candies.Select(c => c + extraCandies >= currentMax).ToArray();
        }
    }
}
