using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0226 : ISolution
    {
        public string Name => "Invert Binary Tree";
        public string Description => "Given the root of a binary tree, invert the tree, and return its root.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(4,
                new(2,
                    new(1, null, null),
                    new(3, null, null)),
                new(7,
                    new(6, null, null),
                    new(9, null, null))
            );
            var result = InvertTree(root);

            // Prettify
            root.PrintBinaryTree();
            result.PrintBinaryTree();
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            InvertTree(root.left);
            InvertTree(root.right);

            (root.right, root.left) = (root.left, root.right);
            return root;
        }
    }
}
