using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0019 : ISolution
    {
        public string Name => "Remove Nth Node From End of List";
        public string Description => "Given the head of a linked list, remove the nth node from the end of the list and return its head.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode head = new(1,new(2, new (3, new(4, new(5, null)))));

            int n = 1;
            var result = RemoveNthFromEnd(head, n);

            // Prettify
            Console.WriteLine($"Input: head = {head} n = {n}");
            Console.WriteLine($"Output: {result}");
        }

        // Note: could also use fast/slow pointer
        // See solutions for example
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            Dictionary<int, ListNode> orderedList = new();

            int i = 0;
            while (head != null)
            {
                orderedList.Add(i, head);
                i++;
                head = head.next;
            }

            
            if (n != orderedList.Count)
            {
                var toRemove = orderedList[orderedList.Count - n];
                var previous = orderedList[orderedList.Count - n - 1];
                previous.next = toRemove.next;
                return orderedList[0];
            } 
            else
            {
                if (n == 1) return null;
                return orderedList[1];
            }
        }
    }
}
