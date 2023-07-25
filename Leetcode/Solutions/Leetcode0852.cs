using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0852 : ISolution
    {
        public string Name => "Peak Index in a Mountain Array";
        public string Description => "An array arr a mountain if the following properties hold:\r\n\r\n    arr.length >= 3\r\n    There exists some i with 0 < i < arr.length - 1 such that:\r\n        arr[0] < arr[1] < ... < arr[i - 1] < arr[i] \r\n        arr[i] > arr[i + 1] > ... > arr[arr.length - 1]\r\n\r\nGiven a mountain array arr, return the index i such that arr[0] < arr[1] < ... < arr[i - 1] < arr[i] > arr[i + 1] > ... > arr[arr.length - 1].\r\n\r\nYou must solve it in O(log(arr.length)) time complexity.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 3, 5, 3, 2, 0 };
            var result = PeakIndexInMountainArray(arr);

            // Prettify
            Console.WriteLine($"Input: data = {arr.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Binary Search
        // Mountain in shape of /\ so find i where arr[i - 1] < arr[i] > arr[i + 1]
        // I.e., if element to the right is bigger, we're still on left side, so can adjust l to current spot
        // If element on right is smaller, we're on the right side, so adjust r to current spot
        // Once l and r are equal, we at the peak
        public int PeakIndexInMountainArray(int[] arr)
        {
            var l = 0; var r = arr.Length - 1;
            
            while (l <= r)
            {
                var pivot = l + ((r - l) >> 1);

                if (arr[pivot] < arr[pivot + 1])
                    l = pivot + 1;
                else
                    r = pivot - 1;
            }
            return l;
        }
    }
}
