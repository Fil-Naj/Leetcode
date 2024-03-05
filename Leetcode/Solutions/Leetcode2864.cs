using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode2864 : ISolution
    {
        public string Name => "Maximum Odd Binary Number";
        public string Description => "You are given a binary string s that contains at least one '1'.\r\n\r\nYou have to rearrange the bits in such a way that the resulting binary number is the maximum odd binary number that can be created from this combination.\r\n\r\nReturn a string representing the maximum odd binary number that can be created from the given combination.\r\n\r\nNote that the resulting string can have leading zeros.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "0101";
            var result = MaximumOddBinaryNumber(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string MaximumOddBinaryNumber(string s)
        {
            var ones = s.Count(c => c == '1');

            StringBuilder sb = new();
            sb.Append('1', ones - 1);
            sb.Append('0', s.Length - ones);
            sb.Append('1');

            return sb.ToString();
        }
    }
}
