using Leetcode.Common_Objects;
using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    public class Leetcode0129 : ISolution
    {
        public string Name => "Sum Root to Leaf Numbers";
        public string Description => "You are given the root of a binary tree containing digits from 0 to 9 only.\r\n\r\nEach root-to-leaf path in the tree represents a number.\r\n\r\n    For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.\r\n\r\nReturn the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will fit in a 32-bit integer.\r\n\r\nA leaf node is a node with no children.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(4,
                new(9,
                    new(5),
                    new(1)),
                new(0)
            );
            
            root.PrintBinaryTree();
            var result = SumNumbers(root);
            Console.WriteLine($"Output: {result}");
        }

        // Since we were guaranteed an int value as the sum, would have been better to keep an int count instead of using a string
        // But, eh
        public int SumNumbers(TreeNode root)
        {
            if (root == null) return 0;

            var result = 0;
            StringBuilder sb = new();
            void Dfs(TreeNode root)
            {
                if (root.left == null && root.right == null)
                {
                    result += int.Parse(sb.ToString());
                    return;
                }

                if (root.left != null)
                {
                    sb.Append(root.left.val);
                    Dfs(root.left);
                    sb.Remove(sb.Length - 1, 1);
                }

                if (root.right != null)
                {
                    sb.Append(root.right.val);
                    Dfs(root.right);
                    sb.Remove(sb.Length - 1, 1);
                }
            }

            sb.Append(root.val);
            Dfs(root);

            return result;
        }
    }
}
