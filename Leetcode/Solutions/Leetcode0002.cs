using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0002 : ISolution
    {
        public string Name => "Add Two Numbers";
        public string Description => "You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode l1 = new(2, new(4, new(3, null)));
            ListNode l2 = new(5, new(6, new(4, null)));

            ListNode result = AddTwoNumbers(l1, l2);

            // Prettify
            Console.WriteLine($"Inputs: l1 = {l1}, l1 = {l2}");
            Console.WriteLine($"Output: {result}");
        }

        /// <summary>
        /// Given two linked lists representing two non-negative intergers in reverse, return the sum of the two numbers
        /// also as a reversed linked list.
        /// </summary>
        /// <param name="l1">root of number in reverse</param>
        /// <param name="l2">root of number in reverse</param>
        /// <returns>root of the reverse of the sum</returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            bool carry = false;

            int sum = (l1?.val ?? 0) + (l2?.val ?? 0);
            ListNode first = new(sum % 10);
            ListNode current = first;
            if (sum >= 10) carry = true;

            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val;
                if (carry)
                {
                    sum++;
                    carry = false;
                }
                ListNode node = new(sum % 10);
                if (sum >= 10)
                    carry = true;

                current.next = node;
                current = node;

                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            return first;
        }

        
    }
}
