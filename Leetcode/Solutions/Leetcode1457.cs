using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1457 : ISolution
    {
        public string Name => "Pseudo-Palindromic Paths in a Binary Tree";
        public string Description => "Given a binary tree where node values are digits from 1 to 9. A path in the binary tree is said to be pseudo-palindromic if at least one permutation of the node values in the path is a palindrome.\r\n\r\nReturn the number of pseudo-palindromic paths going from the root node to leaf nodes";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(2,
                new(3,
                    new(3, null, null),
                    new(1, null, null)
                ),
                new(1,
                    null,
                    new(1, null, null)
                )
            );
            var result = PseudoPalindromicPaths(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
            

        }

        private Dictionary<int, int> Counts;
        private int Count;

        public int PseudoPalindromicPaths(TreeNode root)
        {
            Init();
            DFS(root);
            return Count;
        }

        private void Init()
        {
            Count = 0;
            Counts = Enumerable.Range(1, 9).ToDictionary(n => n, x => 0);
        }

        private void DFS(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                Counts[root.val]++;
                if (IsPseudoPalindromic())
                    Count++;
                Counts[root.val]--;
                return;
            }
            if (root.left != null)
            {
                Counts[root.val]++;
                DFS(root.left);
                Counts[root.val]--;
            }
            if (root.right != null)
            {
                Counts[root.val]++;
                DFS(root.right);
                Counts[root.val]--;
            }
        }

        private bool IsPseudoPalindromic()
        {
            int oddCount = 0;
            foreach (int val in Counts.Values)
            {
                if (val % 2 == 1)
                    oddCount++;

                if (oddCount > 1)
                    return false;
            }
            return true;
        }
    }
}
