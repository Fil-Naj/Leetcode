using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0077 : ISolution
    {
        public string Name => "Combinations";
        public string Description => "Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].\r\n\r\nYou may return the answer in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var n = 4;
            var k = 2;
            var result = Combine(n, k);

            // Prettify
            Console.WriteLine($"Input: n = {n}, k = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> result = new();
            var combination = new int[k];

            void Dfs(int index, int start)
            {
                for (int i = start; i <= n; i++)
                {
                    combination[index] = i;

                    if (index == k - 1)
                        result.Add(combination.ToList());
                    else
                        Dfs(index + 1, i + 1);
                }
            }
            
            Dfs(0, 1);

            return result;
        }
    }
}
