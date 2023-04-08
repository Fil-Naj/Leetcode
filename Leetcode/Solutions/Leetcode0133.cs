using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0133 : ISolution
    {
        public string Name => "Clone Graph";
        public string Description => "Given a reference of a node in a connected undirected graph.\r\n\r\nReturn a deep copy (clone) of the graph.\r\n\r\nEach node in the graph contains a value (int) and a list (List[Node]) of its neighbors.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            var node = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            var node4 = new Node(4);

            node.children = new List<Node>() { node2, node4 };
            node2.children = new List<Node>() { node, node3 };
            node3.children = new List<Node>() { node2, node4 };
            node4.children = new List<Node>() { node, node3 };

            var result = CloneGraph(node);
        }

        public Node CloneGraph(Node node)
        {
            Dictionary<int, Node> nodes = new();
            var clone = new Node(node.val);
            nodes.Add(clone.val, clone);

            Queue<Node> queue = new();
            queue.Enqueue(node);

            // BFS
            while (queue.Count > 0)
            {
                var nodeToClone = queue.Dequeue();

                foreach (var child in nodeToClone.children)
                {
                    if (nodes.ContainsKey(child.val))
                    {
                        nodes[nodeToClone.val].children.Add(nodes[child.val]);
                    }
                    else
                    {
                        var newChild = new Node(child.val, new List<Node>());
                        nodes[newChild.val] = newChild;
                        nodes[nodeToClone.val].children.Add(newChild);

                        queue.Enqueue(child);
                    }
                }
            }

            return nodes[node.val];
        }
    }
}
