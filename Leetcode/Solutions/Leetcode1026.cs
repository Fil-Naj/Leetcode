using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1026 : ISolution
    {
        public string Name => "Maximum Difference Between Node and Ancestor";
        public string Description => "Given the root of a binary tree, find the maximum value v for which there exist different nodes a and b where v = |a.val - b.val| and a is an ancestor of b.\r\n\r\nA node a is an ancestor of b if either: any child of a is equal to b or any child of a is an ancestor of b.\r\n\r\n ";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(
                8,
                new(3,
                    new(1),
                    new(6,
                        new(4),
                        new(7))
                    ),
                new(10,
                    null,
                    new(14,
                        new(13)
                        )
                )
            );

            var result = MaxAncestorDiff(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int MaxAncestorDiff(TreeNode root)
        {
            var maxDiff = 0;

            void Dfs(TreeNode root, int ancestorMin, int ancestorMax)
            {
                if (root == null) return;

                maxDiff = Math.Max(maxDiff, Math.Max(Math.Abs(root.val - ancestorMin), Math.Abs(root.val - ancestorMax)));

                var newMin = Math.Min(root.val, ancestorMin);
                var newMax = Math.Max(root.val, ancestorMax);
                Dfs(root.left, newMin, newMax);
                Dfs(root.right, newMin, newMax);
            }

            Dfs(root, root.val, root.val);

            return maxDiff;
        }
    }
}
