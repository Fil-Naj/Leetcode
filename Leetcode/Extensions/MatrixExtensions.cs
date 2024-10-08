﻿namespace Leetcode.Extensions
{
    public static class MatrixExtensions
    {
        public static string GetString<T>(this T[][] matrix)
        {
            if (matrix == null) return null;

            return string.Join(Environment.NewLine, matrix.Select(r => r?.GetString()));
        }
        
        public static string GetString<T>(this T[][] matrix, string? delimiter = null)
        {
            if (matrix == null) return null;

            return string.Format("[{0}]", string.Join(delimiter ?? Environment.NewLine, matrix.Select(r => r?.GetString())));
        }

        public static void PrintMatrix<T>(this T[][] matrix)
        {
            Console.WriteLine(matrix?.GetString());
        }
    }
}
