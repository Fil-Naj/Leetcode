using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1 : ISolution
    {
        public string Name => "TwoSum";
        public string Description => "Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[] { 3, 2, 4 };
            var target = 6;
            var result = TwoSum(data, target);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}, target = {target}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> values = new();
            for (int i = 0; i < nums.Length; i++)
            {
                int lookingFor = target - nums[i];
                if (values.TryGetValue(lookingFor, out var answer))
                    return new int[] { answer, i};
                else
                    if (!values.ContainsKey(nums[i])) values.Add(nums[i], i);
            }
            return null;
        }
    }
}
