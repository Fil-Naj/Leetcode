using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0100 : ISolution
    {
        public string Name => "Same Tree";
        public string Description => "Given the roots of two binary trees p and q, write a function to check if they are the same or not.\r\n\r\nTwo binary trees are considered the same if they are structurally identical, and the nodes have the same value.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode p = new(1, 
                new TreeNode(2, null, null),
                new TreeNode(3, null, null));

            TreeNode q = new(1,
                new TreeNode(2, null, null),
                new TreeNode(3, null, null));

            var result = IsSameTree(p, q);

            // Prettify
            
            Console.WriteLine($"Output: {result}");
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            if (p.val != q.val) return false;

            if (!IsSameTree(p.left, q.left)) return false;
            if (!IsSameTree(p.right, q.right)) return false;

            return true;
        }
    }
}
