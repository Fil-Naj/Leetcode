using Leetcode.Common_Objects;
using Leetcode.Extensions;
using System;

namespace Leetcode.Solutions
{
    public class Leetcode0106 : ISolution
    {
        public string Name => "Construct Binary Tree from Inorder and Postorder Traversal";
        public string Description => "Given two integer arrays inorder and postorder where inorder is the inorder traversal of a binary tree and postorder is the postorder traversal of the same tree, construct and return the binary tree.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var inorder = new int[] { 9, 3, 15, 20, 7 };
            var postorder = new int[] { 9, 15, 7, 20, 3 };
            var result = BuildTree(inorder, postorder);

            // Prettify
            Console.WriteLine($"Input: inorder = {inorder.GetString()}, postorder = {postorder}");
            result.PrintBinaryTree();
        }

        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            var rightIndex = postorder.Length - 1;
            Dictionary<int, int> inorderIndexes = new();
            for (int i = 0; i <= rightIndex; i++) 
                inorderIndexes[inorder[i]] = i;

            TreeNode Dfs(int left, int right)
            {
                if (left > right) return null;

                TreeNode root = new(postorder[rightIndex--]);
                
                var currIndex = inorderIndexes[root.val];
                root.right = Dfs(currIndex + 1, right);
                root.left = Dfs(left, currIndex - 1);

                return root;
            }

            return Dfs(0, rightIndex);
        }
    }
}
