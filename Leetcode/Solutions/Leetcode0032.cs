using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    // Source: https://www.youtube.com/watch?v=q56S5NIqjdE
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

        // Time: O(n)
        // Space: O(n)
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

        // Time: O(n) as n + n
        // Space O(1)
        public int LongestValidParentheses2(string s)
        {
            int result = 0;

            var l = 0; var r = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    l++;
                else
                    r++;

                if (l == r)
                {
                    result = Math.Max(result, r * 2);
                }
                else if (r > l)
                {
                    l = 0; r = 0;
                }
            }

            l = 0; r = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                    r++;
                else
                    l++;

                if (l == r)
                {
                    result = Math.Max(result, r * 2);
                }
                else if (r < l)
                {
                    l = 0; r = 0;
                }
            }

            return result;
        }
    }
}
