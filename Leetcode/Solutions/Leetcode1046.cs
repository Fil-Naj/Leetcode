using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1046 : ISolution
    {
        public string Name => "Last Stone Weight";
        public string Description => "You are given an array of integers stones where stones[i] is the weight of the ith stone.\r\n\r\nWe are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together. Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:\r\n\r\n    If x == y, both stones are destroyed, and\r\n    If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.\r\n\r\nAt the end of the game, there is at most one stone left.\r\n\r\nReturn the weight of the last remaining stone. If there are no stones left, return 0.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var stones = new int[] { 2, 7, 4, 1, 8, 1 };
            var result = LastStoneWeight(stones);

            // Prettify
            Console.WriteLine($"Input: stones = {stones.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int LastStoneWeight(int[] stones)
        {
            // Priority queue where priority sorted in desc order
            PriorityQueue<int, int> pq = new(Comparer<int>.Create((a, b) => b - a));
            foreach (var stone in stones)
            {
                pq.Enqueue(stone, stone);
            }

            while (pq.Count > 1)
            {
                var y = pq.Dequeue();
                var x = pq.Dequeue();

                if (y == x) continue;

                var left = y - x;
                pq.Enqueue(left, left);
            }

            return pq.TryPeek(out var result, out var _) ? result : 0;
        }
    }
}
