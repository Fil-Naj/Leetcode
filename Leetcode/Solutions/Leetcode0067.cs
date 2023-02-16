using Leetcode.Extensions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0067 : ISolution
    {
        public string Name => "Add Binary";
        public string Description => "Given two binary strings a and b, return their sum as a binary string.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            string a = "10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101";
            string b = "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011";
            //string a = "1010";
            //string b = "1011";
            var result = AddBinary(a, b);

            Console.WriteLine($"Input: a = {a}, b = {b}");
            Console.WriteLine($"Output: {result}");
        }

        public string AddBinary(string a, string b)
        {
            var maxLen = Math.Max(a.Length, b.Length);
            var adder = new TwoBitAdder();
            
            for (int i = 0; i < maxLen; i++)
            {
                adder.Add(i < a.Length ? a[a.Length - i - 1] : '0', i < b.Length ? b[b.Length - i - 1] : '0');
            }

            return adder.GetAnswer();
        }

        public class TwoBitAdder
        {
            private StringBuilder _sb;
            private bool _carry;

            public TwoBitAdder()
            {
                _sb = new();
            }

            public void Add(char a, char b)
            {
                var sum = 
                    (a == '1' ? 1 : 0) +
                    (b == '1' ? 1 : 0) +
                    (_carry ? 1 : 0);

                _sb.Insert(0, sum & 1);
                _carry = sum >= 2;
            }

            public string GetAnswer()
            {
                if (_carry) _sb.Insert(0, '1');

                return _sb.ToString();
            }
        }
    }
}
