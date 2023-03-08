using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0875 : ISolution
    {
        public string Name => "Koko Eating Bananas";
        public string Description => "Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.\r\n\r\nKoko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead and will not eat any more bananas during this hour.\r\n\r\nKoko likes to eat slowly but still wants to finish eating all the bananas before the guards return.\r\n\r\nReturn the minimum integer k such that she can eat all the bananas within h hours.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var piles = new int[] { 805306368, 805306368, 805306368 };
            var h = 1000000000;
            var result = MinEatingSpeed(piles, h);

            // Prettify
            Console.WriteLine($"Input: piles = {piles.GetString()}, h = {h}");
            Console.WriteLine($"Output: {result}");
        }

        // Binary Search involved
        // Here, we learnt 'doubles' are a lot faster than using 'decimals'
        public int MinEatingSpeed(int[] piles, int h)
        {
            int l = 1;
            int r = piles.Max();

            var result = r;

            while (l <= r)
            {
                var pivot = l + (r - l) / 2;
                var time = 0;

                foreach (var p in piles)
                {
                    time += (int)Math.Ceiling((double)p / pivot);

                    // If already over, we can stop counting
                    if (time > h) break;
                }

                if (time > h)
                {
                    l = pivot + 1;
                }
                else
                {
                    result = Math.Min(result, pivot);
                    r = pivot - 1;
                }

            }
            return result;
        }
    }
}
