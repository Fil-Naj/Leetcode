using Leetcode.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Leetcode.Solutions
{
    public class Leetcode0032 : ISolution
    {
        public string Name => "Longest Valid Parentheses";
        public string Description => "Given a string containing just the characters '(' and ')', return the length of the longest valid (well-formed) parentheses\r\nsubstring\r\n.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = ")()())";
            var result = LongestValidParentheses(s);

            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        public int LongestValidParentheses(string s)
        {
            Stack<int> invalidStarts = new(new int[] { -1 });
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    invalidStarts.Push(i);
                }
                else
                {
                    // Remove last '(' as it is now valid
                    invalidStarts.TryPop(out var _);

                    if (invalidStarts.Count == 0)
                    {
                        invalidStarts.Push(i);
                    }
                    else
                    {
                        // Get last valid index by peeking top of stack.
                        result = Math.Max(result, i - invalidStarts.Peek());
                    }
                }
            }

            return result;
        }
    }
}
