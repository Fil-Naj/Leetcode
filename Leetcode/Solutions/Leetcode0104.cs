using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0104 : ISolution
    {
        public string Name => "Maximum Depth of Binary Tree";
        public string Description => "Given the root of a binary tree, return its maximum depth.\r\n\r\nA binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(3,
                new(9, null, null),
                new(20,
                    new(15, null, null),
                    new(7, null, null)
                )
            );
            var result = MaxDepthRecursive(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            var depth = 0;
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var count = queue.Count;
                depth++;

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }

            return depth;
        }

        public int MaxDepthRecursive(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(MaxDepthRecursive(root.left), MaxDepthRecursive(root.right)) + 1;
        }
    }
}
