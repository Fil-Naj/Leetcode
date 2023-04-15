using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2218 : ISolution
    {
        public string Name => "Maximum Value of K Coins From Piles";
        public string Description => "There are n piles of coins on a table. Each pile consists of a positive number of coins of assorted denominations.\r\n\r\nIn one move, you can choose any coin on top of any pile, remove it, and add it to your wallet.\r\n\r\nGiven a list piles, where piles[i] is a list of integers denoting the composition of the ith pile from top to bottom, and a positive integer k, return the maximum total value of coins you can have in your wallet if you choose exactly k coins optimally.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var piles = new List<IList<int>>
            //{
            //    new List<int> { 1,100,3 },
            //    new List<int> { 7,8,9 },
            //};
            //var piles = new List<IList<int>>
            //{
            //    new List<int> { 80,62,78,78,40,59,98,35 },
            //    new List<int> { 79,19,100,15 },
            //    new List<int> { 79,2,27,73,12,13,11,37,27,55,54,55,87,10,97,26,78,20,75,23,46,94,56,32,14,70,70,37,60,46,1,53 },
            //};
            var piles = new List<IList<int>>
            {
                new List<int> { 37,88 },
                new List<int> { 51,64,65,20,95,30,26 },
                new List<int> { 9,62,20 },
                new List<int> { 44 },
            };
            var k = 9;
            var result = MaxValueOfCoins(piles, k);

            // Prettify
            Console.WriteLine($"Input: piles = {string.Join(", ", piles.Select(p => p.GetString()))}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int MaxValueOfCoins(IList<IList<int>> piles, int k)
        {
            int p = piles.Count;
            int[,] dp = new int[k + 1, p];

            int Dfs(int k, int pile)
            {
                // If we have gone too far
                if (pile == p)
                    return 0;

                if (dp[k, pile] > 0)
                    return dp[k, pile];

                // Skip to next pile
                dp[k, pile] = Dfs(k, pile + 1);

                // Stick with current pile
                var currentPile = 0;
                var possibleCollections = Math.Min(k, piles[pile].Count);
                for (int i = 0; i < possibleCollections; i++) 
                {
                    currentPile += piles[pile][i];
                    dp[k, pile] = Math.Max(dp[k, pile], currentPile + Dfs(k - i - 1, pile + 1));
                }

                return dp[k, pile];
            }

            return Dfs(k, 0);
        }
    }
}
