using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1472 : ISolution
    {
        public string Name => "Design Browser History";
        public string Description => "You have a browser of one tab where you start on the homepage and you can visit another url, get back in the history number of steps or move forward in the history number of steps.\r\n\r\nImplement the BrowserHistory class:\r\n\r\n    BrowserHistory(string homepage) Initializes the object with the homepage of the browser.\r\n    void visit(string url) Visits url from the current page. It clears up all the forward history.\r\n    string back(int steps) Move steps back in history. If you can only return x steps in the history and steps > x, you will return only x steps. Return the current url after moving back in history at most steps.\r\n    string forward(int steps) Move steps forward in history. If you can only forward x steps in the history and steps > x, you will forward only x steps. Return the current url after forwarding in history at most steps.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            BrowserHistory browserHistory = new("leetcode.com");
            browserHistory.Visit("google.com");
            browserHistory.Visit("facebook.com");
            browserHistory.Visit("youtube.com");
            Console.WriteLine($"browserHistory.Back(1). Expected: \"facebook.com\", Actual {browserHistory.Back(1)}");
            Console.WriteLine($"browserHistory.Back(1). Expected: \"google.com\", Actual {browserHistory.Back(1)}");
            Console.WriteLine($"browserHistory.Forward(1). Expected: \"facebook.com\", Actual {browserHistory.Forward(1)}");
            browserHistory.Visit("linkedin.com");
            Console.WriteLine($"browserHistory.Forward(1). Expected: \"linkedin.com\", Actual {browserHistory.Forward(2)}");
            Console.WriteLine($"browserHistory.Back(2). Expected: \"google.com\", Actual {browserHistory.Back(2)}");
            Console.WriteLine($"browserHistory.Back(7). Expected: \"leetcode.com\", Actual {browserHistory.Back(7)}");
        }

        // It's just a linked list
        public class BrowserHistory
        {
            private Website _currentPage;

            public BrowserHistory(string homepage)
            {
                _currentPage = new(homepage);
            }

            public void Visit(string url)
            {
                Website toVisit = new(url, _currentPage);

                _currentPage.To = toVisit;
                toVisit.From = _currentPage;
                _currentPage = toVisit;
            }

            public string Back(int steps)
            {
                var stepsTaken = 0;
                while (stepsTaken < steps && _currentPage.From != null)
                {
                    _currentPage = _currentPage.From;
                    stepsTaken++;
                }

                return _currentPage.Url;
            }

            public string Forward(int steps)
            {
                var stepsTaken = 0;
                while (stepsTaken < steps && _currentPage.To != null)
                {
                    _currentPage = _currentPage.To;
                    stepsTaken++;
                }

                return _currentPage.Url;
            }
        }

        public class Website
        {
            public string Url;
            public Website From;
            public Website To;

            public Website(string url, Website from = null)
            {
                Url = url;
                From = from;
            }
        }
    }
}
