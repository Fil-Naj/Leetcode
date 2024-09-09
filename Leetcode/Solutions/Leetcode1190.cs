using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1190 : ISolution
    {
        public string Name => "Reverse Substrings Between Each Pair of Parentheses";
        public string Description => "You are given a string s that consists of lower case English letters and brackets.\r\n\r\nReverse the strings in each pair of matching parentheses, starting from the innermost one.\r\n\r\nYour result should not contain any brackets.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var s = "(ed(et(oc))el)";
            var result = ReverseParentheses(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public string ReverseParentheses(string s)
        {
            Stack<string> stack = [];

            var currString = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(currString);
                    currString = string.Empty;
                }
                else if (s[i] == ')')
                {
                    currString = stack.TryPop(out var baseStr)
                        ? baseStr + new string(currString.Reverse().ToArray())
                        : new string(currString.Reverse().ToArray());
                }
                else
                {
                    currString += s[i];
                }
            }

            return currString;
        }
    }
}
