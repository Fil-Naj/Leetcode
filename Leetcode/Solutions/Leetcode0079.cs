using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0079 : ISolution
    {
        public string Name => "Word Search";
        public string Description => "Given an m x n grid of characters board and a string word, return true if word exists in the grid.\r\n\r\nThe word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring. The same letter cell may not be used more than once.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            char[][] data = [['A', 'B', 'C', 'E'], ['S', 'F', 'C', 'S'], ['A', 'D', 'E', 'E']];
            var word = "ABCB";
            var result = Exist(data, word);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}, target = {word}");
            Console.WriteLine($"Output: {result}");
        }

        public bool Exist(char[][] board, string word)
        {
            var n = board[0].Length;
            var m = board.Length;

            bool Dfs(int row, int col, int index)
            {
                // If passed the word, then we have found the whole thing
                if (index == word.Length)
                    return true;

                // If out of bounds, dont look further
                if (row < 0 || row >= m || col < 0 || col >= n)
                    return false;

                // If in bounds, but not equal to what we are looking for, stop the search
                if (board[row][col] != word[index])
                    return false;

                // Adjust the board as to not loop
                var temp = board[row][col];
                board[row][col] = ' ';

                if (Dfs(row + 1, col, index + 1)  // down
                    || Dfs(row - 1, col, index + 1)  // up
                    || Dfs(row, col + 1, index + 1)  // right
                    || Dfs(row, col - 1, index + 1)) // left
                    return true;

                // If reached this point, failed to find word
                // Add back char
                board[row][col] = temp;
                return false;
            }

            for (var row = 0; row < m; row++)
            {
                for (var col = 0; col < n; col++)
                {
                    if (Dfs(row, col, 0))
                        return true;
                }
            }

            return false;
        }
    }
}
