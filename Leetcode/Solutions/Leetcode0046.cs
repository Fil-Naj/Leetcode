using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0046 : ISolution
    {
        public string Name => "Permutations";
        public string Description => "Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var nums = new int[] { 1, 2, 3 };
            var result = Permute(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        // We don't need to go through each step of finding a path from the start (e.g., 1 -> 1, 2 -> 1, 2, 3)
        // Instead, we can just swap the entire path to find a new one (e.g., 1, 2, 3 -> 2, 1, 3)
        // This saves a lot of the in between steps
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new();

            void Dfs(int index)
            {
                if (index == nums.Length)
                {
                    result.Add(nums.ToList());
                    return;
                }

                for (int i = index; i < nums.Length; i++)
                {
                    (nums[index], nums[i]) = (nums[i], nums[index]);
                    Dfs(index + 1);
                    (nums[index], nums[i]) = (nums[i], nums[index]);
                }
            }

            Dfs(0);
            return result;
        }
    }
}
