using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode2095 : ISolution
    {
        public string Name => "Delete the Middle Node of a Linked List";
        public string Description => "You are given the head of a linked list. Delete the middle node, and return the head of the modified linked list.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var data = new ListNode(1, new(2, new(3, new(4, null))));
            //var data = new ListNode(1, new(2, new(3, new(4, new(5, null)))));
            var data = new ListNode(1, new(2, null));
            Console.WriteLine($"Input: head = {data}");
            var result = DeleteMiddle(data);

            // Prettify
            
            Console.WriteLine($"Output: {result}");
        }

        public ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null) return null;
            if (head.next.next == null)
            {
                head.next = null;
                return head;
            }

            var slow = head.next;
            var fast = head.next;

            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            slow.val = slow.next.val;
            slow.next = slow.next.next;
            
            return head;
        }
    }
}
