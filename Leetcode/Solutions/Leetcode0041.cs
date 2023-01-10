using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    [ToBeContinued("Find true time complexity of O(n)")]
    public class Leetcode0041 : ISolution
    {
        public string Name => "First Missing Positive";
        public string Description => "Given an unsorted integer array nums, return the smallest missing positive integer.\r\n\r\nYou must implement an algorithm that runs in O(n) time and uses constant extra space.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 2, 0 };
            //var nums = new int[] { 3, 4, -1, 1 };
            //var nums = new int[] { 0, 2, 2, 4, 0, 1, 0, 1, 3 };
            //var nums = new int[] { 12, 34, 41, 9, 14, 9, 26, 13, 13, 4, 19, 5, 19, 18, -1, 6, 5, 32, -9, 8, 35, -6, 41, -2, 11, 41, -6, 13, 17, -8, 41, 34, -2, 40, 2, 24, 21, 36, 1, 22, 1, 3 };
            //var nums = new int[] { 99, 94, 96, 11, 92, 5, 91, 89, 57, 85, 66, 63, 84, 81, 79, 61, 74, 78, 77, 30, 64, 13, 58, 18, 70, 69, 51, 12, 32, 34, 9, 43, 39, 8, 1, 38, 49, 27, 21, 45, 47, 44, 53, 52, 48, 19, 50, 59, 3, 40, 31, 82, 23, 56, 37, 41, 16, 28, 22, 33, 65, 42, 54, 20, 29, 25, 10, 26, 4, 60, 67, 83, 62, 71, 24, 35, 72, 55, 75, 0, 2, 46, 15, 80, 6, 36, 14, 73, 76, 86, 88, 7, 17, 87, 68, 90, 95, 93, 97, 98 };
            var result = FirstMissingPositive(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Not exaclty O(n) time, but the space is constant O(1)
        // Worst case in this case is to loop another n times, thus O(n^2).
        public int FirstMissingPositive(int[] nums)
        {
            var result = 1;
            var start = 0;

            var count = 0;
            while (start != result)
            {
                start = result;
                count++;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (result == nums[i]) result++;
                }

                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (result == nums[i]) result++;
                }
            }
            Console.WriteLine($"Used {count} iterations, n = {nums.Length}");
            return result;
        }
    }
}
