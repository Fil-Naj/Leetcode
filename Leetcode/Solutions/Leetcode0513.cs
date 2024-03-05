using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0513 : ISolution
    {
        public string Name => "Find Bottom Left Tree Value";
        public string Description => "Given the root of a binary tree, return the leftmost value in the last row of the tree.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(2,
                new(1),
                new(3));
            var result = FindBottomLeftValue(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            var leftMost = -1;
            while (queue.Count > 0)
            {
                var rowCount = queue.Count;

                leftMost = queue.Peek().val;
                for (var i = 0; i < rowCount; i++)
                {
                    var node = queue.Dequeue();
                    if (node.left is not null) queue.Enqueue(node.left);
                    if (node.right is not null) queue.Enqueue(node.right);
                }
            }

            return leftMost;
        }
    }
}
