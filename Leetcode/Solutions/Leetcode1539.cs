using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1539 : ISolution
    {
        public string Name => "Kth Missing Positive Number";
        public string Description => "Given an array arr of positive integers sorted in a strictly increasing order, and an integer k.\r\n\r\nReturn the kth positive integer that is missing from this array.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 2, 3, 4, 7, 11 };
            var k = 5;
            var result = FindKthPositive(arr, k);

            // Prettify
            Console.WriteLine($"Input: arr = {arr.GetString()}, k = {k}");
            Console.WriteLine($"Output: {result}");
        }

        public int FindKthPositive(int[] arr, int k)
        {
            int BinSearch(int left, int right)
            {
                if (left > right) return left + k;

                var pivot = left + (right - left) / 2;
                if (arr[pivot] - (pivot + 1) < k) return BinSearch(pivot + 1, right);
                else return BinSearch(left, pivot - 1);
            }

            return BinSearch(0, arr.Length - 1);
        }
    }
}
