using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Leetcode.Solutions
{
    [ToBeContinued("Shit hard + wrong implentation")]
    public class Leetcode32
    {
        public int LongestValidParentheses(string s)
        {
            Stack<char> stack = new();
            int count = 0;
            int longest = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.TryPeek(out var top))
                    {
                        if (top == '(')
                        {
                            count += 2;
                            if (count > longest)
                                longest = count;
                            stack.Pop();
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
            }
            return longest;
        }
    }
}
