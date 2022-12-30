using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0113 : ISolution
    {
        public string Name => "Path Sum II";
        public string Description => "Given the root of a binary tree and an integer targetSum, return all root-to-leaf paths where the sum of the node values in the path equals targetSum. Each path should be returned as a list of the node values, not node references.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(5,
                new(4,
                    new(11,
                        new(7, null, null),
                        new(2, null, null)),
                    null),
                new(8,
                    new(13, null, null),
                    new(4,
                        new(5, null, null),
                        new(1, null, null)
                    )
                )
            );
            int target = 22;
            var result = PathSum(root, target);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Input: root = (see above), targetSum = {target}");
            //var result = solution.SmartHasPathSum(root, target);
            Console.WriteLine($"Output: {result.GetString()}");
        }

        int DynamicSum = 0;
        IList<IList<int>> Result;
        List<int> CurrentPathVals;
        int Target;


        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            Result = new List<IList<int>>();
            DynamicSum = 0;
            CurrentPathVals = new();
            Target = targetSum;

            if (root == null) return Result;

            // Let's DFS
            DFS(root);
            return Result;
        }

        private void DFS(TreeNode node)
        {
            DynamicSum += node.val;
            CurrentPathVals.Add(node.val);

            if (node.left == null && node.right == null)
            {
                if (DynamicSum == Target)
                    Result.Add(CurrentPathVals.ToList());
                return;
            }
            if (node.left != null)
            {
                DFS(node.left);
                DynamicSum -= node.left.val;
                CurrentPathVals.RemoveAt(CurrentPathVals.Count - 1);
            }
            if (node.right != null)
            {
                DFS(node.right);
                DynamicSum -= node.right.val;
                CurrentPathVals.RemoveAt(CurrentPathVals.Count - 1);
            }
        }
    }
}
