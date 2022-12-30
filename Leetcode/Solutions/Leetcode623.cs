using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode623 : ISolution
    {
        public string Name => "Add One Row to Tree";
        public string Description => "Given the root of a binary tree and two integers val and depth, add a row of nodes with value val at the given depth depth.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(4,
                new(2,
                    new(3, null, null),
                    new(1, null, null)
                ),
                new(6,
                    new(5, null, null),
                    null
                )
            );
            int val = 420;
            int depth = 2;

            root.PrintBinaryTree();
            Console.WriteLine("Output: ");
            var result = AddOneRow(root, val, depth);
            result.PrintBinaryTree();
        }

        public TreeNode AddOneRow(TreeNode root, int val, int depth)
        {
            if (depth == 1)
                return new TreeNode(val, root, null);

            int deepness = 2;
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            int rowAmount = 1;

            while (queue.Count > 0)
            {
                if (deepness != depth)
                {
                    // This traverses across a whole row
                    for (int i = 0; i < rowAmount; i++)
                    {
                        var node = queue.Dequeue();

                        if (node.left != null) queue.Enqueue(node.left);
                        if (node.right != null) queue.Enqueue(node.right);
                    }
                    // Check how many in row to iterate for next time
                    rowAmount = queue.Count;

                    // deep
                    deepness++;
                }
                else
                {
                    var rowNode = queue.Dequeue();

                    rowNode.left = new TreeNode(val, rowNode.left, null);
                    rowNode.right = new TreeNode(val, null, rowNode.right);
                }
            }

            return root;
        }
    }
}
