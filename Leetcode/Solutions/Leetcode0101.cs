using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0101 : ISolution
    {
        public string Name => "Symmetric Tree";
        public string Description => "Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(2,
                new(3,
                    new(4),
                    new(5)),
                new(3,
                    null,
                    new(4))
            );
            var result = IsSymmetric(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            bool IsSymmetricRecursive(TreeNode left, TreeNode right)
            {
                if (left == null && right == null) return true;
                if (left?.val != right?.val) return false;

                return IsSymmetricRecursive(left.left, right.right) && IsSymmetricRecursive(left.right, right.left);
            }

            return IsSymmetricRecursive(root.left, root.right);
        }
    }
}
