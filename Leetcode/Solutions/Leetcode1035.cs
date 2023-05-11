using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1035 : ISolution
    {
        public string Name => "Uncrossed Lines";
        public string Description => "You are given two integer arrays nums1 and nums2. We write the integers of nums1 and nums2 (in the order they are given) on two separate horizontal lines.\r\n\r\nWe may draw connecting lines: a straight line connecting two numbers nums1[i] and nums2[j] such that:\r\n\r\n    nums1[i] == nums2[j], and\r\n    the line we draw does not intersect any other connecting (non-horizontal) line.\r\n\r\nNote that a connecting line cannot intersect even at the endpoints (i.e., each number can only belong to one connecting line).\r\n\r\nReturn the maximum number of connecting lines we can draw in this way.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums1 = new int[] { 1, 3, 7, 1, 7, 5 };
            var nums2 = new int[] { 1, 9, 2, 5, 1 };
            var result = MaxUncrossedLines(nums1, nums2);

            // Prettify
            Console.WriteLine($"Input: nums1 = {nums1.GetString()}, nums2 = {nums2.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // DFS + memoisation
        public int MaxUncrossedLines(int[] nums1, int[] nums2)
        {
            int n1 = nums1.Length;
            int n2 = nums2.Length;

            Dictionary<int, List<int>> line2 = new();
            for (int i = 0; i < nums2.Length; i++)
            {
                if (line2.ContainsKey(nums2[i]))
                    line2[nums2[i]].Add(i);
                else
                    line2[nums2[i]] = new List<int>() { i };
            }

            var dp = new int[nums1.Length, nums2.Length];
            int Dfs(int index, int bottomLineMax)
            {
                if (index >= n1 || bottomLineMax >= n2) return 0;

                if (dp[index, bottomLineMax] > 0) return dp[index, bottomLineMax];

                // Skip current top line number
                var skipResult = Dfs(index + 1, bottomLineMax);

                var connections = 0;
                if (line2.TryGetValue(nums1[index], out var bottoms))
                {
                    foreach (var bottom in bottoms)
                    {
                        if (bottom < bottomLineMax) continue;

                        connections = Math.Max(connections, Dfs(index + 1, bottom + 1) + 1);
                    }
                }
                dp[index, bottomLineMax] = Math.Max(skipResult, connections);

                return dp[index, bottomLineMax];
            }

            return Dfs(0, 0);
        }
    }
}
