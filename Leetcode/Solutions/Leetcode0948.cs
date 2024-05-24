using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0948 : ISolution
    {
        public string Name => "Bag of Tokens";
        public string Description => "You start with an initial power of power, an initial score of 0, and a bag of tokens given as an integer array tokens, where each tokens[i] donates the value of tokeni.\r\n\r\nYour goal is to maximize the total score by strategically playing these tokens. In one move, you can play an unplayed token in one of the two ways (but not both for the same token):\r\n\r\n    Face-up: If your current power is at least tokens[i], you may play tokeni, losing tokens[i] power and gaining 1 score.\r\n    Face-down: If your current score is at least 1, you may play tokeni, gaining tokens[i] power and losing 1 score.\r\n\r\nReturn the maximum possible score you can achieve after playing any number of tokens.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var tokens = new int[] { 2897, 6861, 2070, 5292, 3402, 9784, 9718, 2089, 5660, 3294, 9685, 9245, 5861, 7200, 6813, 3533, 9163, 8994, 3306, 7473, 90, 8163, 5648, 9523, 3631, 6257, 3230, 7827, 6007, 9874, 10, 1407, 436, 1258, 9293, 9486, 4804, 9466, 8183, 7786, 7472, 1876, 5488, 4238, 9497, 1738, 1698, 6588, 1574, 1100 };
            var power = 5039;
            var result = BagOfTokensScore(tokens, power);

            // Prettify
            Console.WriteLine($"Input: tokens = {tokens.GetString()}, power = {power}");
            Console.WriteLine($"Output: {result}");
        }

        public int BagOfTokensScore(int[] tokens, int power)
        {
            // Sort tokens in ascending order
            Array.Sort(tokens);

            var currScore = 0;
            var maxScore = 0;

            // Two pointer solution
            var l = 0;
            var r = tokens.Length - 1;

            // While pointers do not cross over
            while (l <= r)
            {
                // If we have enough power, play token face-up
                // Always play token with least power (greedy)
                if (tokens[l] <= power)
                {
                    currScore++;
                    maxScore = Math.Max(maxScore, currScore);
                    power -= tokens[l++];
                }
                // If have enough score, play face-down
                // Always play token with most power
                else if (currScore > 0)
                {
                    power += tokens[r--];
                    currScore--;
                }
                // If can't play at all, stop playing
                else
                {
                    break;
                }
            }

            return maxScore;
        }
    }
}
