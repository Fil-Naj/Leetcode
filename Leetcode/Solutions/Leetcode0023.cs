using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0023 : ISolution
    {
        public string Name => "Merge k Sorted Lists";
        public string Description => "You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.\r\n\r\nMerge all the linked-lists into one sorted linked-list and return it.";
        public Difficulty Difficulty => Difficulty.Hard;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode[] lists = new ListNode[]
            {
                new(1, new(4, new(5, null))),
                new(1, new(3, new(4, null))),
                new(2, new(6, null))
            };

            ListNode result = MergeKLists(lists);

            // Prettify
            Console.WriteLine($"Inputs: l1 = {lists}");
            Console.WriteLine($"Output: {result}");
        }

        /*
         * Solution:
         * Put all nodes into a priority queue, sorted in asecnding order of the each node's value
         * Dequeue entire pq, rearranging the next pointer of each node as it is dequeued
         * Ta da. Sorted 
         * Time: O(n·log(n)). Space: O(n)
         */
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0) return null;

            PriorityQueue<ListNode, int> pq = new();
            foreach (var list in lists)
            {
                var head = list;
                while (head != null)
                {
                    pq.Enqueue(head, head.val);
                    head = head.next;
                }
            }

            if (pq.Count == 0) return null;

            var result = pq.Dequeue();
            var current = result;
            while (pq.Count > 0)
            {
                var next = pq.Dequeue();
                current.next = next;
                current = next;
            }
            current.next = null;

            return result;
        }
    }
}
