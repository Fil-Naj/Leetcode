using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1406 : ISolution
    {
        public string Name => "Stone Game III";
        public string Description => "Alice and Bob continue their games with piles of stones. There are several stones arranged in a row, and each stone has an associated value which is an integer given in the array stoneValue.\r\n\r\nAlice and Bob take turns, with Alice starting first. On each player's turn, that player can take 1, 2, or 3 stones from the first remaining stones in the row.\r\n\r\nThe score of each player is the sum of the values of the stones taken. The score of each player is 0 initially.\r\n\r\nThe objective of the game is to end with the highest score, and the winner is the player with the highest score and there could be a tie. The game continues until all the stones have been taken.\r\n\r\nAssume Alice and Bob play optimally.\r\n\r\nReturn \"Alice\" if Alice will win, \"Bob\" if Bob will win, or \"Tie\" if they will end the game with the same score.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var stoneValue = new int[] { 1, 2, 3, 7 };
            var result = StoneGameIII(stoneValue);

            // Prettify
            Console.WriteLine($"Input: stoneValue = {stoneValue.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Can implement as a bottom up approach since it practically works from back to front, with O(1) space, but cba
        // Uses implementation of mini-max and memoisation
        public string StoneGameIII(int[] stoneValue)
        {
            var dp_alice = new int?[stoneValue.Length];
            var dp_bob = new int?[stoneValue.Length];

            int PlayTurn(int start, bool isAlice)
            {
                if (start >= stoneValue.Length) return 0;

                if (isAlice)
                    if (dp_alice[start].HasValue) return dp_alice[start].Value;
                    else
                    if (dp_bob[start].HasValue) return dp_bob[start].Value;

                var pile = 0;
                var maxReturn = int.MinValue;
                for (int i = start; i < Math.Min(start + 3, stoneValue.Length); i++)
                {
                    pile += stoneValue[i];
                    maxReturn = Math.Max(maxReturn, pile - PlayTurn(i + 1, !isAlice));
                }
                if (isAlice)
                    dp_alice[start] = maxReturn;
                else
                    dp_bob[start] = maxReturn;

                return maxReturn;
            }

            var result = PlayTurn(0, true);
            return result > 0 ? "Alice" : result < 0 ? "Bob" : "Tie";
        }
    }
}
