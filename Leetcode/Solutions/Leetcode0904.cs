using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0904 : ISolution
    {
        public string Name => "Fruit Into Baskets";
        public string Description => "You are visiting a farm that has a single row of fruit trees arranged from left to right. The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.\r\n\r\nYou want to collect as much fruit as possible. However, the owner has some strict rules that you must follow:\r\n\r\n    You only have two baskets, and each basket can only hold a single type of fruit. There is no limit on the amount of fruit each basket can hold.\r\n    Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right. The picked fruits must fit in one of your baskets.\r\n    Once you reach a tree with fruit that cannot fit in your baskets, you must stop.\r\n\r\nGiven the integer array fruits, return the maximum number of fruits you can pick.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var fruits = new int[] { 0, 1 };
            var result = TotalFruit(fruits);

            // Prettify
            Console.WriteLine($"Input: fruits = {fruits.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int TotalFruit(int[] fruits)
        {
            int prev = 0;
            int current = fruits[0];

            // Starting points
            int threadStart = 0;
            int currentStart = 0;

            int result = 1;

            for (int i = 1; i < fruits.Length; i++)
            {
                // Is same fruit as last
                if (fruits[i] == current) continue;

                // Is second fruit in basket, but not the most recent
                if (fruits[i] == prev)
                {
                    prev = current;
                    current = fruits[i];
                }
                // Is a completely new fruit
                else
                {
                    result = Math.Max(result, i - threadStart);

                    prev = current;
                    threadStart = currentStart;
                    current = fruits[i];
                }

                // Keep track of start of same fruit train
                currentStart = i;
            }

            return Math.Max(result, fruits.Length - threadStart);
        }
    }
}
