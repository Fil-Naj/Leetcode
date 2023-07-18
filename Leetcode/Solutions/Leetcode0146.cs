using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0146 : ISolution
    {
        public string Name => "LRU Cache";
        public string Description => "Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.\r\n\r\nImplement the LRUCache class:\r\n\r\n    LRUCache(int capacity) Initialize the LRU cache with positive size capacity.\r\n    int get(int key) Return the value of the key if the key exists, otherwise return -1.\r\n    void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.\r\n\r\nThe functions get and put must each run in O(1) average time complexity.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            //var lru = new LRUCache(2);
            //Console.WriteLine($"Put (1, 1)"); lru.Put(1, 1);
            //Console.WriteLine($"Put (2, 2)"); lru.Put(2, 2);
            //Console.WriteLine($"Get 1. Expected: {1} | Actual: {lru.Get(1)}");
            //Console.WriteLine($"Put (3, 3)"); lru.Put(3, 3);
            //Console.WriteLine($"Get 2. Expected: {-1} | Actual: {lru.Get(2)}");
            //Console.WriteLine($"Put (4, 4)"); lru.Put(4, 4);
            //Console.WriteLine($"Get 1. Expected: {-1} | Actual: {lru.Get(1)}");
            //Console.WriteLine($"Get 3. Expected: {3} | Actual: {lru.Get(3)}");
            //Console.WriteLine($"Get 4. Expected: {4} | Actual: {lru.Get(4)}"); 
            
            var lru = new LRUCache(1);
            Console.WriteLine($"Get 6. Expected: {-1} | Actual: {lru.Get(6)}");
            Console.WriteLine($"Get 8. Expected: {-1} | Actual: {lru.Get(8)}");
            Console.WriteLine($"Put (12, 1)"); lru.Put(12, 1);
            Console.WriteLine($"Get 2. Expected: {-1} | Actual: {lru.Get(2)}");
            Console.WriteLine($"Put (15, 1)"); lru.Put(15, 1);
            Console.WriteLine($"Put (5, 2)"); lru.Put(5, 2);
            Console.WriteLine($"Put (1, 15)"); lru.Put(1, 15);
            Console.WriteLine($"Put (4, 2)"); lru.Put(4, 2);
            Console.WriteLine($"Get 5. Expected: {-1} | Actual: {lru.Get(5)}");
            Console.WriteLine($"Put (15, 15)"); lru.Put(15, 15);
        }

        public class LRUCache
        {
            private QueueNode _head;
            private QueueNode _tail;
            private Dictionary<int, int> _cache;
            private int _capacity;
            private int _size;

            public LRUCache(int capacity)
            {
                _cache = new();
                _capacity = capacity;
                _size = 0;
            }

            public int Get(int key)
            {
                if (_cache.TryGetValue(key, out var value))
                {
                    RemoveFromQueue(key);
                    Enqueue(key);
                    return value;
                }
                
                return -1;
            }

            public void Put(int key, int value)
            {
                if (_cache.ContainsKey(key))
                {
                    RemoveFromQueue(key);
                    Enqueue(key);
                }
                else if (_size == _capacity)
                {
                    _cache.Remove(Dequeue());
                }
                else
                {
                    _size++;
                }

                Enqueue(key);
                _cache[key] = value;
            }

            private void Enqueue(int key)
            {
                QueueNode newElement = new(key, next: _head);
                if (_head is not null)
                {
                    _head.Previous = newElement;
                    _head = newElement;
                }
                else
                {
                    _head = newElement;
                    _tail = _head;
                }
            }

            private int Dequeue()
            {
                var toReturn = _tail.Key;
                _tail = _tail.Previous;
                if (_tail is null)
                    _head = null;
                else
                    _tail.Next = null;

                return toReturn;
            }

            private void RemoveFromQueue(int key)
            {
                if (_size == 0) return;

                if (_head.Key == key)
                {
                    if (_head.Next is not null)
                    {
                        _head.Next.Previous = null;
                        _head = _head.Next;
                    }
                    return;
                }

                if (_tail.Key == key)
                {
                    if (_tail.Previous is not null)
                    {
                        _tail.Previous.Next = null;
                        _tail = _tail.Previous;
                    }
                    return;
                }

                var front = _head;
                var back = _tail;

                while (front.Key != key && back.Key != key)
                {
                    front = front.Next;
                    back = back.Previous;
                }

                if (front.Key == key)
                {
                    if (front.Previous is not null)
                        front.Previous.Next = front.Next;

                    front.Next.Previous = front.Previous;
                }
                else
                {
                    back.Previous.Next = back.Next;

                    if (back.Next is not null)
                        back.Next.Previous = back.Previous;
                }
            }
        }

        private class QueueNode
        {
            public int Key { get; set; }
            public QueueNode Previous { get; set; }
            public QueueNode Next { get; set; }

            public QueueNode(int key, QueueNode previous = null, QueueNode next = null)
            {
                Key = key;
                Previous = previous;
                Next = next;
            }
        }
    }
}
