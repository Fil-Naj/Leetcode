using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0048 : ISolution
    {
        public string Name => "Rotate Image";
        public string Description => "You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var matrix = new int[][] {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5, 6 },
                new int[] { 7, 8, 9 }
            };
            
            // Prettify
            Console.WriteLine($"Input: matrix = {matrix.GetString()}");
            Rotate(matrix);
            Console.WriteLine($"Output: {matrix.GetString()}");
        }

        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            int[][] temp = matrix.Select(a => (int[])a.Clone()).ToArray();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j][(n - 1) - i] = temp[i][j];
                }
            }
        }
    }
}
