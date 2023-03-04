using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0912 : ISolution
    {
        public string Name => "Sort an Array";
        public string Description => "Given an array of integers nums, sort the array in ascending order and return it.\r\n\r\nYou must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 5, 2, 3, 1 };
            var result = SortArray(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        // We shall implement Heap Sort - Time: O(n·log n), Space: O(1)
        public int[] SortArray(int[] nums)
        {
            HeapSort.Sort(nums);

            return nums;
        }

        public static class HeapSort
        {
            public static void Sort(int[] nums)
            {
                var n = nums.Length;

                // Build Heap
                for (int i = n / 2; i >= 0; i--)
                {
                    Heapify(nums, n, i);
                }

                // One by one, extract an element from the heap
                for (int i = n - 1; i > 0; i--)
                {
                    // Move current root to end
                    (nums[0], nums[i]) = (nums[i], nums[0]);

                    // Call max heapify on the reduced heap
                    Heapify(nums, i, 0);
                }
            }

            private static void Heapify(int[] nums, int n, int i)
            {
                // Largest starts as the root
                var largest = i;
                var l = 2 * i + 1;
                var r = 2 * i + 2;

                // If left bigger than root
                if (l < n && nums[l] > nums[largest])
                    largest = l;

                // If right bigger than root
                if (r < n && nums[r] > nums[largest])
                    largest = r;

                // If largest is not the root anymore...
                if (largest != i)
                {
                    // Swap intial with new largest
                    (nums[i], nums[largest]) = (nums[largest], nums[i]);

                    // Recursivelyt heapify the affected sub-tree
                    Heapify(nums, n, largest);
                }
            }
        }
    }
}
