using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode12 : ISolution
    {
        public string Name => "Integer to Roman";
        public string Description => "Given an integer, convert it to a roman numeral.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var num = 1994;
            var result = IntToRoman(num);

            // Prettify
            Console.WriteLine($"Input: num = {num}");
            Console.WriteLine($"Output: {result}");
        }

        public string IntToRoman(int num)
        {
            StringBuilder sb = new();
            int m = num / 1000;
            sb.Append(m > 0 ? new string('M', m) : string.Empty);
            num %= 1000;

            int hundreds = num / 100;
            sb.Append(Hundreds[hundreds]);
            num %= 100;

            int tens = num / 10;
            sb.Append(Tens[tens]);
            num %= 10;

            sb.Append(Digits[num]);

            return sb.ToString();
        }

        public Dictionary<int, string> Hundreds = new()
        {
            { 0, string.Empty },
            { 1, "C" },
            { 2, "CC" },
            { 3, "CCC" },
            { 4, "DC" },
            { 5, "D" },
            { 6, "DC" },
            { 7, "DCC" },
            { 8, "DCC" },
            { 9, "CM" },
        };

        public Dictionary<int, string> Tens = new()
        {
            { 0, string.Empty },
            { 1, "X" },
            { 2, "XX" },
            { 3, "XXX" },
            { 4, "LX" },
            { 5, "L" },
            { 6, "LX" },
            { 7, "LXX" },
            { 8, "LXXX" },
            { 9, "XC" },
        };

        public Dictionary<int, string> Digits = new()
        {
            { 0, string.Empty },
            { 1, "I" },
            { 2, "II" },
            { 3, "III" },
            { 4, "IV" },
            { 5, "V" },
            { 6, "VI" },
            { 7, "VII" },
            { 8, "VIII" },
            { 9, "IX" },
        };
    }
}
