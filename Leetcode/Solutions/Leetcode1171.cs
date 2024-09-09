using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1171 : ISolution
    {
        public string Name => "Remove Zero Sum Consecutive Nodes from Linked List";
        public string Description => "Given the head of a linked list, we repeatedly delete consecutive sequences of nodes that sum to 0 until there are no such sequences.\r\n\r\nAfter doing so, return the head of the final linked list.  You may return any such answer.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode head = new(1, new(2, new(-3, new(3, new(1)))));
            var result = RemoveZeroSumSublists(head);

            // Prettify
            Console.WriteLine($"Input: head = {head}");
            Console.WriteLine($"Output: {result}");
        }

        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            var dummy = new ListNode(0, head);
            var prefixSum = 0;
            Dictionary<int, ListNode> sums = [];
            sums[0] = dummy;

            var current = head;
            while (current is not null)
            {
                prefixSum += current.val;

                if (sums.TryGetValue(prefixSum, out var startNode))
                {
                    var deleteFrom = startNode.next;
                    var tempSum = prefixSum + deleteFrom.val;

                    while (deleteFrom != current)
                    {
                        sums.Remove(tempSum);
                        deleteFrom = deleteFrom.next;
                        tempSum += deleteFrom.val;
                    }

                    sums[prefixSum].next = current.next;
                }
                else
                {
                    sums[prefixSum] = current;
                }

                current = current.next;
            }

            return dummy.next;
        }
    }
}
