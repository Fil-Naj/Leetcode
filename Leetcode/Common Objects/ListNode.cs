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

        public ListNode(int[] values)
        {
            if (values == null || values.Length == 0) return;

            val = values[0];

            var prev = this;
            for (var i = 1; i < values.Length; i++)
            {
                var next = new ListNode(values[i]);
                prev.next = next;
                prev = next;
            }
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
