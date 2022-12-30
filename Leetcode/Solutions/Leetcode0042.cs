using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    // Inspiration (Source): https://www.youtube.com/watch?v=ZI2z5pq0TqA
    public class Leetcode0042 : ISolution
    {
        public string Name => "Trapping Rain Water";
        public string Description => "Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var result = Trap2(height);

            // Prettify
            Console.WriteLine($"Input: height = {height}");
            Console.WriteLine($"Output: {result}");
        }

        // <summary>
        // Stored values of maxL and maxR
        // Time: O(n), Space: O(n)
        // </summary>
        // <param name = "height" ></ param >
        // < returns ></ returns >
        public int Trap2(int[] height)
        {
            int length = height.Length;
            if (length == 0) return 0;

            int sum = 0;

            int[] maxL = new int[length];
            int[] maxR = new int[length];

            // Populate maxL and maxR
            for (int leftPointer = 1; leftPointer < length; leftPointer++)
            {
                var rightPointer = length - 1 - leftPointer;

                maxL[leftPointer] = Math.Max(maxL[leftPointer - 1], height[leftPointer - 1]);
                maxR[rightPointer] = Math.Max(maxR[rightPointer + 1], height[rightPointer + 1]);
            }

            // Calculate sum
            for (int i = 0; i < length; i++)
            {
                int possibleAmount = Math.Min(maxL[i], maxR[i]) - height[i];
                sum += possibleAmount > 0 ? possibleAmount : 0;
            }

            return sum;
        }

        /// <summary>
        /// Pointer implementation
        /// Time: O(n), Space: O(1)
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int leftPointer = 0;
            int maxL = height[leftPointer];

            int rightPointer = height.Length - 1;
            int maxR = height[rightPointer];

            int sum = 0;

            while (leftPointer < rightPointer)
            {
                int blockSum;
                if (maxL < maxR)
                {
                    leftPointer++;
                    maxL = Math.Max(maxL, height[leftPointer]);
                    blockSum = maxL - height[leftPointer];
                    sum += blockSum > 0 ? blockSum : 0;
                }
                else
                {
                    rightPointer--;
                    maxR = Math.Max(maxR, height[rightPointer]);
                    blockSum = maxR - height[rightPointer];
                    sum += blockSum > 0 ? blockSum : 0;
                }
            }

            return sum;
        }
    }
}
