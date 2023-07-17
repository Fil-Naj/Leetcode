using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0445 : ISolution
    {
        public string Name => "Add Two Numbers II";
        public string Description => "You are given two non-empty linked lists representing two non-negative integers. The most significant digit comes first and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.\r\n\r\nYou may assume the two numbers do not contain any leading zero, except the number 0 itself.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode l1 = new(7, new(2, new(4, new(3))));
            ListNode l2 = new(5, new(6, new(4)));
            var result = AddTwoNumbers(l1, l2);

            // Prettify
            Console.WriteLine($"Input: l1 = {l1}, l2 = {l2}");
            Console.WriteLine($"Output: {result}");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var revL1 = ReverseList(l1);
            var revL2 = ReverseList(l2);

            ListNode answer = null;
            var carry = 0;
            while (revL1 is not null || revL2 is not null)
            {
                carry = Math.DivRem((revL1?.val ?? 0) + (revL2?.val ?? 0) + carry, 10, out var sum);
                ListNode next = new(sum, answer);
                answer = next;
                revL1 = revL1?.next;
                revL2 = revL2?.next;
            }

            if (carry > 0)
            {
                ListNode next = new(carry, answer);
                answer = next;
            }

            if (answer is null) return null;

            return answer;
        }

        private ListNode ReverseList(ListNode l1)
        {
            ListNode reverse = new(-1);
            while (l1 != null)
            {
                ListNode next = l1.next;
                l1.next = reverse.next;
                reverse.next = l1;
                l1 = next;
            }
            return reverse.next;
        }
    }
}
