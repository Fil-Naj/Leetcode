namespace Leetcode.Common_Objects
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
            children = new List<Node>();
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }

        public void PrintTree()
        {
            int n = 0;
            Queue<Node> queue = new();
            queue.Enqueue(this);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                n++;
                foreach (var child in node.children)
                    queue.Enqueue(child);
            }

            bool[] flag = new bool[n];
            for (int i = 0; i < n; i++)
                flag[i] = true;

            PrintNTree(this, flag, 0, false);
        }

        private static void PrintNTree(Node x,
                       bool[] flag,
                       int depth, bool isLast)
        {

            // Condition when node is None
            if (x == null)
                return;

            // Loop to print the depths of the
            // current node
            for (int i = 1; i < depth; ++i)
            {

                // Condition when the depth
                // is exploring
                if (flag[i] == true)
                {
                    Console.Write("| "
                       + " "
                       + " "
                       + " ");
                }

                // Otherwise print
                // the blank spaces
                else
                {
                    Console.Write(" "
                       + " "
                       + " "
                       + " ");
                }
            }

            // Condition when the current
            // node is the root node
            if (depth == 0)
                Console.WriteLine(x.val);

            // Condition when the node is
            // the last node of
            // the exploring depth
            else if (isLast)
            {
                Console.Write("+--- " + x.val + '\n');

                // No more childrens turn it
                // to the non-exploring depth
                flag[depth] = false;
            }
            else
            {
                Console.Write("+--- " + x.val + '\n');
            }

            int it = 0;
            foreach (Node i in x.children)
            {
                ++it;

                // Recursive call for the
                // children nodes
                PrintNTree(i, flag, depth + 1,
                    it == (x.children.Count) - 1);
            }
            flag[depth] = true;
        }
    }
}
