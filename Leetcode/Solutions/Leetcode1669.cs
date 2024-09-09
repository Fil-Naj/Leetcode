using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1669 : ISolution
    {
        public string Name => "Merge In Between Linked Lists";
        public string Description => "You are given two linked lists: list1 and list2 of sizes n and m respectively.\r\n\r\nRemove list1's nodes from the ath node to the bth node, and put list2 in their place.\r\n\r\nThe blue edges and nodes in the following figure indicate the result:";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode list1 = new(10, new(1, new(13, new(6, new(9, new(5))))));
            var a = 3;
            var b = 4;
            ListNode list2 = new(1000, new(1001, new(1002)));
            var result = MergeInBetween(list1, a, b, list2);

            // Prettify
            Console.WriteLine($"Input: list1 = {list1}, a = {a}, b = {b}, list2 = {list2}");
            Console.WriteLine($"Output: {result}");
        }

        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var current = list1;
            ListNode start = null;
            for (var i = 1; i < b; i++)
            {
                if (i == a)
                {
                    start = current;
                }

                current = current.next;
            }
            var end = current.next;
            (start ?? current).next = list2;
            GetLastNode(list2).next = end.next;

            return list1;
        }

        private ListNode GetLastNode(ListNode l)
        {
            var current = l;
            while (current.next is not null)
            {
                current = current.next;
            }

            return current;
        }
    }
}
