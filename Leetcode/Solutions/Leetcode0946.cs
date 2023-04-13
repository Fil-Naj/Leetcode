using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0946 : ISolution
    {
        public string Name => "Validate Stack Sequences";
        public string Description => "Given two integer arrays pushed and popped each with distinct values, return true if this could have been the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var pushed = new int[] { 1, 2, 3, 4, 5 };
            var popped = new int[] { 4, 5, 3, 2, 1 };
            var result = ValidateStackSequences(pushed, popped);

            // Prettify
            Console.WriteLine($"Input: pushed = {pushed.GetString()}, popped = {popped.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        // Pretty poor attempt but eh
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> previous = new();
            HashSet<int> hasBeenPushed = new();
            int pushedUntil = 0;

            for (int i = 0; i < popped.Length; i++)
            {
                var toPop = popped[i];

                if (previous.TryPeek(out var prev) && prev == toPop)
                {
                    previous.Pop();
                }
                else if (hasBeenPushed.Contains(toPop))
                {
                    return false;
                }
                else
                { 
                    var start = pushedUntil;
                    for (int j = start; j < popped.Length; j++)
                    {
                        var toPush = pushed[j];
                        pushedUntil++;
                        if (toPush == toPop)
                        {
                            break;
                        }
                        else
                        {
                            hasBeenPushed.Add(toPush);
                            previous.Push(toPush);
                        }
                    }
                }
            }

            return true;
        }
    }
}
