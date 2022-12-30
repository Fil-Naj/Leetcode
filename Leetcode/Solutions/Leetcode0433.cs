using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0433 : ISolution
    {
        public string Name => "Minimum Genetic Mutation";
        public string Description => "A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.\r\n\r\nSuppose we need to investigate a mutation from a gene string start to a gene string end where one mutation is defined as one single character changed in the gene string.\r\n\r\n    For example, \"AACCGGTT\" --> \"AACCGGTA\" is one mutation.\r\n\r\nThere is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it a valid gene string.\r\n\r\nGiven the two gene strings start and end and the gene bank bank, return the minimum number of mutations needed to mutate from start to end. If there is no such a mutation, return -1.\r\n\r\nNote that the starting point is assumed to be valid, so it might not be included in the bank.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var start = "AACCGGTT";
            var end = "AACCGGTA";
            var bank = new string[] { "AACCGGTA" };
            var result = MinMutation(start, end, bank);

            // Prettify
            Console.WriteLine($"Input: start = {start}, end = {end}, bank = {bank.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinMutation(string start, string end, string[] bank)
        {
            // time to bfs this bitch
            HashSet<string> visited = new();
            Queue<string> queue = new();
            HashSet<string> fastBank = new(bank);
            var possible = new string[] { "A", "C", "G", "T" };

            // Let's start babyyyyy
            queue.Enqueue(start);

            int depth = 0;
            while (queue.Count > 0)
            {
                var count = queue.Count;

                for (int i = 0; i < count; i++)
                {
                    var gene = queue.Dequeue();
                    visited.Add(gene);

                    if (gene == end) return depth;

                    for (int j = 0; j < 8; j++)
                    {
                        foreach (var c in possible)
                        {
                            var temp = gene.Remove(j, 1).Insert(j, c);
                            if (fastBank.Contains(temp) && !visited.Contains(temp))
                                queue.Enqueue(temp);
                        }
                    }
                }
                depth++;
            }
            return -1;
        }
    }
}
