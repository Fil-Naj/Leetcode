using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode94 : ISolution
    {
        public string Name => "Binary Tree Inorder Traversal";
        public string Description => "Given the root of a binary tree, return the inorder traversal of its nodes' values.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode node = new(1, null, new(2, new(3), null));

            var result = InorderTraversal(node);

            Console.WriteLine($"Input: ");
            node.PrintBinaryTree();

            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> result = new List<int>();

            Stack<TreeNode> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Peek();
                if (node.left != null)
                {
                    stack.Push(node.left);
                    node.left = null;
                    continue;
                }

                result.Add(node.val);
                stack.Pop();
                

                if (node.right != null)
                {
                    stack.Push(node.right);
                    node.right = null;
                }
            }

            return result;
        }
    }
}
