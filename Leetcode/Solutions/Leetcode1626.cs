using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1626 : ISolution
    {
        public string Name => "Best Team With No Conflicts";
        public string Description => "You are the manager of a basketball team. For the upcoming tournament, you want to choose the team with the highest overall score. The score of the team is the sum of scores of all the players in the team.\r\n\r\nHowever, the basketball team is not allowed to have conflicts. A conflict exists if a younger player has a strictly higher score than an older player. A conflict does not occur between players of the same age.\r\n\r\nGiven two lists, scores and ages, where each scores[i] and ages[i] represents the score and age of the ith player, respectively, return the highest overall score of all possible basketball teams.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var scores = new int[] { 4, 5, 6, 5 };
            var ages = new int[] { 2, 1, 2, 1 };
            var result = BestTeamScore(scores, ages);

            // Prettify
            Console.WriteLine($"Input: scores = {scores.GetString()}, ages = {ages.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Things we learnt today
        // For these Longest Increasing Subsequence (LIS) type problems, take things step by step. Literally
        // Check team size for 1, then add anoother, then another
        // Also, sorting makes things bliss
        public int BestTeamScore(int[] scores, int[] ages)
        {
            List<Person> people = new();
            for (int i = 0; i < scores.Length; i++)
            {
                people.Add(new Person { score = scores[i], age = ages[i] });
            }

            people = people.OrderBy(x => x.score).ThenBy(x => x.age).ToList();
            int[] dp = new int[people.Count];

            dp[0] = people[0].score;

            int megaMax = people[0].score;

            for (int i = 1; i < people.Count; i++)
            {
                int currMax = people[i].score;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (people[i].age < people[j].age && people[i].score > people[j].score) continue;

                    currMax = Math.Max(currMax, people[i].score + dp[j]);
                }

                dp[i] = currMax;
                megaMax = Math.Max(megaMax, currMax);
            }

            return megaMax;
        }

        public class Person
        {
            public int score;
            public int age;
        }
    }
}
