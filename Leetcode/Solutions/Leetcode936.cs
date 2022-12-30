namespace Leetcode.Solutions
{
    [ToBeContinued("Learnt Iterative deeping for some reason. Might revisit and correct one day. Looked easy enough")]
    public class Leetcode936
    {
        /*
         * The answer to this was not interative deepening, it was BFS like I initially expected.
         * However, it still works, just a lotttt slower because we have to go down the search every single time.
         * But, it was fun to learn anyway.
         * Thanks.
         */
        private string Stamp {get; set;}

        public int[] MovesToStamp(string stamp, string target)
        {
            var depthLimit = target.Length * 10;
            Stamp = stamp;
            var intialString = new string('?', target.Length);

            var root = new Node
            {
                S = intialString,
                History = new List<int>()
            };

            return IterativeDeepeningSearch(root, target, depthLimit);
        }

        private int[]? DepthLimitedSearch(Node root, string goal, int depth)
        {
            if (depth == 0 && root.S == goal)
            {
                return root.History.ToArray();
            }
            else if (depth > 0)
            {
                // Need to change this to loop through possibilities of where can can stamp
                foreach (var child in root.GetChildren(Stamp))
                {
                    var result = DepthLimitedSearch(child, goal, depth - 1);
                    if (result != null)
                    {
                        return result;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        private int[] IterativeDeepeningSearch(Node root, string key, int depth)
        {
            for (int currentDepth = 0; currentDepth < depth; currentDepth++)
            {
                var steps = DepthLimitedSearch(root, key, currentDepth);
                if (steps != null)
                    return steps;
            }
            return Array.Empty<int>();
        }

        private class Node
        {
            public string S;
            public List<int> History;

            public Node[] GetChildren(string stamp)
            {
                var stampLength = stamp.Length;
                var lastIndex = S.Length - stampLength;

                Node[] result = new Node[lastIndex + 1];

                for (int i = 0; i <= lastIndex; i++)
                {
                    var newStampedString = S.Remove(i, stampLength).Insert(i, stamp);
                    var newHistory = new List<int>(History)
                    {
                        i
                    };
                    result[i] = new Node
                    {
                        S = newStampedString,
                        History = newHistory
                    };
                }
                return result;
            }
        }
    }
}
