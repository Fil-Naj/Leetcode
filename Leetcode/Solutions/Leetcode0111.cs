using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0111 : ISolution
    {
        public string Name => "Minimum Depth of Binary Tree";
        public string Description => "Given a binary tree, find its minimum depth.\r\n\r\nThe minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.\r\n\r\nNote: A leaf is a node with no children.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(3,
                new(9),
                new(20,
                    new(15),
                    new(7)
                )
            ); 
            var result = MinDepth(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> queue = new();
            var count = 1;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var numInRow = queue.Count;

                for (int i = 0; i < numInRow; i++)
                {
                    var node = queue.Dequeue();

                    if (node.left == null && node.right == null) return count;

                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }

                count++;
            }

            return count;
        }
    }
}
