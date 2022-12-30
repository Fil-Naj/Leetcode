using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0429 : ISolution
    {
        public string Name => "N-ary Tree Level Order Traversal";
        public string Description => "Given an n-ary tree, return the level order traversal of its nodes' values.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            Node root = new(1, new List<Node>
            {
                new Node(3, new List<Node>
                {
                    new Node(5, new List<Node>()),
                    new Node(6, new List<Node>())
                }),
                new Node(2, new List<Node>()),
                new Node(4, new List<Node>())
            });

            var result = LevelOrder(root);

            // Prettify
            root.PrintTree();
            Console.WriteLine($"Output: {result}");
        }

        /// <summary>
        /// Given the root node of an n-ary tree, returns the level order traversal of its nodes' values
        /// </summary>
        /// <param name="root">the root node</param>
        /// <returns>list of each level's values</returns>
        public IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null)
                return Array.Empty<IList<int>>();

            List<IList<int>> levels = new();

            // Let us use BFS
            Queue<Node> queue = new();

            // Start by adding root to queue
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                // Used for possible storage advantages
                int layerCount = queue.Count;
                List<int> levelValues = new();

                for (int i = 0; i < layerCount; i ++)
                {
                    Node node = queue.Dequeue();
                    levelValues.Add(node.val);

                    List<Node> children = new List<Node>(node.children);
                    children.ForEach(n => queue.Enqueue(n));
                }
                levels.Add(levelValues);
            }

            return levels;
        }
    }
}
