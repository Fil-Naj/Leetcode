using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1609 : ISolution
    {
        public string Name => "Even Odd Tree";
        public string Description => "A binary tree is named Even-Odd if it meets the following conditions:\r\n\r\n    The root of the binary tree is at level index 0, its children are at level index 1, their children are at level index 2, etc.\r\n    For every even-indexed level, all nodes at the level have odd integer values in strictly increasing order (from left to right).\r\n    For every odd-indexed level, all nodes at the level have even integer values in strictly decreasing order (from left to right).\r\n\r\nGiven the root of a binary tree, return true if the binary tree is Even-Odd, otherwise return false.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var root = new TreeNode(1,
                new(4,
                    new(3,
                        new(12),
                        new(8)
                    )),
                new(10,
                    new(7,
                        new(6)),
                    new(9,
                        null,
                        new(2))
                    )
                );
            var result = IsEvenOddTree(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public bool IsEvenOddTree(TreeNode root)
        {
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            var isEvenLevel = true;
            while (queue.Count > 0)
            {
                var rowCount = queue.Count;

                var prev = queue.Dequeue();
                if (IsEven(prev.val) == isEvenLevel) return false;
                if (prev.left is not null) queue.Enqueue(prev.left);
                if (prev.right is not null) queue.Enqueue(prev.right);

                for (var i = 1; i < rowCount; i++)
                {
                    var curr = queue.Dequeue();
                    if (IsEven(curr.val) == isEvenLevel) return false;

                    if (isEvenLevel
                        ? curr.val <= prev.val
                        : curr.val >= prev.val)
                        return false;

                    // If here, we good to traverse to next level
                    if (curr.left is not null) queue.Enqueue(curr.left);
                    if (curr.right is not null) queue.Enqueue(curr.right);

                    prev = curr;
                }

                isEvenLevel = !isEvenLevel;
            }

            return true;
        }

        private bool IsEven(int val) => val % 2 == 0;
    }
}
