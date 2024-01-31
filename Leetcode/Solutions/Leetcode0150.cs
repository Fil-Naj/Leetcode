using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0150 : ISolution
    {
        public string Name => "Evaluate Reverse Polish Notation";
        public string Description => "You are given an array of strings tokens that represents an arithmetic expression in a Reverse Polish Notation.\r\n\r\nEvaluate the expression. Return an integer that represents the value of the expression.\r\n\r\nNote that:\r\n\r\n    The valid operators are '+', '-', '*', and '/'.\r\n    Each operand may be an integer or another expression.\r\n    The division between two integers always truncates toward zero.\r\n    There will not be any division by zero.\r\n    The input represents a valid arithmetic expression in a reverse polish notation.\r\n    The answer and all the intermediate calculations can be represented in a 32-bit integer.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            string[] tokens = ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"];
            var result = EvalRPN(tokens);

            // Prettify
            Console.WriteLine($"Input: tokens = {tokens.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = [];

            foreach (var token in tokens)
            {
                if (int.TryParse(token, out var number))
                {
                    stack.Push(number);
                }
                else
                {
                    var n1 = stack.Pop();
                    var n2 = stack.Pop();
                    stack.Push(token switch
                    {
                        "+" => n2 + n1,
                        "-" => n2 - n1,
                        "*" => n2 * n1,
                        "/" => n2 / n1,
                        _ => 0
                    });
                }
            }

            return stack.Peek();
        }
    }
}
