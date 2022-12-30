using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1962 : ISolution
    {
        public string Name => "Remove Stones to Minimize the Total";
        public string Description => "You are given a 0-indexed integer array piles, where piles[i] represents the number of stones in the ith pile, and an integer k. You should apply the following operation exactly k times:\r\n\r\n    Choose any piles[i] and remove floor(piles[i] / 2) stones from it.\r\n\r\nNotice that you can apply the operation on the same pile more than once.\r\n\r\nReturn the minimum possible total number of stones remaining after applying the k operations.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var piles = new int[] { 3, 2, 4 };
            var k = 6;
            var result = MinStoneSum(piles, k);

            // Prettify
            Console.WriteLine($"Input: piles = {piles.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        // The way to efficiently solve the problem is to always remove stones from the pile with the most stones
        // We can use a priority queue to add the number back everytime which is O(log N)
        // We simply add the result of floor(pile[i] / 2) back in
        // To maximise time complexity, we can keep a cumulative track of the number of stones in the piles
        public int MinStoneSum(int[] piles, int k)
        {
            
            int minAmount = int.MaxValue;
            return minAmount;
        }

        public class PileQueue
        {
            private PriorityQueue<int, int> queue;
            private int NumberOfStones;

            public PileQueue()
            {
                queue = new();
                NumberOfStones = 0;
            }

            public void Enqueue(int number) 
            {
                queue.Enqueue(number, number)
            }
        }
    }
}
