using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1318 : ISolution
    {
        public string Name => "Minimum Flips to Make a OR b Equal to c";
        public string Description => "Given 3 positives numbers a, b and c. Return the minimum flips required in some bits of a and b to make ( a OR b == c ). (bitwise OR operation).\r\nFlip operation consists of change any single bit 1 to 0 or change the bit 0 to 1 in their binary representation.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var a = 8;
            var b = 3;
            var c = 5;
            var result = MinFlips(a, b, c);

            // Prettify
            Console.WriteLine($"Input: a = {a}, b = {b}, c = {c}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinFlips(int a, int b, int c)
        {
            var flips = 0;
            while (c > 0 || a > 0 || b > 0)
            {
                if ((c & 1) == 1 && (a & 1) == (b & 1) && (a & 1) == 0)
                {
                    flips++;
                }
                else if ((c & 1) == 0)
                {
                    if ((a & 1) == (b & 1))
                    {
                        if ((a & 1) == 1)
                        {
                            flips += 2;
                        }
                    }
                    else
                    {
                        flips++;
                    }
                }


                a >>= 1; 
                b >>= 1;
                c >>= 1;
            }

            return flips;
        }
    }
}
