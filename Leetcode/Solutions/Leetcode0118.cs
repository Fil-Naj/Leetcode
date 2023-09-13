using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0118 : ISolution
    {
        public string Name => "Pascal's Triangle";
        public string Description => "Given an integer numRows, return the first numRows of Pascal's triangle.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var numRows = 6;
            var result = Generate(numRows);

            // Prettify
            Console.WriteLine($"Input: numRows = {numRows}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> Generate(int numRows)
        {
            var result = new List<IList<int>>() { new int[1] { 1 } };

            for (int i = 1; i < numRows; i++)
            {
                var row = new int[i + 1];
                row[0] = 1; row[^1] = 1;
                var prevRow = result[i - 1];
                for (int j = 1; j < i; j++)
                {
                    row[j] = prevRow[j - 1] + prevRow[j];
                }
                result.Add(row);
            }

            return result;
        }
    }
}
