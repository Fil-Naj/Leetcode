using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0103 : ISolution
    {
        public string Name => "Binary Tree Zigzag Level Order Traversal";
        public string Description => "Given the root of a binary tree, return the zigzag level order traversal of its nodes' values. (i.e., from left to right, then right to left for the next level and alternate between).";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(3,
                new(9,null, null),
                new(20,
                    new(15, null, null),
                    new(7, null, null))
            );
            var result = ZigzagLevelOrder(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {string.Join(", ", result.Select(a => a.GetString()))}");
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            List<IList<int>> result = new();

            if (root == null) return result;

            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            var leftToRight = true;

            while (queue.Count > 0)
            {
                var count = queue.Count;
                var toAdd = new List<int>();

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (node == null) continue;

                    if (leftToRight)
                    {
                        toAdd.Add(node.val);
                    }
                    else
                    {
                        toAdd.Insert(0, node.val);
                    }

                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }

                leftToRight = !leftToRight;

                if (toAdd.Count > 0)
                {
                    result.Add(toAdd);
                }
            }

            return result;
        }
    }
}
