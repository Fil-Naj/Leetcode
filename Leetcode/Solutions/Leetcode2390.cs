using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2390 : ISolution
    {
        public string Name => "Removing Stars From a String";
        public string Description => "You are given a string s, which contains stars *.\r\n\r\nIn one operation, you can:\r\n\r\n    Choose a star in s.\r\n    Remove the closest non-star character to its left, as well as remove the star itself.\r\n\r\nReturn the string after all stars have been removed.\r\n\r\nNote:\r\n\r\n    The input will be generated such that the operation is always possible.\r\n    It can be shown that the resulting string will always be unique.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = "leet**cod*e";
            var result = RemoveStars(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string RemoveStars(string s)
        {
            Stack<char> stack = new();
            foreach (char c in s)
            {
                if (c == '*') stack.TryPop(out var _);
                else stack.Push(c);
            }

            return string.Join("", stack.Reverse());
        }
    }
}
