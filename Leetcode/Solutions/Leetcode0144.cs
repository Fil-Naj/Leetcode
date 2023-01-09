using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0144 : ISolution
    {
        public string Name => "Binary Tree Preorder Traversal";
        public string Description => "Given the root of a binary tree, return the preorder traversal of its nodes' values.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode data = new(1,
                null,
                new(2,
                    new(3, null, null),
                    null
                )
            );
            var result = PreorderTraversal(data);

            // Prettify
            data.PrintBinaryTree();
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new();

            Stack<TreeNode> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                result.Add(node.val);

                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null) 
                    stack.Push(node.left);
            }

            return result;
        }
    }
}
