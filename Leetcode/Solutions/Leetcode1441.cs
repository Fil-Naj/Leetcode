using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1441 : ISolution
    {
        public string Name => "Build an Array With Stack Operations";
        public string Description => "You are given an integer array target and an integer n.\r\n\r\nYou have an empty stack with the two following operations:\r\n\r\n    \"Push\": pushes an integer to the top of the stack.\r\n    \"Pop\": removes the integer on the top of the stack.\r\n\r\nYou also have a stream of the integers in the range [1, n].\r\n\r\nUse the two stack operations to make the numbers in the stack (from the bottom to the top) equal to target. You should follow the following rules:\r\n\r\n    If the stream of the integers is not empty, pick the next integer from the stream and push it to the top of the stack.\r\n    If the stack is not empty, pop the integer at the top of the stack.\r\n    If, at any moment, the elements in the stack (from the bottom to the top) are equal to target, do not read new integers from the stream and do not do more operations on the stack.\r\n\r\nReturn the stack operations needed to build target following the mentioned rules. If there are multiple valid answers, return any of them.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var target = new int[] { 1, 2, 3 };
            var n = 3;
            var result = BuildArray(target, n);

            // Prettify
            Console.WriteLine($"Input: target = {target.GetString()}, n = {n}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<string> BuildArray(int[] target, int n)
        {
            var result = new List<string>();
            var stream = 1;
            var i = 0;
            while (i < target.Length)
            {
                if (target[i] == stream)
                {
                    result.Add("Push");
                    i++;
                }
                else
                {
                    result.Add("Push");
                    result.Add("Pop");
                }
                stream++;
            }

            return result;
        }
    }
}
