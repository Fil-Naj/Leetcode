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
            var result = PermuteWithSwap(nums);

            // Prettify
            Console.WriteLine($"Input: data = {nums.GetString()}");
            foreach (var lst in result)
            {
                Console.WriteLine(lst.GetString());
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new();

            int n = nums.Length;
            HashSet<int> availableNums = new(nums);
            List<int> currPath = new();

            void Dfs(int i)
            {
                if (currPath.Count == n)
                {
                    var newPath = currPath.ToList();
                    result.Add(newPath);
                    return;
                }
                
                var toTraverse = availableNums.ToList();
                foreach (var index in toTraverse)
                {
                    currPath.Add(index);
                    availableNums.Remove(index);

                    Dfs(index);

                    currPath.RemoveAt(currPath.Count - 1);
                    availableNums.Add(index);
                }
            }

            Dfs(0);

            return result;
        }

        // We don't need to go through each step of finding a path from the start (e.g., 1 -> 1, 2 -> 1, 2, 3)
        // Instead, we can just swap the entire path to find a new one (e.g., 1, 2, 3 -> 2, 1, 3)
        // This saves a lot of the in between steps
        public IList<IList<int>> PermuteWithSwap(int[] nums)
        {
            List<IList<int>> result = new();
            Solve(0, nums, result);
            return result;
        }

        public void Solve(int index, int[] nums, List<IList<int>> result)
        {
            // If at end of shuffle
            if (index == nums.Length)
            {
                 result.Add(new List<int>(nums));
                return;
            }

            for (int i = index; i < nums.Length; i++) 
            {
                Swap(nums, index, i);
                Solve(index + 1, nums, result);
                Swap(nums, index, i);
            }
        }

        public void Swap(int[] nums, int first, int second)
        {
            var temp = nums[first];
            nums[first] = nums[second];
            nums[second] = temp;
        }
    }
}
