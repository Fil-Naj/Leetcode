using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1996 : ISolution
    {
        public string Name => "The Number of Weak Characters in the Game";
        public string Description => "You are playing a game that contains multiple characters, and each of the characters has two main properties: attack and defense. You are given a 2D integer array properties where properties[i] = [attacki, defensei] represents the properties of the ith character in the game.\r\n\r\nA character is said to be weak if any other character has both attack and defense levels strictly greater than this character's attack and defense levels. More formally, a character i is said to be weak if there exists another character j where attackj > attacki and defensej > defensei.\r\n\r\nReturn the number of weak characters.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var properties = new int[][]
            {
                new int[] { 5, 5 },
                new int[] { 6, 3 },
                new int[] { 3, 6 },
            };
            var result = NumberOfWeakCharacters(properties);

            // Prettify
            Console.WriteLine($"Input: properties = {properties}");
            Console.WriteLine($"Output: {result}");
        }

        public int NumberOfWeakCharacters(int[][] properties)
        {
            var sorted = properties.OrderByDescending(n => n[0]).ThenBy(n => n[1]);
            var result = 0;
            var maxD = 0;
            foreach (int[] character in sorted)
            {
                if (character[1] < maxD)
                    result++;
                else
                    maxD = character[1];
            }
            return result;
        }
    }
}
