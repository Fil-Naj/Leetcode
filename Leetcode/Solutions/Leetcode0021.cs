using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0021 : ISolution
    {
        public string Name => "Merge Two Sorted Lists";
        public string Description => "You are given the heads of two sorted linked lists list1 and list2.\r\n\r\nMerge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.\r\n\r\nReturn the head of the merged linked list.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode l1 = new(1, new(2, new(4)));
            ListNode l2 = new(1, new(3, new(4)));
            var result = MergeTwoLists(l1, l2);

            // Prettify
            Console.WriteLine($"Input: l1 = {l1}, l2 = {l1}");
            Console.WriteLine($"Output: {result}");
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 is null)
                return list2;
            else if (list2 is null) 
                return list1;

            if (list1.val <=  list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }

            list2.next = MergeTwoLists(list2.next, list1);
            return list2;
        }
    }
}
