using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1011 : ISolution
    {
        public string Name => "Capacity To Ship Packages Within D Days";
        public string Description => "A conveyor belt has packages that must be shipped from one port to another within days days.\r\n\r\nThe ith package on the conveyor belt has a weight of weights[i]. Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.\r\n\r\nReturn the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within days days.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var weights = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var days = 5;
            var result = ShipWithinDays(weights, days);

            // Prettify
            Console.WriteLine($"Input: weights = {weights.GetString()}, days = {days}");
            Console.WriteLine($"Output: {result}");
        }

        // Uses a binary search approach
        // Source: https://www.youtube.com/watch?v=ER_oLmdc-nw
        public int ShipWithinDays(int[] weights, int days)
        {
            var lowerBound = weights.Max();
            var upperBound = weights.Sum();

            bool CanShip(int cap)
            {
                var numShips = 1;
                var currentCap = cap;

                foreach (var weight in weights)
                {
                    if (currentCap - weight < 0)
                    {
                        numShips++;
                        currentCap = cap;
                    }
                    currentCap -= weight;
                }

                return numShips <= days;
            }


            var result = upperBound;
            while (lowerBound <= upperBound)
            {
                var cap = (lowerBound + upperBound) / 2;

                if (CanShip(cap))
                {
                    result = Math.Min(result, cap);
                    upperBound = cap - 1;
                }
                else
                {
                    lowerBound = cap + 1;
                }
            }

            return result;
        }
    }
}
