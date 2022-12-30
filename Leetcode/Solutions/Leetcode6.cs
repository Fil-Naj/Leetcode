using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode6 : ISolution
    {
        public string Name => "Zigzag Conversion";
        public string Description => "Write the code that will take a string and make a zigzag conversion given a number of rows";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "PAYPALISHIRING";
            var numRows = 3;
            string result = Convert(s, numRows);

            // Prettyify
            Console.WriteLine($"Input: s = {s}, numRows = {numRows}");
            Console.WriteLine($"Output: {result}");
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            string[] rows = new string[numRows];

            int rowNum = 0;
            bool isGoingDown = true;
            foreach (char c in s)
            {
                rows[rowNum] += c;
                rowNum += isGoingDown ? 1 : -1;
                if (rowNum == 0 || rowNum == numRows - 1) isGoingDown = !isGoingDown;
            }
                
            return string.Join("", rows);
        }
    }
}
