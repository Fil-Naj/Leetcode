using System.Collections;

namespace Leetcode.Extensions
{
    public static class ListExtensions
    {
        public static void PrintList<T>(this IList list)
        {
            Console.WriteLine("[{0}]", string.Join(", ", list));
        }

        public static string GetString<T>(this IList<T> list)
        {
            return GetString((IList) list);
        }

        private static string GetString(this IList list)
        {
            List<string> items = new();
            foreach (var item in list)
            {
                if (item is IList nestedList)
                    items.Add(GetString(nestedList));
                else if (item is Array array)
                    items.Add(GetString(array));
                else
                    items.Add(item?.ToString() ?? string.Empty);
            }

            return string.Format("[{0}]", string.Join(", ", items));
        }
    }
}
