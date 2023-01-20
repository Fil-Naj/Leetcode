using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0491 : ISolution
    {
        public string Name => "Non-decreasing Subsequences";
        public string Description => "Given an integer array nums, return all the different possible non-decreasing subsequences of the given array with at least two elements. You may return the answer in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] {  };
            var result = FindSubsequences(nums);

            // Prettify
            Console.WriteLine($"Input: nums = {nums.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            HashSet<string> paths = new();

            void Dfs(int index, string path)
            {
                for (int j = index + 1; j < nums.Length; j++)
                {
                    if (nums[index] > nums[j]) continue;

                    string newPath = path + ", " + nums[j];
                    if (paths.Contains(newPath)) continue;

                    paths.Add(newPath);
                    Dfs(j, newPath);
                }
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                StringBuilder sb = new();
                sb.Append(nums[i]);

                Dfs(i, sb.ToString());
            }

            return paths.Select(p => p.Split(", ").Select(n => int.Parse(n)).ToList()).ToList<IList<int>>();
        }
    }
}
