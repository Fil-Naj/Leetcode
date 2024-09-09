using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0860 : ISolution
    {
        public string Name => "Lemonade Change";
        public string Description => "At a lemonade stand, each lemonade costs $5. Customers are standing in a queue to buy from you and order one at a time (in the order specified by bills). Each customer will only buy one lemonade and pay with either a $5, $10, or $20 bill. You must provide the correct change to each customer so that the net transaction is that the customer pays $5.\r\n\r\nNote that you do not have any change in hand at first.\r\n\r\nGiven an integer array bills where bills[i] is the bill the ith customer pays, return true if you can provide every customer with the correct change, or false otherwise.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            int[] bills = [5, 5, 5, 10, 20];
            var result = LemonadeChange(bills);

            // Prettify
            Console.WriteLine($"Input: bills = {bills.GetString()}");
            Console.WriteLine($"Output: {result}");
        }

        private const int Cost = 5;

        public bool LemonadeChange(int[] bills)
        {
            var fives = 0;
            var tens = 0;

            foreach (var bill in bills)
            {
                var change = bill - Cost;

                // $5 bill presented
                if (change == 0)
                {
                    fives++;
                    continue;
                }
                // $10 bill presented
                else if (change == 5)
                {
                    if (fives == 0)
                    {
                        return false;
                    }
                    tens++;
                    fives--;
                }
                // $20 bill presented
                else if (change == 15)
                {
                    if (fives >= 1 && tens >= 1)
                    {
                        fives--;
                        tens--;
                    }
                    else if (fives >= 3)
                    {
                        fives -= 3;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
