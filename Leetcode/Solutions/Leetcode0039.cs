using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0039 : ISolution
    {
        public string Name => "Combination Sum";
        public string Description => "Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.\r\n\r\nThe same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the\r\nfrequency\r\nof at least one of the chosen numbers is different.\r\n\r\nThe test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] candidates = [2, 3, 6, 7];
            var target = 7;
            var result = CombinationSum(candidates, target);

            // Prettify
            Console.WriteLine($"Input: candidates = {candidates.GetString()}, target = {target}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = [];
            var n = candidates.Length;

            void BackTrack(Stack<int> stack, int left, int index)
            {
                // If hit target on the dot
                if (left == 0)
                {
                    result.Add([.. stack]);
                    return;
                }

                // If sum greater than the target
                if (left < 0) return;

                // If no more numbers to add
                if (index == n) return;

                // Skip this number
                BackTrack(stack, left, index + 1);

                var numberToAdd = candidates[index];
                var canFit = left / numberToAdd;

                for (var i = 1; i <= canFit; i++)
                {
                    stack.Push(numberToAdd);
                    BackTrack(stack, left - (numberToAdd * i), index + 1);
                }

                for (var i = 0; i < canFit; i++)
                    stack.Pop();
            }

            BackTrack(new(), target, 0);

            return result;
        }
    }
}
