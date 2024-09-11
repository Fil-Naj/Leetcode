using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0024 : ISolution
    {
        public string Name => "Swap Nodes in Pairs";
        public string Description => "Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var head = new ListNode([1, 2, 3, 4, 5]);

            // Prettify
            Console.WriteLine($"Input: head = {head}");
            var result = SwapPairs(head);
            Console.WriteLine($"Output: {result}");
        }

        public ListNode SwapPairs(ListNode head)
        {
            if (head is null || head.next is null) return head;

            var toReturn = new ListNode(0, head.next);
            var prev = toReturn;
            var current = head;
            var adj = current.next;

            while (current is not null && adj is not null)
            {
                var tempNext = adj.next;
                (current.next, adj.next) = (adj.next, current);

                prev.next = adj;
                prev = current;

                current = tempNext;
                adj = current?.next;
            }

            return toReturn.next;
        }
    }
}
