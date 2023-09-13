using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0168 : ISolution
    {
        public string Name => "Excel Sheet Column Title";
        public string Description => "Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var columnNumber = 6;
            var result = ConvertToTitle(columnNumber);

            // Prettify
            Console.WriteLine($"Input: columnNumber = {columnNumber}");
            Console.WriteLine($"Output: {result}");
        }

        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder sb = new();
            while (columnNumber > 0)
            {
                sb.Insert(0, (char)('A' + (columnNumber - 1) % 26));
                columnNumber = (columnNumber - 1) / 26;
            }

            return sb.ToString();
        }
    }
}
