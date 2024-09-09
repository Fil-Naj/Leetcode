using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0988 : ISolution
    {
        public string Name => "Smallest String Starting From Leaf";
        public string Description => "You are given the root of a binary tree where each node has a value in the range [0, 25] representing the letters 'a' to 'z'.\r\n\r\nReturn the lexicographically smallest string that starts at a leaf of this tree and ends at the root.\r\n\r\nAs a reminder, any shorter prefix of a string is lexicographically smaller.\r\n\r\n    For example, \"ab\" is lexicographically smaller than \"aba\".\r\n\r\nA leaf of a node is a node that has no children.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            //TreeNode root = new(25,
            //    new(1,
            //        new(1),
            //        new(3)),
            //    new(3,
            //        new(0),
            //        new(2))); 

            TreeNode root = new(4,
                new(0,
                    new(1)),
                new(1));
            var result = SmallestFromLeaf(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result}");
        }

        public string SmallestFromLeaf(TreeNode root)
        {
            string Dfs(TreeNode root, string s)
            {
                if (root is null) 
                    return string.Empty;

                var current = $"{(char)(root.val + 97)}{s}";

                if (root.left is null && root.right is null)
                    return current;

                var leftStr = Dfs(root.left, current);
                var rightStr = Dfs(root.right, current);

                if (leftStr == string.Empty)
                    return rightStr;

                if (rightStr == string.Empty)
                    return leftStr;

                return leftStr.CompareTo(rightStr) < 0
                    ? leftStr
                    : rightStr;
            }

            return Dfs(root, string.Empty);
        }
    }
}
