using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode112 : ISolution
    {
        public string Name => "Path Sum";
        public string Description => "Given the root of a binary tree and an integer targetSum, return true if the tree has a root-to-leaf path such that adding up all the values along the path equals targetSum.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new TreeNode(5,
                new TreeNode(4,
                    new TreeNode(11,
                        new TreeNode(7, null, null),
                        new TreeNode(2, null, null)),
                    null),
                new TreeNode(8,
                    new TreeNode(13, null, null),
                    new TreeNode(4,
                        null,
                        new TreeNode(1, null, null)
                    )
                )
            );
            int target = 22;
            var result = HasPathSum(root, target);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Input: root = (see above), targetSum = {target}");
            //var result = solution.SmartHasPathSum(root, target);
            Console.WriteLine($"Output: {result}");
        }

        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            int dynamicSum = 0;
            HashSet<TreeNode> visited = new();
            HashSet<TreeNode> added = new();
            Stack<TreeNode> stack = new();

            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();
                
                if (!added.Contains(node))
                {
                    dynamicSum += node.val;
                    added.Add(node);
                }
                // Console.WriteLine($"Node: {node.val}, Sum: {dynamicSum}");
                if (!visited.Contains(node))
                {
                    if (node.left == null && node.right == null && dynamicSum == targetSum)
                        return true;
                        
                    if (node.left != null && !visited.Contains(node.left))
                    {
                        stack.Push(node.left);
                        continue;
                    }
                    if (node.right != null && !visited.Contains(node.right))
                    {
                        stack.Push(node.right);
                        continue;
                    }
                    visited.Add(node);
                    stack.Pop();
                    dynamicSum -= node.val;
                }
            }
            return false;
        }

        public bool SmartHasPathSum(TreeNode root, int targetSum)
        {
            if (root == null) return false;

            Stack<TreeNode> stack = new();

            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();

                if (node.left == null && node.right == null && node.val == targetSum)
                    return true;

                if (node.left != null)
                {
                    node.left.val += node.val;
                    stack.Push(node.left);
                }
                if (node.right != null)
                {
                    node.right.val += node.val;
                    stack.Push(node.right);
                }
                
            }
            return false;
        }
    }
}
