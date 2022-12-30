namespace Leetcode.Extensions
{
    public static class ListExtensions
    {
        public static void PrintList<T>(this IList<T> list)
        {
            Console.WriteLine("[{0}]", string.Join(", ", list));
        }

        public static string GetString<T>(this IList<T> list)
        {
            return string.Format("[{0}]", string.Join(", ", list));
        }
    }
}
