using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1547 : ISolution
    {
        public string Name => "Minimum Cost to Cut a Stick";
        public string Description => "Given a wooden stick of length n units. The stick is labelled from 0 to n. For example, a stick of length 6 is labelled as follows:\r\n\r\nGiven an integer array cuts where cuts[i] denotes a position you should perform a cut at.\r\n\r\nYou should perform the cuts in order, you can change the order of the cuts as you wish.\r\n\r\nThe cost of one cut is the length of the stick to be cut, the total cost is the sum of costs of all cuts. When you cut a stick, it will be split into two smaller sticks (i.e. the sum of their lengths is the length of the stick before the cut). Please refer to the first example for a better explanation.\r\n\r\nReturn the minimum total cost of the cuts.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 7;
            var cuts = new int[] { 1, 3, 4, 5 };
            var result = MinCost(n, cuts);

            // Prettify
            Console.WriteLine($"Input: n = {n}, cuts = {cuts.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // More optimal to use the indexes of the cuts for the dp and for loop
        // Better to iterate through max 100 than max 10^6
        public int MinCost(int n, int[] cuts)
        {
            Dictionary<(int from, int to), int> dp = new();

            int Cut(int from, int to)
            {
                if (dp.ContainsKey((from, to)))
                    return dp[(from, to)];

                var cost = to - from;
                var cutCost = int.MaxValue;
                var hasCut = false;
                foreach (var cut in cuts)
                {
                    if (cut <= from || cut >= to) continue;

                    hasCut = true;
                    cutCost = Math.Min(cutCost, Cut(from, cut) + Cut(cut, to) + cost);
                }
                dp[(from, to)] = hasCut ? cutCost : 0;
                return dp[(from, to)];
            }

            return Cut(0, n);
        }
    }
}
