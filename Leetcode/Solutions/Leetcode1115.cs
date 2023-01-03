using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1115 : ISolution
    {
        public string Name => "Print FooBar Alternately";
        public string Description => "The same instance of FooBar will be passed to two different threads:\r\n\r\n    thread A will call foo(), while\r\n    thread B will call bar().\r\n\r\nModify the given program to output \"foobar\" n times.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            int n = 4;
            FooBarWithAutoResetEvent fooBar = new(n);

            Thread threadA = new(() => fooBar.Foo(() => Console.WriteLine("foo")));
            Thread threadB = new(() => fooBar.Bar(() => Console.WriteLine("bar")));

            threadA.Start();
            threadB.Start();
        }

        public class FooBar
        {
            private int n;

            private SemaphoreSlim _isFooTime = new(1);
            private SemaphoreSlim _isBarTime = new(1);

            public FooBar(int n)
            {
                this.n = n;
                _isBarTime.Wait();
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    _isFooTime.Wait();
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    _isBarTime.Release();
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    _isBarTime.Wait();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    _isFooTime.Release();
                }
            }
        }

        /*
         * AutoResetEvent should be used to share resources in simple scenarios
         * - It is a synchronization mechanism that allows one or more threads to wait for a signal from another thread. 
         *   It works by blocking a thread until the event is signaled, at which point it unblocks the thread and allows it to continue executing.
         * - Outperforms Semaphores, but only in simple situations
         * - Semaphores are more versatile
        */
        public class FooBarWithAutoResetEvent
        {
            private int n;

            private AutoResetEvent _isFooTime = new(true);
            private AutoResetEvent _isBarTime = new(false);

            public FooBarWithAutoResetEvent(int n)
            {
                this.n = n;
            }

            public void Foo(Action printFoo)
            {

                for (int i = 0; i < n; i++)
                {
                    _isFooTime.WaitOne();
                    // printFoo() outputs "foo". Do not change or remove this line.
                    printFoo();
                    _isBarTime.Set();
                }
            }

            public void Bar(Action printBar)
            {

                for (int i = 0; i < n; i++)
                {
                    _isBarTime.WaitOne();
                    // printBar() outputs "bar". Do not change or remove this line.
                    printBar();
                    _isFooTime.Set();
                }
            }
        }
    }
}
