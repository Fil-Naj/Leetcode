using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0958 : ISolution
    {
        public string Name => "Check Completeness of a Binary Tree";
        public string Description => "Given the root of a binary tree, determine if it is a complete binary tree.\r\n\r\nIn a complete binary tree, every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(1,
                new(2,
                    new(4),
                    new(5)
                ),
                new(3,
                    new(6),
                    null
                )
            );
            var result = IsCompleteTree(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public bool IsCompleteTree(TreeNode root)
        {
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    while (queue.Count > 0)
                    {
                        if (queue.Dequeue() != null) return false;
                    }
                }
            }

            return true;
        }
    }
}
