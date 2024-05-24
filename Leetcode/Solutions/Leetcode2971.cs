using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2971 : ISolution
    {
        public string Name => "Find Polygon With the Largest Perimeter";
        public string Description => "You are given an array of positive integers nums of length n.\r\n\r\nA polygon is a closed plane figure that has at least 3 sides. The longest side of a polygon is smaller than the sum of its other sides.\r\n\r\nConversely, if you have k (k >= 3) positive real numbers a1, a2, a3, ..., ak where a1 <= a2 <= a3 <= ... <= ak and a1 + a2 + a3 + ... + ak-1 > ak, then there always exists a polygon with k sides whose lengths are a1, a2, a3, ..., ak.\r\n\r\nThe perimeter of a polygon is the sum of lengths of its sides.\r\n\r\nReturn the largest possible perimeter of a polygon whose sides can be formed from nums, or -1 if it is not possible to create a polygon.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] nums = [300005055, 352368231, 311935527, 315829776, 327065463, 388851949, 319541150, 397875604, 311309167, 391897750, 366860048, 359976490, 325522439, 390648914, 359891976, 369105322, 350430086, 398592583, 354559219, 372400239, 344759294, 379931363, 308829137, 335032174, 336962933, 380797651, 378305476, 336617902, 393487098, 301391791, 394314232, 387440261, 316040738, 388074503, 396614889, 331609633, 374723367, 380418460, 349845809, 318514711, 308782485, 308291996, 375362898, 397542455, 397628325, 392446446, 368662132, 378781533, 372327607, 378737987];
            var result = LargestPerimeter(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        public long LargestPerimeter(int[] nums)
        {
            Array.Sort(nums, (a, b) => b - a);
            var sumOfAllSides = 0L; 
            foreach (var num in nums)
                sumOfAllSides += num;

            var maxPerimiter = -1L;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] < sumOfAllSides - nums[i]) 
                    maxPerimiter = Math.Max(maxPerimiter, sumOfAllSides);

                sumOfAllSides -= nums[i];
            }

            return maxPerimiter;
        }
    }
}
