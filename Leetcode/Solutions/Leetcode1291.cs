using System.Text;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1291 : ISolution
    {
        public string Name => "Sequential Digits";
        public string Description => "An integer has sequential digits if and only if each digit in the number is one more than the previous digit.\r\n\r\nReturn a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var low = 10;
            var high = 1000000000;
            var result = SequentialDigits(low, high);

            // Prettify
            Console.WriteLine($"Input: low = {low}, high = {high}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        const string Numbers = "123456789";

        public IList<int> SequentialDigits(int low, int high)
        {
            List<int> result = [];

            void Dfs(int l, int r)
            {
                if (r == 10) return;

                var num = int.Parse(Numbers[l..r]);
                if (num >= low && num <= high)
                    result.Add(num);

                Dfs(l, r + 1);
            }

            for (var i = 1; i <= 9; i++)
                Dfs(i, i + 1);

            result.Sort();
            return result;
        }
    }
}
