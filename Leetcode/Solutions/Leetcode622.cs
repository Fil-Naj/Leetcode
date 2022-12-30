using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode622 : ISolution
    {
        public string Name => "Design Circular Queue";
        public string Description => "Design your implementation of the circular queue.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            // Prettify
            Console.WriteLine("It's just an implementation of a Circular Queue. Nothing special.");
        }

        public class MyCircularQueue
        {
            public int[] Queue { get; internal set; }
            public int Count { get; internal set; }
            private int _head { get; set; }


            public MyCircularQueue(int k)
            {
                Queue = new int[k];
                Count = 0;
                _head = 0;
            }

            public bool EnQueue(int value)
            {
                if (IsFull()) return false;

                Count++;
                Queue[(_head + Count - 1) % Queue.Length] = value;
                return true;
            }

            public bool DeQueue()
            {
                if (IsEmpty()) return false;

                Count--;
                Queue[_head] = 0;
                _head = (_head + 1) % Queue.Length;
                return true;
            }

            public int Front()
            {
                return IsEmpty() ? -1 : Queue[_head];
            }

            public int Rear()
            {
                return IsEmpty() ? -1 : Queue[(_head + Count - 1) % Queue.Length];
            }

            public bool IsEmpty()
            {
                return Count == 0;
            }

            public bool IsFull()
            {
                return Count == Queue.Length;
            }
        }
    }
}
