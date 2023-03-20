using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0605 : ISolution
    {
        public string Name => "Can Place Flowers";
        public string Description => "You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.\r\n\r\nGiven an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var flowerbed = new int[] { 1, 0, 0, 0, 1 };
            var n = 2;
            var result = CanPlaceFlowers(flowerbed, n);

            // Prettify
            Console.WriteLine($"Input: flowerbed = {flowerbed.GetString()}, n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;

            int len = flowerbed.Length;
            for (int i = 0; i < len; i++)
            {
                var goodFromBehind = i - 1 < 0 || flowerbed[i - 1] == 0;
                var goodFromForward = i + 1 >= len || flowerbed[i + 1] == 0;

                if (flowerbed[i] != 1 && goodFromBehind && goodFromForward)
                {
                    n--;
                    flowerbed[i] = 1;
                    if (n <= 0) return true;
                }
            }

            return false;
        }
    }
}
