using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0543 : ISolution
    {
        public string Name => "Diameter of Binary Tree";
        public string Description => "Given the root of a binary tree, return the length of the diameter of the tree.\r\n\r\nThe diameter of a binary tree is the length of the longest path between any two nodes in a tree. This path may or may not pass through the root.\r\n\r\nThe length of a path between two nodes is represented by the number of edges between them.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(1,
                new(2,
                    new(4),
                    new(5)),
                new(3));
            var result = DiameterOfBinaryTree(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            var maxDiameter = 0;

            int Dfs(TreeNode root)
            {
                if (root is null) return 0;

                var left = Dfs(root.left);
                var right = Dfs(root.right);

                maxDiameter = Math.Max(maxDiameter, left + right);

                return Math.Max(left, right) + 1;
            }

            Dfs(root);

            return maxDiameter;
        }
    }
}
