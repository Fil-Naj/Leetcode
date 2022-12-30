using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0237 : ISolution
    {
        public string Name => "Delete Node in a Linked List";
        public string Description => "There is a singly-linked list head and we want to delete a node node in it.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            ListNode root = new(4, new(5, new(1, new(9, null))));
            Console.WriteLine($"Input: data = {root}");

            ListNode toReplace = root.next.next;
            DeleteNode(toReplace);

            // Prettify
            
            Console.WriteLine($"Output: {root}");
        }

        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
