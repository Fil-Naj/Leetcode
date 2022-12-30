using System.Text;

namespace Leetcode.Common_Objects
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public void PrintLinkedList()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var node = this;

            StringBuilder sb = new();
            sb.Append(node.val);

            node = node.next;

            while (node != null)
            {
                sb.Append($" --> {node.val}");
                node = node.next;
            }

            return sb.ToString();
        }
    }
}
