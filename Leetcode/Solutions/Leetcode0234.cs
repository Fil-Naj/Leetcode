using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    // Pallindrome LInked List
    public class Leetcode0234 : ISolution
    {
        public string Name => "Palindrome Linked List";
        public string Description => "Given the head of a singly linked list, return true if it is a palindrome or false otherwise.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode head = new(1, new(2, new(2, new(1, null))));
            Console.WriteLine($"Input: head = {head}");
            bool result = IsPalindrome(head);


            Console.WriteLine($"Output: {result}");
        }

        // See https://cheonhyangzhang.gitbooks.io/leetcode-solutions/content/234-palindrome-linked-list-easy.html

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            ListNode rev = Reverse(slow.next);
            slow = head;
            fast = rev;
            while (fast != null)
            {
                if (slow.val != fast.val)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next;
            }
            return true;
        }

        private static ListNode Reverse(ListNode node)
        {
            ListNode reverse = new(-1);
            while (node != null)
            {
                ListNode next = node.next;
                node.next = reverse.next;
                reverse.next = node;
                node = next;
            }
            return reverse.next;
        }
    }
}
