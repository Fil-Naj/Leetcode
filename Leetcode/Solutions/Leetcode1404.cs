using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode1404 : ISolution
    {
        public string Name => "Number of Steps to Reduce a Number in Binary Representation to One";
        public string Description => "Given the binary representation of an integer as a string s, return the number of steps to reduce it to 1 under the following rules:\r\n\r\n    If the current number is even, you have to divide it by 2.\r\n\r\n    If the current number is odd, you have to add 1 to it.\r\n\r\nIt is guaranteed that you can always reach one for all test cases.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = "11";
            var result = NumSteps(data);

            var arr = new int[]
            {
                36,
                45,
                101
            };

            arr[0] = 1;
            List<string> r = [];
            r.AddRange(Enumerable.Repeat(char.ToString('a'), 3));

            // Prettify
            Console.WriteLine($"Input: data = {data}");
            Console.WriteLine($"Output: {result}");
        }

        public int NumSteps(string s)
        {
            StringBuilder sb = new(s);

            var numSteps = 0;
            while (!(sb.ToString().Count(c => c == '1') == 1 && sb[^1] == '1'))
            {
                // If even, divide it by two
                if (sb[^1] == '0')
                {
                    sb.Length--;
                }
                else
                {
                    for (int i = sb.Length - 1; i >= 0; i--)
                    {
                        // If doesn't carry, break
                        if (sb[i] == '0')
                        {
                            sb[i] = '1';
                            break;
                        }
                        else
                        {
                            sb[i] = '0';
                        }
                    }

                    // If carried all the way, add the extra bit at the front
                    if (sb[0] == '0')
                        sb.Insert(0, '1');
                }

                numSteps++;
            }

            return numSteps;
        }
    }
}
