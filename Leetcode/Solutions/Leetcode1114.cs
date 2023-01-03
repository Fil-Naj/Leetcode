using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1114 : ISolution
    {
        public string Name => "Print in Order";
        public string Description => "The same instance of Foo will be passed to three different threads. Thread A will call first(), thread B will call second(), and thread C will call third(). Design a mechanism and modify the program to ensure that second() is executed after first(), and third() is executed after second().\r\n\r\nNote:\r\n\r\nWe do not know how the threads will be scheduled in the operating system, even though the numbers in the input seem to imply the ordering. The input format you see is mainly to ensure our tests' comprehensiveness.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            Foo foo = new();

            Thread threadA = new(() => foo.First(() => Console.WriteLine("first")));
            Thread threadB = new(() => foo.Second(() => Console.WriteLine("second")));
            Thread threadC = new(() => foo.Third(() => Console.WriteLine("third")));

            threadC.Start();
            threadA.Start();
            threadB.Start();
        }

        public class Foo
        {
            public SemaphoreSlim secondLock = new(1);
            public SemaphoreSlim thirdLock = new(1);

            public Foo()
            {
                secondLock.Wait();
                thirdLock.Wait();
            }

            public void First(Action printFirst)
            {
                
                // printFirst() outputs "first". Do not change or remove this line.
                printFirst();
                secondLock.Release();
            }

            public void Second(Action printSecond)
            {
                secondLock.Wait();
                // printSecond() outputs "second". Do not change or remove this line.
                printSecond();
                thirdLock.Release();
            }

            public void Third(Action printThird)
            {
                thirdLock.Wait();
                // printThird() outputs "third". Do not change or remove this line.
                printThird();
            }
        }
    }
}
