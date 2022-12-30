using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    [ToBeContinued("Just up and down diag checks, nice and easy")]
    public class Leetcode0766 : ISolution
    {
        public string Name => "Toeplitz Matrix";
        public string Description => "Given an m x n matrix, return true if the matrix is Toeplitz. Otherwise, return false.\r\n\r\nA matrix is Toeplitz if every diagonal from top-left to bottom-right has the same elements.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var matrix = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 5, 1, 2, 3 },
                new int[] { 9, 5, 1, 2 },
            };
            var result = IsToeplitzMatrix(matrix);

            // Prettify
            Console.WriteLine($"Input: matrix = {matrix.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public bool IsToeplitzMatrix(int[][] matrix)
        {
            return true;
        }
    }
}
