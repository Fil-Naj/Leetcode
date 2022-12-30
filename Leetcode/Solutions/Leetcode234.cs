using Leetcode.Common_Objects;
using Leetcode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Solutions
{
    // Pallindrome LInked List
    public class Leetcode234 : ISolution
    {
        public string Name => "Palindrome Linked List";
        public string Description => "Given the head of a singly linked list, return true if it is a palindrome or false otherwise.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode head = new(1, new(2, new(2, new(1, null))));
            Console.WriteLine($"Input: head = {head}");
            bool result = isPalindrome(head);

            
            Console.WriteLine($"Output: {result}");
        }

        // See https://cheonhyangzhang.gitbooks.io/leetcode-solutions/content/234-palindrome-linked-list-easy.html

        public bool isPalindrome(ListNode head)
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
            ListNode rev = reverse(slow.next);
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

        private ListNode reverse(ListNode node)
        {
            ListNode reverse = new ListNode(-1);
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
