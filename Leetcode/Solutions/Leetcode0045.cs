using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0045 : ISolution
    {
        public string Name => "Jump Game II";
        public string Description => "You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].\r\n\r\nEach element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:\r\n\r\n    0 <= j <= nums[i] and\r\n    i + j < n\r\n\r\nReturn the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 2, 3, 1, 1, 4 };
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            var result = Jump(nums);

            // Prettify
            Console.WriteLine($"Output: {result}");
        }

        // BFS Solution
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;

            var result = 0;
            Queue<int> queue = new();
            var visited = new bool[nums.Length];

            queue.Enqueue(0);
            

            while (queue.Count > 0)
            {
                result++;
                var possible = queue.Count;
                for (int i = 0; i < possible; i++)
                {
                    var index = queue.Dequeue();
                    var jumpLen = nums[index];

                    for (int j = index + 1; j <= (index + jumpLen); j++)
                    {
                        if (j == nums.Length - 1) return result;
                        if (nums[j] == 0 || visited[j]) continue;

                        queue.Enqueue(j);
                        visited[j] = true;
                    }
                }
            }

            return -1;
        }
    }
}
