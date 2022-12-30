using System.Text;

namespace Leetcode.Extensions
{
    public static class MatrixExtensions
    {
        public static string GetString<T>(this T[][] matrix)
        {
            StringBuilder sb = new();

            foreach (var line in matrix)
                sb.AppendLine(line.ToString());

            return sb.ToString();
        }

        private static void PrintMatrix<T>(this T[][] matrix)
        {
            Console.WriteLine(matrix.GetString());
        }
    }
}
