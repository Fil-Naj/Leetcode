using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1161 : ISolution
    {
        public string Name => "Maximum Level Sum of a Binary Tree";
        public string Description => "Given the root of a binary tree, the level of its root is 1, the level of its children is 2, and so on.\r\n\r\nReturn the smallest level x such that the sum of all the values of nodes at level x is maximal.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(1,
                new(7,
                    new(7),
                    new(-8)
                    ),
                new(0)
            );
            var result = MaxLevelSum(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int MaxLevelSum(TreeNode root)
        {
            if (root == null) return 0;

            Queue<TreeNode> queue = new();
            var maxLevelSum = int.MinValue;
            var maxLevel = 1;
            queue.Enqueue(root);

            var currentLevel = 0;
            while (queue.Count > 0)
            {
                var numInLevel = queue.Count;
                var levelSum = 0;
                currentLevel++;

                for (int i = 0; i < numInLevel; i++)
                {
                    var node = queue.Dequeue();

                    if (node == null) continue;

                    levelSum += node.val;

                    if (node.left is not null) queue.Enqueue(node.left);
                    if (node.right is not null) queue.Enqueue(node.right);
                }

                if (maxLevelSum < levelSum)
                {
                    maxLevelSum = levelSum;
                    maxLevel = currentLevel;
                }
            }

            return maxLevelSum > 0 ? maxLevel : maxLevel + 1;
        }
    }
}
