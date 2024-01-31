using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0232 : ISolution
    {
        public string Name => "Implement Queue using Stacks";
        public string Description => "Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of a normal queue (push, peek, pop, and empty).\r\n\r\nImplement the MyQueue class:\r\n\r\n    void push(int x) Pushes element x to the back of the queue.\r\n    int pop() Removes the element from the front of the queue and returns it.\r\n    int peek() Returns the element at the front of the queue.\r\n    boolean empty() Returns true if the queue is empty, false otherwise.\r\n\r\nNotes:\r\n\r\n    You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, and is empty operations are valid.\r\n    Depending on your language, the stack may not be supported natively. You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.\r\n";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            MyQueue myQueue = new();
            myQueue.Push(1);
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            Console.WriteLine($"Actual: {myQueue.Peek()}. Expected: 1");
            Console.WriteLine($"Actual: {myQueue.Pop()}. Expetcted: 1");
            Console.WriteLine($"Actual: {myQueue.Empty()}. Expected: false");
        }

        public class MyQueue
        {
            private readonly Stack<int> _q1;
            private readonly Stack<int> _q2;

            public MyQueue()
            {
                _q1 = [];
                _q2 = [];
            }

            public void Push(int x)
            {
                while (_q1.Count > 0)
                {
                    _q2.Push(_q1.Pop());
                }

                _q1.Push(x);

                while (_q2.Count > 0)
                {
                    _q1.Push(_q2.Pop());
                }
            }

            public int Pop()
            {
                return _q1.Pop();
            }

            public int Peek()
            {
                return _q1.Peek();
            }

            public bool Empty()
            {
                return _q1.Count == 0;
            }
        }
    }
}
