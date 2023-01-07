using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0134 : ISolution
    {
        public string Name => "Gas Station";
        public string Description => "here are n gas stations along a circular route, where the amount of gas at the ith station is gas[i].\r\n\r\nYou have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. You begin the journey with an empty tank at one of the gas stations.\r\n\r\nGiven two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. If there exists a solution, it is guaranteed to be unique";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var gas = new int[] { 1, 2, 3, 4, 5 };
            //var cost = new int[] { 3, 4, 5, 1, 2 };
            var gas = new int[] { 2, 3, 4 };
            var cost = new int[] { 3, 4, 3 };
            var result = CanCompleteCircuit(gas, cost);

            // Prettify
            Console.WriteLine($"Input: gas = {gas.GetString()}, target = {cost.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            // If not enough fuel to make trip, return -1
            if (gas.Sum() < cost.Sum()) return -1;

            int tank = 0; int start = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                tank += gas[i] - cost[i];

                // If tank is empty (or less), then restart and ajust initial start position
                if (tank < 0)
                {
                    tank = 0;
                    start = i + 1;
                }

            }

            return start;
        }
    }
}
