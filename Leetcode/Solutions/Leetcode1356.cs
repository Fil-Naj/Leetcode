using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1356 : ISolution
    {
        public string Name => "Sort Integers by The Number of 1 Bits";
        public string Description => "You are given an integer array arr. Sort the integers in the array in ascending order by the number of 1's in their binary representation and in case of two or more integers have the same number of 1's you have to sort them in ascending order.\r\n\r\nReturn the array after sorting it.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 8898, 349, 9746 };
            Console.WriteLine($"Input: arr = {arr.GetString()}");

            var result = SortByBits(arr);

            // Prettify
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] SortByBits(int[] arr)
        {
            Array.Sort(arr, new BitComparer());
            return arr;
        }

        public class BitComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                var x1s = CountNumberOf1s(x);
                var y1s = CountNumberOf1s(y);

                if (x1s == y1s) return x - y;

                return x1s - y1s;
            }

            private static int CountNumberOf1s(int x)
            {
                x = (x & (0x55555555)) + ((x >> 1) & (0x55555555));
                x = (x & (0x33333333)) + ((x >> 2) & (0x33333333));
                x = (x & (0x0f0f0f0f)) + ((x >> 4) & (0x0f0f0f0f));
                x = (x & (0x00ff00ff)) + ((x >> 8) & (0x00ff00ff));
                x = (x & (0x0000ffff)) + ((x >> 16) & (0x0000ffff));
                return x;
            }
        }
    }
}
