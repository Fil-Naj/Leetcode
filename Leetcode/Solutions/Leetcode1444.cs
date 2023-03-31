using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1444 : ISolution
    {
        public string Name => "Number of Ways of Cutting a Pizza";
        public string Description => "Given a rectangular pizza represented as a rows x cols matrix containing the following characters: 'A' (an apple) and '.' (empty cell) and given the integer k. You have to cut the pizza into k pieces using k-1 cuts. \r\n\r\nFor each cut you choose the direction: vertical or horizontal, then you choose a cut position at the cell boundary and cut the pizza into two pieces. If you cut the pizza vertically, give the left part of the pizza to a person. If you cut the pizza horizontally, give the upper part of the pizza to a person. Give the last piece of pizza to the last person.\r\n\r\nReturn the number of ways of cutting the pizza such that each piece contains at least one apple. Since the answer can be a huge number, return this modulo 10^9 + 7.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var pizza = new string[]
            {
                "A..",
                "AA.",
                "..."
            };
            var k = 3;
            var result = Ways(pizza, k);

            // Prettify
            Console.WriteLine($"Input: pizza = {pizza.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        // Source: https://www.youtube.com/watch?v=x05misqS7yI
        public int Ways(string[] pizza, int k)
        {
            var rows = pizza.Length;
            var cols = pizza[0].Length;

            var dp = new int?[k, rows, cols];

            // Precalculate number of apples to the right and down of any spot in the pizza
            // Will allow O(1) checks for if both pieces have at least one apple later on
            int[,] apples = new int[rows + 1, cols + 1];
            for (int row = rows - 1; row >= 0; row--)
                for (int col = cols - 1; col >= 0; col--)
                    apples[row, col] = apples[row + 1, col] + apples[row, col + 1] - apples[row + 1, col + 1] + (pizza[row][col] == 'A' ? 1 : 0);

            int Dfs(int k, int r, int c)
            {
                // If no apples in this section, do not continue. Return 0
                if (apples[r, c] == 0) return 0;

                // If no more cuts available, return 1 as no more are possible
                if (k == 0) return 1;

                // If already visited, return stored answer
                if (dp[k, r, c].HasValue) return dp[k, r, c].Value;

                int answer = 0;
                // Cut rows, towards right of current row position
                for (int row = r + 1; row < rows; row++)
                {
                    // If both pices have apples, go to cut again. If not, move on
                    if (apples[r, c] - apples[row, c] > 0)
                        answer = (answer + Dfs(k - 1, row, c)) % 1000000007;
                }

                // Cut cols, towards down of current column position
                for (int col = c + 1; col < cols; col++)
                {
                    // If both pices have apples...
                    if (apples[r, c] - apples[r, col] > 0)
                        answer = (answer + Dfs(k - 1, r, col)) % 1000000007;
                }

                dp[k, r, c] = answer;

                return answer;
            }

            return Dfs(k - 1, 0, 0);
        }
    }
}
