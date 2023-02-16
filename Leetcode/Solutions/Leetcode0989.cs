using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0989 : ISolution
    {
        public string Name => "Add to Array-Form of Integer";
        public string Description => "The array-form of an integer num is an array representing its digits in left to right order.\r\n\r\n    For example, for num = 1321, the array form is [1,3,2,1].\r\n\r\nGiven num, the array-form of an integer, and an integer k, return the array-form of the integer num + k.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var num = new int[] { 1, 2, 0, 0 };
            var k = 34;
            var result = AddToArrayForm(num, k);

            // Prettify it
            Console.WriteLine($"Input: nums = {num.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> AddToArrayForm(int[] num, int k)
        {
            var adder = new TenDigitAdder();
            var index = num.Length;

            while (index >= 0 || k != 0)
            {
                var digitToAdd = k % 10;
                adder.AddDigit(index >= 0 ? num[index] : 0, digitToAdd);

                index--;
                k /= 10;
            }

            return adder.GetResult();
        }

        public class TenDigitAdder
        {
            private Stack<int> _result;
            private bool _carry;

            public TenDigitAdder()
            {
                _result = new();
                _carry = false;
            }

            public void AddDigit(int a, int b)
            {
                var sum = a + b +
                    (_carry ? 1 : 0);

                _carry = sum > 9;
                _result.Push(sum % 10);
            }

            public IList<int> GetResult()
            {
                if (_carry) _result.Push(1);

                return _result.ToList();
            }
        }
    }
}
