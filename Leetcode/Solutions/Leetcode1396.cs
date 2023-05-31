using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode1396 : ISolution
    {
        public string Name => "Design Underground System";
        public string Description => "An underground railway system is keeping track of customer travel times between different stations. They are using this data to calculate the average time it takes to travel from one station to another.\r\n\r\nImplement the UndergroundSystem class:\r\n\r\n    void checkIn(int id, string stationName, int t)\r\n        A customer with a card ID equal to id, checks in at the station stationName at time t.\r\n        A customer can only be checked into one place at a time.\r\n    void checkOut(int id, string stationName, int t)\r\n        A customer with a card ID equal to id, checks out from the station stationName at time t.\r\n    double getAverageTime(string startStation, string endStation)\r\n        Returns the average time it takes to travel from startStation to endStation.\r\n        The average time is computed from all the previous traveling times from startStation to endStation that happened directly, meaning a check in at startStation followed by a check out from endStation.\r\n        The time it takes to travel from startStation to endStation may be different from the time it takes to travel from endStation to startStation.\r\n        There will be at least one customer that has traveled from startStation to endStation before getAverageTime is called.\r\n\r\nYou may assume all calls to the checkIn and checkOut methods are consistent. If a customer checks in at time t1 then checks out at time t2, then t1 < t2. All events happen in chronological order.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();
        }

        public class UndergroundSystem
        {
            private readonly Dictionary<int, (string checkedInStation, int time)> _customers;
            private readonly Dictionary<(string from, string to), (int totalTimeTaken, int numTrips)> _trips;

            public UndergroundSystem()
            {
                _customers = new();
                _trips = new();
            }

            public void CheckIn(int id, string stationName, int t)
            {
                _customers.Add(id, (stationName, t));
            }

            public void CheckOut(int id, string stationName, int t)
            {
                _customers.Remove(id, out var checkInData);

                if (_trips.ContainsKey((checkInData.checkedInStation, stationName)))
                {
                    var (totalTimeTaken, numTrips) = _trips[(checkInData.checkedInStation, stationName)];
                    _trips[(checkInData.checkedInStation, stationName)] = (totalTimeTaken + (t - checkInData.time), numTrips + 1);
                }
                else
                {
                    _trips.Add((checkInData.checkedInStation, stationName), (t - checkInData.time, 1));
                }
            }

            public double GetAverageTime(string startStation, string endStation)
            {
                var (totalTimeTaken, numTrips) = _trips[(startStation, endStation)];
                return (double)totalTimeTaken / numTrips;
            }
        }
    }
}
