using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0926 : ISolution
    {
        public string Name => "Flip String to Monotone Increasing";
        public string Description => "A binary string is monotone increasing if it consists of some number of 0's (possibly none), followed by some number of 1's (also possibly none).\r\n\r\nYou are given a binary string s. You can flip s[i] changing it from 0 to 1 or from 1 to 0.\r\n\r\nReturn the minimum number of flips to make s monotone increasing.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = "00011000";
            var result = MinFlipsMonoIncr(s);

            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int MinFlipsMonoIncr(string s)
        {
            var result = 0;
            var oneCounter = 0;

            foreach (char c in s)
            {
                if (c == '1')
                    oneCounter++;
                else
                    result = Math.Min(result + 1, oneCounter);
            }

            return result;
        }
    }
}
