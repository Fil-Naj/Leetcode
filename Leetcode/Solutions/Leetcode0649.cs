using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0649 : ISolution
    {
        public string Name => "Dota2 Senate";
        public string Description => "In the world of Dota2, there are two parties: the Radiant and the Dire.\r\n\r\nThe Dota2 senate consists of senators coming from two parties. Now the Senate wants to decide on a change in the Dota2 game. The voting for this change is a round-based procedure. In each round, each senator can exercise one of the two rights:\r\n\r\n    Ban one senator's right: A senator can make another senator lose all his rights in this and all the following rounds.\r\n    Announce the victory: If this senator found the senators who still have rights to vote are all from the same party, he can announce the victory and decide on the change in the game.\r\n\r\nGiven a string senate representing each senator's party belonging. The character 'R' and 'D' represent the Radiant party and the Dire party. Then if there are n senators, the size of the given string will be n.\r\n\r\nThe round-based procedure starts from the first senator to the last senator in the given order. This procedure will last until the end of voting. All the senators who have lost their rights will be skipped during the procedure.\r\n\r\nSuppose every senator is smart enough and will play the best strategy for his own party. Predict which party will finally announce the victory and change the Dota2 game. The output should be \"Radiant\" or \"Dire\".";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var senate = "RRRRDDDD";
            var result = PredictPartyVictory(senate);

            // Prettify
            Console.WriteLine($"Input: senate = {senate}");
            Console.WriteLine($"Output: {result}");
        }

        public string PredictPartyVictory(string senate)
        {
            Queue<int> r = new();
            Queue<int> d = new();
            var n = senate.Length;

            for (int i =  0; i < senate.Length; i++)
            {
                if (senate[i] == 'R')
                    r.Enqueue(i);
                else
                    d.Enqueue(i);
            }

            while (r.Count > 0 && d.Count > 0)
            {
                var rVote = r.Dequeue();
                var dVote = d.Dequeue();

                if (rVote < dVote)
                {
                    r.Enqueue(rVote + n);
                }
                else
                {
                    d.Enqueue(dVote + n);
                }
            }

            return r.Count > 0 ? "Radiant" : "Dire";
        }
    }
}
