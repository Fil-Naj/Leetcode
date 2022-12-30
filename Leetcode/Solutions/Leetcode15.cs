using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode15 : ISolution
    {
        public string Name => "3Sum";
        public string Description => "Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var data = new int[] { -1, 0, 1, 2, -1, -4 };
            var result = ThreeSum(data);

            // Prettify
            Console.WriteLine($"Input: data = {data.GetString()}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            int pre = 0;
            for (int i = nums.Length - 1; i > 1; i--)
            {
                // If not at the start of the loop and prev number equals current number
                // No need to conitinue, move on
                if (i != nums.Length - 1 && nums[i] == pre)
                    continue;

                var remainder = 0 - nums[i];

                // update previous number
                pre = nums[i];

                for (int j = i - 1; j > 0; j--)
                {
                    // If number is same as previous, would make duplicate. Get rid
                    if (j != i - 1 && nums[j] == pre)
                        continue;

                    // Calculate last number needed
                    int last = remainder - nums[j];

                    // update previous
                    pre = nums[j];

                    // Binary search the last number
                    var lastNum = Array.BinarySearch<int>(nums, 0, j, last);

                    if (lastNum >= 0)
                        result.Add(new List<int>() { nums[i], nums[j], last });
                }

            }
            
            return result;
        }

        //public void TestButDIdntWork()
        //{
        //    Dictionary<int, List<List<int>>> answers = new();

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length; j++)
        //        {
        //            var sum = nums[i] + nums[j];
        //            if (answers.TryGetValue(sum, out var _))
        //                answers[sum].Add(new List<int>() { i, j });
        //            else
        //                answers.Add(sum, new List<List<int>> { new List<int> { i, j } });
        //        }
        //    }

        //    HashSet<IList<int>> complete = new HashSet<IList<int>>();
        //    for (int k = 0; k < nums.Length; k++)
        //    {
        //        var searchFor = 0 - nums[k];
        //        if (answers.TryGetValue(searchFor, out var possible))
        //        {
        //            foreach (var list in possible)
        //            {
        //                if (!list.Contains(k))
        //                {
        //                    var toAdd = new List<int>(list);
        //                    toAdd.Add(k);
        //                    complete.Add(toAdd.OrderBy(n => n).ToList());
        //                }
        //            }
        //        }
        //    }
        //    var x = complete;
        //}
    }
}
