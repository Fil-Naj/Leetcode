using Leetcode.Common_Objects;
using Leetcode.Extensions;
using System.Linq;

namespace Leetcode.Solutions
{
    public class Leetcode987 : ISolution
    {
        public string Name => "Vertical Order Traversal of a Binary Tree";
        public string Description => "Given the root of a binary tree, calculate the vertical order traversal of the binary tree.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(3,
                new(9, null, null),
                new(20,
                    new(15, null, null),
                    new(7, null, null)
                )
            );

            var result = VerticalTraversal(root);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            Dictionary<int, List<(int Depth, int Value)>> columnValues = new Dictionary<int, List<(int Depth, int Value)>>();
            Queue<(int Depth, int Column, TreeNode Node)> queue = new Queue<(int Depth, int Column, TreeNode node)>();
            
            // We are going to use BFS to traverse every node. Then, add each value to a list of values for each respective column
            // Add first node to queue
            queue.Enqueue((0, 0, root));

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                // Check if entry in dictionary exists. If not, create it
                if (columnValues.TryGetValue(item.Column, out var column))
                {
                    column.Add((item.Depth, item.Node.val));
                }
                else
                {
                    columnValues.Add(item.Column, new List<(int Depth, int Value)>());
                    columnValues[item.Column].Add((item.Depth, item.Node.val));
                }

                if (item.Node.left != null)
                    queue.Enqueue((item.Depth + 1, item.Column - 1, item.Node.left));

                if (item.Node.right != null)
                    queue.Enqueue((item.Depth + 1, item.Column + 1, item.Node.right));
            }

            IList<IList<int>> result = new List<IList<int>>();

            foreach (int colNum in columnValues.Keys.OrderBy(x => x))
                result.Add(columnValues[colNum].OrderBy(x => x.Depth).ThenBy(x => x.Value).Select(x => x.Value).ToList());

            return result;
        }
    }
}
