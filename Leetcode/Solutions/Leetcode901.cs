using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode901 : ISolution
    {
        public string Name => "Online Stock Span";
        public string Description => "Design an algorithm that collects daily price quotes for some stock and returns the span of that stock's price for the current day.\r\n\r\nThe span of the stock's price today is defined as the maximum number of consecutive days (starting from today and going backward) for which the stock price was less than or equal to today's price.\r\n\r\n    For example, if the price of a stock over the next 7 days were [100,80,60,70,60,75,85], then the stock spans would be [1,1,1,2,1,4,6].\r\n\r\nImplement the StockSpanner class:\r\n\r\n    StockSpanner() Initializes the object of the class.\r\n    int next(int price) Returns the span of the stock's price given that today's price is price.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            
        }

        public class StockSpanner
        {

            public StockSpanner()
            {

            }

            public int Next(int price)
            {
                return 0;
            }
        }
    }
}
