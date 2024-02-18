using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1642 : ISolution
    {
        public string Name => "Furthest Building You Can Reach";
        public string Description => "You are given an integer array heights representing the heights of buildings, some bricks, and some ladders.\r\n\r\nYou start your journey from building 0 and move to the next building by possibly using bricks or ladders.\r\n\r\nWhile moving from building i to building i+1 (0-indexed),\r\n\r\n    If the current building's height is greater than or equal to the next building's height, you do not need a ladder or bricks.\r\n    If the current building's height is less than the next building's height, you can either use one ladder or (h[i+1] - h[i]) bricks.\r\n\r\nReturn the furthest building index (0-indexed) you can reach if you use the given ladders and bricks optimally.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var heights = new int[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 };
            var bricks = 10;
            var ladders = 2;
            var result = FurthestBuilding(heights, bricks, ladders);

            // Prettify
            Console.WriteLine($"Input: heights = {heights.GetString()}, bricks = {bricks}, ladders = {ladders}");
            Console.WriteLine($"Output: {result}");
        }

        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            PriorityQueue<int, int> pq = new();

            for (var i = 0; i < heights.Length - 1; i++)
            {
                var diff = heights[i + 1] - heights[i];

                // If next building is smaller or same, continue
                if (diff < 0) continue;

                // Else, add the difference to the pq
                pq.Enqueue(diff, diff);

                // Greedy method, use ladders first
                // Once we have more buildings to climb than ladders, replace the smallest building climbs with bricks
                // If we have less than zero bricks after this replacement, then we cannot go further
                if (pq.Count > ladders)
                    bricks -= pq.Dequeue();

                if (bricks < 0)
                    return i;
            }

            // If reached here, we are on the last building. Thus, return index of last building
            return heights.Length - 1;
        }
    }
}
