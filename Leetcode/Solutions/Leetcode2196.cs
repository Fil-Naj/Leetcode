using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2196 : ISolution
    {
        public string Name => "Create Binary Tree From Descriptions";
        public string Description => "You are given a 2D integer array descriptions where descriptions[i] = [parenti, childi, isLefti] indicates that parenti is the parent of childi in a binary tree of unique values. Furthermore,\r\n\r\n    If isLefti == 1, then childi is the left child of parenti.\r\n    If isLefti == 0, then childi is the right child of parenti.\r\n\r\nConstruct the binary tree described by descriptions and return its root.\r\n\r\nThe test cases will be generated such that the binary tree is valid.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[][] descriptions = [[20, 15, 1], [20, 17, 0], [50, 20, 1], [50, 80, 0], [80, 19, 1]];
            var result = CreateBinaryTree(descriptions);

            // Prettify
            Console.WriteLine($"Input: descriptions = {descriptions.GetString()}");
            result.PrintBinaryTree();
        }

        public TreeNode CreateBinaryTree(int[][] descriptions)
        {
            Dictionary<int, TreeNode> tree = [];
            HashSet<int> children = [];

            foreach(var desc in descriptions)
            {
                var parent = desc[0];
                var child = desc[1];
                var isLeft = desc[2] == 1;

                if (!tree.TryGetValue(child, out var childNode))
                {
                    childNode = new TreeNode(child);
                    tree[child] = childNode;
                }

                if (!tree.TryGetValue(parent, out var parentNode))
                {
                    parentNode = new TreeNode(parent);
                    tree[parent] = parentNode;
                }

                if (isLeft)
                    parentNode.left = childNode;
                else
                    parentNode.right = childNode;

                children.Add(child);
            }

            return tree.Single(r => !children.Contains(r.Key)).Value;
        }
    }
}
