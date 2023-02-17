using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0783 : ISolution
    {
        public string Name => "Minimum Distance Between BST Nodes";
        public string Description => "Given the root of a Binary Search Tree (BST), return the minimum difference between the values of any two different nodes in the tree.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(4,
                new(2,
                    new(1, null, null),
                    new(3, null, null)
                ),
                new(6, null, null)
            );
            var result = MinDiffInBST(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        // Given Binary Search Tree, values will be in ascending order in an in-order traversal
        // Do in-order traversal, and simply check the difference at each step
        public int MinDiffInBST(TreeNode root)
        {
            var result = int.MaxValue;
            TreeNode prev = null;

            void InorderTraversal(TreeNode root)
            {
                if (root == null) return;

                InorderTraversal(root.left);

                if (prev != null)
                    result = Math.Min(result, root.val - prev.val);

                prev = root;

                InorderTraversal(root.right);
            }

            InorderTraversal(root);

            return result;
        }
    }
}
