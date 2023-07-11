using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0863 : ISolution
    {
        public string Name => "All Nodes Distance K in Binary Tree";
        public string Description => "Given the root of a binary tree, the value of a target node target, and an integer k, return an array of the values of all nodes that have a distance k from the target node.\r\n\r\nYou can return the answer in any order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(3,
                new(5,
                    new(6),
                    new(2,
                        new(7),
                        new(4)
                    )
                ),
                new(1,
                    new(0),
                    new(8)
                )
            );
            var target = root.left;
            var k = 4;
            var result = DistanceK(root, target, k);

            // Prettify
            Console.WriteLine($"Input: root = {root}, target = {target}, k = {k}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            var result = new List<int>();
            if (root == null) return result;

            Dictionary<TreeNode, TreeNode> parents = new();

            // BFS Entire Tree
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);
            parents.Add(root, null);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.left is not null)
                {
                    parents[node.left] = node;
                    queue.Enqueue(node.left);
                }

                if (node.right is not null)
                {
                    parents[node.right] = node;
                    queue.Enqueue(node.right);
                }
            }

            queue.Enqueue(target);
            HashSet<TreeNode> visited = new() { target };
            var distance = 0;
            while (queue.Count > 0 && distance <= k)
            {
                var count = queue.Count;

                for (int i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();

                    if (distance == k)
                    {
                        result.Add(node.val);
                        continue;
                    }

                    var parent = parents[node];
                    if (parent is not null && !visited.Contains(parent))
                    {
                        visited.Add(parent);
                        queue.Enqueue(parent);
                    }

                    if (node.left is not null && !visited.Contains(node.left))
                    {
                        visited.Add(node.left);
                        queue.Enqueue(node.left);
                    }

                    if (node.right is not null && !visited.Contains(node.right))
                    {
                        visited.Add(node.right);
                        queue.Enqueue(node.right);
                    }
                }
                distance++;
            }

            return result;
        }
    }
}
