using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0020 : ISolution
    {
        public string Name => "Valid Parentheses";
        public string Description => "Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.\r\n\r\nAn input string is valid if:\r\n\r\n    Open brackets must be closed by the same type of brackets.\r\n    Open brackets must be closed in the correct order.\r\n    Every close bracket has a corresponding open bracket of the same type.\r\n";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            string s = "]";
            var result = IsValid(s);

            // Prettify
            Console.WriteLine($"Input: s = {s}");
            Console.WriteLine($"Output: {result}");
        }

        Dictionary<char, char> Brackets = new()
        {
            { '{', '}' },
            { '(', ')' },
            { '[', ']' },
        };

        public bool IsValid(string s)
        {
            Stack<char> stack = new();

            foreach (var c in s)
            {
                if (Brackets.ContainsKey(c))
                    stack.Push(c);
                else
                    if (!stack.TryPop(out var closing) || Brackets[closing] != c) return false;
            }

            return stack.Count == 0;
        }
    }
}
