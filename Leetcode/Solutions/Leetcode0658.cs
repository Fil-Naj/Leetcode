using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0658 : ISolution
    {
        public string Name => "Find K Closest Elements";
        public string Description => "Given a sorted integer array arr, two integers k and x, return the k closest integers to x in the array. The result should also be sorted in ascending order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var arr = new int[] { 1, 2, 3, 4, 5 };
            int k = 4;
            int x = 3;

            var result = FindClosestElements(arr, k, x);

            // Prettify
            Console.WriteLine($"Input: arr = {arr.GetString()}, k = {k}, x = {x}");
            Console.WriteLine($"Output: {result.GetString()}");
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            PriorityQueue<Element, Element> pq = new();
            foreach (int i in arr)
            {
                var element = new Element(x, i);
                pq.Enqueue(element, element);
            }

            List<int> result = new();
            for (int i = 0; i < k; i++)
                result.Add(pq.Dequeue().Magnitude);
             
            return result.OrderBy(n => n).ToList();
        }

        private class Element : IComparable<Element>
        {
            public int X;
            public int Magnitude;

            public Element(int x, int mag)
            {
                X = x;
                Magnitude = mag;
            }

            public int CompareTo(Element? other)
            {
                /*
                 * Less than zero = precedes
                 * Zero = equal
                 * Greater than zero = comes first
                 */
                var magMe = Math.Abs(this.Magnitude - this.X);
                var magOther = Math.Abs(other.Magnitude - other.X);

                if (magMe < magOther)
                {
                    return -1;
                }
                else if (magMe == magOther)
                {
                    return this.Magnitude < other.Magnitude ? -1 : 1;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
