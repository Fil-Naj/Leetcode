﻿namespace Leetcode.Extensions
{
    public static class ArrayExtensions
    {
        public static string GetString<T>(this T[] array)
        {
            return string.Format("[{0}]", string.Join(", ", array));
        }

        public static void PrintArray<T>(this T[] array)
        {
            Console.WriteLine("[{0}]", string.Join(", ", array));
        }
    }
}
