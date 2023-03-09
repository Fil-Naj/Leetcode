using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0142 : ISolution
    {
        public string Name => "Linked List Cycle II";
        public string Description => "Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.\r\n\r\nThere is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed). It is -1 if there is no cycle. Note that pos is not passed as a parameter.\r\n\r\nDo not modify the linked list.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode pos = new(2);
            ListNode head = new(3, new(0, new(-4, null)));
            pos.next = new(0, new(-4, pos));

            var result = DetectCycle(head);

            // Prettify
            Console.WriteLine($"Input: data = {head.val}");
            Console.WriteLine($"Output: {result?.val ?? -1}");
        }

        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> visited = new();
            while (head != null) 
            {
                if (visited.Contains(head))
                    return head;
                
                visited.Add(head);
                head = head.next;
            }
            return null;
        }
    }
}
